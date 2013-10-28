
Create PROCEDURE [dbo].[SP_A_AGENTES]
	@clave bigint,
	@descripcion varchar(100),
	@contacto varchar(50),
	@email varchar(50),
	@alias varchar(50)   
AS  

UPDATE PAPERLESS_AGENTE
SET
Descripcion = @descripcion,  
Contacto = @contacto,  
Email = @email,
alias = @alias

WHERE Id = @clave
 
 
 