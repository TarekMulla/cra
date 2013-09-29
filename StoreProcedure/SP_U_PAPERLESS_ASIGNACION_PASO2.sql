ALTER PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO2]         
                @FechaEta datetime,                                              
                @AperturaNavieras datetime,                                      
                @PlazoEmbarcadores datetime,                                     
                @IdAsignacion bigint,                                            
                @IdEstado int,
                @Courier bit,
                @EnDestino bit, 
                @MasterConfirmado bit,
                @FechaMasterConfirmado datetime,
                @txtCourier varchar(30),
                @FechaMaximaVinculacionDiff int,
                @IdResultado INT OUTPUT,
                @Resultado VARCHAR(255) OUTPUT
AS                                                               
                                                                  
IF YEAR(@AperturaNavieras) = 9999 SET @AperturaNavieras = NULL   
IF YEAR(@PlazoEmbarcadores) = 9999 SET @PlazoEmbarcadores = NULL 


DECLARE @IdEstadoActual INT

SELECT @IdResultado=0, @Resultado=''

SELECT @IdEstadoActual = IdEstado
FROM paperless_asignacion
WHERE id=@IdAsignacion


-- Valida q la modificación de estados sea consistente con el flujo de proceso.
/*
 1      Nuevo                          
 2      En Asignacion                  
 3      Asignado Usuario 1ra Etapa     
 4      Aceptado Por Usuario 1ra Etapa 
 5      En Proceso Usuario 1ra Etapa   
 6      Enviado Usuario 2da Etapa      
 7      En Proceso Usuario 2da Etapa   
 8      Proceso Terminado              
 9      Rechazada Usuario 1ra Etapa    
*/
-- Unica excepción en la secuencia de ids
IF @IdEstado=9 and @IdEstadoActual<>3
    BEGIN
        SELECT @Resultado='Error generado por inconsistencia en la Asignación imposible asignar los estados:' + convert(varchar(2),@IdEstado) + '/' + convert(varchar(2),@IdEstadoActual)
        SELECT @IdResultado=1
        RETURN 0
    END
ELSE
    BEGIN
        IF (@IdEstado <> @IdEstadoActual)
            BEGIN
                IF (@IdEstado <> @IdEstadoActual + 1) 
                BEGIN
                    SELECT @Resultado='Error generado por inconsistencia en la Asignación imposible asignar los estados:' + convert(varchar(2),@IdEstado) + '/' + convert(varchar(2),@IdEstadoActual)
                    SELECT @IdResultado=1
                    RETURN 0
                END
            END
        END

IF YEAR(@FechaMasterConfirmado) = 9999 SET @FechaMasterConfirmado = NULL 

UPDATE PAPERLESS_ASIGNACION SET                                  
     FechaEta = @FechaEta,                                            
     AperturaNavieras = @AperturaNavieras,                            
     PlazoEmbarcadores = @PlazoEmbarcadores,                          
     IdEstado = @IdEstado,                                            
     FechaPaso2 = GETDATE(),
     courier= @Courier,
     EnDestino=@EnDestino,
     MasterConfirmado=@MasterConfirmado,
     FechaMasterConfirmado=@FechaMasterConfirmado,
     txtCourier = @txtCourier,
     FechaMaximaVinculacionDiff=@FechaMaximaVinculacionDiff
WHERE Id = @IdAsignacion                                         


RETURN 0

Go