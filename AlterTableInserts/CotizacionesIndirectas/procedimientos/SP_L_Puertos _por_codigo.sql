DROP Procedure [dbo].[SP_L_Puertos_por_codigo]
GO

CREATE Procedure [dbo].[SP_L_Puertos_por_codigo]
@codigo varchar(30)
AS
Begin
      SET NOCOUNT ON
      select codigo as puerto,nombre,pais from puertos where codigo=@codigo
end  
GO
