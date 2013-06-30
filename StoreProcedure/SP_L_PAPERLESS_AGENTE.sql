SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_L_PAPERLESS_AGENTE] 

@Activo bit 


AS 


SELECT Id, 

Descripcion, 

Activo,

Contacto,

EMail,
Alias

FROM PAPERLESS_AGENTE 

WHERE Activo = @Activo 

order by Descripcion 
