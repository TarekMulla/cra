CREATE Procedure [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_ID_OPCION]
		 @idOpcion bigint
as
begin
             select a.*,b.codigo as monedaCodigo,b.nombre as monedaNombre
            ,c.NOMBRE as conceptoNombre,c.DESCRIPCION as conceptoDescripcion
            ,d.nombre as detalleNombre,d.descripcion as detalleDescripcion
    from 
    COTIZACION_DIRECTA_OPCIONES_DETALLES as a
    , COTIZACION_MONEDAS b
    , COTIZACION_DIRECTA_CONCEPTOS c
    ,COTIZACION_DIRECTA_ITEMS d
    where a.COTIZACION_MONEDAS_id = b.id
    and a.COTIZACION_DIRECTA_CONCEPTO_ID =c.ID
    and a.COTIZACION_DIRECTA_ITEMS_id = d.id
    and a.COTIZACION_DIRECTA_OPCIONES_id  = @idOpcion
end
