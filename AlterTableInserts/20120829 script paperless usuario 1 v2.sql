CREATE TABLE  PAPERLESS_PASOS_USUARIO1_V2
    (
        IdPaso INT NOT NULL IDENTITY,
        NumPaso INT,
        Descripcion NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS,
        Activo BIT,
        PasoAnterior INT,
        PasoSiguiente INT,
        CONSTRAINT PK_PAPERLESS_PASOS_USUARIO1_v2 PRIMARY KEY (IdPaso)
    )
    
    
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 1, 'Ingreso de Datos', 1, null, 2);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 2, 'Crear Manifiesto', 1, 1, 3);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 3, 'Cargar Copia BL', 1, 2, 4);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 4, 'Facturar', 1, 3, 5);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 5, 'Generar/enviar avisos', 1, 4, 6);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 6, 'Registrar Excepciones', 1, 5, 7);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 7, 'Ingreso de MBl a Netship y contable', 1, 6, 8);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 8, 'Ingreso de invoice a netship y al contable', 1, 7, 9);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 9, 'Imprimir etiquetas y BLS', 1, 8, 10);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 10, 'Envio de disputa', 1, 9, 11);
insert into PAPERLESS_PASOS_USUARIO1_V2 ( NumPaso, Descripcion, Activo, PasoAnterior, PasoSiguiente) values ( 11, 'Enviar Aviso a Usuario 2', 1, 10, null);

ALTER TABLE PAPERLESS_ASIGNACION add versionUsuario1 int not null default 2
GO

ALTER table PAPERLESS_USUARIO1_HOUSESBL add transbordoTransito int not null default 0
GO 

UPDATE PAPERLESS_ASIGNACION  set versionUsuario1 = 1
GO

create PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS_V2]
    @IdAsignacion bigint
AS 


IF (SELECT COUNT(*) FROM PAPERLESS_USUARIO1_PASOS_ESTADO WHERE IdAsignacion = @IdAsignacion) = 0
   BEGIN
        INSERT INTO PAPERLESS_USUARIO1_PASOS_ESTADO
        SELECT @IdAsignacion, NumPaso, 'false',null FROM PAPERLESS_PASOS_USUARIO1_v2 where  activo=1
    END
UPDATE PAPERLESS_ASIGNACION  set versionUsuario1 = 2 where id=@IdAsignacion
GO




ALTER PROCEDURE "dbo"."SP_L_PAPERLESS_ASIGNACION"                                                                     
 --DECLARE                                                                                                               
 @desde datetime,                                                                                                        
 @hasta datetime,                                                                                                        
 @usuario1 bigint,                                                                                                       
 @usuario2 bigint,                                                                                                       
 @estado varchar(50),--int
 @NConsolidado nvarchar(50),                                                                                             
 @nave varchar(100),
 @DesdeEmbarcadores datetime,
 @HastaEmbarcadores datetime,
 @DesdeNavieras datetime,
 @HastaNavieras datetime,
 @nummaster nvarchar (100)
                                                                                                      
 AS                                                                                                                      
                                                                                                                         
 /*                                                                                                                      
 SET @desde = '9999-01-01'                                                                                               
 SET @hasta = '9999-01-01'                                                                                               
 set @usuario1 = -1 --41                                                                                                 
 set @usuario2 = 41                                                                                                      
 SET @estado = -1                                                                                                        
 SET @NConsolidado = '-1'                                                                                                
 */                                                                                                                      
                                                                                                                         
 IF YEAR(@desde) = 9999 SET @desde = null                                                                                
 IF YEAR(@hasta) = 9999 SET @hasta = null      
 IF YEAR(@DesdeEmbarcadores) = 9999 set @DesdeEmbarcadores = NULL
 IF YEAR(@HastaEmbarcadores) = 9999 set @HastaEmbarcadores= NULL
 IF YEAR(@DesdeNavieras) = 9999 set @DesdeNavieras = NULL
 IF YEAR(@HastaNavieras) = 9999 set @HastaNavieras = NULL                                                                          
 --IF @usuario1 = -1 set @usuario1 = null                                                                                
 --IF @usuario2 = -1 set @usuario2 = null                                                                                
 IF @estado = '-1' set @estado = null                                                                                      
 IF @NConsolidado = '-1' SET @NConsolidado = NULL
 IF @nummaster = '-1' SET @nummaster = NULL
                                                                                                                         
 declare @username1 nvarchar(50)                                                                                         
 set @username1 = null                                                                                                   
 if(@usuario1 > 0)                                                                 
    SET @username1 = (select NombreUsuario from USUARIOS where Id = @usuario1)                                             
                                                                                                                                    
 declare @username2 nvarchar(50)                                                                                         
 set @username2 = null                                                                                                   
 if(@usuario2 > 0)                                                                                                       
    select @username2 = NombreUsuario from USUARIOS where Id = @usuario2                                                   
                                                                                                                         
                                                                                                                         
                                                                                                                         
 declare @sql nvarchar(4000)                                                                                             
                                                                                                                         
 set @sql = 'SELECT PA.Id,NumMaster, NumHousesBL, FechaMaster, '                                                         
 set @sql += 'Usuario1, '                                                                                                
 set @sql += 'U1.ApellidoPaterno APU1, U1.ApellidoMaterno AMU1, U1.Nombres NU1,U1.Email Email1, '                        
 set @sql += ' PA.IdImportancia, PAR.Descripcion Importancia,'                                                           
 set @sql += ' Usuario2,'                                                                                                
 set @sql += ' U2.ApellidoPaterno APU2, U2.ApellidoMaterno AMU2, U2.Nombres NU2, U2.Email Email2,'                       
 set @sql += ' PA.IdEstado, PE.Descripcion Estado,'                                                                      
 set @sql += ' PA.FechaCreacion ,'                                                                                       
 set @sql += ' PA.IdAgente, PAG.Descripcion Agente,'                                                                     
 set @sql += ' PA.IdNaviera, PN.Descripcion Naviera,'                                                                    
 set @sql += ' isnull(PA.IdNave,0) as IdNave, isnull(PNAVE.Descripcion ,'''') as Nave,'                                                                       
 set @sql += ' PA.Viaje,'                                                                                                
 set @sql += ' PA.IdTipoCarga, TP.Descripcion TipoCarga,'                                                                
 set @sql += ' PA.FechaETA,PA.AperturaNavieras, PA.PlazoEmbarcadores,'                                                   
 set @sql += ' PA.ObservacionUsuario1,PA.ObservacionUsuario2,'                                                           
 set @sql += ' PHINFO.NumConsolidado,'                                                                                   
 set @sql += ' PA.IdUsuarioCreacion, UC.ApellidoPaterno UCAP, UC.ApellidoMaterno UCAM, UC.Nombres UCN, UC.Email EmailUC, '
 set @sql += ' isnull(PA.IdNaveTransbordo,0) as IdNaveTransbordo ,isnull(PNAVET.Descripcion ,'''') as NaveTransbordo,'
 set @sql += ' PA.versionUsuario1'
 set @sql += ' FROM PAPERLESS_ASIGNACION PA'                                                                             
 set @sql += ' LEFT OUTER JOIN USUARIOS U1'                                                                              
 set @sql += ' ON PA.Usuario1 = U1.Id'                                                                                   
 set @sql += ' LEFT OUTER JOIN USUARIOS U2'                                
 set @sql += ' ON PA.Usuario2 = U2.Id'                                                                                   
 set @sql += ' INNER JOIN PAPERLESS_ESTADO PE'                                                                           
 set @sql += ' ON PA.IdEstado = PE.Id'                                                                                   
 set @sql += ' LEFT OUTER JOIN PARAM_PARAMETROS PAR'                                                                     
 set @sql += ' ON PA.IdImportancia = PAR.Id'                                                                             
 set @sql += ' LEFT OUTER JOIN PAPERLESS_AGENTE PAG'                                                                     
 set @sql += ' ON PA.IdAgente = PAG.Id'                                                                                  
 set @sql += ' LEFT OUTER JOIN PAPERLESS_NAVIERA PN'                                                                     
 set @sql += ' ON PA.IdNaviera = PN.Id'                                                                                  
 set @sql += ' LEFT OUTER JOIN PAPERLESS_NAVE PNAVE'                                                                     
 set @sql += ' ON PA.IdNave = PNAVE.Id'
set @sql += ' LEFT OUTER JOIN PAPERLESS_NAVE PNAVET'                                                                     
 set @sql += ' ON PA.IdNaveTransbordo = PNAVET.Id'                                                                                   
 set @sql += ' INNER JOIN PAPERLESS_TIPO_CARGA TP'                                                                       
 set @sql += ' ON PA.IdTipoCarga = TP.Id'                                                                                
 set @sql += ' LEFT OUTER JOIN PAPERLESS_USUARIO1_HOUSESBL_INFO PHINFO'                                                  
 set @sql += ' ON PA.Id = PHINFO.IdAsignacion'                                                                           
 set @sql += ' INNER JOIN USUARIOS UC'                                                                                   
 set @sql += ' ON PA.IdUsuarioCreacion = UC.Id'                                                                          
 set @sql += ' WHERE PA.Id>0'                                                                                            
                                                                                                                         
 if(@desde is not null)                                                                                                  
    set @sql += ' AND convert(varchar(20),PA.FechaCreacion,112) >= ISNULL(''' + CONVERT(NVARCHAR(20),@desde,112) + ''',PA.FechaCreacion)'             
                                                                                                                         
 if(@hasta is not null)                                                                                                  
    set @sql += ' AND convert(varchar(20),PA.FechaCreacion,112) <= ISNULL(''' + CONVERT(NVARCHAR(20),@hasta,112) + ''',PA.FechaCreacion)'           
                                                                                                                           
 if(@usuario1 > 0)                                                                                                        
    set @sql += ' AND U1.NombreUsuario = ISNULL(''' + @username1 + ''',U1.NombreUsuario)'                                  
                                                                                                                           
 if(@usuario2 > 0)                                                                                                       
    set @sql += ' AND U2.NombreUsuario = ISNULL(''' + @username2 + ''',U2.NombreUsuario)'                                  
                                                                                                                         
 if(@estado is not null)                                                                                                 
    set @sql += ' AND PA.IdEstado in (' + @estado + ' )'
  --    set @sql += ' AND PA.IdEstado in ( ISNULL(' + CONVERT(NVARCHAR(1),CAST(@estado AS INT)) + ',PA.IdEstado))'
                                                                                                                           
 if (@nave is not null and @nave <> '')                                                                                  
    set @sql += ' AND PNAVE.Descripcion like ISNULL(''%' + @nave + '%'',PNAVE.Descripcion)'    
    
 if (@DesdeEmbarcadores is not null and @DesdeEmbarcadores <> '')   
    set @sql += 'AND convert(varchar(20),PlazoEmbarcadores,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@DesdeEmbarcadores,112)+''',PlazoEmbarcadores)'
    
if (@HastaEmbarcadores  is not null and @HastaEmbarcadores <> '')   
    set @sql += 'AND convert(varchar(20),PlazoEmbarcadores,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@HastaEmbarcadores,112)+''',PlazoEmbarcadores)'

if (@DesdeNavieras is not null and @DesdeNavieras <> '')    
    set @sql += 'AND convert(varchar(20),PA.AperturaNavieras,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@DesdeNavieras,112)+''',PA.AperturaNavieras)'
    
if (@HastaNavieras is not null and @HastaNavieras <> '')    
    set @sql += 'AND convert(varchar(20),PA.AperturaNavieras,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@HastaNavieras,112)+''',PA.AperturaNavieras)'                            
                                                    
if(@nummaster is not null and  @nummaster <> '')                                                                                                       
    set @sql += ' AND PA.NumMaster = ISNULL(''' + @nummaster + ''',PA.NumMaster)' 
                                                                                                                               
 set @sql += ' ORDER BY PA.Id desc'                                                                                      
 execute(@sql)                                                                                                           
                                                                                                                         
 /*                                                                                                                      
 SELECT                                                                                                                  
 PA.Id,NumMaster, NumHousesBL, FechaMaster,                                                                              
 Usuario1,                                                                                                               
 U1.ApellidoPaterno APU1, U1.ApellidoMaterno AMU1, U1.Nombres NU1,U1.Email Email1,                                       
 PA.IdImportancia, PAR.Descripcion Importancia,                                                                          
 Usuario2,                                                                                                               
 U2.ApellidoPaterno APU2, U2.ApellidoMaterno AMU2, U2.Nombres NU2, U2.Email Email2,                                      
 PA.IdEstado, PE.Descripcion Estado,                                                                                     
 PA.FechaCreacion ,                                                                                                      
 PA.IdAgente, PAG.Descripcion Agente,                                                                                    
 PA.IdNaviera, PN.Descripcion Naviera,                                                                                   
 PA.IdNave, PNAVE.Descripcion Nave,                                                                                      
 PA.Viaje,                                                                                                               
 PA.IdTipoCarga, TP.Descripcion TipoCarga,                                                                               
 PA.FechaETA,PA.AperturaNavieras, PA.PlazoEmbarcadores,                                                                  
 PA.ObservacionUsuario1,PA.ObservacionUsuario2,                                                                          
 PHINFO.NumConsolidado,                                                                                                  
 PA.IdUsuarioCreacion, UC.ApellidoPaterno UCAP, UC.ApellidoMaterno UCAM, UC.Nombres UCN, UC.Email EmailUC                
 FROM PAPERLESS_ASIGNACION PA                                                                                            
 LEFT OUTER JOIN USUARIOS U1                                                                                             
 ON PA.Usuario1 = U1.Id                                                                                                  
 LEFT OUTER JOIN USUARIOS U2                                                                                             
 ON PA.Usuario2 = U2.Id                                                                                                  
 INNER JOIN PAPERLESS_ESTADO PE                                                                                          
 ON PA.IdEstado = PE.Id                                                                                                  
 LEFT OUTER JOIN PARAM_PARAMETROS PAR                                                                                    
 ON PA.IdImportancia = PAR.Id                                                                                            
 LEFT OUTER JOIN PAPERLESS_AGENTE PAG                                                                                    
 ON PA.IdAgente = PAG.Id                                                                                                 
 LEFT OUTER JOIN PAPERLESS_NAVIERA PN                                                                                    
 ON PA.IdNaviera = PN.Id                                                                                                 
 LEFT OUTER JOIN PAPERLESS_NAVE PNAVE                                                                                    
 ON PA.IdNave = PNAVE.Id                                                                                                 
 INNER JOIN PAPERLESS_TIPO_CARGA TP                                                                                      
 ON PA.IdTipoCarga = TP.Id                                                                                               
 LEFT OUTER JOIN PAPERLESS_USUARIO1_HOUSESBL_INFO PHINFO                                                                 
 ON PA.Id = PHINFO.IdAsignacion                                                                                          
 INNER JOIN USUARIOS UC                                                                                                  
 ON PA.IdUsuarioCreacion = UC.Id                                                                                         
 WHERE PA.Id>0                                                                                                           
 AND PA.FechaCreacion >= ISNULL(@desde,PA.FechaCreacion)                                                                 
 AND PA.FechaCreacion <= ISNULL(@hasta,PA.FechaCreacion)                                                                 
 AND U1.NombreUsuario = ISNULL(@username1,U1.NombreUsuario)                                                              
 AND U2.NombreUsuario = ISNULL(@username2,U2.NombreUsuario)                                                              
 AND PA.IdEstado = ISNULL(@estado,PA.IdEstado)                                                                           
 --AND PHINFO.NumConsolidado = ISNULL(@NConsolidado,PHINFO.NumConsolidado)                                               
 ORDER BY PA.Id desc                   
*/
GO



ALTER PROCEDURE "dbo"."SP_C_PAPERLESS_GESTION"
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
set @sql += 'PA.IdUsuarioCreacion, '
set @sql += 'PA.versionUsuario1 '
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
GO


CREATE PROCEDURE "dbo"."SP_C_PAPERLESS_USUARIO1_PASOS_ESTADO_v2" 
@IdAsignacion bigint

AS

SELECT 
PA.Id IdAsignacion,
PU1ESTADO.NumPaso,
PU1ESTADO.Estado,
PU1.Descripcion,
PU1ESTADO.Id IdPasoEstado,
PU1ESTADO.NumPaso
FROM PAPERLESS_ASIGNACION PA
INNER JOIN PAPERLESS_USUARIO1_PASOS_ESTADO PU1ESTADO
ON PA.Id = PU1ESTADO.IdAsignacion
INNER JOIN PAPERLESS_PASOS_USUARIO1_v2 PU1
ON PU1ESTADO.NumPaso = PU1.NumPaso
WHERE PA.Id = @IdAsignacion
ORDER BY PA.Id, PU1ESTADO.NumPaso
GO


CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_TRANSBORDOTRANSITO]
@transbordoTransito bigint,
@IdHouse bigint
AS                                    
UPDATE PAPERLESS_USUARIO1_HOUSESBL
SET transbordoTransito = @transbordoTransito
WHERE Id = @IdHouse
GO

CREATE TABLE PAPERLESS_TIPO_TRANSITO_TRANSBORDO    (
        Id INT NOT NULL IDENTITY,
        Descripcion NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS,
        Activo BIT,
        CONSTRAINT PK_PAPERLESS_TIPO_TRANSITO_TRANSBORDO PRIMARY KEY (Id)
    )
GO


insert PAPERLESS_TIPO_TRANSITO_TRANSBORDO (Descripcion,activo) values ('Transbordo y transito',1)
insert PAPERLESS_TIPO_TRANSITO_TRANSBORDO (Descripcion,activo) values ('Solo Transbordo',1)
insert PAPERLESS_TIPO_TRANSITO_TRANSBORDO (Descripcion,activo) values ('Solo IMO',1)
GO

CREATE TABLE PAPERLESS_TIPO_EXCEPCIONES    (
        Id INT NOT NULL IDENTITY,
        Descripcion NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS,
        Activo BIT,
        CONSTRAINT PK_PAPERLESS_TIPO_EXCEPCIONES PRIMARY KEY (Id)
    )
GO
insert PAPERLESS_TIPO_EXCEPCIONES (Descripcion,activo) values ('Sobrevalor pendiente',1)
insert PAPERLESS_TIPO_EXCEPCIONES (Descripcion,activo) values ('Falta de informacion de contacto',1)
insert PAPERLESS_TIPO_EXCEPCIONES (Descripcion,activo) values ('Master en la nominacion',1)
insert PAPERLESS_TIPO_EXCEPCIONES (Descripcion,activo) values ('Master no valorado',1)
insert PAPERLESS_TIPO_EXCEPCIONES (Descripcion,activo) values ('No envio de copia  de BL',1)
insert PAPERLESS_TIPO_EXCEPCIONES (Descripcion,activo) values ('Otros',1)
GO

CREATE TABLE PAPERLESS_TIPO_RESPONSABILIDAD    (
        Id INT NOT NULL IDENTITY,
        Descripcion NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS,
        Activo BIT,
        CONSTRAINT PK_PAPERLESS_TIPO_RESPONSABILIDAD PRIMARY KEY (Id)
    )
GO
insert PAPERLESS_TIPO_RESPONSABILIDAD (Descripcion,activo) values ('Usuario 1',1)
insert PAPERLESS_TIPO_RESPONSABILIDAD (Descripcion,activo) values ('Usuario 2',1)
GO

CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_TRANSITO_TRANSBORDO]
AS
select id,Descripcion
from PAPERLESS_TIPO_TRANSITO_TRANSBORDO
where activo = 1 
GO

CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_TRANSBORDOTRANSITO]
@IdHouse bigint
AS
select b.id,b.descripcion
from PAPERLESS_USUARIO1_HOUSESBL as A ,PAPERLESS_TIPO_TRANSITO_TRANSBORDO as B
where  A.transbordoTransito = B.ID 
and A.ID = @idhouse
GO

CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_EXCEPCIONES]
AS
select id,Descripcion
from PAPERLESS_TIPO_EXCEPCIONES
where activo = 1 
order by id 
GO

CREATE PROCEDURE [dbo].[SP_L_PAPERLESS_TIPO_RESPONSABILIDAD]
AS
select id,Descripcion
from PAPERLESS_TIPO_RESPONSABILIDAD
where activo = 1 
order by id 
GO


CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_TRANSBORDOTRANSITO]
@transbordoTransito bigint,
@IdHouse bigint
AS                                    
UPDATE PAPERLESS_USUARIO1_HOUSESBL
SET transbordoTransito = @transbordoTransito
WHERE Id = @IdHouse
GO

ALTER TABLE PAPERLESS_USUARIO1_EXCEPCIONES add TieneExcepciones bit 
GO
ALTER TABLE PAPERLESS_USUARIO1_EXCEPCIONES add TipoExcepcion bigint null 
GO
ALTER TABLE PAPERLESS_USUARIO1_EXCEPCIONES add TipoResponsabilidad bigint null 
GO


CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2]
@TieneExcepciones bit,
@TipoExcepcion bigint,
@TipoResponsabilidad bigint,
@IdExcepcion bigint
AS
UPDATE PAPERLESS_USUARIO1_EXCEPCIONES
SET TieneExcepciones = @TieneExcepciones,TipoExcepcion=@TipoExcepcion, TipoResponsabilidad=@TipoResponsabilidad
WHERE Id = @IdExcepcion
GO


CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2]
@IdExcepcion bigint
AS
select a.TieneExcepciones,
b.id as id_tipo_excepcion,
b.descripcion as descripcion_tipo_excepcion,
c.id as id_tipo_responsabilidad,
c.descripcion as descripcion_tipo_responsabilidad
from PAPERLESS_USUARIO1_EXCEPCIONES A
LEFT OUTER JOIN PAPERLESS_TIPO_EXCEPCIONES B on a.TieneExcepciones = b.id
LEFT OUTER JOIN PAPERLESS_TIPO_RESPONSABILIDAD c on a.TipoResponsabilidad = c.id
where A.id=@IdExcepcion
GO


ALTER PROCEDURE "dbo"."SP_C_PAPERLESS_USUARIO1_EXCEPCIONES" 
@IdAsignacion bigint

AS

SELECT 
PE.Id,
PE.IdAsignacion,
IdHouseBL,
RecargoCollect,
RecargoCollectResuelto,
SobrevalorPendiente,
SobrevalorPendienteResuelto,
AvisoNoEnviado,
AvisoNoEnviadoResuelto,
PH.IdCliente,
PH.IdTipoCliente , TC.Descripcion TipoCliente,
PH.Freehand,
PH.HouseBL,
PH.IndexHouse
FROM PAPERLESS_USUARIO1_EXCEPCIONES PE
INNER JOIN PAPERLESS_USUARIO1_HOUSESBL PH
ON PH.Id = PE.IdHouseBL
INNER JOIN CLIENTES_MASTER_TIPO_CLIENTE TC
ON PH.IdTipoCliente = TC.Id
WHERE PE.IdAsignacion = @IdAsignacion
ORDER BY IdHouseBL
