DROP PROCEDURE SP_A_COTIZACION_DIRECTA_ESTADO
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_ESTADO]                                                                  
     @IdCotizacion bigint,
     @IdEstado bigint
AS
    /*
     1      Ingresado          (sistema) 
     2      En proceso          (sistema)
     3      Tarifa Disponible   (sistema)
     4      Enviada al cliente  (sistema)
     5      Reevaluación        (usuario)
     6      Perdido (tarifa)    (usuario)
     7      Perdido (otros)     (usuario)
     8      Cerrado             (usuario)
     9      Cerrado LCL         (usuario)
    */
                                                                                                                        
    DECLARE @EstadoActualCotizacion bigint

    SELECT @EstadoActualCotizacion = COTIZACION_Directa_ESTADOS_id
    FROM COTIZACION_SOLICITUD_COTIZACIONES
    WHERE Id=@IdCotizacion

    IF @EstadoActualCotizacion NOT IN (6,7,8,9)
    BEGIN
        UPDATE COTIZACION_DIRECTA_OPCIONES
        SET COTIZACION_DIRECTA_ESTADOS_id = @IdEstado
        WHERE COTIZACION_SOLICITUD_COTIZACIONES_id=@IdCotizacion
    
        UPDATE COTIZACION_SOLICITUD_COTIZACIONES
         SET COTIZACION_Directa_ESTADOS_id = @IdEstado
        WHERE Id=@IdCotizacion

        RETURN 0
    END
    ELSE
    BEGIN
        RETURN 1
    END
