CREATE    PROCEDURE  SP_E_PAPERLESS_USUARIO1_EXCEPCIONES 
  
  @IdExcepcion bigint
  
   AS                                              
  delete from  PAPERLESS_USUARIO1_EXCEPCIONES   WHERE Id = @IdExcepcion    