Create Procedure SP_N_COTIZACION_DIRECTA_OPCIONES
	@numero varchar(45) =null,
	@fechaIngreso datetime =null,
	@fechaValidezInicio datetime =null,
	@fechaValidezFin datetime =null,
	@agente varchar(45) =null,
	@naviera varchar(45) =null,
	@comentario varchar(150) =null,
	@comentarioInterno varchar(150) =null,
	@idUsuario bigint =null,
	@createDate datetime=null,
	@COTIZACION_SOLICITUD_COTIZACIONES_id bigint,
	@COTIZACION_INDIRECTA_ESTADOS_id bigint,
	@id bigint OUTPUT
AS
Begin
	SET NOCOUNT ON
	insert into COTIZACION_DIRECTA_OPCIONES
		( numero, fechaIngreso, fechaValidezInicio, fechaValidezFin, agente, naviera, comentario, comentarioInterno, idUsuario, createDate, COTIZACION_SOLICITUD_COTIZACIONES_id,COTIZACION_INDIRECTA_ESTADOS_id)
	values
		(@numero,@fechaIngreso,@fechaValidezInicio,@fechaValidezFin,@agente,@naviera,@comentario,@comentarioInterno,@idUsuario,@createDate,@COTIZACION_SOLICITUD_COTIZACIONES_id,@COTIZACION_INDIRECTA_ESTADOS_id)

	select @id = SCOPE_IDENTITY()
End
Go