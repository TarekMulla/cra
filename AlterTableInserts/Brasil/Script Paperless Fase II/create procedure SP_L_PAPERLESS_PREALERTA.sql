
DROP procedure [dbo].[SP_L_PAPERLESS_PREALERTA]
go
create procedure [dbo].[SP_L_PAPERLESS_PREALERTA]
@NumConsolidada nvarchar(50)
AS
Begin
	SELECT	NumConsolidada,NumMaster,IdAgente, IdNaviera, IdNave,FechaSalida,FechaLlegada,FechaRecibimiento,
			FechaCreacion,IdUsuarioCreacion,FechaModificacion,IdUsuarioModificacion,FechaCancelacion,
			IdUsuarioCancelacion,IdEstado,IdPuertoOrigen,IdPuertoDestino, Id
	  FROM PAPERLESS_PREALERTA
	WHERE NumConsolidada = @NumConsolidada
End


GO