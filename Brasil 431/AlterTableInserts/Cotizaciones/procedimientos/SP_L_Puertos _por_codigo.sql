CREATE Procedure [dbo].[SP_L_Puertos _por_codigo]
@codigo varchar(30)
AS
Begin
      SET NOCOUNT ON
      select codigo,nombre,pais from puertos where codigo=@codigo
end  

