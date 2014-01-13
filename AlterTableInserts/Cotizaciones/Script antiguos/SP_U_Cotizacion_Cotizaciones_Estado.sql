Create Procedure [dbo].[SP_U_Cotizacion_Cotizaciones_Estado]
    @ID	bigint,
	@IdEstado			bigint
	
AS
Begin
      SET NOCOUNT ON
 
      update Cotizacion_Cotizaciones set IdEstado=@IdEstado where id =@id

End

