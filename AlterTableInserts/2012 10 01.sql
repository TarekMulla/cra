/****** Object:  StoredProcedure [dbo].[SP_U_PARAM_COMUNA]    Script Date: 09/29/2012 16:46:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[SP_U_PARAM_COMUNA] 
@IdComuna int,
@IdRegion int,
@Descripcion varchar (100)

as

update PARAM_COMUNA set  IdCiudad=@IdRegion, descripcion = rtrim(ltrim(@Descripcion))
where id=@IdComuna

--select * from PARAM_COMUNA where id = 2
--select * from PARAM_CIUDAD where Id = 2

--id es reg de la comuna
--idCiudad es la region
--descripcion nombre de la comuna






/****** Object:  StoredProcedure [dbo].[SP_N_PARAM_COMUNA]    Script Date: 09/29/2012 16:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SP_N_PARAM_COMUNA]
@IdCiudad int,
@Descripcion varchar (100)
as

declare @Existe int 
select @Existe = (select 1 from PARAM_COMUNA  where descripcion =  rtrim(ltrim (@Descripcion)))
if (@Existe is null)
	begin
		Insert into PARAM_COMUNA values (@IdCiudad,rtrim(ltrim(@Descripcion)))
	end
	
SELECT SCOPE_IDENTITY()





/****** Object:  StoredProcedure [dbo].[SP_N_PAPERLESS_NAVIERA]    Script Date: 09/13/2012 16:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_N_PAPERLESS_NAVIERA]
@Descripcion nvarchar(1000),
@Activo bit,
@Existe int 

AS

select @Existe = (select 1 from PAPERLESS_NAVIERA  where descripcion =  rtrim(ltrim (@Descripcion)))
if (@Existe != 1)
	begin
		INSERT INTO PAPERLESS_NAVIERA(Descripcion,Activo,FechaCreacion)
		VALUES(rtrim(ltrim(@Descripcion)),@Activo,GETDATE())
	end

SELECT SCOPE_IDENTITY()




create  procedure SP_U_PAPERLESS_NAVIERA
@Id int,
@Descripcion varchar (100)

as

update PAPERLESS_NAVIERA set Descripcion = rtrim(ltrim(@Descripcion)) 
where id=@Id





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure  [dbo].[SP_N_CLIENTES_CLIENTE_MASTER]
@NombreCompania nvarchar(255),
@Nombres nvarchar(255),
@ApPaterno nvarchar(255),
@ApMaterno nvarchar(255),
@RUT nvarchar(50), 
@CodTipo nvarchar(3),
@DireccionInfo bigint,
@TipoCliente int,
@NombreFantasia nvarchar(255),
@IdUsuario int
AS

if @DireccionInfo = -1 set @DireccionInfo = NULL

DECLARE @EXISTE INT
--SELECT @EXISTE = (SELECT top 1 1 FROM CLIENTES_MASTER WHERE RUT = @RUT AND CODTIPO = @CODTIPO)
SELECT @EXISTE = (SELECT top 1 1 FROM CLIENTES_MASTER WHERE replace (RUT,' ','') = replace (@RUT,' ','') AND CodTipo = ISNULL(@CodTipo,CodTipo))
--exec SP_C_CLIENTE_MASTER_EXISTE_RUT @RUT,@CODTIPO ,@EXISTE output
IF (@EXISTE IS NULL)
BEGIN
INSERT INTO CLIENTES_MASTER (NombreCompania,Nombres,ApellidoPaterno,ApellidoMaterno, RUT,CodTipo,FechaCreacion,IdDireccionInfo,NombreFantasia,IdUsuario)
VALUES (@NombreCompania,@Nombres,@ApPaterno,@ApMaterno, @RUT,@CodTipo,GetDate(),@DireccionInfo,@NombreFantasia,@IdUsuario)

SELECT  SCOPE_IDENTITY()
END



-- insert into PERFILES values ('Administrador de Datos Maestros',GETDATE(),null)
--insert into USUARIOS_PERFILES values (43,21,0)

ALTER PROCEDURE [dbo].[SP_L_PAPERLESS_NAVIERAALL]  

  
AS  
  
SELECT Id, Descripcion, Activo ,FechaCreacion FROM PAPERLESS_NAVIERA    