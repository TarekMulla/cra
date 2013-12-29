DROP PROCEDURE [dbo].[SP_A_COTIZACION_SOLICITUD_COTIZACIONES]
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_SOLICITUD_COTIZACIONES]
         @id                               bigint,   
         @producto                         varchar(20),  
         @idUsuario                        bigint,   
         @idCliente                        bigint,   
         @nombreCliente                    varchar(45),  
         @fechaSolicitud                   datetime, 
         @idIncoterms                      bigint,   
         @commodity                        varchar(60),
         @puertoEmbarque                   varchar(100),
         @navieraReferencia                varchar(45),
         @tarifaReferencia                 varchar(45),
         @Observaciones                    varchar(500),
         @mercaderia                       varchar(45),
         @gastosLocales                    decimal,  
         @proveedorCarga                   varchar(45),  
         @credito                          varchar(45),   
         @fechaEstimadaEmbarque            varchar(45),   
         @conAgenciamento                  bit
AS
BEGIN
    UPDATE COTIZACION_SOLICITUD_COTIZACIONES
    SET 
         producto=@producto,  
         idUsuario=@idUsuario,   
         idCliente=@idCliente,   
         nombreCliente=@nombreCliente,  
         fechaSolicitud=@fechaSolicitud, 
         idIncoterms=@idIncoterms,   
         commodity=@commodity,
         puertoEmbarque=@puertoEmbarque,
         navieraReferencia=@navieraReferencia,
         tarifaReferencia=@tarifaReferencia,
         Observaciones=@Observaciones,
         mercaderia=@mercaderia,
         gastosLocales=@gastosLocales,  
         proveedorCarga=@proveedorCarga,  
         credito=@credito,   
         fechaEstimadaEmbarque=@fechaEstimadaEmbarque,   
         conAgenciamento=@conAgenciamento
    WHERE Id=@Id
END
RETURN 0

