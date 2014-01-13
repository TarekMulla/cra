DROP PROCEDURE SP_U_PAPERLESS_ASIGNACION_ESTADo 
GO
ALTER PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_ESTADo] 
                @IdEstado INT,                                    
                @IdAsignacion BIGINT,
                @IdResultado INT OUTPUT,
                @Resultado VARCHAR(255) OUTPUT
AS                                              

DECLARE @IdEstadoActual INT

SELECT @IdEstadoActual = IdEstado
FROM paperless_asignacion
WHERE id=@IdAsignacion

SELECT @IdResultado=0, @Resultado=''

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


IF @IdEstado=9
BEGIN
    UPDATE PAPERLESS_ASIGNACION                       
SET IdEstado = @IdEstado                          
WHERE Id = @IdAsignacion  
SELECT @IdResultado=1
        RETURN 0
END     

 --Unica excepción en la secuencia de ids
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

UPDATE PAPERLESS_ASIGNACION                       
SET IdEstado = @IdEstado                          
WHERE Id = @IdAsignacion  

-- Marca la fecha/hora de aceptación del usuario
IF @IdEstado=5
BEGIN
    UPDATE PAPERLESS_ASIGNACION            
    SET FechaAceptacionUsr1 = getdate()                          
    WHERE Id = @IdAsignacion  
END     
                                                                                                                                       

RETURN 0