ALTER PROCEDURE [dbo].[SP_L_PAPERLESS_ASIGNACION]
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
 @nummaster nvarchar (100),
 @Shipping varchar(100)
                                                                                                      
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
 set @sql += ' PA.versionUsuario1,'
 set @sql += ' PA.txtShipping'
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
    
if(@Shipping is not null and  @Shipping <> '')                                                                                                       
    set @sql += ' AND PA.txtShipping = ISNULL(''' + @Shipping + ''',PA.txtShipping)'     
                                                                                                                               
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
