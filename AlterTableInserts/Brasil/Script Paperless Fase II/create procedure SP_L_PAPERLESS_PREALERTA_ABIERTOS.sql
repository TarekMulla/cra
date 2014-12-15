create procedure [dbo].[SP_L_PAPERLESS_PREALERTA_ABIERTOS]
AS
Begin
	--1=Abierto
	SELECT COUNT(*)
	  FROM PAPERLESS_PREALERTA
	WHERE IdEstado = 1
	  AND FechaSalida < GETDATE()
End


GO