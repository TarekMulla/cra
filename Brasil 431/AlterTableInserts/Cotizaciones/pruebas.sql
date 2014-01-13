begin 
declare @id bigint
select @id=28;
select * from COTIZACION_SOLICITUD_COTIZACIONES where id=@id
select * from COTIZACION_DIRECTA_OPCIONES where COTIZACION_SOLICITUD_COTIZACIONES_id= @id
select * from COTIZACION_DIRECTA_OPCIONES_PUERTOS where cotizacion_directa_opciones_id in (
	select id from COTIZACION_DIRECTA_OPCIONES where COTIZACION_SOLICITUD_COTIZACIONES_id= @id
)

select * from COTIZACION_DIRECTA_OPCIONES_DETALLES where cotizacion_directa_opciones_id in (
	select id from COTIZACION_DIRECTA_OPCIONES where COTIZACION_SOLICITUD_COTIZACIONES_id= @id
)

--proximanete los comentarios
select * from COTIZACION_COMENTARIOS where COTIZACION_SOLICITUD_COTIZACIONES_id=@id
select * from COTIZACION_DIRECTA_COMENTARIOS where COTIZACION_DIRECTA_OPCIONES_id=(
  select id from COTIZACION_DIRECTA_OPCIONES where COTIZACION_SOLICITUD_COTIZACIONES_id= @id
)
end 