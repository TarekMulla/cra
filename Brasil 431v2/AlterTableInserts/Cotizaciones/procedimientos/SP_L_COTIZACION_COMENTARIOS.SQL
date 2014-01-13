CREATE Procedure [dbo].[SP_L_COTIZACION_COMENTARIOS]
		 @idOpcion_o_Cotizacion bigint
as
begin
       SELECT [id]
      ,[fecha]
      ,[EsHistorial]
      ,[Comentario]
      ,[idUsuario]
      ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
      ,[CreateDate]
  FROM [dbo].[COTIZACION_COMENTARIOS]
  WHERE COTIZACION_SOLICITUD_COTIZACIONES_id =@idOpcion_o_Cotizacion;
end
