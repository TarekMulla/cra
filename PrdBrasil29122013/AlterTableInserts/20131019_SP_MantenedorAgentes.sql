IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_L_AGENTES') 
BEGIN
	DROP PROCEDURE [dbo].[SP_L_AGENTES]
END
GO

Create Procedure [dbo].[SP_L_AGENTES]  
AS  

select 
Id,
descripcion,
Contacto,
Email,
alias

from PAPERLESS_AGENTE  
where Activo = 1
    
go

-----------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_A_AGENTES') 
BEGIN
	drop procedure  [dbo].[SP_A_AGENTES]
END
GO

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

go
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

IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_N_AGENTES') 
BEGIN
	drop procedure  [dbo].[SP_N_AGENTES]
END
GO

CREATE PROCEDURE [dbo].[SP_N_AGENTES]
	@descripcion varchar(100),
	@contacto varchar(50),
	@email varchar(50),
	@alias varchar(59)
AS  

 INSERT INTO [dbo].[PAPERLESS_AGENTE]
           (Descripcion,
			FechaCreacion,
			Activo,
			Contacto,
			Email,
			alias)  
 VALUES
	(@descripcion,
	getdate(),
	1,
	@contacto,
	@email,
	@alias)
           
GO