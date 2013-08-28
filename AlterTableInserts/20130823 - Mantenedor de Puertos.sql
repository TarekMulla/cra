/*EJECUTAR SOLO UNA VEZ */
ALTER TABLE puertos ADD
	activo bit  default(1)
GO

update Puertos set  activo=1
GO

ALTER TABLE dbo.PARAM_PARAMETROS
ALTER COLUMN [Descripcion] VARCHAR(1000)
GO

/*EJECUTAR SOLO UNA VEZ */
INSERT INTO [dbo].[PARAM_PARAMETROS]
           (IdTipoParametro,
           [CodParametro]
           ,[Descripcion])
     VALUES
           (32,32
           ,'* Sujeto a aceptación de espacio y disponibilidad de equipo por parte de naviera.
* Carga IMO sujeto a aceptación de la naviera.
* Carga + unidad no debe sobrepasar peso máximo en origen.-
* Tiempo de carguío EXW no debe exceder 2 Hrs.
* Tarifa sujeta a recargos por sobrepeso.
* No cubre eventual intervención por aduana.
* Tarifa Sujeta a posibles reajustes de GRI/GRR/Bunker.')
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


DROP  PROCEDURE [dbo].[SP_A_PARAM_PARAMETROS_POR_ID]                                                                  
go

create  PROCEDURE [dbo].[SP_A_PARAM_PARAMETROS_POR_ID]                                                                  
     @id bigint,
     @descripcion varchar(1000)
AS
        UPDATE PARAM_PARAMETROS
         SET descripcion = @descripcion
        WHERE Id=@id

GO


