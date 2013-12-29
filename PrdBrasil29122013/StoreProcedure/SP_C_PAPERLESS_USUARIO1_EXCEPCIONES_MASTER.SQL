Alter PROCEDURE  SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_MASTER     
@IdAsignacion bigint        
        
AS        
       
SELECT         
PE.ID,   
Idasignacion,   
IDhousebl,  
tieneExcepcion,  
tipoexcepcion,  
PTE.Descripcion as descripcion_tipo_excepcion,  
tiporesponsabilidad,  
PTR.DESCRIPCION AS descripcion_tipo_responsabilidad,  
comentario,  
resuelto,  
estado,  
usuarioUltimaModificacion,  
AgenteCausador,  
PTA.Descripcion,
PE.usuarioCreador   
        
FROM PAPERLESS_USUARIO1_EXCEPCIONES_MASTER PE        
INNER JOIN PAPERLESS_TIPO_EXCEPCIONES PTE on PE.tipoexcepcion=PTE.Id  
INNER JOIN PAPERLESS_TIPO_RESPONSABILIDAD PTR ON PE.tiporesponsabilidad=PTR.ID  
INNER JOIN PAPERLESS_TIPO_AGENTECAUSADOR PTA ON PE.AgenteCausador=PTA.ID  
WHERE PE.IdAsignacion = @IdAsignacion        
and PE.Estado = 1      
--ORDER BY IdHouseBL 
