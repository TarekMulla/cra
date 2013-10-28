Create Procedure [dbo].[SP_L_AGENTES]  
AS  

select 
Id,
descripcion,
Contacto,
Email,
alias

from PAPERLESS_AGENTE  
where Activo = 1
    
go
