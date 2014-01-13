DROP PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES]
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES]
             @id                                    bigint,        
             @numero                                varchar(45),       
             @fechaValidezInicio                    datetime,        
             @fechaValidezFin                       datetime,        
             @Naviera                               bigint,        
             @TiempoTransito                        varchar(50),       
             @idUsuario                             bigint        
AS
BEGIN
    UPDATE COTIZACION_DIRECTA_OPCIONES
    SET 
        numero=@numero,
        fechaValidezInicio=@fechaValidezInicio,
        fechaValidezFin=@fechaValidezFin,
        Naviera=@Naviera,
        TiempoTransito=@TiempoTransito,
        idUsuario=@idUsuario
    WHERE Id=@Id
END
RETURN 0