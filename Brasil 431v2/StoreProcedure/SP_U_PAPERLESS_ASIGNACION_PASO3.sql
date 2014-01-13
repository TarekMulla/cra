ALTER PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO3] 
                    @IdUsuario1 int,                                 
                    @ObservacionUsuario1 nvarchar(4000),             
                    @IdImportancia int,                              
                    @IdUsuario2 int,                                 
                    @ObservacionUsuario2 nvarchar(4000),             
                    @IdEstado int,                                   
                    @IdAsignacion bigint,
                    @IdResultado INT OUTPUT,
                    @Resultado VARCHAR(255) OUTPUT

AS                                               

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

IF @IdEstado=3 and @IdEstadoActual=9--quiere decir que hubo cancelacion
    BEGIN
    UPDATE PAPERLESS_ASIGNACION SET                  
    Usuario1 = @IdUsuario1,                          
    ObservacionUsuario1 = @ObservacionUsuario1,      
    IdImportancia = @IdImportancia,                  
    Usuario2 = @IdUsuario2,                          
     ObservacionUsuario2 = @ObservacionUsuario2,      
     IdEstado = @IdEstado,                            
     FechaPaso3 = GETDATE()                           
     WHERE Id = @IdAsignacion      
        SELECT @IdResultado=1
        RETURN 0
    END
    
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

UPDATE PAPERLESS_ASIGNACION SET                  
    Usuario1 = @IdUsuario1,                          
    ObservacionUsuario1 = @ObservacionUsuario1,      
    IdImportancia = @IdImportancia,                  
    Usuario2 = @IdUsuario2,                          
     ObservacionUsuario2 = @ObservacionUsuario2,      
     IdEstado = @IdEstado,                            
     FechaPaso3 = GETDATE()                           
     WHERE Id = @IdAsignacion                                                                               
     
RETURN 0