DROP procedure [dbo].[SP_N_PAPERLESS_PREALERTA]
GO
CREATE procedure [dbo].[SP_N_PAPERLESS_PREALERTA]
@NumConsolidada nvarchar(50),
@IdAgente bigint,
@IdNaviera bigint,
@IdNave bigint,
@FechaSalida datetime,
@FechaLlegada datetime,
@PuertoOrigen nvarchar(50),
@PuertoDestino nvarchar(50),
@FechaCreacion datetime,
@IdUsuarioCreacion bigint,
@IdUsuarioModificacion bigint,
@NumMaster nvarchar(50),
@FechaRecibimiento datetime,
@IdEstado bigint
AS

IF @IdAgente = -1 SET @IdAgente = NULL
IF @IdNaviera = -1 SET @IdNaviera = NULL
IF @IdNave = -1 SET @IdNave = NULL
IF YEAR(@FechaSalida) = 9999 SET @FechaSalida = NULL
IF YEAR(@FechaLlegada) = 9999 SET @FechaLlegada = NULL
IF YEAR(@FechaRecibimiento) = 9999 SET @FechaRecibimiento = NULL

IF Not EXISTS (select NumConsolidada from PAPERLESS_PREALERTA where NumConsolidada=@NumConsolidada)
Begin

	INSERT INTO PAPERLESS_PREALERTA
		(NumConsolidada,NumMaster,IdAgente, IdNaviera, IdNave,FechaSalida,FechaLlegada,FechaRecibimiento,
		FechaCreacion,IdUsuarioCreacion,IdUsuarioModificacion,IdEstado,IdPuertoOrigen,IdPuertoDestino)
	VALUES
		(@NumConsolidada,@NumMaster,@IdAgente, @IdNaviera, @IdNave,@FechaSalida,@FechaLlegada,@FechaRecibimiento,
		@FechaCreacion,@IdUsuarioCreacion,@IdUsuarioModificacion,@IdEstado,@PuertoOrigen,@PuertoDestino)

End


