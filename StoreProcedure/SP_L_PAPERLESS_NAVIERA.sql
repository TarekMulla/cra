SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE [dbo].[SP_L_PAPERLESS_NAVIERA]  
@Activo bit  
  
AS  
  
SELECT Id, Descripcion, Activo ,FechaCreacion FROM PAPERLESS_NAVIERA  
WHERE Activo = @Activo  
  order by Descripcion