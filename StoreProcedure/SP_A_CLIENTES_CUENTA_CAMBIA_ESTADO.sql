DROP PROCEDURE SP_A_CLIENTES_CUENTA_CAMBIA_ESTADO
GO
CREATE PROCEDURE SP_A_CLIENTES_CUENTA_CAMBIA_ESTADO
					@IdCuenta				int,
                    @IdEstado          int
AS

-- LK 16-03-2014 Permite activar o desactivar una cuenta
UPDATE CLIENTES_CUENTA
SET IdEstado = @IdEstado
WHERE Id = @IdCuenta

RETURN 0