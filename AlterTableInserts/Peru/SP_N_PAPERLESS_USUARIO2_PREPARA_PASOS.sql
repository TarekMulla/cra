Alter PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO2_PREPARA_PASOS]  
@IdAsignacion bigint  
AS  
 Declare @idCarga int 
--declare @IdAsignacion bigint     
 select @idCarga= (select top 1 idTipoCarga from PAPERLESS_ASIGNACION where Id= @IdAsignacion)  
  
 IF (SELECT COUNT(*) FROM PAPERLESS_USUARIO2_PASOS_ESTADO WHERE IdAsignacion = @IdAsignacion) = 0  
 BEGIN  
  INSERT INTO PAPERLESS_USUARIO2_PASOS_ESTADO  
  SELECT @IdAsignacion, NumPaso, 'false',null FROM PAPERLESS_PASOS_USUARIO2   where @idCarga=idTipoCarga order by idTipoCarga, NumPaso 
 END  
 
-- select * from PAPERLESS_USUARIO2_PASOS_ESTADO