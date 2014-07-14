DROP PROCEDURE [dbo].[SP_C_PAPERLESS_ASIGNACION_POR_ID]
go
CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_ASIGNACION_POR_ID]
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
PA.versionUsuario1 /* LK 25-05-2014 Para implementar en Chile mejora acceder a las pantallas desde el Panel de Control*/
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

