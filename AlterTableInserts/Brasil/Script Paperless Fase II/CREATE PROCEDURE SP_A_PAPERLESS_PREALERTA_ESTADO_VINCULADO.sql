CREATE PROCEDURE [dbo].[SP_A_PAPERLESS_PREALERTA_ESTADO_VINCULADO]
@NumConsolidada nvarchar(50)
AS
IF EXISTS (select NumConsolidada from PAPERLESS_PREALERTA where NumConsolidada=@NumConsolidada)
Begin
	UPDATE PAPERLESS_PREALERTA
		SET IdEstado = 4
	WHERE NumConsolidada = @NumConsolidada
End
GO