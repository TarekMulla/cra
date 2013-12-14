Alter PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO1_EXCEPCIONES]  
@IdAsignacion bigint,   
@IdHouseBL bigint,   
@RecargoCollect bit,   
@RecargoCollectResuelto bit,  
@SobrevalorPendiente bit,   
@SobrevalorPendienteResuelto bit,  
@AvisoNoEnviado bit,   
@AvisoNoEnviadoResuelto bit  ,
@UsuarioUltimaMod bigint
  
AS  
  
INSERT INTO PAPERLESS_USUARIO1_EXCEPCIONES  
(IdAsignacion, IdHouseBL, RecargoCollect, RecargoCollectResuelto,  
SobrevalorPendiente, SobrevalorPendienteResuelto,AvisoNoEnviado, AvisoNoEnviadoResuelto,Estado,UsuarioUltimaMod)  
VALUES  
(@IdAsignacion, @IdHouseBL, @RecargoCollect, @RecargoCollectResuelto,  
@SobrevalorPendiente, @SobrevalorPendienteResuelto,@AvisoNoEnviado, @AvisoNoEnviadoResuelto,1,@UsuarioUltimaMod)  
  
SELECT SCOPE_IDENTITY()