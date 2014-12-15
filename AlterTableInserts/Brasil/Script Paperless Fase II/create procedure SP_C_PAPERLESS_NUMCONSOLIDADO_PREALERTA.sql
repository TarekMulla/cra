CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_NUMCONSOLIDADO_PREALERTA]  
@numConsolidado nvarchar (100)                                  
   
AS                                                                                                                        
   
select NumConsolidada
from PAPERLESS_PREALERTA
where NumConsolidada = @numConsolidado 