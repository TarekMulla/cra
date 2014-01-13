
-- =============================================
-- Author:        VhsPiceros
-- Create date:   12/04/2013
-- Description:   
-- Revisions:     
-- =============================================
alter Procedure SP_N_COTIZACION_SOLICITUD_COTIZACIONES
      @idCliente bigint = null,
      @idUsuario bigint = null,
      @nombreCliente varchar(45) = null,
      @fechaSolicitud datetime = null,
      @idIncoterms bigint = null,
      @puertoEmbarque varchar(100) = null,
      @POL varchar(45) = null,
      @POD varchar(45) = null,
      @navieraReferencia varchar(45) = null,
      @tarifaReferencia varchar(45) = null,
      @mercaderia varchar(45) = null,
      @gastosLocales varchar(45) = null,
      @proveedorCarga varchar(45) = null,
      @credito varchar(45) = null,
      @idUsuarioPricing bigint = null,
      @fechaEstimadaEmbarque varchar(45) = null,
      @conAgenciamento bit = null,
      @COTIZACION_TIPOS_TRANSBORDOS_id bigint = null,
      @COTIZACION_ESTADOS_id bigint = null,
      @COTIZACION_TIPOS_id bigint = null,
      @Comentario  varchar(300),
      @id bigint OUTPUT
AS
Begin
      SET NOCOUNT ON
      insert into COTIZACION_SOLICITUD_COTIZACIONES
            ( idCliente, idUsuario, nombreCliente, fechaSolicitud, idIncoterms, puertoEmbarque, POL, POD, navieraReferencia, tarifaReferencia, mercaderia, gastosLocales, proveedorCarga, credito, idUsuarioPricing, fechaEstimadaEmbarque, conAgenciamento, COTIZACION_TIPOS_TRANSBORDOS_id, COTIZACION_ESTADOS_id, COTIZACION_TIPOS_id)
      values
            (@idCliente,@idUsuario,@nombreCliente,@fechaSolicitud,@idIncoterms,@puertoEmbarque,@POL,@POD,@navieraReferencia,@tarifaReferencia,@mercaderia,@gastosLocales,@proveedorCarga,@credito,@idUsuarioPricing,@fechaEstimadaEmbarque,@conAgenciamento,@COTIZACION_TIPOS_TRANSBORDOS_id,@COTIZACION_ESTADOS_id,@COTIZACION_TIPOS_id)

      select @id = SCOPE_IDENTITY()
End
Go