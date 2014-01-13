ALTER Procedure [dbo].[SP_L_Cotizacion_Tarifas]
 --   @IDCotizacion		bigint,
	--@Fecha				datetime,
	--@FechaValidezInicio	datetime,
	--@FechaValidezFin	datetime,
	--@Agente				varchar (150),
	--@ComentarioCotizacion	varchar(500),
	--@ComentarioInterno	varchar(500),
	--@IdEstado			bigint,
	--@CreateDate			datetime,
	@id bigint
AS
Begin
      SET NOCOUNT ON
select 
ID,
IDCotizacion,
Fecha,
FechaValidezInicio,
FechaValidezFin,
Agente,
ComentarioCotizacion,
ComentarioInterno,
IdEstado,
CreateDate
from Cotizacion_Tarifas
Where ID=@id

End
