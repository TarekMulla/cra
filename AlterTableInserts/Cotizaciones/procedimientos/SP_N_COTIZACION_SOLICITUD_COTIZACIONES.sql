CREATE Procedure [dbo].[SP_N_COTIZACION_SOLICITUD_COTIZACIONES]
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
           ,@COTIZACION_TIPOS_id bigint = null
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
           ,[COTIZACION_TIPOS_id])
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
           ,@COTIZACION_TIPOS_id)

select @id = SCOPE_IDENTITY()
select @id;
end