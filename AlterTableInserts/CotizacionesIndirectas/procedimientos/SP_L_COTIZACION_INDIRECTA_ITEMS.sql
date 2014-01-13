drop  Procedure [dbo].[SP_L_COTIZACION_INDIRECTA_ITEMS]
GO

create Procedure [dbo].[SP_L_COTIZACION_INDIRECTA_ITEMS]
AS
Begin
      SET NOCOUNT ON
      select id,nombre,descripcion,activo,createdate from dbo.COTIZACION_INDIRECTA_ITEMS
end
GO