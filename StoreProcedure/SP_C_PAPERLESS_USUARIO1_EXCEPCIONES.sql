ALTER PROCEDURE  SP_C_PAPERLESS_USUARIO1_EXCEPCIONES  
@IdAsignacion bigint    
    
AS    
    
SELECT     
PE.Id,    
PE.IdAsignacion,    
IdHouseBL,    
RecargoCollect,    
RecargoCollectResuelto,    
SobrevalorPendiente,    
SobrevalorPendienteResuelto,    
AvisoNoEnviado,    
AvisoNoEnviadoResuelto,    
PH.IdCliente,    
PH.IdTipoCliente , TC.Descripcion TipoCliente,    
PH.Freehand,    
PH.HouseBL,    
PH.IndexHouse,    
PE.comentario  ,  
PE.UsuarioUltimaMod  ,
PE.Causador
    
FROM PAPERLESS_USUARIO1_EXCEPCIONES PE    
INNER JOIN PAPERLESS_USUARIO1_HOUSESBL PH ON PH.Id = PE.IdHouseBL    
INNER JOIN CLIENTES_MASTER_TIPO_CLIENTE TC ON PH.IdTipoCliente = TC.Id    
WHERE PE.IdAsignacion = @IdAsignacion    
and PE.Estado = 1  
ORDER BY IdHouseBL 