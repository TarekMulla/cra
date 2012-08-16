CREATE PROCEDURE [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]                                                 
 @NumMaster nvarchar(100),                                                                                
 @FechaMaster datetime,                    
                                                                 
 @IdAgente bigint,                                                                                        
 @IdNaviera bigint,                                                                 
                        
 @IdNave bigint,                                                                                          
 @Viaje nvarchar(100),                                                                                    
 @NumHousesBL int 
 ,                                                                                        
 @IdTipoCarga int,                                                                                        
 @IdEstado int,                                            
                                                 
 @IdUsuarioCreo int,                                                                                      
 @IdTipoServicio int                                                                                
        
                                                                                                          
 AS                                                                                                       

DECLARE @TiempoEstimadoUsr1 FLOAT
DECLARE @Duracion FLOAT
                                                                                                          
 IF @IdAgente = -1 SET @IdAgente = NULL                                                                   
 IF @IdNaviera = -1 SET @IdNaviera = NULL                                                                 
 IF @IdNave = -1 SET @IdNave = NULL                                                                       
 IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL  

SELECT @Duracion = duracion
FROM PAPERLESS_PROCESOS_DURACION
WHERE idtipocarga=@IdTipoCarga

SELECT @TiempoEstimadoUsr1 = ISNULL(@NumHousesBL * @Duracion,0)                                                    
                                                
                                                            
 INSERT INTO PAPERLESS_ASIGNACION(                                                                        
 	NumMaster,FechaMaster,IdAgente,IdNaviera,IdNave,Viaje,NumHousesBL,IdTipoCarga, IdTipoServicio,          
 	IdEstado,FechaCreacion, FechaPaso1,IdUsuarioCreacion, Usuario1, Usuario2, TiempoEstimadoUsr1
 	)                                                                                                       
 VALUES(                           
                                                                         
 	@NumMaster,@FechaMaster,@IdAgente,@IdNaviera,@IdNave,@Viaje,@NumHousesBL,@IdTipoCarga, @IdTipoServicio, 
 	@IdEstado,GETDATE(), GETDATE(),@IdUsuarioCreo, -1, -1, @TiempoEstimadoUsr1                                                   
 )                                                                                                        
           
 SELECT SCOPE_IDENTITY()                                                                                                                                                                                                                            