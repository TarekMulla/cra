
CREATE PROCEDURE SP_A_AGENTES
	 @descripcion varchar(100),
	 @contacto varchar(50),
	 @email varchar(50),
	 @alias varchar(50)   
AS  

Declare @Id bigint

Set @Id = (Select Id From PAPERLESS_AGENTE where Descripcion = @descripcion)


UPDATE PAPERLESS_AGENTE
SET
--Descripcion = @descripcion,  
Contacto = @contacto,  
Email = @email,
alias = @alias

WHERE Id = @Id
 
 
 