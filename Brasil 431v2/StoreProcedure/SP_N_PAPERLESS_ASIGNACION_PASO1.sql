ALTER PROCEDURE [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]
@NumMaster nvarchar(100),
@FechaMaster datetime,
@IdAgente bigint,
@IdNaviera bigint,
@IdNave bigint,
@Viaje nvarchar(100),
@NumHousesBL int,
@IdTipoCarga int,
@IdEstado int,
@IdUsuarioCreo int,
@IdTipoServicio int,
@IdNaveTransbordo int,
@txtShipping varchar(100)

AS

IF @IdAgente = -1 SET @IdAgente = NULL
IF @IdNaviera = -1 SET @IdNaviera = NULL
IF @IdNave = -1 SET @IdNave = NULL
IF @IdNaveTransbordo = -1 SET @IdNaveTransbordo = NULL
IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL

INSERT INTO PAPERLESS_ASIGNACION(
	NumMaster,FechaMaster,IdAgente,IdNaviera,IdNave,Viaje,NumHousesBL,IdTipoCarga, IdTipoServicio, 
	IdEstado,FechaCreacion, FechaPaso1,IdUsuarioCreacion, Usuario1, Usuario2,IdNaveTransbordo,
	txtShipping
	)
VALUES(
	@NumMaster,@FechaMaster,@IdAgente,@IdNaviera,@IdNave,@Viaje,@NumHousesBL,@IdTipoCarga, @IdTipoServicio,
	@IdEstado,GETDATE(), GETDATE(),@IdUsuarioCreo, -1, -1,@IdNaveTransbordo,@txtShipping
)

SELECT SCOPE_IDENTITY()

