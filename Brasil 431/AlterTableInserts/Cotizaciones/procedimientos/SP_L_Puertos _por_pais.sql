CREATE Procedure [dbo].[SP_L_Puertos _por_pais]
@pais varchar(300)
AS
Begin
      SET NOCOUNT ON
      select codigo,nombre,pais from puertos where pais=@pais
end  

