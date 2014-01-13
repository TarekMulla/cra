USE [scc]
GO
/****** Object:  StoredProcedure [dbo].[SP_C_CLIENTES_MASTER_TIPOS_RELACIONES]    Script Date: 06/03/2012 21:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter procedure  [dbo].[SP_C_CLIENTES_MASTER_TIPOS_RELACIONES]
@IdCliente bigint

AS

SELECT P.Id, P.IdTipoParametro, P.CodParametro, P.Descripcion,CMTC.Descripcion as tipo, CMTC.Id as idTipoCliente
FROM CLIENTES_TIPORELACION CTR
INNER JOIN PARAM_PARAMETROS P ON CTR.IdTipoRelacion = P.Id
INNER JOIN CLIENTES_MASTER_TIPO_CLIENTE CMTC on CMTC.idClientetiporelacion =P.Id
WHERE CTR.IdCliente = @IdCliente


go
