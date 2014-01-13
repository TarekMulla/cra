alter PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]   				   
@NumMaster nvarchar(50),   
@FechaMaster datetime,   
@IdAgente bigint,   
@IdNaviera bigint,   
@IdNave bigint,   
@Viaje nvarchar(100),   
@NumHouses int,   
@IdTipoCarga int,   
@IdAsignacion bigint,  
@IdTipoServicio int, 
@IdNaveTransbordo bigint,
@motivoModificacion varchar(50)    AS      IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL


UPDATE PAPERLESS_ASIGNACION SET   NumMaster = @NumMaster,
 FechaMaster = @FechaMaster,   
 IdAgente = @IdAgente,   
 IdNaviera = @IdNaviera,
 IdNave = @IdNave ,   
 Viaje = @Viaje,   
 NumHousesBL = @NumHouses,   
 IdTipoCarga = @IdTipoCarga,   
 FechaPaso1 = GETDATE(),   
 IdTipoServicio = @IdTipoServicio,   
 MotivoModificacion = @motivoModificacion ,
 IdNaveTransbordo=  @IdNaveTransbordo
WHERE Id = @IdAsignacion

