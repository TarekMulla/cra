Create  PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES]  
@IdCotizacion bigint,
@idusuario bigint
 AS                                                                                                                        
  
  
select CSC.ID as CSC_ID,  
fechasolicitud,  
idcliente,  
idincoterms,  
proveedorcarga,  
cotizacion_tipos_id,  
cotizacion_directa_estados_id--,'C.Tarifas' as C_Tarifas  
 from COTIZACION_SOLICITUD_COTIZACIONES CSC  
inner join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
--inner join COTIZACION_DIRECTA_OPCIONES CDO on CDO.cotizacion_solicitud_cotizaciones_id = CSC.ID  
where CT.id = @IdCotizacion   
and   CSC.idusuario= @idusuario
  