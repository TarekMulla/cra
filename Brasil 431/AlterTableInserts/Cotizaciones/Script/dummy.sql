INSERT INTO [dbo].[COTIZACION_SOLICITUD_COTIZACIONES]
           ([producto]
           ,[idUsuario]
           ,[idCliente]
           ,[idTarget]
           ,[nombreCliente]
           ,[fechaSolicitud]
           ,[idIncoterms]
           ,[commodity]
           ,[puertoEmbarque]
           ,[POL]
           ,[POD]
           ,[navieraReferencia]
           ,[tarifaReferencia]
           ,[ObservacionesFijas]
           ,[Observaciones]
           ,[mercaderia]
           ,[gastosLocales]
           ,[proveedorCarga]
           ,[credito]
           ,[fechaEstimadaEmbarque]
           ,[conAgenciamento]
           ,[createDate]
           ,[COTIZACION_TIPOS_TRANSBORDOS_id]
           ,[COTIZACION_Directa_ESTADOS_id]
           ,[COTIZACION_TIPOS_id])
     VALUES
           ('ASD'
           ,1
           ,1
           ,1
           ,'victor'
           ,GETDATE()
           ,1
           ,'hola'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,1
           ,GETDATE()
           ,null
           ,1
           ,1)
GO





INSERT INTO [dbo].[COTIZACION_SOLICITUD_COTIZACIONES]
           ([producto]
           ,[idUsuario]
           ,[idCliente]
           ,[idTarget]
           ,[nombreCliente]
           ,[fechaSolicitud]
           ,[idIncoterms]
           ,[commodity]
           ,[puertoEmbarque]
           ,[POL]
           ,[POD]
           ,[navieraReferencia]
           ,[tarifaReferencia]
           ,[ObservacionesFijas]
           ,[Observaciones]
           ,[mercaderia]
           ,[gastosLocales]
           ,[proveedorCarga]
           ,[credito]
           ,[fechaEstimadaEmbarque]
           ,[conAgenciamento]
           ,[createDate]
           ,[COTIZACION_TIPOS_TRANSBORDOS_id]
           ,[COTIZACION_Directa_ESTADOS_id]
           ,[COTIZACION_TIPOS_id])
     VALUES
           ('ASD'
           ,44
           ,2
           ,3
           ,'Paul'
           ,GETDATE()
           ,1
           ,'hola'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,'123'
           ,1
           ,GETDATE()
           ,null
           ,1
           ,1)
GO


update [COTIZACION_SOLICITUD_COTIZACIONES] set proveedorCarga = 'ProveedorCarga1' where ID=12
go
update [COTIZACION_SOLICITUD_COTIZACIONES] set proveedorCarga = 'ProveedorCarga2' where ID=14
go


insert into COTIZACION_DIRECTA_OPCIONES values(
12,GETDATE(),GETDATE(),1,'1','1','1',44,GETDATE(),1,1)
insert into COTIZACION_DIRECTA_OPCIONES values(
12,GETDATE(),GETDATE(),1,'2','2','2',44,GETDATE(),1,1)


INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,2,3
           ,'Paul2'
           ,GETDATE()
           ,1
           ,'hola2'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'123'
           ,'TarifaReferencia2'
           ,'ObservacionesFijas2'
           ,'Observaciones2'
           ,'Mercaderia2'
           ,123
           ,'ProveedorCarga2'
           ,'Credito2'
           ,'FechaEstimada2'
           ,1,GETDATE(),null,1,1)
GO

INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,3,3
           ,'Paul3'
           ,GETDATE()
           ,1
           ,'hola3'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'133'
           ,'TarifaReferencia3'
           ,'ObservacionesFijas3'
           ,'Observaciones3'
           ,'Mercaderia3'
           ,133
           ,'ProveedorCarga3'
           ,'Credito3'
           ,'FechaEstimada3'
           ,1,GETDATE(),null,1,1)
GO

INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,4,4
           ,'Paul4'
           ,GETDATE()
           ,1
           ,'hola4'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'144'
           ,'TarifaReferencia4'
           ,'ObservacionesFijas4'
           ,'Observaciones4'
           ,'Mercaderia4'
           ,144
           ,'ProveedorCarga4'
           ,'Credito4'
           ,'FechaEstimada4'
           ,1,GETDATE(),null,1,1)
GO

INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,5,5
           ,'Paul5'
           ,GETDATE()
           ,1
           ,'hola5'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'155'
           ,'TarifaReferencia5'
           ,'ObservacionesFijas5'
           ,'Observaciones5'
           ,'Mercaderia5'
           ,155
           ,'ProveedorCarga5'
           ,'Credito5'
           ,'FechaEstimada5'
           ,1,GETDATE(),null,1,1)
GO

INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,6,6
           ,'Paul6'
           ,GETDATE()
           ,1
           ,'hola6'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'166'
           ,'TarifaReferencia6'
           ,'ObservacionesFijas6'
           ,'Observaciones6'
           ,'Mercaderia6'
           ,166
           ,'ProveedorCarga6'
           ,'Credito6'
           ,'FechaEstimada6'
           ,1,GETDATE(),null,1,1)
GO

INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,7,7
           ,'Paul7'
           ,GETDATE()
           ,1
           ,'hola7'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'177'
           ,'TarifaReferencia7'
           ,'ObservacionesFijas7'
           ,'Observaciones7'
           ,'Mercaderia7'
           ,177
           ,'ProveedorCarga7'
           ,'Credito7'
           ,'FechaEstimada7'
           ,1,GETDATE(),null,1,1)
GO
INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,8,8
           ,'Paul8'
           ,GETDATE()
           ,1
           ,'hola8'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'188'
           ,'TarifaReferencia8'
           ,'ObservacionesFijas8'
           ,'Observaciones8'
           ,'Mercaderia8'
           ,188
           ,'ProveedorCarga8'
           ,'Credito8'
           ,'FechaEstimada8'
           ,1,GETDATE(),null,1,1)
GO


INSERT INTO COTIZACION_SOLICITUD_COTIZACIONES          
     VALUES
           ('ASD',44,9,9
           ,'Paul9'
           ,GETDATE()
           ,1
           ,'hola9'
           ,'AEFAT'
           ,'AEFAT'
           ,'AEFAT'
           ,'199'
           ,'TarifaReferencia9'
           ,'ObservacionesFijas9'
           ,'Observaciones9'
           ,'Mercaderia9'
           ,199
           ,'ProveedorCarga9'
           ,'Credito9'
           ,'FechaEstimada9'
           ,1,GETDATE(),null,1,1)
GO


--Carga detalle mas elaborado 

declare @idcoti  bigint 
declare @id bigint
DECLARE CargaOpciones CURSOR 
FOR select id from COTIZACION_SOLICITUD_COTIZACIONES where idusuario=44
OPEN CargaOpciones
FETCH CargaOpciones INTO @id
WHILE (@@FETCH_STATUS = 0)
BEGIN	
FETCH CargaOpciones INTO @id
insert into COTIZACION_DIRECTA_OPCIONES values( @id,GETDATE(),GETDATE(),1,'1','1','1',44,GETDATE(),@id,1)
print @id
END 
CLOSE CargaOpciones
DEALLOCATE CargaOpciones 


go
declare @idcoti  bigint 
declare @id bigint
DECLARE CargaOpciones CURSOR 
FOR select id from COTIZACION_SOLICITUD_COTIZACIONES where idusuario=44
OPEN CargaOpciones
FETCH CargaOpciones INTO @id
WHILE (@@FETCH_STATUS = 0)
BEGIN	
FETCH CargaOpciones INTO @id
insert into COTIZACION_DIRECTA_OPCIONES values( @id,GETDATE(),GETDATE(),1,''+@id,''+@id,''+@id,44,GETDATE(),@id,1)
print @id
END 
CLOSE CargaOpciones
DEALLOCATE CargaOpciones 
go