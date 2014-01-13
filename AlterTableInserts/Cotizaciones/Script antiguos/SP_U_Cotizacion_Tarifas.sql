
if object_id('SP_U_Cotizacion_Tarifas', 'P') is not null 
       drop proc SP_U_Cotizacion_Tarifas 
GO

Create Procedure SP_U_Cotizacion_Tarifas
    @IDCotizacion		bigint,
	@Fecha				datetime,
	@FechaValidezInicio	datetime,
	@FechaValidezFin	datetime,
	@Agente				varchar (150),
	@ComentarioCotizacion	varchar(500),
	@ComentarioInterno	varchar(500),
	@IdEstado			bigint,
	@CreateDate			datetime,
	@id bigint
AS
Begin
      SET NOCOUNT ON
 
      update Cotizacion_Tarifas set
        IDCotizacion=@IDCotizacion,
        Fecha=@Fecha,
		FechaValidezInicio =@FechaValidezInicio,
		FechaValidezFin=@FechaValidezFin,
		Agente=@Agente,
		ComentarioCotizacion=@ComentarioCotizacion,
		ComentarioInterno=@ComentarioInterno,
		IdEstado=@IdEstado,
		CreateDate=@CreateDate
		where id =@id

End

GO
