DROP PROCEDURE [dbo].[SP_A_COTIZACION_INDIRECTA_ASIGNA_USUARIO_PRICING]                                                                  
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_INDIRECTA_ASIGNA_USUARIO_PRICING]                                                                  
     @IdCotizacion bigint,
     @IdUsuario bigint
    AS
    
        UPDATE COTIZACION_SOLICITUD_COTIZACIONES
         SET idUsuarioPricing = @IdUsuario
        WHERE Id=@IdCotizacion
GO