create procedure [dbo].[SP_A_PAPERLESS_PREALERTA]
@Id bigint,
@NumConsolidada nvarchar(50),
@IdAgente bigint,
@IdNaviera bigint,
@IdNave bigint,
@FechaSalida datetime,
@FechaLlegada datetime,
@PuertoOrigen nvarchar(50),
@PuertoDestino nvarchar(50),
@FechaRecibimiento datetime,
@FechaModificacion datetime,
@IdUsuarioModificacion bigint,
@IdEstado bigint,
@NumMaster nvarchar(50)

AS

IF @IdAgente = -1 SET @IdAgente = NULL
IF @IdNaviera = -1 SET @IdNaviera = NULL
IF @IdNave = -1 SET @IdNave = NULL
IF YEAR(@FechaSalida) = 9999 SET @FechaSalida = NULL
IF YEAR(@FechaLlegada) = 9999 SET @FechaLlegada = NULL
IF YEAR(@FechaRecibimiento) = 9999 SET @FechaRecibimiento = NULL
IF YEAR(@FechaModificacion) = 9999 SET @FechaModificacion = NULL

	UPDATE PAPERLESS_PREALERTA
		SET NumConsolidada = @NumConsolidada,
			NumMaster = @NumMaster,
			IdAgente = @IdAgente,
			IdNaviera = @IdNaviera,
			IdNave = @IdNave,
			FechaSalida = @FechaSalida,
			FechaLlegada = @FechaLlegada,
			FechaRecibimiento = @FechaRecibimiento,
			FechaModificacion = @FechaModificacion,
			IdUsuarioModificacion = @IdUsuarioModificacion,
			IdEstado = @IdEstado,
			IdPuertoOrigen = @PuertoOrigen,
			IdPuertoDestino = @PuertoDestino
	WHERE Id = @Id

GO