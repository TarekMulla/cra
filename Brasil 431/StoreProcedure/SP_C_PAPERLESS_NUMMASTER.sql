Create PROCEDURE [dbo].[SP_C_PAPERLESS_NUMMASTER]
@numMaster nvarchar (100)                                
 
AS                                                                                                                      
 
select nummaster from PAPERLESS_ASIGNACION where NumMaster = @numMaster 