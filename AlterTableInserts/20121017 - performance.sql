CREATE TABLE  LOG_PERFORMANCE
    (
        Id INT NOT NULL IDENTITY,
        NombreUsuario NVARCHAR(50) not NULL,
        Modulo  NVARCHAR(100) not NULL,
        Accion  NVARCHAR(300) not NULL,
        Tiempo decimal(12,3) not null,
        create_date datetime default getdate(),
        CONSTRAINT PK_LOG_PERFORMANCE PRIMARY KEY (ID)
    )
GO

CREATE PROCEDURE "dbo"."SP_N_LOG_PERFORMANCE"
					@NombreUsuario varchar(50),
					@Modulo VARCHAR(100),
					@Accion	VARCHAR(300),
					@Tiempo decimal(12,3)

AS

INSERT INTO dbo.LOG_PERFORMANCE (NombreUsuario,Modulo,Accion, Tiempo)
VALUES (@NombreUsuario,@Modulo,@Accion,@Tiempo)
SELECT SCOPE_IDENTITY()

RETURN 0


ALTER TABLE PAPERLESS_USUARIO1_EXCEPCIONES add comentario varchar(300)
GO


CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO2_EXCEPCIONES_V2] 
@RecargoCollect bit,                                          
@RecargoCollectResuelto bit,
@SobrevalorPendiente bit,          
@SobrevalorPendienteResuelto bit,    
@AvisoNoEnviado bit,          
@AvisoNoEnviadoResuelto bit,
@IdExcepcion bigint,
@comentario varchar(300)                   
As
UPDATE PAPERLESS_USUARIO1_EXCEPCIONES SET                      
RecargoCollect = @RecargoCollect,
RecargoCollectResuelto = @RecargoCollectResuelto,
SobrevalorPendiente = @SobrevalorPendiente,
SobrevalorPendienteResuelto = @SobrevalorPendienteResuelto,
AvisoNoEnviado = @AvisoNoEnviado,
AvisoNoEnviadoResuelto = @AvisoNoEnviadoResuelto,
comentario = @comentario
WHERE Id = @IdExcepcion
GO

ALTER PROCEDURE "dbo"."SP_C_PAPERLESS_USUARIO1_EXCEPCIONES" 
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
PE.comentario

FROM PAPERLESS_USUARIO1_EXCEPCIONES PE
INNER JOIN PAPERLESS_USUARIO1_HOUSESBL PH ON PH.Id = PE.IdHouseBL
INNER JOIN CLIENTES_MASTER_TIPO_CLIENTE TC ON PH.IdTipoCliente = TC.Id
WHERE PE.IdAsignacion = @IdAsignacion
ORDER BY IdHouseBL
GO

alter PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2]
@IdExcepcion bigint
AS
select a.TieneExcepciones,
b.id as id_tipo_excepcion,
b.descripcion as descripcion_tipo_excepcion,
c.id as id_tipo_responsabilidad,
c.descripcion as descripcion_tipo_responsabilidad
from PAPERLESS_USUARIO1_EXCEPCIONES A
LEFT OUTER JOIN PAPERLESS_TIPO_EXCEPCIONES B on a.tipoExcepcion= b.id
LEFT OUTER JOIN PAPERLESS_TIPO_RESPONSABILIDAD c on a.TipoResponsabilidad = c.id
where A.id=@IdExcepcion  
GO