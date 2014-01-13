alter Procedure SP_N_Cotizacion_Cotizaciones
      @idCliente bigint = null,
      @IdUsuario bigint = null,
      @IdTipoCotizacin bigint = null,
      @FechaSolicitud datetime = null,
      @IdIncoterm bigint = null,
      @PuertoEmbarque varchar(100)= null,
      @POL varchar(300)= null,
      @POD varchar(300)= null,
      @NavieraReferencia varchar(500) = null,
      @TarifaReferencia varchar(300) = null,
      @Mercaderia varchar(300) = null,
      @GastosLocales varchar(500) = null,
      @ProveedorCarga varchar(1000) = null,
      @Credito varchar(100) = null,
      @Comentario varchar(2000) = null,
      @NombreCliente varchar(120) = null,
      @idUsuarioPricingAsignado bigint =null,
      @ID bigint OUTPUT
AS
Begin
      SET NOCOUNT ON
      insert into Cotizacion_Cotizaciones
            ( idCliente, IdUsuario, IdTipoCotizacin, FechaSolicitud, IdIncoterm, PuertoEmbarque, POL, POD, NavieraReferencia, TarifaReferencia, Mercaderia, GastosLocales, ProveedorCarga, Credito, Comentario, NombreCliente,idUsuarioPricingAsignado,idEstado)
      values
            (@idCliente,@IdUsuario,@IdTipoCotizacin,@FechaSolicitud,@IdIncoterm,@PuertoEmbarque,@POL,@POD,@NavieraReferencia,@TarifaReferencia,@Mercaderia,@GastosLocales,@ProveedorCarga,@Credito,@Comentario,@NombreCliente,@idUsuarioPricingAsignado,1)

      select @ID = SCOPE_IDENTITY()
End

GO