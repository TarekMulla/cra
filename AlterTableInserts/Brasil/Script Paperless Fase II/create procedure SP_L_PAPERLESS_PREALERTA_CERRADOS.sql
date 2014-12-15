drop procedure [dbo].[SP_L_PAPERLESS_PREALERTA_CERRADOS]
go
create procedure [dbo].[SP_L_PAPERLESS_PREALERTA_CERRADOS]
AS
Begin
	--2=Cerrado
	SELECT NumConsolidada
	  FROM PAPERLESS_PREALERTA
	WHERE IdEstado = 2
End


GO