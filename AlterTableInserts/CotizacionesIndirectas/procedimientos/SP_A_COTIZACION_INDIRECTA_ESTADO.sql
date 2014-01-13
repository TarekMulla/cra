DROP PROCEDURE [dbo].[SP_A_COTIZACION_INDIRECTA_ESTADO]                                                                  
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_INDIRECTA_ESTADO]                                                                  
     @IdCotizacion bigint,
     @IdEstado bigint,
     @IdUsuario bigint
     
    AS
        
	DECLARE @EstadoActualCotizacion bigint
	DECLARE @IdComentario bigint
	DECLARE @comentario varchar(500)
	
	SELECT @EstadoActualCotizacion = COTIZACION_INDirecta_ESTADOS_id
	FROM COTIZACION_SOLICITUD_COTIZACIONES
	WHERE Id=@IdCotizacion
    
        UPDATE COTIZACION_SOLICITUD_COTIZACIONES
	SET COTIZACION_INDirecta_ESTADOS_id = @IdEstado
        WHERE Id=@IdCotizacion
	
	select @comentario = comentario from dbo.COTIZACION_INDIRECTA_ESTADOS where id=@IdEstado
	
	
	exec SP_N_COTIZACION_COMENTARIOS @EsHistorial = 1
								,@comentario = @comentario
								,@idUsuario =@IdUsuario
								,@idOpcion_o_Cotizacion = @idCotizacion
								,@idEstadoActual = @EstadoActualCotizacion
								,@idEstadoNuevo = @IdEstado
								,@id = @IdComentario output
GO		