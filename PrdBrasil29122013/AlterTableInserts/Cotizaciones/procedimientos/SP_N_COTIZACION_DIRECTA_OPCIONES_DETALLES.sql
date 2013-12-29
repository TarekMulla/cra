CREATE Procedure [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES_DETALLES]
			@cantidad decimal(10,6)
           ,@costo decimal(10,6)
           ,@venta decimal(10,6)
           ,@COTIZACION_MONEDAS_id bigint
           ,@COTIZACION_DIRECTA_ITEMS_id bigint
           ,@COTIZACION_DIRECTA_OPCIONES_id bigint
           ,@COTIZACION_DIRECTA_CONCEPTO_ID bigint
           ,@id bigint OUTPUT
as
begin
INSERT INTO [dbo].[COTIZACION_DIRECTA_OPCIONES_DETALLES]
           ([cantidad]
           ,[costo]
           ,[venta]
           ,[COTIZACION_MONEDAS_id]
           ,[COTIZACION_DIRECTA_ITEMS_id]
           ,[COTIZACION_DIRECTA_OPCIONES_id]
           ,[COTIZACION_DIRECTA_CONCEPTO_ID]
           ,[CreateDate])
     VALUES
           (@cantidad
           ,@costo
           ,@venta
           ,@COTIZACION_MONEDAS_id
           ,@COTIZACION_DIRECTA_ITEMS_id
           ,@COTIZACION_DIRECTA_OPCIONES_id
           ,@COTIZACION_DIRECTA_CONCEPTO_ID
           ,getdate())

select @id = SCOPE_IDENTITY()
select @id;

end
