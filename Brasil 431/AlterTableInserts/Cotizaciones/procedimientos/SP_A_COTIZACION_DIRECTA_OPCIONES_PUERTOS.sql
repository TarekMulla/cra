DROP PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES_PUERTOS]
GO
CREATE PROCEDURE [dbo].[SP_A_COTIZACION_DIRECTA_OPCIONES_PUERTOS]
                 @id                              bigint,
                 @puerto                          varchar(10),
                 @tipo                            varchar(5)
        AS
BEGIN
    UPDATE COTIZACION_DIRECTA_OPCIONES_PUERTOS
    SET 
         puerto=@puerto,
         tipo=@tipo                            
    WHERE Id=@Id
END
RETURN 0

