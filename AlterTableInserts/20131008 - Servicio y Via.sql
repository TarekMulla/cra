IF EXISTS (SELECT * FROM sysobjects WHERE name='COTIZACION_TIPOS_VIAS') 
BEGIN
	drop TABLE [dbo].[COTIZACION_TIPOS_VIAS]
END
GO

CREATE TABLE [dbo].[COTIZACION_TIPOS_VIAS](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[ACTIVO] bit default 1,
	[createDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[COTIZACION_TIPOS_VIAS] ADD  DEFAULT (getdate()) FOR [createDate]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='COTIZACION_TIPOS_SERVICIO') 
BEGIN
	DROP TABLE [dbo].[COTIZACION_TIPOS_SERVICIO]
END
GO
CREATE TABLE [dbo].[COTIZACION_TIPOS_SERVICIO](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[ACTIVO] bit default 1,
	[createDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[COTIZACION_TIPOS_SERVICIO] ADD  DEFAULT (getdate()) FOR [createDate]
GO


INSERT dbo.COTIZACION_TIPOS_SERVICIO (NOMBRE) VALUES ('Directo')
INSERT dbo.COTIZACION_TIPOS_SERVICIO (NOMBRE) VALUES ('Transbordo')
GO


IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_COTIZACION_TIPOS_SERVICIO') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_COTIZACION_TIPOS_SERVICIO]
END
GO

CREATE Procedure [dbo].[SP_L_COTIZACION_TIPOS_SERVICIO]
AS
Begin
      SET NOCOUNT ON
     SELECT [ID]
      ,[NOMBRE]
      ,[ACTIVO]
  FROM [dbo].[COTIZACION_TIPOS_SERVICIO]
end  
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_COTIZACION_TIPOS_VIAS') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_COTIZACION_TIPOS_VIAS]
END
GO

CREATE Procedure [dbo].[SP_L_COTIZACION_TIPOS_VIAS]
AS
Begin
      SET NOCOUNT ON
     SELECT [ID]
      ,[NOMBRE]
      ,[ACTIVO]
  FROM [dbo].[COTIZACION_TIPOS_VIAS]
end  
GO




IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_CLIENTES_MASTER_TARGET_POR_VENDEDOR') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_CLIENTES_MASTER_TARGET_POR_VENDEDOR]
END
GO

CREATE Procedure [dbo].[SP_L_CLIENTES_MASTER_TARGET_POR_VENDEDOR]
@IdVendedor int
AS
Begin
      SET NOCOUNT ON
	select distinct cm.*
	from CLIENTES_TARGET_ACCOUNT as c,DIRECCION_META as d ,CLIENTES_MASTER as cm,DIRECCION_META_ASIGNACION as asig
	where c.IdTargetSource = d.Id
	and c.idclientemaster= cm.id
	and asig.idmeta =d.id 
	and asig.idvendedorasignado  = @IdVendedor
	and CodTipo=1
end  
GO



insert COTIZACION_TIPOS_VIAS (nombre) values('Busan')
insert COTIZACION_TIPOS_VIAS (nombre) values('Hong Kong')
insert COTIZACION_TIPOS_VIAS (nombre) values('Shanghai')
insert COTIZACION_TIPOS_VIAS (nombre) values('Keelung')
insert COTIZACION_TIPOS_VIAS (nombre) values('Xiamen')
insert COTIZACION_TIPOS_VIAS (nombre) values('Durban')
insert COTIZACION_TIPOS_VIAS (nombre) values('Chiwan')
insert COTIZACION_TIPOS_VIAS (nombre) values('Yokohama')
insert COTIZACION_TIPOS_VIAS (nombre) values('Shekou')
insert COTIZACION_TIPOS_VIAS (nombre) values('Ningbo')
insert COTIZACION_TIPOS_VIAS (nombre) values('Singapore')
insert COTIZACION_TIPOS_VIAS (nombre) values('Manzanillo')
insert COTIZACION_TIPOS_VIAS (nombre) values('Río Grande')
insert COTIZACION_TIPOS_VIAS (nombre) values('Cartagena')
insert COTIZACION_TIPOS_VIAS (nombre) values('Colon')
insert COTIZACION_TIPOS_VIAS (nombre) values('Amberes')
insert COTIZACION_TIPOS_VIAS (nombre) values('Balboa')
insert COTIZACION_TIPOS_VIAS (nombre) values('Callao')
GO



IF NOT  EXISTS (SELECT * FROM sysobjects WHERE name='ID_TIPO_SERVICIO') 
BEGIN 
	ALTER TABLE COTIZACION_DIRECTA_OPCIONES add ID_TIPO_SERVICIO bigint
END 
GO

IF NOT  EXISTS (SELECT * FROM sysobjects WHERE name='ID_TIPO_VIA') 
BEGIN 
	ALTER TABLE COTIZACION_DIRECTA_OPCIONES add ID_TIPO_VIA bigint
END 
GO


IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_N_COTIZACION_DIRECTA_OPCIONES') 
BEGIN
	DROP PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES]
END
GO


CREATE  Procedure [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES]
	     @numero varchar(45)
           ,@fechaValidezInicio datetime
           ,@fechaValidezFin  datetime
           ,@Naviera bigint
           ,@TiempoTransito varchar(50)
           ,@idUsuario bigint
           ,@COTIZACION_SOLICITUD_COTIZACIONES_id bigint 
           ,@idTipoServicio bigint
	   ,@idTipoVia bigint
	   ,@id bigint OUTPUT
AS
BEGIN
INSERT INTO [dbo].[COTIZACION_DIRECTA_OPCIONES]
           ([numero]
           ,[fechaValidezInicio]
           ,[fechaValidezFin]
           ,[Naviera]
           ,[TiempoTransito]
           ,[idUsuario]
           ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
           ,[COTIZACION_DIRECTA_ESTADOS_id]
	   ,ID_TIPO_SERVICIO
	   ,ID_TIPO_VIA
	   )
        VALUES
           (@numero
           ,@fechaValidezInicio
           ,@fechaValidezFin
           ,@Naviera
           ,@TiempoTransito
           ,@idUsuario
           ,@COTIZACION_SOLICITUD_COTIZACIONES_id
           ,1
	   ,@idTipoServicio
	   ,@idTipoVia)


select @id = SCOPE_IDENTITY()
select @id;

END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION]
END
GO

create  PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION]
	@IdCotizacion bigint
AS
BEGIN

SELECT op.[id]
      ,[numero]
      ,[fechaValidezInicio]
      ,[fechaValidezFin]
      ,[Naviera]
      ,[POD]
      ,[POL]
      ,[TiempoTransito]
      ,[idUsuario]
      ,op.[createDate]
      ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
      ,[COTIZACION_DIRECTA_ESTADOS_id]
      ,op.id_tipo_servicio as tipo_servicio_id
      ,Serv.nombre as tipo_servicio_nombre
      ,op.id_tipo_via as tipo_via_id
      ,via.nombre as tipo_via_nombre
  FROM [dbo].[COTIZACION_DIRECTA_OPCIONES] as op
  left outer join COTIZACION_TIPOS_SERVICIO  as Serv on op.id_tipo_servicio=Serv.id
    left outer join COTIZACION_TIPOS_VIAS  as via on op.id_tipo_via=via.id
  where [COTIZACION_SOLICITUD_COTIZACIONES_id] = @IdCotizacion
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_A_COTIZACION_DIRECTA_OPCIONES') 
BEGIN
	DROP PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES]
END
GO

CREATE  PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES]
             @id                                    bigint,        
             @numero                                varchar(45),       
             @fechaValidezInicio                    datetime,        
             @fechaValidezFin                       datetime,        
             @Naviera                               bigint,        
             @TiempoTransito                        varchar(50),       
             @idUsuario                             bigint  
	   ,@idTipoServicio bigint
	   ,@idTipoVia bigint	     
AS
BEGIN
    UPDATE COTIZACION_DIRECTA_OPCIONES
    SET 
        numero=@numero,
        fechaValidezInicio=@fechaValidezInicio,
        fechaValidezFin=@fechaValidezFin,
        Naviera=@Naviera,
        TiempoTransito=@TiempoTransito,
        idUsuario=@idUsuario
	 ,ID_TIPO_SERVICIO = @idTipoServicio
	,ID_TIPO_VIA = @idTipoVia
    WHERE Id=@Id
END
RETURN 0