/* MONEDAS */ 
INSERT INTO [dbo].[COTIZACION_MONEDAS] ([codigo],[nombre],[activo],[createDate])
 VALUES('USD','Dolar',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_MONEDAS] ([codigo],[nombre],[activo],[createDate])
 VALUES('EUR','Euro',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_MONEDAS] ([codigo],[nombre],[activo],[createDate])
 VALUES('CLP','Peso Chileno',1,GETDATE())
GO


/* TIPOS DE COTIZACION */ 
INSERT INTO [dbo].[COTIZACION_TIPOS] ([nombre],[createDate])
     VALUES  ('Directa',GETDATE())
INSERT INTO [dbo].[COTIZACION_TIPOS] ([nombre],[createDate])
     VALUES  ('Indirecta',GETDATE())
GO


/* ESTADOS */
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Ingresado',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('En proceso',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Tarifa Disponible',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Enviada al cliente',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Reevaluación',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Perdido (tarifa)',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Perdido (otros)',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Cerrado',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre] ,[activo] ,[createdate])
     VALUES      ('Cerrado LCL',1,GETDATE())
GO

/*CONCEPTOS*/
INSERT INTO [dbo].[COTIZACION_DIRECTA_CONCEPTOS] ([NOMBRE],[DESCRIPCION],[ACTIVO],[CREATEDATE])
     VALUES
           ('+ THC','+ THC',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_CONCEPTOS] ([NOMBRE],[DESCRIPCION],[ACTIVO],[CREATEDATE])
     VALUES
           ('All In','All In',1,GETDATE())
GO

/* COTIZACION_DIRECTA_ITEMS*/
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('20’ Estándar','20’ Estándar',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('20’ Reefer','20’ Reefer',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Estándar','40’ Estándar',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ High Cube','40’ High Cube',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Reefer','40’ Reefer',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Reefer High Cube','40’ Reefer High Cube',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('40’ Open Top ','40’ Open Top ',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('Break Bulk','Break Bulk',1,GETDATE())
INSERT INTO [dbo].[COTIZACION_DIRECTA_ITEMS]([nombre],[descripcion],[activo],[createdate])
     VALUES
           ('Proyecto u otros ','Proyecto u otros ',1,GETDATE())
GO

