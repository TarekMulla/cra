
update PAPERLESS_PASOS_USUARIO2 set PasoSiguiente=5, pantalla='Vinculacion' where idPaso in (3,6,9,12)
GO
update PAPERLESS_PASOS_USUARIO2 set Descripcion='Vinculação' where idPaso in (3,6,9,12)
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


IF (@IdEstado=9 or @idEstado=10 or @idEstado=8)
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




update PAPERLESS_USUARIO2_PASOS_ESTADO  set estado=1  where IdAsignacion in (select id from PAPERLESS_ASIGNACION where IdEstado=8) and NumPaso in (4,5) 
GO


ALTER  PROCEDURE [dbo].[SP_C_PAPERLESS_ASIGNACION_POR_ID]
@IdAsignacion bigint

AS

SELECT PA.Id, NumMaster,FechaMaster,
IdAgente,PAA.Descripcion Agente,
IdNaviera, PAN.Descripcion Naviera,
IdNave, PANAVE.Descripcion Nave,
Viaje,NumHousesBL,
IdTipoCarga, VP.Descripcion TipoCarga,
FechaETA,AperturaNavieras,PlazoEmbarcadores,
Usuario1, U1.ApellidoPaterno APU1, U1.ApellidoMaterno AMU1, U1.Nombres NU1,U1.Email EmailU1,
ObservacionUsuario1,
IdImportancia, PAR.Descripcion Importancia,
Usuario2,U2.ApellidoPaterno APU2, U2.ApellidoMaterno AMU2, U2.Nombres NU2, U2.Email EmailU2,
ObservacionUsuario2,
IdEstado, PE.Descripcion Estado,
IdUsuarioCreacion,
PA.FechaCreacion,
PA.FechaPaso1,
PA.FechaPaso2,
PA.FechaPaso3,
PA.IdTipoServicio, TS.Descripcion TipoServicio,
IdNaveTransbordo, PANAVET.Descripcion as NaveTransbordo,
PA.Courier,
PA.EnDestino,
PA.MasterConfirmado,
PA.FechaMasterConfirmado,
PA.txtCourier,
PA.FechaMaximaVinculacion,
PA.versionUsuario1,
PA.empresa,
PA.numContenedor
FROM PAPERLESS_ASIGNACION PA
LEFT OUTER JOIN PAPERLESS_AGENTE PAA
ON PA.IdAgente = PAA.Id
LEFT OUTER JOIN PAPERLESS_NAVIERA PAN
ON PA.IdNaviera = PAN.Id
LEFT OUTER JOIN PAPERLESS_NAVE PANAVE
ON PA.IdNave = PANAVE.Id
LEFT OUTER JOIN PAPERLESS_NAVE PANAVET
ON PA.IdNaveTransbordo = PANAVET.Id
INNER JOIN PAPERLESS_TIPO_CARGA VP
ON PA.IdTipoCarga = VP.Id
LEFT OUTER JOIN USUARIOS U1
ON PA.Usuario1 = U1.Id
LEFT OUTER JOIN USUARIOS U2
ON PA.Usuario2 = U2.Id
INNER JOIN PAPERLESS_ESTADO PE
ON PA.IdEstado = PE.Id
LEFT OUTER JOIN PARAM_PARAMETROS PAR
ON PA.IdImportancia = PAR.Id
LEFT OUTER JOIN PAPERLESS_TIPO_SERVICIO TS
ON PA.IdTipoServicio = TS.Id
WHERE PA.Id = @IdAsignacion
GO