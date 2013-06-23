CREATE Procedure [dbo].[SP_L_COTIZACION_TIPOS]
AS
Begin
      SET NOCOUNT ON
      select id,nombre from COTIZACION_TIPOS
end  