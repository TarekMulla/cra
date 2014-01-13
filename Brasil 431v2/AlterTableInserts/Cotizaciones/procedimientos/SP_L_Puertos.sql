CREATE Procedure [dbo].[SP_L_Puertos]
AS
Begin
      SET NOCOUNT ON
      select codigo,nombre,pais from puertos
end  