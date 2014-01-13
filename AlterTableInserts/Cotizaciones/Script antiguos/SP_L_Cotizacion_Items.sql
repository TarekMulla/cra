ALTER Procedure [dbo].[SP_L_Cotizacion_Items]
 AS
Begin
      SET NOCOUNT ON
select ID,Nombre,Descripcion from Cotizacion_ItemsTarifas
End