CREATE  PROCEDURE  SP_E_PAPERLESS_USUARIO1_EXCEPCIONES_MASTER
      
  @IdExcepcion bigint  ,  
  @idUsuarioUltimaModificacion bigint  
      
   AS                                                  
  update PAPERLESS_USUARIO1_EXCEPCIONES_MASTER   
  set Estado = 0 ,UsuarioUltimaModificacion=@idUsuarioUltimaModificacion      
  WHERE Id = @IdExcepcion 
  
  
