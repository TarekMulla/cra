
CREATE procedure [dbo].[SP_U_PARAM_COMUNA] 
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

go
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

go

create  PROCEDURE [dbo].[SP_N_PAPERLESS_NAVIERAV2]  
@Descripcion nvarchar(1000),  
@Activo bit   
  
AS  
  
declare @Existe int  
set @Existe = 0  
select @Existe = (select top 1 id from PAPERLESS_NAVIERA  where descripcion =  rtrim(ltrim (@Descripcion))) if (@Existe is null)  begin   INSERT INTO PAPERLESS_NAVIERA(Descripcion,Activo,FechaCreacion)  
  VALUES(rtrim(ltrim(@Descripcion)),@Activo,GETDATE())  end  
  
SELECT SCOPE_IDENTITY()  


go


ALTER PROCEDURE [dbo].[SP_N_PAPERLESS_NAVIERA]
@Descripcion nvarchar(1000),
@Activo bit

AS

INSERT INTO PAPERLESS_NAVIERA(Descripcion,Activo,FechaCreacion)
VALUES(@Descripcion,@Activo,GETDATE())


SELECT SCOPE_IDENTITY()
go


create procedure [dbo].[SP_U_PAPERLESS_NAVIERA] 

@Id int, 
@Descripcion varchar (100)  
as  

update PAPERLESS_NAVIERA set Descripcion = rtrim(ltrim(@Descripcion))  where id=@Id

go


create PROCEDURE [dbo].[SP_L_PAPERLESS_NAVIERAALL]  

  
AS  
  
SELECT Id, Descripcion, Activo ,FechaCreacion FROM PAPERLESS_NAVIERA    

go



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
IF (@CodTipo in (1,2))
Begin
	if (replace (@RUT,' ','') is not null)
	BEGIN
	SELECT @EXISTE = (SELECT top 1 1 FROM CLIENTES_MASTER WHERE replace (RUT,' ','') = replace (@RUT,' ','') AND CodTipo = ISNULL(@CodTipo,CodTipo))
	END
End 

--exec SP_C_CLIENTE_MASTER_EXISTE_RUT @RUT,@CODTIPO ,@EXISTE output
IF (@EXISTE IS NULL)
BEGIN
	INSERT INTO CLIENTES_MASTER (NombreCompania,Nombres,ApellidoPaterno,ApellidoMaterno, RUT,CodTipo,FechaCreacion,IdDireccionInfo,NombreFantasia,IdUsuario)
VALUES (@NombreCompania,@Nombres,@ApPaterno,@ApMaterno, @RUT,@CodTipo,GetDate(),@DireccionInfo,@NombreFantasia,@IdUsuario)

SELECT  SCOPE_IDENTITY()
END

go



insert into PERFILES values ('AdministradorDatosMaestros',GETDATE(),null)
insert into USUARIOS_PERFILES values (44,22,0)-- asignacion de datos maestros pbeltran
go