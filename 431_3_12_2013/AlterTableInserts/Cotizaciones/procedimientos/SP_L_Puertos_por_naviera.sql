CREATE Procedure [dbo].[SP_L_Puertos_por_Naviera]
@idNaviera varchar(30)
AS
Begin
      SET NOCOUNT ON
      select * 
	  from dbo.puertos,NAVIERA_PUERTO
      where NAVIERA_PUERTO.idNaviera=@idNaviera
      and puertos.codigo = naviera_puerto.puerto
end  

