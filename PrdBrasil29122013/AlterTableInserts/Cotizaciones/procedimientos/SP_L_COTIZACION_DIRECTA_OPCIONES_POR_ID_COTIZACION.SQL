CREATE PROCEDURE SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION
	@IdCotizacion bigint
AS
BEGIN

SELECT [id]
      ,[numero]
      ,[fechaValidezInicio]
      ,[fechaValidezFin]
      ,[Naviera]
      ,[POD]
      ,[POL]
      ,[TiempoTransito]
      ,[idUsuario]
      ,[createDate]
      ,[COTIZACION_SOLICITUD_COTIZACIONES_id]
      ,[COTIZACION_DIRECTA_ESTADOS_id]
  FROM [dbo].[COTIZACION_DIRECTA_OPCIONES]
  where [COTIZACION_SOLICITUD_COTIZACIONES_id] = @IdCotizacion
END