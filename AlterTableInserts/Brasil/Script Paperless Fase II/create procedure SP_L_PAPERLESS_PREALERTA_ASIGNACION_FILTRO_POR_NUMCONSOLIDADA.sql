DROP PROCEDURE [dbo].[SP_L_PAPERLESS_PREALERTA_ASIGNACION_FILTRO_POR_NUMCONSOLIDADA]                                                                     
GO
CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_PREALERTA_ASIGNACION_FILTRO_POR_NUMCONSOLIDADA]                                                                     
				@NConsolidado nvarchar(50)
AS

SELECT PA.Id, PA.NumConsolidada, PA.IdAgente, PAG.Descripcion Agente, PA.IdNaviera, PN.Descripcion Naviera, 
	   PA.IdNave, PNAVE.Descripcion Nave, PA.NumMaster
FROM PAPERLESS_PREALERTA PA
LEFT OUTER JOIN PAPERLESS_AGENTE PAG
ON PA.IdAgente = PAG.Id
LEFT OUTER JOIN PAPERLESS_NAVIERA PN
ON PA.IdNaviera = PN.Id
LEFT OUTER JOIN PAPERLESS_NAVE PNAVE
ON PA.IdNave = PNAVE.Id
WHERE PA.NumConsolidada = @NConsolidado