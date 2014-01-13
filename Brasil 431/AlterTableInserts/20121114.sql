ALTER PROCEDURE "dbo"."SP_C_CLIENTE_MASTER"                                                                                             
 @busqueda nvarchar(255),                                                         
 @tipo int,                                                                                                                                 
 @IdEstado int                                         
                                                                                       
                                                                                                                                            
 AS                         
                                                                                                                  
                                                                                                                                              
  if @busqueda = '-1' set @busqueda = null                                                                                                   
 if @tipo = -1 set @tipo = null                                                                                    
 if @IdEstado = -1 set @IdEstado = null                                                                                                     
                                                                                        
                                                    
 declare @sql nvarchar(4000)                                                                                                                
                                                             
                                                                                 
 set @sql =  ' SELECT '                                                                                                                     
 set @sql += ' CLIENTES_MASTER.Id, '                                                                                                        
 set @sql += ' CLIENTES_MASTER.NombreCompania, '                                                                                            
 set @sql += ' CLIENTES_MASTER.Nombres, '                                                                                                   
 set @sql += ' CLIENTES_MASTER.ApellidoPaterno, '                                                                        
                     
 set @sql += ' CLIENTES_MASTER.ApellidoMaterno, '                                                                                           
 set @sql += ' 1,   '                                                                         
                                                
 set @sql += ' CLIENTES_CUENTA.IdEstado AS IdEstadoCuenta, '                                                                                
 set @sql += ' CLIENTES_MASTER.CodTipo,'                           
                                                                           
 set @sql += ' CLIENTES_MASTER.RUT,'                                                                                                        
 set @sql += ' CLIENTES_MASTER.NombreFantasia,'

 --por Vhspiceros
 set @sql += ' C.IdCliente, '
 set @sql += ' C.IdTipoCarga, V.Descripcion, V.Activo, '
 set @sql += ' C.IdCustomer,C.Id,'  
 set @sql += ' U.Nombres as U_nombres, U.ApellidoPaterno as u_ApellidoPaterno, U.ApellidoMaterno as u_ApellidoMaterno,'
 set @sql += ' U.Id IdCliente, U.Email' 
 -- Fin Vhspiceros

 set @sql += ' FROM CLIENTES_TARGET '                                                                                                       
 set @sql +=   '   RIGHT OUTER JOIN CLIENTES_MASTER '                                                                                         
 set @sql += ' ON CLIENTES_TARGET.IdMaster = CLIENTES_MASTER.Id '                                                              
               
 set @sql += ' LEFT OUTER JOIN CLIENTES_CUENTA '                                                                                            
 set @sql += ' ON CLIENTES_MASTER.Id = CLIENTES_CUENTA.IdMaster'                                    
--por vhspiceros
 set @sql += ' LEFT OUTER JOIN CLIENTES_TIPOCARGA C '                                                                                            
 set @sql += ' ON CLIENTES_MASTER.Id = c.idcliente '

 set @sql += ' LEFT OUTER JOIN VENTAS_TIPOS_PRODUCTO V'
 set @sql += ' ON C.IdTipoCarga = V.Id '
 set @sql += ' LEFT OUTER JOIN  USUARIOS U'
 set @sql += ' on C.IdCustomer = U.Id'
  -- fin vhspiceros
                                          
 set @sql += ' WHERE CLIENTES_MASTER.Id > 0'                                                                                                
 if(@busqueda is not null)                                               
                                                                     
    begin                                                                                                                                   
 	set @sql += ' AND ( NombreCompania like ''%'' + isnull(''' + @busqueda + ''',NombreCompania)+''%'' OR'	                                   
 	set @sql += ' Nombres like''%'' + isnull(''' + @busqueda + ''',Nombres)+''%'' OR'                                                         
 	set @sql +=   ' ApellidoPaterno like''%''+isnull('''+@busqueda+''',ApellidoPaterno)+''%'' OR'                                             
 	set @sql += ' ApellidoMaterno like''%''+isnull('''+@busqueda+''',ApellidoMaterno)+''%'''                                           
         
 	set @sql += ' )'                                                                                                                          
    end                                                                                                   
                                    
                                                                                                                                            
 -- NULL = Todos                                                               
                                                               
 -- Target = 1                                                                                                                              
 -- Cuenta = 2                                      
                                                                                          
 -- CuentaPaperless = 3                                                                                                                     
 -- Comercial = 4        
                                                                                                                     
 -- Si se quiere filtrar un tipo particular de cliente                                             
 if(@tipo is not null)                 
                                                                                                       
     begin                                                                                                                                  
         if (@tipo = 4)                                                                                                                      
             begin                                                                                                            
                
                 set @sql += ' AND CLIENTES_MASTER.CodTipo IN (1,2) '                                                                       
             end                                                                                   
                                           
         else                                                                                                                               
             begin                                                      
                                                                      
                 set @sql += ' AND CLIENTES_MASTER.CodTipo = isnull('''  +   CONVERT(NVARCHAR(2),@tipo) + ''',CLIENTES_MASTER.CodTipo)'     
             end                             
                                                                                                 
     end                                                                                                                                    
 -- Si se quiere   filtrar sólo los Target y Cuentas                             
 if(@tipo = 1 or @tipo = 2 or @tipo = 4) and @IdEstado is not null                                                                                                                
   begin                   
        set @sql += ' AND (CLIENTES_TARGET.IdEstado = isnull(' + convert(nvarchar(2),cast(@IdEstado as int)) +',CLIENTES_TARGET.IdEstado)'   
       
        set @sql += '   OR CLIENTES_CUENTA.IdEstado = isnull(' + convert(nvarchar(2),cast(@IdEstado as int)) +',CLIENTES_CUENTA.IdEstado) )'   
   end                                                                                                   
                                     
                                                                                                                                            
 set @sql += ' ORDER BY CLIENTES_MASTER.NombreCompania, '                     
                                                                
 set @sql += ' CLIENTES_MASTER.Nombres, '                                                                                                   
 set @sql += ' CLIENTES_MASTER.ApellidoPaterno, '  
                                                                                           
 set @sql += ' CLIENTES_MASTER.ApellidoMaterno'                                                                                             
                        
                                                                                                                      
 exec(@sql)