ALTER Procedure [dbo].[SP_N_Cotizacion_Tarifas]
    @IDCotizacion		bigint,
	@Fecha				datetime,
	@FechaValidezInicio	datetime,
	@FechaValidezFin	datetime,
	@Agente				varchar (150),
	@ComentarioCotizacion	varchar(500),
	@ComentarioInterno	varchar(500),
	@IdEstado			bigint,
	@CreateDate			datetime,
	@numero				varchar(100),
	@ID bigint OUTPUT
AS
Begin
      SET NOCOUNT ON
      insert into Cotizacion_Tarifas
(IDCotizacion,
Fecha,
FechaValidezInicio,
FechaValidezFin,
Agente,
ComentarioCotizacion,
ComentarioInterno,
IdEstado,
CreateDate,
numero)
values 
(@IDCotizacion,
@Fecha,
@FechaValidezInicio,
@FechaValidezFin,
@Agente,
@ComentarioCotizacion,
@ComentarioInterno,
@IdEstado,
@CreateDate,
@numero)
  
select @ID = SCOPE_IDENTITY()
SELECT SCOPE_IDENTITY()

End