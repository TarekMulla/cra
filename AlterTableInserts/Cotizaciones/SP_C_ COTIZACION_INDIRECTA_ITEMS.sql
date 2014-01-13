Create Procedure SP_N_COTIZACION_DIRECTA_OPCIONES
	@IDCotizacion bigint,
	@Fecha datetime = null,
	@FechaValidezInicio datetime = null,
	@FechaValidezFin datetime = null,
	@Naviera varchar(500) = null,
	@TiempoTransito varchar(300) = null,
	@Agente varchar(150) =  NULL,
	@ComentarioCotizacion varchar(500)=null,
	@ComentarioInterno varchar(500) = null,
	@IdEstado bigint = null,
	@numero varchar(100) = null,
	@CreateDate datetime = null,
	@ID bigint OUTPUT
AS
Begin
	SET NOCOUNT ON
	insert into Cotizacion_CotizacionDirecta_Opciones
		( IDCotizacion, Fecha, FechaValidezInicio, FechaValidezFin, Naviera, TiempoTransito, Agente, ComentarioCotizacion, ComentarioInterno, IdEstado, numero, CreateDate)
	values
		(@IDCotizacion,@Fecha,@FechaValidezInicio,@FechaValidezFin,@Naviera,@TiempoTransito,@Agente,@ComentarioCotizacion,@ComentarioInterno,@IdEstado,@numero,@CreateDate)

	select @ID = SCOPE_IDENTITY()
End
Go
