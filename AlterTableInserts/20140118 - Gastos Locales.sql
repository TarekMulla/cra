if  exists(select * from syscolumns where object_name(id) = 'COTIZACION_DIRECTA_GASTOS_LOCALES' )
Begin
	DROP TABLE [dbo].[COTIZACION_DIRECTA_GASTOS_LOCALES]
END
GO

CREATE TABLE [dbo].[COTIZACION_DIRECTA_GASTOS_LOCALES](
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[descripcion] [varchar](70) NULL,
		[monto] [decimal](18, 0) NULL,
		[COTIZACION_SOLICITUD_COTIZACIONES_id] [bigint] NOT NULL,
		[createDate] [datetime] NOT NULL default getdate(),
		CONSTRAINT [PK_COTIZACION_DIRECTA_GASTOS_LOCALES] PRIMARY KEY CLUSTERED ([id] ASC)
		WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[COTIZACION_DIRECTA_GASTOS_LOCALES]  WITH CHECK ADD  CONSTRAINT [fk_COTIZACION_DIRECTA_GASTOS_LOCALES] FOREIGN KEY([COTIZACION_SOLICITUD_COTIZACIONES_id])
	REFERENCES [dbo].[COTIZACION_SOLICITUD_COTIZACIONES] ([id])
GO


insert into COTIZACION_DIRECTA_GASTOS_LOCALES(descripcion,monto,COTIZACION_SOLICITUD_COTIZACIONES_id)
      (select 'Apertura',gastosLocales,id from COTIZACION_SOLICITUD_COTIZACIONES where gastosLocales>0)
GO

if  exists(select * from syscolumns where object_name(id) = 'SP_L_COTIZACION_DIRECTA_GASTOS_LOCALES' )
Begin
	DROP PROCEDURE[dbo].[SP_L_COTIZACION_DIRECTA_GASTOS_LOCALES]
END
GO

CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_GASTOS_LOCALES]                                                                  
     @IdCotizacion bigint                                                                                                       
AS  
BEGIN
	select    *
	from COTIZACION_DIRECTA_GASTOS_LOCALES
	where cotizacion_solicitud_cotizaciones_id = @IdCotizacion 
END
GO

if  exists(select * from syscolumns where object_name(id) = 'SP_N_COTIZACION_DIRECTA_GASTOS_LOCALES' )
Begin
	DROP PROCEDURE[dbo].[SP_N_COTIZACION_DIRECTA_GASTOS_LOCALES]
END
GO


CREATE PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_GASTOS_LOCALES]                                                                  
     @IdCotizacion bigint ,
     @descripcion varchar(70),
     @monto decimal(18,0),
     @id bigint OUTPUT
AS  
BEGIN
	INSERT INTO [dbo].[COTIZACION_DIRECTA_GASTOS_LOCALES]
           ([descripcion]
           ,[monto]
           ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
           )
     VALUES
           (@descripcion
           ,@monto
           ,@IdCotizacion)
	   
select @id = SCOPE_IDENTITY()
select @id;


END
GO

if  exists(select * from syscolumns where object_name(id) = 'SP_E_COTIZACION_DIRECTA_GASTOS_LOCALES_POR_ID_COTIZACION' )
Begin
	DROP PROCEDURE[dbo].[SP_E_COTIZACION_DIRECTA_GASTOS_LOCALES_POR_ID_COTIZACION]
END
GO

CREATE PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_GASTOS_LOCALES_POR_ID_COTIZACION]                                                                  
     @IdCotizacion bigint 
AS  
BEGIN
	delete from [dbo].[COTIZACION_DIRECTA_GASTOS_LOCALES]
           where [COTIZACION_SOLICITUD_COTIZACIONES_id] = @IdCotizacion
END
GO
	