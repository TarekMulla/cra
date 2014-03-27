if not exists(select * from sysobjects where object_name(id) = 'COTIZACION_SOLICITUD_COTIZACIONES_LOG')
begin
	create table COTIZACION_SOLICITUD_COTIZACIONES_LOG(
	 ID bigint primary key  not null identity,
	 Idusuario bigint, 
	 IdCotizacionDirecta bigint,
	 fecha datetime,
	 Tipo int,
	 descripcion varchar(40),
	 [createdate] DATETIME default getdate()
	 )
end
go


IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_N_COTIZACION_SOLICITUD_COTIZACIONES_LOG') 
BEGIN
	DROP PROCEDURE [dbo].[SP_N_COTIZACION_SOLICITUD_COTIZACIONES_LOG]
END
GO

Create Procedure [dbo].[SP_N_COTIZACION_SOLICITUD_COTIZACIONES_LOG]
	@Idusuario bigint, 
	 @IdCotizacionDirecta bigint,
	 @fecha datetime,
	 @Tipo int,
	 @descripcion varchar(40),
	 @id bigint OUTPUT
	 
AS
begin
INSERT INTO [dbo].[COTIZACION_SOLICITUD_COTIZACIONES_LOG]
           ([Idusuario]
           ,[IdCotizacionDirecta]
           ,[fecha]
           ,[Tipo]
           ,[descripcion])
     VALUES
           (@Idusuario, 
	 @IdCotizacionDirecta,
	 @fecha,
	 @Tipo,
	 @descripcion)
	 
	select @id = SCOPE_IDENTITY()
	select @id;		
END
GO