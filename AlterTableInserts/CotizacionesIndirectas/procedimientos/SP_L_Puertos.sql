drop Procedure [dbo].[SP_L_Puertos]         
GO

create Procedure [dbo].[SP_L_Puertos]         
AS
Begin
      SET NOCOUNT ON
      select codigo as puerto,nombre,pais from puertos
end
GO