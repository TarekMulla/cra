DROP PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]   
GO
CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]   
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
 @motivoModificacion varchar(50)                            
 AS                                
                           

DECLARE @TiempoEstimadoUsr1 FLOAT
DECLARE @Duracion FLOAT

IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL         

SELECT @Duracion = duracion
FROM PAPERLESS_PROCESOS_DURACION
WHERE idtipocarga=@IdTipoCarga

SELECT @Tiempo 
 EstimadoUsr1 = ISNULL(@NumHouses * @Duracion,0)   
                                                            
UPDATE PAPERLESS_ASIGNACION SET                            
    NumMaster = @NumMaster,                                    
    FechaMaster = @FechaMaster,                                
    IdAgente = @IdAgente,                                      
    IdNaviera = @IdNaviera,                                    
    IdNave = @IdNave ,                                         
    Viaje = @Viaje ,                                            
    NumHousesBL = @NumHouses,                                  
    IdTipoCarga = @IdTipoCarga,                                
    FechaPaso1 = GETDATE(),                                    
    IdTipoServicio = @IdTipoServicio,                          
    MotivoModificacion = @motivoModificacion,
    TiempoEstimadoUsr1 = @TiempoEstimadoUsr1
WHERE Id = @IdAsignacion                                                                                              