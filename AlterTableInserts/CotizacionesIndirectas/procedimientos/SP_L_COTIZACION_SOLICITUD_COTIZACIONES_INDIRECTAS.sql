drop procedure SP_L_COTIZACION_SOLICITUD_COTIZACIONES
go
create  PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES]  
        @idTipo bigint,
        @idusuario bigint
AS                                                                                                                        
IF (@idTipo = 1) 
BEGIN
	select CSC.ID as CSC_ID,  
	fechasolicitud,  
	idcliente,  
	idincoterms,  
	proveedorcarga,  
	cotizacion_tipos_id,  
	cotizacion_directa_estados_id--,'C.Tarifas' as C_Tarifas  
	from COTIZACION_SOLICITUD_COTIZACIONES CSC  
	inner join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
	where CT.id = @idTipo   
	and   CSC.idusuario= @idusuario
END
IF (@idTipo = 2)
BEGIN
	select CSC.ID as CSC_ID,  
	fechasolicitud,  
	idcliente,  
	idincoterms,  
	proveedorcarga,  
	@idTipo as cotizacion_tipos_id,  
	cotizacion_indirecta_estados_id as estado_id  
	from COTIZACION_SOLICITUD_COTIZACIONES CSC  
	where CSC.COTIZACION_TIPOS_id = @idTipo   
	and   CSC.idusuario= @idusuario
END
GO