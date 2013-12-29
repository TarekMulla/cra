if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_PASOS_USUARIO1' and name = 'idTipoCarga')
begin
	ALTER TABLE PAPERLESS_PASOS_USUARIO1 ADD	idTipoCarga bigint
end
GO

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_TIPO_EXCEPCIONES ' and name = 'Tipo')
begin
	alter table PAPERLESS_TIPO_EXCEPCIONES add Tipo varchar (20)
end
GO

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_TIPO_RESPONSABILIDAD' and name = 'Tipo')
begin
	alter table PAPERLESS_TIPO_RESPONSABILIDAD add Tipo varchar(20)
end
GO


if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_PASOS_USUARIO1_V2' and name = 'idTipoCarga')
begin 
	ALTER TABLE PAPERLESS_PASOS_USUARIO1_V2 ADD idTipoCarga bigint 
end
GO

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_PASOS_USUARIO1' and name = 'pantalla')
begin 
	ALTER TABLE PAPERLESS_PASOS_USUARIO1 ADD pantalla varchar(300)
end
GO


if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_PASOS_USUARIO1_V2' and name = 'pantalla')
begin
	ALTER TABLE PAPERLESS_PASOS_USUARIO1_V2 ADD pantalla varchar(300)
end
GO



/* DE AQUI EN ADELANTE PROCEDIMIENTOS ALMACENADOS */

IF object_id('SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS', 'p') is not null
	DROP PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS]
GO

CREATE PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS]
		@IdAsignacion bigint
	AS 

	Declare @idCarga int 
	select @idCarga= (select top 1 idTipoCarga from PAPERLESS_ASIGNACION where Id= @IdAsignacion)

	IF (SELECT COUNT(*) FROM PAPERLESS_USUARIO1_PASOS_ESTADO WHERE IdAsignacion = @IdAsignacion) = 0
	   BEGIN
			INSERT INTO PAPERLESS_USUARIO1_PASOS_ESTADO
			SELECT @IdAsignacion, NumPaso, 'false',null FROM PAPERLESS_PASOS_USUARIO1 where activo=1 and idTipoCarga=@idCarga
		END
GO

IF object_id('SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS_V2', 'p') is not null
	DROP PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS_V2]
GO

CREATE PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS_V2]
	    @IdAsignacion bigint
	AS 

	Declare @idCarga int 
	select @idCarga= (select top 1 idTipoCarga from PAPERLESS_ASIGNACION where Id= @IdAsignacion)

	IF (SELECT COUNT(*) FROM PAPERLESS_USUARIO1_PASOS_ESTADO WHERE IdAsignacion = @IdAsignacion) = 0
	   BEGIN
		INSERT INTO PAPERLESS_USUARIO1_PASOS_ESTADO
		SELECT @IdAsignacion, NumPaso, 'false',null FROM PAPERLESS_PASOS_USUARIO1_v2 where  activo=1 and idTipoCarga=@idCarga
	    END
	UPDATE PAPERLESS_ASIGNACION  set versionUsuario1 = 2 where id=@IdAsignacion and idTipoCarga=@idCarga
GO

IF object_id('SP_C_PAPERLESS_USUARIO1_PASOS_ESTADO_v2', 'p') is not null
	DROP PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_PASOS_ESTADO_v2]
GO
CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO1_PASOS_ESTADO_v2] 
	@IdAsignacion bigint

	AS
	SELECT 
	PA.Id IdAsignacion,
	PU1ESTADO.NumPaso,
	PU1ESTADO.Estado,
	PU1.Descripcion,
	PU1ESTADO.Id IdPasoEstado,
	PU1ESTADO.NumPaso,
	PU1.pantalla
	FROM PAPERLESS_ASIGNACION PA
	INNER JOIN PAPERLESS_USUARIO1_PASOS_ESTADO PU1ESTADO
	ON PA.Id = PU1ESTADO.IdAsignacion 
	INNER JOIN PAPERLESS_PASOS_USUARIO1_v2 PU1
	ON PU1ESTADO.NumPaso = PU1.NumPaso and PU1.idTipoCarga=PA.idTipoCarga
	WHERE PA.Id = @IdAsignacion
	ORDER BY PA.Id, PU1ESTADO.NumPaso

GO