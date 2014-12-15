CREATE PROCEDURE [dbo].[SP_A_PAPERLESS_PREALERTA_NUMMASTER]
@NumConsolidada nvarchar(50),
@NumMaster nvarchar(50),
@IdNaviera int
AS
IF EXISTS (select NumConsolidada from PAPERLESS_PREALERTA where NumConsolidada=@NumConsolidada)
Begin
	UPDATE PAPERLESS_PREALERTA
		SET NumMaster = @NumMaster, IdNaviera = @IdNaviera
	WHERE NumConsolidada = @NumConsolidada
End