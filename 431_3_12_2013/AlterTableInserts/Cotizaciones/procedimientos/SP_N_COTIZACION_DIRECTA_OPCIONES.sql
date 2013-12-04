CREATE Procedure [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES]
			@numero varchar(45)
           ,@fechaValidezInicio datetime
           ,@fechaValidezFin  datetime
           ,@Naviera bigint
           ,@TiempoTransito varchar(50)
           ,@idUsuario bigint
           ,@COTIZACION_SOLICITUD_COTIZACIONES_id bigint 
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
           ,[COTIZACION_DIRECTA_ESTADOS_id])
        VALUES
           (@numero
           ,@fechaValidezInicio
           ,@fechaValidezFin
           ,@Naviera
           ,@TiempoTransito
           ,@idUsuario
           ,@COTIZACION_SOLICITUD_COTIZACIONES_id
           ,1)


select @id = SCOPE_IDENTITY()
select @id;

END