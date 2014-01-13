if object_id('SP_N_Cotizacion_DetalleTarifa', 'P') is not null 
       drop proc SP_N_Cotizacion_DetalleTarifa
GO

Create Procedure SP_N_Cotizacion_DetalleTarifa
    @IdTarifa		bigint,
    @IdItem			bigint,
	@IdMonda		bigint,
	@Cantidad decimal,
	@Costo decimal, 
	@Venta decimal,
	@ID bigint OUTPUT
AS
Begin
      SET NOCOUNT ON
      insert into  Cotizacion_DetalleTarifa
(iDTarifa,
idItem,
IdMonda,
Cantidad,
Costo,
Venta)
values 
(@IdTarifa,
@IdItem,
@IdMonda,
@Cantidad,
@Costo,
@Venta)
  
  select @ID = SCOPE_IDENTITY()
End

GO
