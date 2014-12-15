create procedure [dbo].[SP_A_PAPERLESS_PREALERTA_ESTADO_CANCELACION]
@NumConsolidada nvarchar(50),
@FechaCancelacion datetime,
@IdUsuarioCancelacion bigint,
@IdEstado bigint
AS

IF EXISTS (select NumConsolidada from PAPERLESS_PREALERTA where NumConsolidada=@NumConsolidada)
Begin

	UPDATE PAPERLESS_PREALERTA
		SET FechaCancelacion = @FechaCancelacion,
			IdUsuarioCancelacion = @IdUsuarioCancelacion,
			IdEstado = @IdEstado
	WHERE NumConsolidada = @NumConsolidada

End


GO

