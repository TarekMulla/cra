  
CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_AGENTECAUSADOR]  
  
AS    
select id,Descripcion    
from PAPERLESS_TIPO_AGENTECAUSADOR    
where activo = 1  
  
  
  