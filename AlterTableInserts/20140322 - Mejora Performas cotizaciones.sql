ALTER  PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_USUARIO]  	
	@idusuario bigint
	,@desde datetime
 AS              
	BEGIN                                                                                                          
		SELECT  CSC.ID as CSC_ID,  
		fechasolicitud,  
		idcliente,  
		idincoterms,  
		proveedorcarga,  
		cotizacion_tipos_id,  
		cotizacion_directa_estados_id,
		USU.id  as usuario_id,
		USU.Nombres as usuario_nombres,
		USU.ApellidoPaterno  as usuario_ApellidoPaterno,
		USU.ApellidoMaterno as usuario_ApellidoMaterno,
		USU.NombreUsuario as usuario_NombreUsuario,
		cliente.Id as cliente_Id,
		cliente.NombreCompania as cliente_NombreCompania,
		cliente.Nombres as cliente_Nombres,
		cliente.ApellidoPaterno as cliente_ApellidoPaterno,
		cliente.ApellidoMaterno as cliente_ApellidoMaterno,
		cliente.NombreFantasia as cliente_NombreFantasia,
		cliente.RUT as cliente_RUT,
		cliente.CodTipo as cliente_CodTipo,
		cliente.FechaCreacion as cliente_FechaCreacion,
		cliente.IdDireccionInfo as cliente_IdDireccionInfo,
		(select top 1 FechaFollowUp from 	CLIENTES_FOLLOW_UP where idCotizacion=CSC.id and fechafollowup>DATEADD(day, -1, getdate()) and activo=1 order by fechafollowup ) as NextFollowUp
		FROM COTIZACION_SOLICITUD_COTIZACIONES CSC  
		INNER  join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
		INNER JOIN USUARIOS USU ON CSC.idUsuario = USU.Id
		inner join CLIENTES_MASTER cliente on csc.idcliente = cliente.id
		where CT.id = 1
		and   CSC.idusuario= @idusuario
		and cotizacion_directa_estados_id<>10
		AND CSC.fechasolicitud>@desde
	end
GO

alter  PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES]  	
	@desde datetime
 AS 
	BEGIN                                                                                                                        
		SELECT  CSC.ID as CSC_ID,  
		fechasolicitud,  
		idcliente,  
		idincoterms,  
		proveedorcarga,  
		cotizacion_tipos_id,  
		cotizacion_directa_estados_id,
		USU.id  as usuario_id,
		USU.Nombres as usuario_nombres,
		USU.ApellidoPaterno  as usuario_ApellidoPaterno,
		USU.ApellidoMaterno as usuario_ApellidoMaterno,
		USU.NombreUsuario as usuario_NombreUsuario,
		cliente.Id as cliente_Id,
		cliente.NombreCompania as cliente_NombreCompania,
		cliente.Nombres as cliente_Nombres,
		cliente.ApellidoPaterno as cliente_ApellidoPaterno,
		cliente.ApellidoMaterno as cliente_ApellidoMaterno,
		cliente.NombreFantasia as cliente_NombreFantasia,
		cliente.RUT as cliente_RUT,
		cliente.CodTipo as cliente_CodTipo,
		cliente.FechaCreacion as cliente_FechaCreacion,
		cliente.IdDireccionInfo as cliente_IdDireccionInfo,
		(select top 1 FechaFollowUp from 	CLIENTES_FOLLOW_UP where idCotizacion=CSC.id and fechafollowup>DATEADD(day, -1, getdate()) and activo=1 order by fechafollowup ) as NextFollowUp
		FROM COTIZACION_SOLICITUD_COTIZACIONES CSC  
		INNER  join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
		INNER JOIN USUARIOS USU ON CSC.idUsuario = USU.Id
		inner join CLIENTES_MASTER cliente on csc.idcliente = cliente.id
		where CT.id = 1 
			AND CSC.fechasolicitud>@desde
	END
	
GO