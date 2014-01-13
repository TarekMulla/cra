create Procedure [dbo].[SP_N_COTIZACION_COMENTARIOS]
		@EsHistorial bit = null 
           ,@Comentario varchar	(500) =null
           ,@idUsuario bigint  =null
           ,@idOpcion_o_Cotizacion bigint  =null
           ,@id bigint OUTPUT
as 
begin

INSERT INTO [dbo].[COTIZACION_COMENTARIOS]
           ([fecha]
           ,[EsHistorial]
           ,[Comentario]
           ,[idUsuario]
           ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
           ,[CreateDate])
     VALUES
           (getdate()
           ,@EsHistorial
           ,@comentario
           ,@idUsuario
           ,@idOpcion_o_Cotizacion
           ,getdate())
	
	select @id = SCOPE_IDENTITY()
	select @id;
end