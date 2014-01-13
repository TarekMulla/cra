alter  PROCEDURE [dbo].[SP_C_PAPERLESS_NUMCONSOLIDADO]    
@numConsolidado nvarchar (100)                                    
     
AS                                                                                                                          
     
select   NumConsolidado,idasignacion from  PAPERLESS_USUARIO1_HOUSESBL_INFO where NumConsolidado = @numConsolidado   