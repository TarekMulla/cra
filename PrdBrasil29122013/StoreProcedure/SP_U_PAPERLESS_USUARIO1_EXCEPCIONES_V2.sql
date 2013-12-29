if object_id('SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2', 'p') is null
exec ('
create   PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2]    
@TieneExcepciones bit,          
  @TipoExcepcion bigint,          
  @TipoResponsabilidad bigint,          
  @IdExcepcion bigint,          
  @comentario varchar(300),        
  @Resuelto bit        ,    
  @ResueltoUser2 bit     ,
  @Causador int
  AS                                              
  UPDATE PAPERLESS_USUARIO1_EXCEPCIONES          
  SET TieneExcepciones = @TieneExcepciones,TipoExcepcion=@TipoExcepcion, TipoResponsabilidad=@TipoResponsabilidad, comentario=@comentario  ,         
  Resuelto=@Resuelto    ,    
  Resuelto_User2=@ResueltoUser2 , 
  Causador =     @Causador
  WHERE Id = @IdExcepcion    ')
else
exec ('

  
alter    PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2]      
@TieneExcepciones bit,          
  @TipoExcepcion bigint,          
  @TipoResponsabilidad bigint,          
  @IdExcepcion bigint,          
  @comentario varchar(300),        
  @Resuelto bit        ,    
  @ResueltoUser2 bit     ,
  @Causador int
  AS                                              
  UPDATE PAPERLESS_USUARIO1_EXCEPCIONES          
  SET TieneExcepciones = @TieneExcepciones,TipoExcepcion=@TipoExcepcion, TipoResponsabilidad=@TipoResponsabilidad, comentario=@comentario  ,         
  Resuelto=@Resuelto    ,    
  Resuelto_User2=@ResueltoUser2 , 
  Causador =     @Causador
  WHERE Id = @IdExcepcion  ')