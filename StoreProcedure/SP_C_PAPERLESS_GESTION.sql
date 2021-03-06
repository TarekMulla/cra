ALTER PROCEDURE [dbo].[SP_C_PAPERLESS_GESTION]
@NumMaster nvarchar(50),
@NumConsolidado nvarchar(50),
@Desde datetime,
@Hasta datetime,
@Usuario1 varchar(10),
@Usuario2 varchar(10),
@Nave varchar (100),
@DesdeEmbarcadores datetime,
@HastaEmbarcadores datetime,
@DesdeNavieras datetime,
@HastaNavieras datetime


AS

IF @NumMaster = '-1' set @NumMaster = NULL
IF @NumConsolidado = '-1' set @NumConsolidado = NULL
IF YEAR(@Desde) = 9999 set @Desde = NULL
IF YEAR(@Hasta) = 9999 set @Hasta = NULL
IF YEAR(@DesdeEmbarcadores) = 9999 set @DesdeEmbarcadores = NULL
IF YEAR(@HastaEmbarcadores) = 9999 set @HastaEmbarcadores= NULL
IF YEAR(@DesdeNavieras) = 9999 set @DesdeNavieras = NULL
IF YEAR(@HastaNavieras) = 9999 set @HastaNavieras = NULL
If @Usuario1 = -1 SET @Usuario1 = NULL
If @Usuario2 = -1 SET @Usuario2 = NULL

declare @sql varchar(4000)

set @sql = 'SELECT PA.Id, NumMaster, FechaMaster, '
set @sql += 'PAG.Descripcion  as Agente, '
set @sql += 'PN.Descripcion as Naviera, '
set @sql += 'PNA.Descripcion as Nave, '
set @sql += 'Viaje, NumHousesBL, '
set @sql += 'IdTipoCarga,  '
set @sql += 'PTC.Descripcion as TipoCarga, '
set @sql += 'FechaPaso1, '
set @sql += 'FechaETA, AperturaNavieras, PlazoEmbarcadores, FechaPaso2, '
set @sql += 'U1.ApellidoPaterno U1AP, U1.ApellidoMaterno U1AM, U1.Nombres U1N, '
set @sql += 'ObservacionUsuario1, '
set @sql += 'PARA.Descripcion Importancia, '
set @sql += 'U2.ApellidoPaterno U2AP, U2.ApellidoMaterno U2AM, U2.Nombres U2N, '
set @sql += 'ObservacionUsuario2, '
set @sql += 'FechaPaso3, '
set @sql += 'IdEstado,  '
set @sql += 'PE.Descripcion Estado, '
set @sql += 'PINFO.NumConsolidado,  '
set @sql += 'PTIEMPOS.ComienzoUsuario1, PTIEMPOS.TerminoUsuario1, '
set @sql += 'PTIEMPOS.ComienzoUsuario2, PTIEMPOS.TerminoUsaurio2, '
set @sql += '(Select MAX(FechaMarca) from PAPERLESS_USUARIO1_PASOS_ESTADO P1 where P1.IdAsignacion = PA.Id) UltimoPasoU1, '
set @sql += '(Select MAX(FechaMarca) from PAPERLESS_USUARIO2_PASOS_ESTADO P2 where P2.IdAsignacion = PA.Id) UltimoPasoU2, '
set @sql += 'PA.FechaCreacion, '
set @sql += 'PA.IdUsuarioCreacion '
set @sql += 'FROM PAPERLESS_ASIGNACION PA '
set @sql += 'INNER JOIN PAPERLESS_AGENTE PAG ON PA.IdAgente = PAG.Id '
set @sql += 'INNER JOIN PAPERLESS_NAVIERA PN ON PA.IdNaviera = PN.Id '
set @sql += 'INNER JOIN PAPERLESS_NAVE PNA ON PA.IdNave = PNA.Id '
set @sql += 'INNER JOIN PAPERLESS_TIPO_CARGA PTC ON PA.IdTipoCarga = PTC.Id '
set @sql += 'INNER JOIN USUARIOS U1 ON PA.Usuario1 = U1.Id '
set @sql += 'INNER JOIN USUARIOS U2 ON PA.Usuario2 = U2.Id '
set @sql += 'INNER JOIN PARAM_PARAMETROS PARA ON PA.IdImportancia = PARA.Id '
set @sql += 'INNER JOIN PAPERLESS_ESTADO PE ON PA.IdEstado = PE.Id  '
set @sql += 'LEFT OUTER JOIN PAPERLESS_USUARIO1_HOUSESBL_INFO PINFO ON PA.Id = PINFO.IdAsignacion '
set @sql += 'LEFT OUTER JOIN PAPERLESS_PROCESOS_REGISTRO_TIEMPOS PTIEMPOS ON PA.Id = PTIEMPOS.IdAsignacion '
set @sql += 'WHERE PA.Id > 0 '

if (@NumMaster is not null and @NumMaster <> '')	
	set @sql += 'AND PA.NumMaster = ISNULL('''+@NumMaster+''',PA.NumMaster)'

if (@Desde is not null and @Desde <> '')	
	set @sql += 'AND convert(varchar(20),PA.FechaCreacion,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@Desde,112)+''',PA.FechaCreacion)'
	
if (@Hasta is not null and @Hasta <> '')	
	set @sql += 'AND convert(varchar(20),PA.FechaCreacion,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@Hasta,112)+''',PA.FechaCreacion)'

if (@Usuario1 is not null and @Usuario1 <> '')	
	set @sql += 'AND PA.Usuario1 = ISNULL('+@Usuario1+',PA.Usuario1)'
	
if (@Usuario2 is not null and @Usuario2 <> '')	
	set @sql += 'AND PA.Usuario2 = ISNULL('+@Usuario2+',PA.Usuario2)'
	
if (@nave is not null and @nave <> '')	
	set @sql += 'AND PNA.Descripcion like ISNULL(''' + @nave + ''',PNA.Descripcion)'--AND PNA.Descripcion like @Nave

if (@DesdeEmbarcadores is not null and @DesdeEmbarcadores <> '')	
	set @sql += 'AND convert(varchar(20),PlazoEmbarcadores,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@DesdeEmbarcadores,112)+''',PlazoEmbarcadores)'
	
if (@HastaEmbarcadores  is not null and @HastaEmbarcadores <> '')	
	set @sql += 'AND convert(varchar(20),PlazoEmbarcadores,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@HastaEmbarcadores,112)+''',PlazoEmbarcadores)'

if (@DesdeNavieras is not null and @DesdeNavieras <> '')	
	set @sql += 'AND convert(varchar(20),PA.AperturaNavieras,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@DesdeNavieras,112)+''',PA.AperturaNavieras)'
	
if (@HastaNavieras is not null and @HastaNavieras <> '')	
	set @sql += 'AND convert(varchar(20),PA.AperturaNavieras,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@HastaNavieras,112)+''',PA.AperturaNavieras)'

print @sql
execute(@sql)
