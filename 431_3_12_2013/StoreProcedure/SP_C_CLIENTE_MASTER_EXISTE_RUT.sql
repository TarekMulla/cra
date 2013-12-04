ALTER procedure  [dbo].[SP_C_CLIENTE_MASTER_EXISTE_RUT]
@RUT nvarchar(255),
@TipoCliente int

AS

if @TipoCliente = -1 set @TipoCliente = NULL

SELECT 1 FROM CLIENTES_MASTER
WHERE replace (RUT,' ','') = replace (@RUT,' ','')
AND CodTipo = ISNULL(@TipoCliente,CodTipo)