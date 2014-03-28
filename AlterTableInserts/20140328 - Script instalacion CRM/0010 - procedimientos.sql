/*
Script generado por Aqua Data Studio 9.0.11 en mar-27-2014 10:12:57 PM
Base de datos: scctest
Esquema: dbo
Objetos: PROCEDURE
*/

DROP PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION]
GO
DROP PROCEDURE [dbo].[SP_L_COTIZACION_TIPOS_SERVICIO]
GO
DROP PROCEDURE [dbo].[SP_L_COTIZACION_TIPOS_VIAS]
GO
DROP PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES]
GO
DROP PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES]
GO


CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_ESTADO]                                                                  
     @IdCotizacion bigint,
     @IdEstado bigint
AS
    /*
     1      Ingresado          (sistema) 
     2      En proceso          (sistema)
     3      Tarifa Disponible   (sistema)
     4      Enviada al cliente  (sistema)
     5      Reevaluación        (usuario)
     6      Perdido (tarifa)    (usuario)
     7      Perdido (otros)     (usuario)
     8      Cerrado             (usuario)
     9      Cerrado LCL         (usuario)
    */
                                                                                                                        
    DECLARE @EstadoActualCotizacion bigint

    SELECT @EstadoActualCotizacion = COTIZACION_Directa_ESTADOS_id
    FROM COTIZACION_SOLICITUD_COTIZACIONES
    WHERE Id=@IdCotizacion

    IF @EstadoActualCotizacion NOT IN (6,7,8,9)
    BEGIN
        UPDATE COTIZACION_DIRECTA_OPCIONES
        SET COTIZACION_DIRECTA_ESTADOS_id = @IdEstado
        WHERE COTIZACION_SOLICITUD_COTIZACIONES_id=@IdCotizacion
    
        UPDATE COTIZACION_SOLICITUD_COTIZACIONES
         SET COTIZACION_Directa_ESTADOS_id = @IdEstado
        WHERE Id=@IdCotizacion

        RETURN 0
    END
    ELSE
    BEGIN
        RETURN 1
    END

GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES]
             @id                                    bigint,        
             @numero                                varchar(45),       
             @fechaValidezInicio                    datetime,        
             @fechaValidezFin                       datetime,        
             @Naviera                               bigint,        
             @TiempoTransito                        varchar(50),       
             @idUsuario                             bigint  
	   ,@idTipoServicio bigint
	   ,@idTipoVia bigint	     
AS
BEGIN
    UPDATE COTIZACION_DIRECTA_OPCIONES
    SET 
        numero=@numero,
        fechaValidezInicio=@fechaValidezInicio,
        fechaValidezFin=@fechaValidezFin,
        Naviera=@Naviera,
        TiempoTransito=@TiempoTransito,
        idUsuario=@idUsuario
	 ,ID_TIPO_SERVICIO = @idTipoServicio
	,ID_TIPO_VIA = @idTipoVia
    WHERE Id=@Id
END
RETURN 0
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES_DETALLES]
         @id                              bigint,
         @cantidad                        decimal,
         @costo                           decimal,
         @venta                           decimal(16,1),
         @COTIZACION_MONEDAS_id           bigint,
         @COTIZACION_DIRECTA_ITEMS_id     bigint,
         @COTIZACION_DIRECTA_CONCEPTO_ID  bigint
        AS
BEGIN
    UPDATE COTIZACION_DIRECTA_OPCIONES_DETALLES
    SET 
         cantidad=@cantidad,
         costo=@costo,
         venta=@venta,
         COTIZACION_MONEDAS_id=@COTIZACION_MONEDAS_id,
         COTIZACION_DIRECTA_ITEMS_id=@COTIZACION_DIRECTA_ITEMS_id,
         COTIZACION_DIRECTA_CONCEPTO_ID=@COTIZACION_DIRECTA_CONCEPTO_ID
    WHERE Id=@Id
END

GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES_PUERTOS]
                 @id                              bigint,
                 @puerto                          varchar(10),
                 @tipo                            varchar(5)
        AS
BEGIN
    UPDATE COTIZACION_DIRECTA_OPCIONES_PUERTOS
    SET 
         puerto=@puerto,
         tipo=@tipo                            
    WHERE Id=@Id
END
RETURN 0


GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_SOLICITUD_COTIZACIONES]
         @id                               bigint,   
         @producto                         varchar(20),  
         @idUsuario                        bigint,   
         @idCliente                        bigint,   
         @nombreCliente                    varchar(45),  
         @fechaSolicitud                   datetime, 
         @idIncoterms                      bigint,   
         @commodity                        varchar(60),
         @puertoEmbarque                   varchar(100),
         @navieraReferencia                varchar(45),
         @tarifaReferencia                 varchar(45),
         @Observaciones                    varchar(500),
         @mercaderia                       varchar(45),
         @gastosLocales                    decimal,  
         @proveedorCarga                   varchar(45),  
         @credito                          varchar(45),   
         @fechaEstimadaEmbarque            varchar(45),   
         @conAgenciamento                  bit
AS
BEGIN
    UPDATE COTIZACION_SOLICITUD_COTIZACIONES
    SET 
         producto=@producto,  
         idUsuario=@idUsuario,   
         idCliente=@idCliente,   
         nombreCliente=@nombreCliente,  
         fechaSolicitud=@fechaSolicitud, 
         idIncoterms=@idIncoterms,   
         commodity=@commodity,
         puertoEmbarque=@puertoEmbarque,
         navieraReferencia=@navieraReferencia,
         tarifaReferencia=@tarifaReferencia,
         Observaciones=@Observaciones,
         mercaderia=@mercaderia,
         gastosLocales=@gastosLocales,  
         proveedorCarga=@proveedorCarga,  
         credito=@credito,   
         fechaEstimadaEmbarque=@fechaEstimadaEmbarque,   
         conAgenciamento=@conAgenciamento
    WHERE Id=@Id
END
RETURN 0


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
CREATE PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_GASTOS_LOCALES_POR_ID_COTIZACION]                                                                  
     @IdCotizacion bigint 
AS  
BEGIN
	delete from [dbo].[COTIZACION_DIRECTA_GASTOS_LOCALES]
           where [COTIZACION_SOLICITUD_COTIZACIONES_id] = @IdCotizacion
END

GO
CREATE PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES]  	
	@id bigint
 AS              
	BEGIN                                                                  
		/*DELETE FROM COTIZACION_DIRECTA_OPCIONES_DETALLES where COTIZACION_DIRECTA_OPCIONES_id = @id
		DELETE FROM COTIZACION_DIRECTA_OPCIONES_PUERTOS where cotizacion_directa_opciones_id=@id
		DELETE FROM COTIZACION_DIRECTA_OPCIONES WHERE id=@id */
		UPDATE  COTIZACION_DIRECTA_OPCIONES SET ACTIVO=0 WHERE  id=@id
	end

GO
CREATE PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_OPCION]                                                                  
     @id_opcion bigint                                                                                                       
AS  
                                                                                                                        
begin                                                                                                                           
	DELETE  from  COTIZACION_DIRECTA_OPCIONES_DETALLES where COTIZACION_DIRECTA_OPCIONES_id=@id_opcion
END

GO
CREATE PROCEDURE [dbo].[SP_E_COTIZACION_DIRECTA_OPCIONES_PUERTOS]                                                                  
     @id_opcion bigint                                                                                                       
AS  
                                                                                                                        
begin                                                                                                                           
	DELETE  from   COTIZACION_DIRECTA_OPCIONES_PUERTOS where cotizacion_directa_opciones_id=@id_opcion
END

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_COMENTARIOS]
		 @idOpcion_o_Cotizacion bigint
as
begin
       SELECT [id]
      ,[fecha]
      ,[EsHistorial]
      ,[Comentario]
      ,[idUsuario]
      ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
      ,[CreateDate]
  FROM [dbo].[COTIZACION_COMENTARIOS]
  WHERE COTIZACION_SOLICITUD_COTIZACIONES_id =@idOpcion_o_Cotizacion;
end

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_COMENTARIOS]
		 @idOpcion_o_Cotizacion bigint
as
begin
       SELECT [id]
      ,[fecha]
      ,[EsHistorial]
      ,[Comentario]
      ,[idUsuario]
      ,[COTIZACION_DIRECTA_OPCIONES_id]
      ,[CreateDate]
  FROM [dbo].[COTIZACION_DIRECTA_COMENTARIOS]
  WHERE COTIZACION_DIRECTA_OPCIONES_id = @idOpcion_o_Cotizacion;
end

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_CONCEPTOS]
AS
Begin
      SET NOCOUNT ON
     SELECT [ID]
      ,[NOMBRE]
      ,[DESCRIPCION]
      ,[ACTIVO]
  FROM [dbo].[COTIZACION_DIRECTA_CONCEPTOS]
end  


GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_ESTADOS]      
 AS                                                            
 Begin                                                         
       SET NOCOUNT ON                                          
       select id,nombre,activo from COTIZACION_DIRECTA_ESTADOS 
 end                                                           



GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_GASTOS_LOCALES]                                                                  
     @IdCotizacion bigint                                                                                                       
AS  
BEGIN
	select    *
	from COTIZACION_DIRECTA_GASTOS_LOCALES
	where cotizacion_solicitud_cotizaciones_id = @IdCotizacion 
END

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_ITEMS]
AS
Begin
      SET NOCOUNT ON
	  SELECT [id],[nombre],[descripcion] ,[activo]
	  FROM [dbo].[COTIZACION_DIRECTA_ITEMS]
end  


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
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_ID_OPCION]
		 @idOpcion bigint
as
begin
             select a.*,b.codigo as monedaCodigo,b.nombre as monedaNombre
            ,c.NOMBRE as conceptoNombre,c.DESCRIPCION as conceptoDescripcion
            ,d.nombre as detalleNombre,d.descripcion as detalleDescripcion
    from 
    COTIZACION_DIRECTA_OPCIONES_DETALLES as a
    , COTIZACION_MONEDAS b
    , COTIZACION_DIRECTA_CONCEPTOS c
    ,COTIZACION_DIRECTA_ITEMS d
    where a.COTIZACION_MONEDAS_id = b.id
    and a.COTIZACION_DIRECTA_CONCEPTO_ID =c.ID
    and a.COTIZACION_DIRECTA_ITEMS_id = d.id
    and a.COTIZACION_DIRECTA_OPCIONES_id  = @idOpcion
end

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION]
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
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_OPCIONES_PUERTOS_POR_ID_OPCION]
    @idOpcion bigint
as 
begin
    select a.id,a.puerto,a.tipo,b.nombre
from 
dbo.COTIZACION_DIRECTA_OPCIONES_PUERTOS as a,Puertos as b
where b.codigo = a.puerto
and cotizacion_directa_opciones_id = @idOpcion
end

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES]  	
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
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_ID]
	@ID bigint 
AS
BEGIN

SELECT [id]
      ,[producto]
      ,[idUsuario]
      ,[idCliente]
      ,[idTarget]
      ,[nombreCliente]
      ,[fechaSolicitud]
      ,[idIncoterms]
      ,[commodity]
      ,[puertoEmbarque]
      ,[POL]
      ,[POD]
      ,[navieraReferencia]
      ,[tarifaReferencia]
      ,[ObservacionesFijas]
      ,[Observaciones]
      ,[mercaderia]
      ,[gastosLocales]
      ,[proveedorCarga]
      ,[credito]
      ,[fechaEstimadaEmbarque]
      ,[conAgenciamento]
      ,[createDate]
      ,[COTIZACION_TIPOS_TRANSBORDOS_id]
      ,[COTIZACION_Directa_ESTADOS_id]
      ,[COTIZACION_TIPOS_id]
      ,[copiadode]
  FROM [dbo].[COTIZACION_SOLICITUD_COTIZACIONES]
  WHERE ID=@ID
END

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_USUARIO]  	
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
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_TIPOS]
AS
Begin
      SET NOCOUNT ON
      select id,nombre from COTIZACION_TIPOS
end  
GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_TIPOS_SERVICIO]
AS
Begin
      SET NOCOUNT ON
     SELECT [ID]
      ,[NOMBRE]
      ,[ACTIVO]
  FROM [dbo].[COTIZACION_TIPOS_SERVICIO]
end  

GO
CREATE PROCEDURE [dbo].[SP_L_COTIZACION_TIPOS_VIAS]
AS
Begin
      SET NOCOUNT ON
     SELECT [ID]
      ,[NOMBRE]
      ,[ACTIVO]
  FROM [dbo].[COTIZACION_TIPOS_VIAS]
end  

GO
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_COMENTARIOS]
		@EsHistorial bit = null 
           ,@Comentario varchar	(500) =null
           ,@idUsuario bigint  =null
           ,@idOpcion_o_Cotizacion bigint  =null
           ,@id bigint OUTPUT
as 
begin

INSERT INTO [dbo].[COTIZACION_COMENTARIOS]
           ([fecha]
           ,[EsHistorial]
           ,[Comentario]
           ,[idUsuario]
           ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
           ,[CreateDate])
     VALUES
           (getdate()
           ,@EsHistorial
           ,@comentario
           ,@idUsuario
           ,@idOpcion_o_Cotizacion
           ,getdate())
	
	select @id = SCOPE_IDENTITY()
	select @id;
end
GO
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_COMENTARIOS]
    @EsHistorial bit = null 
           ,@Comentario varchar (500) =null
           ,@idUsuario bigint  =null
           ,@idOpcion_o_Cotizacion bigint  =null
           ,@id bigint OUTPUT
as 
begin

INSERT INTO [dbo].[COTIZACION_DIRECTA_COMENTARIOS]
           ([fecha]
           ,[EsHistorial]
           ,[Comentario]
           ,[idUsuario]
           ,[COTIZACION_DIRECTA_OPCIONES_id]
           ,[CreateDate])
     VALUES
           (getdate()
           ,@EsHistorial
           ,@comentario
           ,@idUsuario
           ,@idOpcion_o_Cotizacion
           ,getdate())
  
  select @id = SCOPE_IDENTITY()
  select @id;
end
GO
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_GASTOS_LOCALES]                                                                  
     @IdCotizacion bigint ,
     @descripcion varchar(70),
     @monto decimal(18,0),
     @id bigint OUTPUT
AS  
BEGIN
	INSERT INTO [dbo].[COTIZACION_DIRECTA_GASTOS_LOCALES]
           ([descripcion]
           ,[monto]
           ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
           )
     VALUES
           (@descripcion
           ,@monto
           ,@IdCotizacion)
	   
select @id = SCOPE_IDENTITY()
select @id;


END

GO
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES]
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
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES_DETALLES]
			@cantidad decimal(10,6)
           ,@costo decimal(10,6)
           ,@venta decimal(16,6)
           ,@COTIZACION_MONEDAS_id bigint
           ,@COTIZACION_DIRECTA_ITEMS_id bigint
           ,@COTIZACION_DIRECTA_OPCIONES_id bigint
           ,@COTIZACION_DIRECTA_CONCEPTO_ID bigint
           ,@id bigint OUTPUT
as
begin
INSERT INTO [dbo].[COTIZACION_DIRECTA_OPCIONES_DETALLES]
           ([cantidad]
           ,[costo]
           ,[venta]
           ,[COTIZACION_MONEDAS_id]
           ,[COTIZACION_DIRECTA_ITEMS_id]
           ,[COTIZACION_DIRECTA_OPCIONES_id]
           ,[COTIZACION_DIRECTA_CONCEPTO_ID]
           ,[CreateDate])
     VALUES
           (@cantidad
           ,@costo
           ,@venta
           ,@COTIZACION_MONEDAS_id
           ,@COTIZACION_DIRECTA_ITEMS_id
           ,@COTIZACION_DIRECTA_OPCIONES_id
           ,@COTIZACION_DIRECTA_CONCEPTO_ID
           ,getdate())

select @id = SCOPE_IDENTITY()
select @id;

end

GO
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES_PUERTOS]
      @puerto varchar(10) 
           ,@cotizacion_directa_opciones_id bigint 
           ,@tipo varchar(5)
           ,@id bigint OUTPUT
as 
begin
INSERT INTO .[dbo].[COTIZACION_DIRECTA_OPCIONES_PUERTOS]
           ([puerto]
           ,[cotizacion_directa_opciones_id]
           ,[tipo])
     VALUES
           (@puerto
           ,@cotizacion_directa_opciones_id
           ,@tipo)

select @id = SCOPE_IDENTITY()
select @id;
end


GO
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_SOLICITUD_COTIZACIONES]
			@producto varchar(20) = null 
           ,@idUsuario bigint =null
           ,@idCliente bigint  =null
           ,@idTarget bigint =null
           ,@nombreCliente varchar(45) = null 
           ,@fechaSolicitud datetime = null
           ,@idIncoterms bigint = null 
           ,@commodity varchar(60) =null 
           ,@puertoEmbarque varchar(100) =null
           ,@POL varchar(10) =null
           ,@POD varchar(10) =null	
           ,@navieraReferencia varchar(45) = null 
           ,@tarifaReferencia varchar(45) = null
           ,@ObservacionesFijas varchar(500) = null
           ,@Observaciones varchar(500) =null
           ,@mercaderia varchar(45) =null
           ,@gastosLocales decimal(18,0) =null
           ,@proveedorCarga varchar(45) =null
           ,@credito varchar(45) =null
           ,@fechaEstimadaEmbarque varchar(45) =null
           ,@conAgenciamento bit =null
           ,@createDate datetime =null
           ,@COTIZACION_TIPOS_TRANSBORDOS_id bigint = null 
           ,@COTIZACION_Directa_ESTADOS_id bigint =null
	   ,@COTIZACION_Indirecta_ESTADOS_id bigint =null
	   ,@COTIZACION_TIPOS_id bigint = null
	   ,@CopiadoDe bigint = null
           ,@id bigint OUTPUT
as
begin

INSERT INTO [dbo].[COTIZACION_SOLICITUD_COTIZACIONES]
           ([producto]
           ,[idUsuario]
           ,[idCliente]
           ,[idTarget]
           ,[nombreCliente]
           ,[fechaSolicitud]
           ,[idIncoterms]
           ,[commodity]
           ,[puertoEmbarque]
           ,[POL]
           ,[POD]
           ,[navieraReferencia]
           ,[tarifaReferencia]
           ,[ObservacionesFijas]
           ,[Observaciones]
           ,[mercaderia]
           ,[gastosLocales]
           ,[proveedorCarga]
           ,[credito]
           ,[fechaEstimadaEmbarque]
           ,[conAgenciamento]
           ,[createDate]
           ,[COTIZACION_TIPOS_TRANSBORDOS_id]
           ,[COTIZACION_Directa_ESTADOS_id]
           ,[COTIZACION_TIPOS_id]
	   ,[CopiadoDe])
     VALUES
           (@producto
           ,@idUsuario
           ,@idCliente
           ,@idTarget
           ,@nombreCliente
           ,@fechaSolicitud
           ,@idIncoterms
           ,@commodity
           ,@puertoEmbarque
           ,@POL
           ,@POD
           ,@navieraReferencia
           ,@tarifaReferencia
           ,@ObservacionesFijas
           ,@Observaciones
           ,@mercaderia
           ,@gastosLocales
           ,@proveedorCarga
           ,@credito
           ,@fechaEstimadaEmbarque
           ,@conAgenciamento
           ,getdate()
           ,@COTIZACION_TIPOS_TRANSBORDOS_id
           ,@COTIZACION_Directa_ESTADOS_id
           ,@COTIZACION_TIPOS_id
	   ,@CopiadoDe)

select @id = SCOPE_IDENTITY()
select @id

end

GO
CREATE PROCEDURE [dbo].[SP_N_COTIZACION_SOLICITUD_COTIZACIONES_LOG]
	@Idusuario bigint, 
	 @IdCotizacionDirecta bigint,
	 @fecha datetime,
	 @Tipo int,
	 @descripcion varchar(40),
	 @id bigint OUTPUT
	 
AS
begin
INSERT INTO [dbo].[COTIZACION_SOLICITUD_COTIZACIONES_LOG]
           ([Idusuario]
           ,[IdCotizacionDirecta]
           ,[fecha]
           ,[Tipo]
           ,[descripcion])
     VALUES
           (@Idusuario, 
	 @IdCotizacionDirecta,
	 @fecha,
	 @Tipo,
	 @descripcion)
	 
	select @id = SCOPE_IDENTITY()
	select @id;		
END

GO

