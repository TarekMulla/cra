SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_HOUSEBL]
@IdAsignacion bigint

AS

SELECT
PHBL.Id,
PHBL.IdAsignacion,
IndexHouse,
HouseBL,
Freehand,
Ruteado,
IdCliente,
IdTipoCliente,
TC.Descripcion TipoCliente,
EmbarcadorContactado,
ReciboAperturaEmbarcador,
FechaReciboAperturaEmbarcador,
TipoReciboAperturaEmbarcador,
PE.RecargoCollect, 
PE.Id IdExcepcion,
PHBL.Observacion,
cc.PaperlessTipoRecibo
FROM PAPERLESS_USUARIO1_HOUSESBL PHBL LEFT OUTER JOIN CLIENTES_MASTER_TIPO_CLIENTE TC ON PHBL.IdTipoCliente = TC.Id
LEFT OUTER JOIN PAPERLESS_USUARIO1_EXCEPCIONES PE ON PHBL.Id = PE.IdHouseBL
inner join CLIENTES_CUENTA cc on cc.IdMaster=IdCliente
WHERE PHBL.IdAsignacion = @IdAsignacion 
ORDER BY IndexHouse
