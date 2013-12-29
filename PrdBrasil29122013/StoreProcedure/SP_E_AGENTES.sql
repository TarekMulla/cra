CREATE PROCEDURE [dbo].[SP_E_AGENTES]
	@descripcion varchar(100)  
AS  

update PAPERLESS_AGENTE
set activo=0

WHERE Descripcion = @descripcion
 