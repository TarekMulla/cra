create PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES]                                                                  
     @IdCotizacion bigint                                                                                                       
AS  
                                                                                                                        
                                                                                                                            
select 
   
       a.id,
        numero,
        fechavalidezinicio,
        fechavalidezfin,
        naviera,
        pod,
        pol,
        tiempotransito,                                        
        idusuario,
        a.createdate,
        cotizacion_solicitud_cotizaciones_id,
        cotizacion_directa_estados_id as 'Estado',
        b.nombre as 'EstadoDescripcion'
  from COTIZACION_DIRECTA_OPCIONES A INNER JOIN COTIZACION_DIRECTA_ESTADOS B
            ON cotizacion_directa_estados_id=B.id
  where cotizacion_solicitud_cotizaciones_id = @IdCotizacion 