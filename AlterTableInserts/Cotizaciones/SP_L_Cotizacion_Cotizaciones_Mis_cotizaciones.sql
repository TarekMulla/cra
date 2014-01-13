alter Procedure [dbo].[SP_L_Cotizacion_Cotizaciones_Mis_cotizaciones]
@idUsuario int

AS
Begin
      SET NOCOUNT ON
      
select 
	cc.ID,	idCliente,	cc.IdUsuario,	COTIZACION_TIPOS_id as IdTipoCotizacion,	cc.COTIZACION_ESTADOS_id as cc_IdEstado ,	FechaSolicitud,	PuertoEmbarque,	NombreCliente,	POL,	POD,	NavieraReferencia,
	TarifaReferencia,	Mercaderia,	GastosLocales,	ProveedorCarga,
	ctar.ID as ctar_ID , Ctar.FechaIngreso as fecha, Ctar.FechaValidezInicio ,Ctar.FechaValidezFin ,Ctar.Agente,Ctar.comentario,Ctar.ComentarioInterno ,Ctar.CreateDate ,Ctar.COTIZACION_INDIRECTA_ESTADOS_id as Ctar_IdEstado,  --tarifa
	IdIncoterms, TI.Descripcion as TI_Descripcion  , TI.Codigo as TI_Codigo , TI.Estado as TI_Estado --IncoTerm
	,up.id as idUsuarioPricing, up.NombreUsuario as nombreUsuarioPricing
	from COTIZACION_SOLICITUD_COTIZACIONES cc
	inner join Cotizacion_Estados ce on cc.COTIZACION_ESTADOS_id = ce.ID
	inner join Cotizacion_Tipos ct on cc.COTIZACION_ESTADOS_id = ct.ID
	inner join TIPO_INCOTERMS TI on cc.IdIncoterms = TI.Id
	left outer join COTIZACION_DIRECTA_OPCIONES Ctar on cc.id = Ctar.COTIZACION_SOLICITUD_COTIZACIONES_id
	left outer join usuarios up on cc.idUsuarioPricing= up.id
		where cc.IdUsuario=@idUsuario
End