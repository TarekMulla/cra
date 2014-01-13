DROP procedure [dbo].[SP_L_COTIZACION_INDIRECTA_DETALLES_POR_ID_SOLICITUD]
GO


CREATE procedure [dbo].[SP_L_COTIZACION_INDIRECTA_DETALLES_POR_ID_SOLICITUD]
	@id bigint 
as
begin
	SELECT det.id as det_id,  det.cantidad as det_cantidad, item.id as item_id, item.nombre as item_nombre,item.descripcion as item_descripcion,item.activo as item_activo
	FROM dbo.COTIZACION_INDIRECTA_DETALLES det
	left join COTIZACION_INDIRECTA_ITEMS item on item.id = det.COTIZACION_INDIRECTA_ITEMS_id
	WHERE COTIZACION_SOLICITUD_COTIZACIONES_id=@id

end	
GO