CREATE    PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_MASTER]        

@IdExcepcion bigint,
@TieneExcepcion bit,
@TipoExcepcion int,
@TipoResponsabilidad int,
@comentario varchar (200),
@Resuelto bit,
@UsuarioUltimaModificacion int,
@Causador  int

  AS                                              
  UPDATE PAPERLESS_USUARIO1_EXCEPCIONES_MASTER            
  SET TieneExcepcion= @TieneExcepcion,
  TipoExcepcion=@TipoExcepcion, 
  TipoResponsabilidad=@TipoResponsabilidad, 
  comentario=@comentario  ,           
  Resuelto=@Resuelto,
  UsuarioUltimaModificacion=@UsuarioUltimaModificacion,        
  AgenteCausador = @Causador  
  WHERE Id = @IdExcepcion 
  
  