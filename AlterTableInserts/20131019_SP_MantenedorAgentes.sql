IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_AGENTES') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_AGENTES]
END
GO


CREATE Procedure [dbo].[SP_L_AGENTES]  
AS  

Begin  
SET NOCOUNT ON  
 
select 
 descripcion,
 Contacto,
 Email,
 alias
from PAPERLESS_AGENTE  
where Activo = 1
end 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_A_AGENTES') 
BEGIN
	drop procedure  [dbo].[SP_A_AGENTES]
END
GO


CREATE PROCEDURE [dbo].[SP_A_AGENTES]
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
 
 
GO 
----------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_E_AGENTES') 
BEGIN
	drop procedure  [dbo].[SP_E_AGENTES]
END
GO


CREATE PROCEDURE [dbo].[SP_E_AGENTES]
	@descripcion varchar(100)  
AS  

update PAPERLESS_AGENTE
set activo=0
WHERE Descripcion = @descripcion
 
GO
----------------------------