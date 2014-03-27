if not exists (select * from COTIZACION_DIRECTA_ESTADOS where [id]=10 )
Begin
	INSERT INTO [dbo].[COTIZACION_DIRECTA_ESTADOS] ([nombre],[activo],[createdate])VALUES('Cancelado',1,getdate())
End
GO

if  exists(SELECT * FROM sys.objects WHERE name = 'SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_USUARIO' )
Begin
	DROP PROCEDURE[dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_USUARIO]
END
GO

Create  PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_USUARIO]  	
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
		USU.NombreUsuario as usuario_NombreUsuario
		
		FROM COTIZACION_SOLICITUD_COTIZACIONES CSC  
		INNER  join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
		INNER JOIN USUARIOS USU ON CSC.idUsuario = USU.Id
		where CT.id = 1
		and   CSC.idusuario= @idusuario
		and cotizacion_directa_estados_id<>10
		AND CSC.fechasolicitud>@desde
	end
GO 

if  exists(SELECT * FROM sys.objects WHERE name = 'SP_L_COTIZACION_SOLICITUD_COTIZACIONES' )
Begin
	DROP PROCEDURE[dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES]
END
GO

Create  PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES]  	
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
		USU.NombreUsuario as usuario_NombreUsuario
		
		FROM COTIZACION_SOLICITUD_COTIZACIONES CSC  
		INNER  join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
		INNER JOIN USUARIOS USU ON CSC.idUsuario = USU.Id
		where CT.id = 1 
			AND CSC.fechasolicitud>@desde
	END
GO 

if not exists(select * from syscolumns where object_name(id) = 'COTIZACION_DIRECTA_OPCIONES' and name = 'ACTIVO')
Begin
		alter table  COTIZACION_DIRECTA_OPCIONES add  ACTIVO BIT  
	
END
GO
UPDATE  COTIZACION_DIRECTA_OPCIONES SET ACTIVO=1


if  exists(SELECT * FROM sys.objects WHERE name = 'SP_E_COTIZACION_DIRECTA_OPCIONES' )
Begin
	DROP PROCEDURE[dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES]
END
GO

Create  PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES]  	
	@id bigint
 AS              
	BEGIN                                                                  
		/*DELETE FROM COTIZACION_DIRECTA_OPCIONES_DETALLES where COTIZACION_DIRECTA_OPCIONES_id = @id
		DELETE FROM COTIZACION_DIRECTA_OPCIONES_PUERTOS where cotizacion_directa_opciones_id=@id
		DELETE FROM COTIZACION_DIRECTA_OPCIONES WHERE id=@id */
		UPDATE  COTIZACION_DIRECTA_OPCIONES SET ACTIVO=0 WHERE  id=@id
	end
GO 




if  exists(SELECT * FROM sys.objects WHERE name = 'SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION' )
Begin
	DROP PROCEDURE[dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION]
END
GO

create  PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION]
	@IdCotizacion bigint
AS
BEGIN

SELECT op.[id]
      ,[numero]
      ,[fechaValidezInicio]
      ,[fechaValidezFin]
      ,[Naviera]
      ,[POD]
      ,[POL]
      ,[TiempoTransito]
      ,[idUsuario]
      ,op.[createDate]
      ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
      ,[COTIZACION_DIRECTA_ESTADOS_id]
      ,op.id_tipo_servicio as tipo_servicio_id
      ,Serv.nombre as tipo_servicio_nombre
      ,op.id_tipo_via as tipo_via_id
      ,via.nombre as tipo_via_nombre
  FROM [dbo].[COTIZACION_DIRECTA_OPCIONES] as op
  left outer join COTIZACION_TIPOS_SERVICIO  as Serv on op.id_tipo_servicio=Serv.id
    left outer join COTIZACION_TIPOS_VIAS  as via on op.id_tipo_via=via.id
  where [COTIZACION_SOLICITUD_COTIZACIONES_id] = @IdCotizacion
  and op.activo=1
END
GO


if  exists(SELECT * FROM sys.objects WHERE name = 'SP_L_COTIZACION_DIRECTA_OPCIONES' )
Begin
	DROP PROCEDURE[dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES]
END
GO


CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES]                                                                  
     @IdCotizacion bigint                                                                                                       
AS  
                                                                                                                        
begin                                                                                                                           
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
	  and a.activo=1
END
GO

if  exists(SELECT * FROM sys.objects WHERE name = 'SP_E_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_OPCION' )
Begin
	DROP PROCEDURE[dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_OPCION]
END
GO


CREATE PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_OPCION]                                                                  
     @id_opcion bigint                                                                                                       
AS  
                                                                                                                        
begin                                                                                                                           
	DELETE  from  COTIZACION_DIRECTA_OPCIONES_DETALLES where COTIZACION_DIRECTA_OPCIONES_id=@id_opcion
END
GO



if  exists(SELECT * FROM sys.objects WHERE name = 'SP_E_COTIZACION_DIRECTA_OPCIONES_PUERTOS' )
Begin
	DROP PROCEDURE[dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES_PUERTOS]
END
GO


CREATE PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES_PUERTOS]                                                                  
     @id_opcion bigint                                                                                                       
AS  
                                                                                                                        
begin                                                                                                                           
	DELETE  from   COTIZACION_DIRECTA_OPCIONES_PUERTOS where cotizacion_directa_opciones_id=@id_opcion
END
GO

ALTER Procedure [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES]
	     @numero varchar(45)
           ,@fechaValidezInicio datetime
           ,@fechaValidezFin  datetime
           ,@Naviera bigint
           ,@TiempoTransito varchar(50)
           ,@idUsuario bigint
           ,@COTIZACION_SOLICITUD_COTIZACIONES_id bigint 
           ,@idTipoServicio bigint
	   ,@idTipoVia bigint
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
           ,[COTIZACION_DIRECTA_ESTADOS_id]
	   ,ID_TIPO_SERVICIO
	   ,ID_TIPO_VIA
	   ,activo
	   )
        VALUES
           (@numero
           ,@fechaValidezInicio
           ,@fechaValidezFin
           ,@Naviera
           ,@TiempoTransito
           ,@idUsuario
           ,@COTIZACION_SOLICITUD_COTIZACIONES_id
           ,1
	   ,@idTipoServicio
	   ,@idTipoVia
	   ,1)


select @id = SCOPE_IDENTITY()
select @id;
end
GO


/*
		SELECT  COT.ID as cot_id,  
		COT.fechasolicitud, as cot_ fechasolicitud,
		COT.idcliente as cot_idcliente,  
		COT.idincoterms as cot_idincoterms,  
		COT.proveedorcarga as cot_proveedorcarga,  
		COT.cotizacion_tipos_id as cot_cotizacion_tipos_id,  
		COT.cotizacion_directa_estados_id as cot_cotizacion_directa_estados_id ,
		USU.id  as usuario_id,
		USU.Nombres as usuario_nombres,
		USU.ApellidoPaterno  as usuario_ApellidoPaterno,
		USU.ApellidoMaterno as usuario_ApellidoMaterno,
		USU.NombreUsuario as usuario_NombreUsuario,
		OP.id as op_id,
		OP.numero as op_numero,
		OP.fechavalidezinicio as op_fechavalidezinicio,
		OP.fechavalidezfin as op_fechavalidezfin,
		op.naviera as op_naviera,
		op.pod as op_pod,
		op.pol as op_pol,
		op.tiempotransito as op_tiempotransito,
		op.idusuario as op_idusuario,
		op.createdate as op_createdate
		FROM COTIZACION_SOLICITUD_COTIZACIONES COT  
		INNER JOIN COTIZACION_DIRECTA_OPCIONES OP  ON  CSC.id = OP.COTIZACION_SOLICITUD_COTIZACIONES_id
		INNER  join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
		INNER JOIN USUARIOS USU ON CSC.idUsuario = USU.Id
*/