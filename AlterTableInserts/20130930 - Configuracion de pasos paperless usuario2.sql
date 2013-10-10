if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_PASOS_USUARIO2' and name = 'idTipoCarga')
Begin
	ALTER TABLE PAPERLESS_PASOS_USUARIO2 ADD	idTipoCarga bigint 
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_PASOS_USUARIO2' and name = 'pantalla')
Begin
	ALTER TABLE PAPERLESS_PASOS_USUARIO2 ADD pantalla varchar(300)
END
GO

update PAPERLESS_PASOS_USUARIO2 set idTipoCarga=1 
GO


/*PROCEDIMIENTOS */

IF object_id('SP_N_PAPERLESS_USUARIO2_PREPARA_PASOS', 'p') is not null
	DROP PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO2_PREPARA_PASOS]
GO

CREATE PROCEDURE [dbo].[SP_N_PAPERLESS_USUARIO2_PREPARA_PASOS]
@IdAsignacion bigint
AS
	Declare @idCarga int 
	select @idCarga= (select top 1 idTipoCarga from PAPERLESS_ASIGNACION where Id= @IdAsignacion)

	IF (SELECT COUNT(*) FROM PAPERLESS_USUARIO2_PASOS_ESTADO WHERE IdAsignacion = @IdAsignacion) = 0
	BEGIN
		INSERT INTO PAPERLESS_USUARIO2_PASOS_ESTADO
		SELECT @IdAsignacion, NumPaso, 'false',null FROM PAPERLESS_PASOS_USUARIO2   where @idCarga=idTipoCarga
	END
GO


IF object_id('SP_C_PAPERLESS_USUARIO2_PASOS_ESTADO', 'p') is not null
	DROP PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO2_PASOS_ESTADO]
GO

CREATE PROCEDURE [dbo].[SP_C_PAPERLESS_USUARIO2_PASOS_ESTADO]
@IdAsignacion bigint
AS

	SELECT 
	PA.Id IdAsignacion,
	PU2ESTADO.NumPaso,
	PU2ESTADO.Estado,
	PU2.Descripcion,
	PU2ESTADO.Id IdPasoEstado,
	PU2ESTADO.NumPaso,
	PU2.pantalla
	FROM PAPERLESS_ASIGNACION PA
	INNER JOIN PAPERLESS_USUARIO2_PASOS_ESTADO PU2ESTADO
	ON PA.Id = PU2ESTADO.IdAsignacion
	INNER JOIN PAPERLESS_PASOS_USUARIO2 PU2
	ON PU2ESTADO.NumPaso = PU2.NumPaso and PU2.idTipoCarga=PA.idTipoCarga
	WHERE PA.Id = @IdAsignacion
	ORDER BY PA.Id, PU2ESTADO.NumPaso
GO



update PAPERLESS_PASOS_USUARIO2 set pantalla='ResolverExcepciones' where idPAso=1
update PAPERLESS_PASOS_USUARIO2 set pantalla='ContactarEnbarcador' where idPAso=2
update PAPERLESS_PASOS_USUARIO2 set pantalla='AperturaEmbarcadores' where idPAso=3
update PAPERLESS_PASOS_USUARIO2 set pantalla='PresentarManifiesto' where idPAso=4
GO