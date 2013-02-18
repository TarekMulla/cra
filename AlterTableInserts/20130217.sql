alter table PAPERLESS_ASIGNACION add Courier bit
go
alter table PAPERLESS_ASIGNACION add EnDestino bit
go
alter table PAPERLESS_ASIGNACION add MasterConfirmado bit
go
alter table PAPERLESS_ASIGNACION add FechaMasterConfirmado datetime
go

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

UPDATE PAPERLESS_ASIGNACION SET                                  
     FechaEta = @FechaEta,                                            
     AperturaNavieras = @AperturaNavieras,                            
     PlazoEmbarcadores = @PlazoEmbarcadores,                          
     IdEstado = @IdEstado,                                            
     FechaPaso2 = GETDATE(),
     courier= @Courier,
     EnDestino=@EnDestino,
     MasterConfirmado=@MasterConfirmado,
     FechaMasterConfirmado=@FechaMasterConfirmado
WHERE Id = @IdAsignacion                                         


RETURN 0




ALTER PROCEDURE [dbo].[SP_C_PAPERLESS_ASIGNACION_POR_ID]
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
PA.FechaMasterConfirmado
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
 