DROP PROCEDURE [dbo].[SP_A_PUERTOS]
GO

CREATE PROCEDURE [dbo].[SP_A_PUERTOS]                                                                  
     @codigo varchar(10),
     @nombre varchar(100),
     @pais	varchar(100)
AS
	UPDATE [dbo].[Puertos]    
	SET[nombre] = @nombre  ,[pais] = @pais
	WHERE codigo=@codigo
GO

DROP PROCEDURE [dbo].[SP_N_PUERTOS]
GO

CREATE PROCEDURE [dbo].[SP_N_PUERTOS]                                                                  
     @codigo varchar(10),
     @nombre varchar(100),
     @pais	varchar(100)
AS
	INSERT INTO [scctest].[dbo].[Puertos]
           ([codigo]
           ,[nombre]
           ,[pais]
           ,[createDate])
	VALUES
           (@codigo
           ,@nombre
           ,@pais
           ,getdate())
GO

DROP PROCEDURE [dbo].[SP_E_PUERTOS]
GO

CREATE PROCEDURE [dbo].[SP_E_PUERTOS]                                                                  
     @codigo varchar(10)
AS
	DELETE [dbo].[Puertos]   
	WHERE codigo=@codigo
GO
