CREATE Procedure [dbo].[SP_L_AGENTES]  
AS  

Begin  

 SET NOCOUNT ON  
 
 select 
 descripcion,
 Contacto,
 Email,
 alias
 
 from PAPERLESS_AGENTE  
 where Activo = 1
    
end 
