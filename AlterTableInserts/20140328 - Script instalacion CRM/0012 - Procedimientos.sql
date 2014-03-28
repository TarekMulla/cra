/*
Script generado por Aqua Data Studio 9.0.11 en mar-27-2014 10:22:31 PM
Base de datos: scctest
Esquema: dbo
Objetos: PROCEDURE
*/
DROP PROCEDURE [dbo].[SP_C_TARIFAS_MONEDAS]
GO

CREATE PROCEDURE [dbo].[SP_C_TARIFAS_MONEDAS]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id, Codigo,Descripcion
	FROM TARIFADO_MONEDAS	
END
GO
CREATE PROCEDURE [dbo].[SP_L_monedas]
AS
Begin
      SET NOCOUNT ON
      select id,codigo,nombre,activo from cotizacion_monedas
end  
GO

