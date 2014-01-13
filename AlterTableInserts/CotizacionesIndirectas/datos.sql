INSERT INTO COTIZACION_TIPOS_TRANSBORDOS (nombre, createDate) VALUES ('Con Transbordo', getdate());
INSERT INTO COTIZACION_TIPOS_TRANSBORDOS (nombre, createDate) VALUES ('Sin Transbordo', getdate());
INSERT INTO COTIZACION_TIPOS_TRANSBORDOS (nombre, createDate) VALUES ('Ambos', getdate());



/* COTIZACION_INDIRECTA_ITEMS*/
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('20’ Estándar','20’ Estándar',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('20’ Reefer','20’ Reefer',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Estándar','40’ Estándar',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ High Cube','40’ High Cube',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Reefer','40’ Reefer',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Reefer High Cube','40’ Reefer High Cube',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Open Top ','40’ Open Top ',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('Break Bulk','Break Bulk',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('Proyecto u otros ','Proyecto u otros ',1,GETDATE())
GO

INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Ingresado',1,GETDATE(),'Se Ingresa la solicitud de Tarifa')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('En proceso',1,GETDATE(),'Se Acepta la solicitud, quedando en estado en proceso')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Tarifa Disponible',1,GETDATE(),'Se Ingresa Tarifa')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Enviada al cliente',1,GETDATE(),'Se envia al cliente')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Reevaluación',1,GETDATE(),'Se cambia a estado Reevaluación')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Perdido (tarifa)',1,GETDATE(),'Se cambia a estado Perdido (tarifa)')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Perdido (otros)',1,GETDATE(),'Se cambia a estado Perdido (Otros)')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Cerrado',1,GETDATE(),'Se cambia a estado Cerrado')
INSERT INTO [dbo].[COTIZACION_INDIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate],comentario)
     VALUES      ('Cerrado LCL',1,GETDATE(),'Se cambia a estado Cerrado LCL')
GO