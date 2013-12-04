SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure  [dbo].[SP_A_CLIENTES_MASTER]
@IdCuenta bigint
,@IdMaster bigint
,@IdVendedorAsignado int
,@Telefono nvarchar(50)
,@CuentaSkype nvarchar(50)
,@SitioWeb nvarchar(50)
,@Email nvarchar(50)
,@IdEstado int
,@IdZonaVentas int
,@IdCategoriaCliente int
,@Observacion nvarchar(255)
,@IdSectorEconomico int
,@IdMonedaVtaEst int
,@MontoVtaEst decimal(18,0)
,@NumEmpleados int
,@IdUMMovimiento int
,@VolumenMovimiento decimal(18,0)
,@IdFormaContactoPref int
,@PermiteTelOfi bit
,@PermiteTelPart bit
,@PermiteTelCel bit
,@PermiteSkype bit
,@PermiteEmail bit
,@PermiteEmailMasivo bit
,@CodDiaPreferido int
,@CodJornadaPreferida int
,@AutorizadoAduana bit
,@IdClasificacion int
,@PaperlessTipoRecibo int
AS

if(@IdVendedorAsignado=-1) set @IdVendedorAsignado = null;
if(@IdSectorEconomico=-1) set @IdSectorEconomico = null;
if(@IdMonedaVtaEst=-1) set @IdMonedaVtaEst = null;
if(@IdUMMovimiento=-1) set @IdUMMovimiento = null;
if(@IdFormaContactoPref=-1) set @IdFormaContactoPref = null;
if(@CodDiaPreferido=-1) set @CodDiaPreferido = null;
if(@CodJornadaPreferida=-1) set @CodJornadaPreferida = null;
if(@IdZonaVentas=-1) set @IdZonaVentas = null;
if(@IdCategoriaCliente=-1) set @IdCategoriaCliente = null;
if(@MontoVtaEst=-1) set @MontoVtaEst = null;
if(@VolumenMovimiento=-1) set @VolumenMovimiento = null;
if(@NumEmpleados=-1) set @NumEmpleados = null;
if(@IdClasificacion=-1) set @IdClasificacion = null;
if(@PaperlessTipoRecibo=-1) set @PaperlessTipoRecibo = null;

UPDATE CLIENTES_CUENTA
   SET [IdMaster] = @IdMaster
      ,[IdVendedorAsignado] = @IdVendedorAsignado     
      ,[Telefono] = @Telefono
      ,[CuentaSkype] = @CuentaSkype
      ,[SitioWeb] = @SitioWeb
      ,[Email] = @Email
      ,[IdEstado] = @IdEstado
      ,[IdZonaVentas] = @IdZonaVentas
      ,[IdCategoriaCliente] = @IdCategoriaCliente
      ,[Observacion] = @Observacion
      ,[IdSectorEconomico] = @IdSectorEconomico
      ,[IdMonedaVtaEst] = @IdMonedaVtaEst
      ,[MontoVtaEst] = @MontoVtaEst
      ,[NumEmpleados] = @NumEmpleados
      ,[IdUMMovimiento] = @IdUMMovimiento
      ,[VolumenMovimiento] = @VolumenMovimiento
      ,[IdFormaContactoPref] = @IdFormaContactoPref
      ,[PermiteTelOfi] = @PermiteTelOfi
      ,[PermiteTelPart] = @PermiteTelPart
      ,[PermiteTelCel] = @PermiteTelCel
      ,[PermiteSkype] = @PermiteSkype
      ,[PermiteEmail] = @PermiteEmail
      ,[PermiteEmailMasivo] = @PermiteEmailMasivo
      ,[CodDiaPreferido] = @CodDiaPreferido
      ,[CodJornadaPreferida] = @CodJornadaPreferida         
	  ,[AutorizadoAduana] = @AutorizadoAduana 
	  ,[IdClasificacion] = @IdClasificacion
	  ,[PaperlessTipoRecibo] = @PaperlessTipoRecibo
 WHERE Id = @IdCuenta