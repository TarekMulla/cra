CREATE Procedure [dbo].[SP_L_monedas]	
AS
Begin
      SET NOCOUNT ON
      select id,codigo,nombre,activo from cotizacion_monedas
end  