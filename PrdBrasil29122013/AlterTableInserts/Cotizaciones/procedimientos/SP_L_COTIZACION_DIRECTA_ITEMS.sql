CREATE Procedure [dbo].[SP_L_COTIZACION_DIRECTA_ITEMS]
AS
Begin
      SET NOCOUNT ON
	  SELECT [id],[nombre],[descripcion] ,[activo]
	  FROM [dbo].[COTIZACION_DIRECTA_ITEMS]
end  

