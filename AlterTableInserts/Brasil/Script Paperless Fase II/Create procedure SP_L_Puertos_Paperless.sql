DROP PROCEDURE [dbo].[SP_L_Puertos_Paperless]
go
CREATE PROCEDURE [dbo].[SP_L_Puertos_Paperless]
AS
Begin
	SELECT id, codigo,nombre,pais,codigo as puerto
	FROM PAPERLESS_PUERTOS
	WHERE activo=1
	order by nombre ASC	
end 