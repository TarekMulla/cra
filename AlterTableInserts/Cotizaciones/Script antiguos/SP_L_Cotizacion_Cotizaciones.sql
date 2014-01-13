ALTER Procedure [dbo].[SP_L_Cotizacion_Cotizaciones]
@idUsuario int

AS
Begin
      SET NOCOUNT ON
      
      
if (@idUsuario is not null)
begin      
	select 
	cc.ID,	idCliente,	IdUsuario,	IdTipoCotizacin,	cc.IdEstado as cc_IdEstado ,	FechaSolicitud,	PuertoEmbarque,	NombreCliente,	POL,	POD,	NavieraReferencia,
	TarifaReferencia,	Mercaderia,	GastosLocales,	ProveedorCarga,
	ctar.ID as ctar_ID , Ctar.Fecha, Ctar.FechaValidezInicio ,Ctar.FechaValidezFin ,Ctar.Agente,Ctar.ComentarioCotizacion,Ctar.ComentarioInterno ,Ctar.CreateDate ,Ctar.IdEstado as Ctar_IdEstado,  --tarifa
	IdIncoterm, TI.Descripcion as TI_Descripcion  , TI.Codigo as TI_Codigo , TI.Estado as TI_Estado --IncoTerm
	,up.id as idUsuarioPricing, up.NombreUsuario as nombreUsuarioPricing
	from Cotizacion_Cotizaciones cc
	inner join Cotizacion_Estados ce on cc.IdEstado = ce.ID
	inner join Cotizacion_Tipos ct on cc.IdTipoCotizacin = ct.ID
	inner join TIPO_INCOTERMS TI on cc.IdIncoterm = TI.Id
	left outer join Cotizacion_Tarifas Ctar on cc.id = Ctar.IDCotizacion
	left outer join usuarios up on cc.idUsuarioPricingAsignado= up.id
	where  idUsuarioPricingAsignado=@idUsuario
end
else
begin

	select 
	cc.ID,	idCliente,	IdUsuario,	IdTipoCotizacin,	cc.IdEstado as cc_IdEstado ,	FechaSolicitud,	PuertoEmbarque,	NombreCliente,	POL,	POD,	NavieraReferencia,
	TarifaReferencia,	Mercaderia,	GastosLocales,	ProveedorCarga,
	ctar.ID as ctar_ID , Ctar.Fecha, Ctar.FechaValidezInicio ,Ctar.FechaValidezFin ,Ctar.Agente,Ctar.ComentarioCotizacion,Ctar.ComentarioInterno ,Ctar.CreateDate ,Ctar.IdEstado as Ctar_IdEstado,  --tarifa
	IdIncoterm, TI.Descripcion as TI_Descripcion  , TI.Codigo as TI_Codigo , TI.Estado as TI_Estado --IncoTerm
	,up.id as idUsuarioPricing, up.NombreUsuario as nombreUsuarioPricing
	from Cotizacion_Cotizaciones cc
	inner join Cotizacion_Estados ce on cc.IdEstado = ce.ID
	inner join Cotizacion_Tipos ct on cc.IdTipoCotizacin = ct.ID
	inner join TIPO_INCOTERMS TI on cc.IdIncoterm = TI.Id
	left outer join Cotizacion_Tarifas Ctar on cc.id = Ctar.IDCotizacion
	left outer join usuarios up on cc.idUsuarioPricingAsignado= up.id
	
end

End