SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_U_USUARIO2_HOUSESBL]
@EmbarcadorContactado bit,
@ReciboApertura bit,
@FechaReciboApertura datetime,
@TipoReciboAperturaEmbarcador int,
@IdHouse bigint,
@Observacion varchar(100)

AS

IF YEAR(@FechaReciboApertura) = 9999 SET @FechaReciboApertura = null

UPDATE PAPERLESS_USUARIO1_HOUSESBL SET
EmbarcadorContactado = @EmbarcadorContactado,
ReciboAperturaEmbarcador = @ReciboApertura ,
FechaReciboAperturaEmbarcador = @FechaReciboApertura,
TipoReciboAperturaEmbarcador = @TipoReciboAperturaEmbarcador,
Observacion = @Observacion
WHERE Id = @IdHouse
