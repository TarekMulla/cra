
update PAPERLESS_PASOS_USUARIO2 set PasoSiguiente=5, pantalla='Vinculacion' where idPaso in (3,6,9,12)
GO
insert PAPERLESS_PASOS_USUARIO2   (NumPaso,Descripcion,Activo,PasoAnterior,PasoSiguiente,idTipoCarga,pantalla) 
values(5,'Finalizar',1,4,null,1,'Finalizar')
Go
insert PAPERLESS_PASOS_USUARIO2   (NumPaso,Descripcion,Activo,PasoAnterior,PasoSiguiente,idTipoCarga,pantalla) 
values(5,'Finalizar',1,4,null,2,'Finalizar')
GO
insert PAPERLESS_PASOS_USUARIO2   (NumPaso,Descripcion,Activo,PasoAnterior,PasoSiguiente,idTipoCarga,pantalla) 
values(5,'Finalizar',1,4,null,3,'Finalizar')
GO
insert PAPERLESS_PASOS_USUARIO2   (NumPaso,Descripcion,Activo,PasoAnterior,PasoSiguiente,idTipoCarga,pantalla) 
values(5,'Finalizar',1,4,null,4,'Finalizar')
GO

insert into PAPERLESS_USUARIO2_PASOS_ESTADO(IdAsignacion,NumPaso,Estado,FechaMarca) 
      (SELECT IdAsignacion,5,Estado,FechaMarca FROM PAPERLESS_USUARIO2_PASOS_ESTADO WHERE NumPaso=4)
GO


insert PAPERLESS_ESTADO (Descripcion,Activo,PasoAnterior,PasoSiguiente) values ('Enviado a Mercante',1,7,8)
GO
update PAPERLESS_ESTADO set	PasoSiguiente=10 where Id=7
GO
update PAPERLESS_ESTADO set	PasoAnterior=10 where Id=8
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
10      Enviado a Mercante
*/


IF (@IdEstado=9 or @idEstado=10)
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
go




update PAPERLESS_USUARIO2_PASOS_ESTADO  set estado=1  where IdAsignacion in (select id from PAPERLESS_ASIGNACION where IdEstado=8) and NumPaso in (4,5) order by IdAsignacion
GO