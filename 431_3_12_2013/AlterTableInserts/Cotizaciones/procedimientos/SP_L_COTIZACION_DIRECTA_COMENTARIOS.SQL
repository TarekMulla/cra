CREATE Procedure [dbo].[SP_L_COTIZACION_DIRECTA_COMENTARIOS]
		 @idOpcion_o_Cotizacion bigint
as
begin
       SELECT [id]
      ,[fecha]
      ,[EsHistorial]
      ,[Comentario]
      ,[idUsuario]
      ,[COTIZACION_DIRECTA_OPCIONES_id]
      ,[CreateDate]
  FROM [dbo].[COTIZACION_DIRECTA_COMENTARIOS]
  WHERE COTIZACION_DIRECTA_OPCIONES_id = @idOpcion_o_Cotizacion;
end
