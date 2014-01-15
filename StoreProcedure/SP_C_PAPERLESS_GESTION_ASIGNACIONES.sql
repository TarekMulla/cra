
ALTER PROCEDURE SP_C_PAPERLESS_GESTION_ASIGNACIONES    
@Desde datetime,    
@Hasta datetime,  
@Usuario varchar(20) ,   
@TipoCarga varchar(20) ,  
@EstadoPaperless varchar(20),  
@marca varchar (20)    
    
AS    
     
IF YEAR(@Desde) = 9999 set @Desde = NULL    
IF YEAR(@Hasta) = 9999 set @Hasta = NULL    
  
  
    
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
SET @SQL += 'INNER JOIN USUARIOS ON USUARIOS.ID = PA.'+@USUARIO+''   
set @sql += ' WHERE PA.Id > 0 '    
  
IF (@DESDE IS NOT NULL AND @DESDE <> '')            
    SET @SQL += ' AND CONVERT(VARCHAR(20),PA.FECHACREACION,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@DESDE,112)+''',PA.FECHACREACION) '        
        
IF (@HASTA IS NOT NULL AND @HASTA <> '')            
    SET @SQL += ' AND CONVERT(VARCHAR(20),PA.FECHACREACION,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@HASTA,112)+''',PA.FECHACREACION) '        
      
IF (@TIPOCARGA IS NOT NULL AND @TIPOCARGA <> '')      
  SET @SQL += ' AND  IdTipoCarga  = ' + @TIPOCARGA + ' '        
        
IF (@ESTADOPAPERLESS IS NOT NULL AND @ESTADOPAPERLESS <> '')      
  SET @SQL += ' AND  IdEstado  =' + @ESTADOPAPERLESS + ' '       
    
 IF (@marca IS NOT NULL AND @marca <> '')    
 SET @SQL += ' AND  Pa.empresa  = ''' + @marca + ''' ' 
    
print @sql    
execute(@sql) )  