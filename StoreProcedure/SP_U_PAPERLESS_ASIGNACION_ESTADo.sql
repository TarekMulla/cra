DROP PROCEDURE SP_U_PAPERLESS_ASIGNACION_ESTADo 
GO
CREATE PROCEDURE SP_U_PAPERLESS_ASIGNACION_ESTADo 
 @IdEstado int,                                    
 @IdAsignacion bigint                              
                                                   
 AS                                                
                                                   
 UPDATE PAPERLESS_ASIGNACION                       
 SET IdEstado = @IdEstado                          
 WHERE Id = @IdAsignacion  

//Si es en proceso por el usuario etapa1
//entonces registro la fecha ya que ahi
//comienzan a correr los plazos
IF @IdEstado=5
BEGIN
    UPDATE PAPERLESS_ASIGNACION                       
    SET FechaAceptacionUsr1 = getdate()                          
    WHERE Id = @IdAsignacion  
END                        

