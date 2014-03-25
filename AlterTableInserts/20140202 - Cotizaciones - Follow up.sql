if not exists(select * from syscolumns where object_name(id) = 'CLIENTES_FOLLOW_UP' and name = 'idCotizacion')
Begin
		alter table  CLIENTES_FOLLOW_UP add  idCotizacion bigint  
	
END
GO


if  exists(SELECT * FROM sys.objects WHERE name = 'SP_C_CLIENTES_FOLLOW_UP_POR_IDCOTIZACION' )
Begin
	DROP PROCEDURE[dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDCOTIZACION]
END
GO

CREATE PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDCOTIZACION]
	@idCotizacion bigint
AS
begin
	SELECT 
	A.Id,
	FechaFollowUp ,
	B.Id IdActividad,
	B.Descripcion Actividad,
	B.Alias Alias,
	A.Descripcion,
	A.FechaCreacion,
	C.Id IdUsuario,
	C.Nombres,
	C.ApellidoPaterno,
	C.ApellidoMaterno,
	A.IdClienteMaster,
	A.IdLlamadaTelefonica,
	A.IdInformeVisita,
	A.idtarget,
	A.activo ,
	A.idCotizacion
	FROM CLIENTES_FOLLOW_UP A
	LEFT OUTER JOIN VENTAS_TIPO_ACTIVIDAD B
	ON A.IdTipoActividadSiguiente = B.Id
	INNER JOIN USUARIOS C
	ON A.IdUsuario = C.Id
	WHERE A.idCotizacion = @idCotizacion
end
GO

if  exists(SELECT * FROM sys.objects WHERE name = 'SP_N_CLIENTES_FOLLOW_UP' )
Begin
	DROP PROCEDURE[dbo].[SP_N_CLIENTES_FOLLOW_UP]
END
GO


CREATE PROCEDURE [dbo].[SP_N_CLIENTES_FOLLOW_UP]
@IdInformeVisita bigint,
@IdLlamadaTelefonica bigint,
@FechaFollowUp datetime,
@IdTipoActividadSiguiente int,
@IdClienteMaster bigint,
@Descripcion nvarchar(4000),
@FechaCreacion datetime,
@IdUsuario int,
@IdTarget bigint,
@activo bit,
@idSlead int,
@idCotizacion bigint,
 @id bigint OUTPUT
AS
begin
	IF @IdInformeVisita = -1 SET @IdInformeVisita = NULL
	IF @IdLlamadaTelefonica = -1 SET @IdLlamadaTelefonica= NULL
	IF @IdTarget = -1 SET @IdTarget = NULL
	IF @idSlead  = -1 set @idSlead  = NULL
	IF @idCotizacion  = -1 set @idCotizacion  = NULL

	IF @IdClienteMaster = -1 SET @IdClienteMaster = NULL
	IF @IdTipoActividadSiguiente = -1 SET @IdTipoActividadSiguiente = NULL

	INSERT INTO CLIENTES_FOLLOW_UP(IdInformeVisita,IdLlamadaTelefonica,FechaFollowUp,IdTipoActividadSiguiente,
								   IdClienteMaster,Descripcion,FechaCreacion,IdUsuario,idtarget,activo,idSLead,idCotizacion)
	VALUES(
	@IdInformeVisita,@IdLlamadaTelefonica,@FechaFollowUp,@IdTipoActividadSiguiente,
	@IdClienteMaster,@Descripcion,@FechaCreacion,@IdUsuario,@idtarget,@activo,@idSLead,@idCotizacion
	)
	select @id = SCOPE_IDENTITY()
	select @id
end
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
		, (select top 1 FechaFollowUp from 	CLIENTES_FOLLOW_UP where idCotizacion=CSC.id and fechafollowup>DATEADD(day, -1, getdate()) and activo=1 order by fechafollowup ) as NextFollowUp
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
		, (select top 1 FechaFollowUp from 	CLIENTES_FOLLOW_UP where idCotizacion=CSC.id and fechafollowup>DATEADD(day, -1, getdate()) and activo=1 order by fechafollowup ) as NextFollowUp
		FROM COTIZACION_SOLICITUD_COTIZACIONES CSC  
		INNER  join COTIZACION_TIPOS CT on CT.id=CSC.cotizacion_tipos_id  
		INNER JOIN USUARIOS USU ON CSC.idUsuario = USU.Id
		where CT.id = 1 
			AND CSC.fechasolicitud>@desde
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
