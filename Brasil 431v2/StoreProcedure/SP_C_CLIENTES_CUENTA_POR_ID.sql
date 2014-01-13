SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure  [dbo].[SP_C_CLIENTES_CUENTA_POR_ID]
@IdCuenta bigint
AS

SELECT dbo.CLIENTES_MASTER.Id AS IdMaster, 
dbo.CLIENTES_CUENTA.Id IdCuenta, 
dbo.CLIENTES_MASTER.NombreCompania, 
dbo.CLIENTES_MASTER.RUT, 
dbo.CLIENTES_MASTER.CodTipo, 
dbo.CLIENTES_MASTER.FechaCreacion AS FechaCreacionMaster, 
dbo.CLIENTES_CUENTA.Id AS IdCuenta, 
dbo.CLIENTES_CUENTA.IdVendedorAsignado, 
dbo.CLIENTES_CUENTA.Telefono, 
dbo.CLIENTES_CUENTA.CuentaSkype, 
dbo.CLIENTES_CUENTA.SitioWeb, 
dbo.CLIENTES_CUENTA.Email, 
dbo.CLIENTES_CUENTA.IdEstado, 
dbo.CLIENTES_CUENTA.IdZonaVentas, 
dbo.CLIENTES_CUENTA.IdCategoriaCliente, 
dbo.CLIENTES_CUENTA.Observacion, 
dbo.CLIENTES_CUENTA.IdSectorEconomico, 
dbo.CLIENTES_CUENTA.IdMonedaVtaEst, 
dbo.CLIENTES_CUENTA.MontoVtaEst, 
dbo.CLIENTES_CUENTA.NumEmpleados, 
dbo.CLIENTES_CUENTA.IdUMMovimiento, 
dbo.CLIENTES_CUENTA.VolumenMovimiento, 
dbo.CLIENTES_CUENTA.IdFormaContactoPref, 
dbo.CLIENTES_CUENTA.PermiteTelOfi, 
dbo.CLIENTES_CUENTA.PermiteTelPart, 
dbo.CLIENTES_CUENTA.PermiteTelCel, 
dbo.CLIENTES_CUENTA.PermiteSkype, 
dbo.CLIENTES_CUENTA.PermiteEmail, 
dbo.CLIENTES_CUENTA.PermiteEmailMasivo, 
dbo.CLIENTES_CUENTA.CodDiaPreferido, 
dbo.CLIENTES_CUENTA.CodJornadaPreferida, 
dbo.CLIENTES_CUENTA.FechaCreacion AS FechaCreacionTarget,
dbo.CLIENTES_MASTER.IdDireccionInfo,
dbo.CLIENTES_MASTER.NombreFantasia,
dbo.CLIENTES_CUENTA.AutorizadoAduana,
dbo.CLIENTES_CUENTA.IdClasificacion,
dbo.CLIENTES_CUENTA.PaperlessTipoRecibo
FROM dbo.CLIENTES_MASTER 
INNER JOIN dbo.CLIENTES_CUENTA
ON dbo.CLIENTES_MASTER.Id = dbo.CLIENTES_CUENTA.IdMaster
WHERE CLIENTES_CUENTA.Id = @IdCuenta