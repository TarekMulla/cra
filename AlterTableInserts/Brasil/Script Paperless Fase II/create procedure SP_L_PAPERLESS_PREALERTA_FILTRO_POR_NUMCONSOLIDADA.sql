DROP PROCEDURE [dbo].[SP_L_PAPERLESS_PREALERTA_FILTRO_POR_NUMCONSOLIDADA]
go
CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_PREALERTA_FILTRO_POR_NUMCONSOLIDADA]                                                                     
				@NConsolidado nvarchar(50)
AS
SELECT PA.Id, PA.NumConsolidada, PA.IdAgente, PAG.Descripcion Agente, PA.IdNaviera, PN.Descripcion Naviera, 
	   PA.IdNave, PNAVE.Descripcion Nave, PA.FechaSalida, PA.FechaLlegada, PA.FechaRecibimiento,
	   PA.NumMaster, PA.IdUsuarioCreacion, PA.FechaCreacion, U1.NombreUsuario, PA.IdEstado, pep.Descripcion estado,
	   PUO.Id IdPO, PUO.codigo as IdPuertoOrigen,PUO.nombre as NombrePuertoOrigen,
	   PUD.Id IdPD, PUD.codigo as IdPuertoDestino, PUD.nombre as NombrePuertoDestino
FROM PAPERLESS_PREALERTA PA
LEFT OUTER JOIN USUARIOS U1
ON PA.IdUsuarioCreacion = U1.Id
LEFT OUTER JOIN PAPERLESS_AGENTE PAG
ON PA.IdAgente = PAG.Id
LEFT OUTER JOIN PAPERLESS_NAVIERA PN
ON PA.IdNaviera = PN.Id
LEFT OUTER JOIN PAPERLESS_NAVE PNAVE
ON PA.IdNave = PNAVE.Id
INNER JOIN USUARIOS UC
ON PA.IdUsuarioCreacion = UC.Id
LEFT OUTER JOIN PAPERLESS_ESTADO_PREALERTA pep
ON pep.ID = PA.IdEstado
LEFT OUTER JOIN PAPERLESS_PUERTOS PUO
ON PUO.Codigo = PA.IdPuertoOrigen
LEFT OUTER JOIN PAPERLESS_PUERTOS PUD
ON PUD.Codigo = PA.IdPuertoDestino
WHERE PA.NumConsolidada = @NConsolidado