alter table clientes_cuenta add PaperlessTipoRecibo	int
go


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

go


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


go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_HOUSEBL]
@IdAsignacion bigint

AS

SELECT
PHBL.Id,
PHBL.IdAsignacion,
IndexHouse,
HouseBL,
Freehand,
Ruteado,
IdCliente,
IdTipoCliente,
TC.Descripcion TipoCliente,
EmbarcadorContactado,
ReciboAperturaEmbarcador,
FechaReciboAperturaEmbarcador,
TipoReciboAperturaEmbarcador,
PE.RecargoCollect, 
PE.Id IdExcepcion,
PHBL.Observacion,
cc.PaperlessTipoRecibo
FROM PAPERLESS_USUARIO1_HOUSESBL PHBL LEFT OUTER JOIN CLIENTES_MASTER_TIPO_CLIENTE TC ON PHBL.IdTipoCliente = TC.Id
LEFT OUTER JOIN PAPERLESS_USUARIO1_EXCEPCIONES PE ON PHBL.Id = PE.IdHouseBL
LEFT join CLIENTES_CUENTA cc on cc.IdMaster=IdCliente
WHERE PHBL.IdAsignacion = @IdAsignacion 
ORDER BY IndexHouse


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_N_PAPERLESS_ASIGNACION_PASO1]
@NumMaster nvarchar(100),
@FechaMaster datetime,
@IdAgente bigint,
@IdNaviera bigint,
@IdNave bigint,
@Viaje nvarchar(100),
@NumHousesBL int,
@IdTipoCarga int,
@IdEstado int,
@IdUsuarioCreo int,
@IdTipoServicio int,
@IdNaveTransbordo int

AS

IF @IdAgente = -1 SET @IdAgente = NULL
IF @IdNaviera = -1 SET @IdNaviera = NULL
IF @IdNave = -1 SET @IdNave = NULL
IF @IdNaveTransbordo = -1 SET @IdNaveTransbordo = NULL
IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL

INSERT INTO PAPERLESS_ASIGNACION(
	NumMaster,FechaMaster,IdAgente,IdNaviera,IdNave,Viaje,NumHousesBL,IdTipoCarga, IdTipoServicio, 
	IdEstado,FechaCreacion, FechaPaso1,IdUsuarioCreacion, Usuario1, Usuario2,IdNaveTransbordo
	)
VALUES(
	@NumMaster,@FechaMaster,@IdAgente,@IdNaviera,@IdNave,@Viaje,@NumHousesBL,@IdTipoCarga, @IdTipoServicio,
	@IdEstado,GETDATE(), GETDATE(),@IdUsuarioCreo, -1, -1,@IdNaveTransbordo
)

SELECT SCOPE_IDENTITY()


go

alter PROCEDURE [dbo].[SP_U_PAPERLESS_ASIGNACION_PASO1]   				   
@NumMaster nvarchar(50),   
@FechaMaster datetime,   
@IdAgente bigint,   
@IdNaviera bigint,   
@IdNave bigint,   
@Viaje nvarchar(100),   
@NumHouses int,   
@IdTipoCarga int,   
@IdAsignacion bigint,  
@IdTipoServicio int, 
@IdNaveTransbordo bigint,
@motivoModificacion varchar(50)    AS      IF @IdTipoServicio = -1 SET @IdTipoServicio = NULL


UPDATE PAPERLESS_ASIGNACION SET   NumMaster = @NumMaster,
 FechaMaster = @FechaMaster,   
 IdAgente = @IdAgente,   
 IdNaviera = @IdNaviera,
 IdNave = @IdNave ,   
 Viaje = @Viaje,   
 NumHousesBL = @NumHouses,   
 IdTipoCarga = @IdTipoCarga,   
 FechaPaso1 = GETDATE(),   
 IdTipoServicio = @IdTipoServicio,   
 MotivoModificacion = @motivoModificacion ,
 IdNaveTransbordo=  @IdNaveTransbordo
WHERE Id = @IdAsignacion



go

alter PROCEDURE [dbo].[SP_C_PAPERLESS_NUMCONSOLIDADO]  
@numConsolidado nvarchar (100)                                  
   
AS                                                                                                                        
   
select NumConsolidado  from  PAPERLESS_USUARIO1_HOUSESBL_INFO where NumConsolidado = @numConsolidado 

go



update clientes_cuenta set paperlesstiporecibo =1 where id =1
update clientes_cuenta set paperlesstiporecibo =1 where id =2
update clientes_cuenta set paperlesstiporecibo =1 where id =3
update clientes_cuenta set paperlesstiporecibo =1 where id =4
update clientes_cuenta set paperlesstiporecibo =1 where id =5
update clientes_cuenta set paperlesstiporecibo =1 where id =6
update clientes_cuenta set paperlesstiporecibo =1 where id =7
update clientes_cuenta set paperlesstiporecibo =1 where id =8
update clientes_cuenta set paperlesstiporecibo =1 where id =10
update clientes_cuenta set paperlesstiporecibo =1 where id =11
update clientes_cuenta set paperlesstiporecibo =1 where id =12
update clientes_cuenta set paperlesstiporecibo =1 where id =13
update clientes_cuenta set paperlesstiporecibo =1 where id =14
update clientes_cuenta set paperlesstiporecibo =1 where id =15
update clientes_cuenta set paperlesstiporecibo =1 where id =16
update clientes_cuenta set paperlesstiporecibo =1 where id =17
update clientes_cuenta set paperlesstiporecibo =1 where id =18
update clientes_cuenta set paperlesstiporecibo =1 where id =19
update clientes_cuenta set paperlesstiporecibo =1 where id =21
update clientes_cuenta set paperlesstiporecibo =1 where id =22
update clientes_cuenta set paperlesstiporecibo =1 where id =23
update clientes_cuenta set paperlesstiporecibo =1 where id =24
update clientes_cuenta set paperlesstiporecibo =1 where id =25
update clientes_cuenta set paperlesstiporecibo =1 where id =26
update clientes_cuenta set paperlesstiporecibo =1 where id =27
update clientes_cuenta set paperlesstiporecibo =1 where id =28
update clientes_cuenta set paperlesstiporecibo =1 where id =29
update clientes_cuenta set paperlesstiporecibo =1 where id =30
update clientes_cuenta set paperlesstiporecibo =1 where id =31
update clientes_cuenta set paperlesstiporecibo =1 where id =32
update clientes_cuenta set paperlesstiporecibo =1 where id =33
update clientes_cuenta set paperlesstiporecibo =1 where id =34
update clientes_cuenta set paperlesstiporecibo =1 where id =35
update clientes_cuenta set paperlesstiporecibo =1 where id =36
update clientes_cuenta set paperlesstiporecibo =1 where id =37
update clientes_cuenta set paperlesstiporecibo =1 where id =38
update clientes_cuenta set paperlesstiporecibo =1 where id =39
update clientes_cuenta set paperlesstiporecibo =1 where id =40
update clientes_cuenta set paperlesstiporecibo =1 where id =41
update clientes_cuenta set paperlesstiporecibo =1 where id =42
update clientes_cuenta set paperlesstiporecibo =1 where id =43
update clientes_cuenta set paperlesstiporecibo =1 where id =44
update clientes_cuenta set paperlesstiporecibo =1 where id =45
update clientes_cuenta set paperlesstiporecibo =1 where id =46
update clientes_cuenta set paperlesstiporecibo =1 where id =47
update clientes_cuenta set paperlesstiporecibo =1 where id =52
update clientes_cuenta set paperlesstiporecibo =1 where id =60
update clientes_cuenta set paperlesstiporecibo =2 where id =89
update clientes_cuenta set paperlesstiporecibo =1 where id =151
update clientes_cuenta set paperlesstiporecibo =1 where id =217
update clientes_cuenta set paperlesstiporecibo =1 where id =288
update clientes_cuenta set paperlesstiporecibo =1 where id =329

go
update CLIENTES_CUENTA  set PaperlessTipoRecibo =2  where PaperlessTipoRecibo is null
go