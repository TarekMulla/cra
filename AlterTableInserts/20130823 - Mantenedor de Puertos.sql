ALTER TABLE puertos ADD
	activo bit  default(1)
GO

update Puertos set  activo=1
GO

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
	INSERT INTO [dbo].[Puertos]
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
	update puertos set activo=0
	WHERE codigo=@codigo
GO

drop procedure  [dbo].[SP_L_Puertos]
GO
CREATE Procedure [dbo].[SP_L_Puertos]
AS
Begin
	SET NOCOUNT ON
	select codigo,nombre,pais,codigo as puerto
	from puertos
	where activo=1
		
end 
GO

DROP procedure  [dbo].[SP_L_Puertos_por_Naviera]
GO

CREATE Procedure [dbo].[SP_L_Puertos_por_Naviera]
@idNaviera varchar(30)
AS
Begin
	SET NOCOUNT ON
	select * 
	from dbo.puertos,NAVIERA_PUERTO
	where NAVIERA_PUERTO.idNaviera=@idNaviera
	and puertos.codigo = naviera_puerto.puerto
	and activo=1
end  

GO

DROP procedure  [dbo].[SP_L_Puertos_Paises]
GO

CREATE Procedure [dbo].[SP_L_Puertos_Paises]
AS
Begin
	SET NOCOUNT ON
	select distinct pais from puertos
end  
GO


