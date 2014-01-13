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