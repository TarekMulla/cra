ALTER TABLE COTIZACION_DIRECTA_OPCIONES_DETALLES ALTER COLUMN venta decimal(16,1)
GO

alter PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES_DETALLES]
         @id                              bigint,
         @cantidad                        decimal,
         @costo                           decimal,
         @venta                           decimal(16,1),
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
go

alter Procedure [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES_DETALLES]
			@cantidad decimal(10,6)
           ,@costo decimal(10,6)
           ,@venta decimal(16,6)
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
GO