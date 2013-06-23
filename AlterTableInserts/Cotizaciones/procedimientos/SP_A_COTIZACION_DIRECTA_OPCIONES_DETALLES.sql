DROP PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES_DETALLES]
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES_DETALLES]
         @id                              bigint,
         @cantidad                        decimal,
         @costo                           decimal,
         @venta                           decimal,
         @COTIZACION_MONEDAS_id           bigint,
         @COTIZACION_DIRECTA_ITEMS_id     bigint,
         @COTIZACION_DIRECTA_CONCEPTO_ID  bigint
        AS
BEGIN
    UPDATE COTIZACION_DIRECTA_OPCIONES_DETALLES
    SET 
         cantidad=@cantidad,
         costo=@costo,
         venta=@venta,
         COTIZACION_MONEDAS_id=@COTIZACION_MONEDAS_id,
         COTIZACION_DIRECTA_ITEMS_id=@COTIZACION_DIRECTA_ITEMS_id,
         COTIZACION_DIRECTA_CONCEPTO_ID=@COTIZACION_DIRECTA_CONCEPTO_ID
    WHERE Id=@Id
END
RETURN 0