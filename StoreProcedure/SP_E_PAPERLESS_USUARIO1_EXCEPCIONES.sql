
Alter  PROCEDURE  SP_E_PAPERLESS_USUARIO1_EXCEPCIONES   
    
  @IdExcepcion bigint  ,
  @idUsuarioUltimaModificacion bigint
    
   AS                                                
  update PAPERLESS_USUARIO1_EXCEPCIONES 
  set Estado = 0 ,UsuarioUltimaMod=@idUsuarioUltimaModificacion    
  WHERE Id = @IdExcepcion    