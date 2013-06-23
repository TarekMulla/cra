DROP PROCEDURE [dbo].[SP_L_COTIZACION_DIRECTA_ESTADOS]      
go
CREATE Procedure [dbo].[SP_L_COTIZACION_DIRECTA_ESTADOS]      
 AS                                                            
 Begin                                                         
       SET NOCOUNT ON                                          
       select id,nombre,activo from COTIZACION_DIRECTA_ESTADOS 
 end                                                           


