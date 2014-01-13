drop  Procedure [dbo].[SP_L_COTIZACION_TIPOS_TRANSBORDOS]
GO

create Procedure [dbo].[SP_L_COTIZACION_TIPOS_TRANSBORDOS]
AS
Begin
      SET NOCOUNT ON
      select id,nombre  from COTIZACION_TIPOS_TRANSBORDOS
end
GO