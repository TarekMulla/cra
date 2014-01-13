alter procedure  [dbo].[SP_C_CLIENTES_MASTER_POR_RUT] 
@Rut varchar (20)  AS  

SELECT [Id],[NombreCompania],[Nombres],[ApellidoPaterno],[ApellidoMaterno],[NombreFantasia],[RUT],[CodTipo]
,[FechaCreacion],[IdDireccionInfo] 
FROM [dbo].[CLIENTES_MASTER] WHERE RUT = @Rut