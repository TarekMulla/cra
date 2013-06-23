create PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES]
@IdCotizacion bigint                                                                                                      
 AS                                                                                                                      

select id,numero,fechavalidezinicio,fechavalidezfin,naviera,pod,pol,tiempotransito,
idusuario,createdate,cotizacion_solicitud_cotizaciones_id,cotizacion_directa_estados_id
 from COTIZACION_DIRECTA_OPCIONES
 where cotizacion_solicitud_cotizaciones_id = @IdCotizacion