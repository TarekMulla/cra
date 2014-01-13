drop Procedure SP_N_COTIZACION_DIRECTA_OPCIONES
go
Create Procedure SP_N_COTIZACION_DIRECTA_OPCIONES
	 @numero VARCHAR(45),  
	 @fechaValidezInicio DATETIME,
	 @fechaValidezFin DATETIME,
	 @Naviera BIGINT,
	 @pickup VARCHAR(100),
	 @POD VARCHAR(50),
	 @POL VARCHAR(50) , 
	 @TiempoTransbordo VARCHAR(50),
	 @idUsuario BIGINT,
	 @agente VARCHAR(150),
	 @COTIZACION_TIPOS_TRANSBORDOS_id BIGINT	,	
	 @COTIZACION_SOLICITUD_COTIZACIONES_id BIGINT,
	 @COTIZACION_INDIRECTA_ESTADOS_id BIGINT ,
	 @COTIZACION_INDIRECTA_TARIFAS_COPIADA_DE BIGINT	,
	 @Observaciones varchar (500),
	 @ObservacionesFijas varchar (500)
	 ,@id bigint OUTPUT
AS
BEGIN

Insert into COTIZACION_INDIRECTA_OPCIONES  
values 
(
@numero, 
@fechaValidezInicio, 
@fechaValidezFin, 
@Naviera, 
@pickup, 
@POD, 
@POL, 
@TiempoTransbordo, 
@idUsuario ,
@agente ,
@COTIZACION_TIPOS_TRANSBORDOS_id ,
GETDATE(),
@COTIZACION_SOLICITUD_COTIZACIONES_id ,
@COTIZACION_INDIRECTA_ESTADOS_id ,
@COTIZACION_INDIRECTA_TARIFAS_COPIADA_DE ,
@Observaciones ,
@ObservacionesFijas 
)

select @id = SCOPE_IDENTITY()
select @id;

END