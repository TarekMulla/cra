IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_U_PAPERLESS_PASO2_GuardarConfirmarMaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_U_PAPERLESS_PASO2_GuardarConfirmarMaster]
GO

CREATE PROCEDURE [dbo].[SP_U_PAPERLESS_PASO2_GuardarConfirmarMaster]

@IdAsignacion bigint,
@IdEstado int,
@Courier bit,
@EnDestino bit,
@MasterConfirmado bit,
@FechaMasterConfirmado datetime,
@txtCourier varchar(30),
@IdResultado INT OUTPUT,         
@Resultado VARCHAR(255) OUTPUT AS

 IF YEAR(@FechaMasterConfirmado) = 9999 
	SET @FechaMasterConfirmado = NULL  
  
  UPDATE PAPERLESS_ASIGNACION 
  SET courier= @Courier, EnDestino=@EnDestino,MasterConfirmado=@MasterConfirmado,FechaMasterConfirmado=@FechaMasterConfirmado,txtCourier = @txtCourier
  WHERE Id = @IdAsignacion     
  RETURN 0  