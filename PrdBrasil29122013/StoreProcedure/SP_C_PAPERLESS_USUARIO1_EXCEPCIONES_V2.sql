if object_id('SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2', 'p') is null
exec ('
CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2]  
@IdExcepcion bigint  
AS  
select a.TieneExcepciones,      
b.id as id_tipo_excepcion,      
b.descripcion as descripcion_tipo_excepcion,      
c.id as id_tipo_responsabilidad,      
c.descripcion as descripcion_tipo_responsabilidad  ,    
a.Resuelto,    
a.Resuelto_User2   , 
a.Causador,
d.descripcion
from PAPERLESS_USUARIO1_EXCEPCIONES A      
LEFT OUTER JOIN PAPERLESS_TIPO_EXCEPCIONES B on a.tipoExcepcion= b.id      
LEFT OUTER JOIN PAPERLESS_TIPO_RESPONSABILIDAD c on a.TipoResponsabilidad = c.id  
LEFT OUTER JOIN PAPERLESS_TIPO_AGENTECAUSADOR  d on A.causador=d.id
where A.id=@IdExcepcion         
')
else 
exec ('
Alter PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2]  
@IdExcepcion bigint  
AS  
select a.TieneExcepciones,      
b.id as id_tipo_excepcion,      
b.descripcion as descripcion_tipo_excepcion,      
c.id as id_tipo_responsabilidad,      
c.descripcion as descripcion_tipo_responsabilidad  ,    
a.Resuelto,    
a.Resuelto_User2   , 
a.Causador,
d.descripcion
from PAPERLESS_USUARIO1_EXCEPCIONES A      
LEFT OUTER JOIN PAPERLESS_TIPO_EXCEPCIONES B on a.tipoExcepcion= b.id      
LEFT OUTER JOIN PAPERLESS_TIPO_RESPONSABILIDAD c on a.TipoResponsabilidad = c.id  
LEFT OUTER JOIN PAPERLESS_TIPO_AGENTECAUSADOR  d on A.causador=d.id
where A.id=@IdExcepcion          
')

