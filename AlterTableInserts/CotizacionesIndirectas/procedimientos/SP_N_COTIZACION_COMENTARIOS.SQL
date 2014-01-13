DROP Procedure [dbo].[SP_N_COTIZACION_COMENTARIOS]
GO
create Procedure [dbo].[SP_N_COTIZACION_COMENTARIOS]
	   @EsHistorial bit = null 
           ,@Comentario varchar	(500) =null
           ,@idUsuario bigint  =null
           ,@idOpcion_o_Cotizacion bigint  =null
           ,@idEstadoActual bigint  =null
           ,@idEstadoNuevo bigint  =null
	   ,@id bigint OUTPUT
as 
begin
	
INSERT INTO [dbo].[COTIZACION_COMENTARIOS]
           ([fecha]
           ,[EsHistorial]
           ,[Comentario]
           ,[idUsuario]
           ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
	   ,[IdEstadoAnterior]
	   ,[IdEstadoNuevo]
           ,[CreateDate])
     VALUES
           (getdate()
           ,@EsHistorial
           ,@comentario
           ,@idUsuario
           ,@idOpcion_o_Cotizacion
	   ,@idEstadoActual
	   ,@idEstadoNuevo
           ,getdate())
	
	select @id = SCOPE_IDENTITY()
	select @id
end