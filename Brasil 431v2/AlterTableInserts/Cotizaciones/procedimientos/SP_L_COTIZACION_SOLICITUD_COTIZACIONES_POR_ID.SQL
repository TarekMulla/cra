CREATE PROCEDURE SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_ID
	@ID bigint 
AS
BEGIN

SELECT [id]
      ,[producto]
      ,[idUsuario]
      ,[idCliente]
      ,[idTarget]
      ,[nombreCliente]
      ,[fechaSolicitud]
      ,[idIncoterms]
      ,[commodity]
      ,[puertoEmbarque]
      ,[POL]
      ,[POD]
      ,[navieraReferencia]
      ,[tarifaReferencia]
      ,[ObservacionesFijas]
      ,[Observaciones]
      ,[mercaderia]
      ,[gastosLocales]
      ,[proveedorCarga]
      ,[credito]
      ,[fechaEstimadaEmbarque]
      ,[conAgenciamento]
      ,[createDate]
      ,[COTIZACION_TIPOS_TRANSBORDOS_id]
      ,[COTIZACION_Directa_ESTADOS_id]
      ,[COTIZACION_TIPOS_id]
  FROM [dbo].[COTIZACION_SOLICITUD_COTIZACIONES]
  WHERE ID=@ID
END