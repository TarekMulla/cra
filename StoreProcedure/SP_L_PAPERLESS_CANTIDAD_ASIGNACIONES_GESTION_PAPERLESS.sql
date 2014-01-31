ALTER PROCEDURE [DBO].[SP_L_PAPERLESS_CANTIDAD_ASIGNACIONES_GESTION_PAPERLESS]        
@USUARIO VARCHAR (20),        
@DESDE DATETIME,        
@HASTA DATETIME,      
@TIPOCARGA VARCHAR(10) ,      
@ESTADOPAPERLESS VARCHAR(10),      
@MARCA VARCHAR (20)      
      
AS          
--SP_L_PAPERLESS_CANTIDAD_ASIGNACIONES_GESTION_PAPERLESS 'ALL','11-11-2013','01-30-2014'  ,'ALL','ALL','ALL'     
        
IF YEAR(@DESDE) = 9999 SET @DESDE = NULL        
IF YEAR(@HASTA) = 9999 SET @HASTA = NULL        
        
        
DECLARE @SQL VARCHAR(4000)        
SET @SQL = 'SELECT SUM(PA.NumHousesBL ) as CANT,USUARIOS.NOMBREUSUARIO '--COUNT(*)        
SET @SQL += 'FROM PAPERLESS_ASIGNACION PA '       
 
    IF (@USUARIO <> 'ALL')   
		SET @SQL += 'INNER JOIN USUARIOS ON USUARIOS.ID = PA.'+@USUARIO+''        
    ELSE
        SET @SQL += 'INNER JOIN USUARIOS ON USUARIOS.ID = PA.USUARIO1'
        
IF (@DESDE IS NOT NULL AND @DESDE <> '')            
    SET @SQL += ' WHERE CONVERT(VARCHAR(20),PA.FECHACREACION,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@DESDE,112)+''',PA.FECHACREACION) '        
        
IF (@HASTA IS NOT NULL AND @HASTA <> '')            
    SET @SQL += ' AND CONVERT(VARCHAR(20),PA.FECHACREACION,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@HASTA,112)+''',PA.FECHACREACION) '        
      
IF (@TIPOCARGA IS NOT NULL AND @TIPOCARGA <> '')   
     IF (@TIPOCARGA <> 'ALL')       
		SET @SQL += ' AND  IdTipoCarga  = ' + @TIPOCARGA + ' '        
        
IF (@ESTADOPAPERLESS IS NOT NULL AND @ESTADOPAPERLESS <> '') 
       IF (@ESTADOPAPERLESS <> 'ALL')     
		SET @SQL += ' AND  IdEstado  =' + @ESTADOPAPERLESS + ' '        
        
IF (@MARCA IS NOT NULL AND @MARCA <> '')     
	if   (@marca <> 'ALL') 
		SET @SQL += ' AND  Empresa  =''' + @MARCA + ''' '       
            
SET @SQL += ' GROUP BY USUARIOS.NOMBREUSUARIO '        
 ---------------------UNION--------------------------------------  
IF (@USUARIO='ALL')   
 Begin
		SET @SQL += 'UNION SELECT SUM(PA.NumHousesBL ) as CANT,USUARIOS.NOMBREUSUARIO '--COUNT(*)        
		SET @SQL += 'FROM PAPERLESS_ASIGNACION PA '       
		 
			IF (@USUARIO <> 'ALL')   
				SET @SQL += 'INNER JOIN USUARIOS ON USUARIOS.ID = PA.'+@USUARIO+''     
			ELSE
	   			SET @SQL += 'INNER JOIN USUARIOS ON USUARIOS.ID = PA.USUARIO2'    

		        
		IF (@DESDE IS NOT NULL AND @DESDE <> '')            
			SET @SQL += ' WHERE CONVERT(VARCHAR(20),PA.FECHACREACION,112) >= ISNULL('''+CONVERT(NVARCHAR(20),@DESDE,112)+''',PA.FECHACREACION) '        
		        
		IF (@HASTA IS NOT NULL AND @HASTA <> '')            
			SET @SQL += ' AND CONVERT(VARCHAR(20),PA.FECHACREACION,112) <= ISNULL('''+CONVERT(NVARCHAR(20),@HASTA,112)+''',PA.FECHACREACION) '        
		      
		IF (@TIPOCARGA IS NOT NULL AND @TIPOCARGA <> '')   
			 IF (@TIPOCARGA <> 'ALL')       
				SET @SQL += ' AND  IdTipoCarga  = ' + @TIPOCARGA + ' '        
		        
		IF (@ESTADOPAPERLESS IS NOT NULL AND @ESTADOPAPERLESS <> '') 
			   IF (@ESTADOPAPERLESS <> 'ALL')     
				SET @SQL += ' AND  IdEstado  =' + @ESTADOPAPERLESS + ' '        
		        
		IF (@MARCA IS NOT NULL AND @MARCA <> '')     
			if   (@marca <> 'ALL') 
				SET @SQL += ' AND  Empresa  =''' + @MARCA + ''' '       
		           
SET @SQL += ' GROUP BY USUARIOS.NOMBREUSUARIO '       
END
PRINT @SQL        
        
EXECUTE(@SQL) 