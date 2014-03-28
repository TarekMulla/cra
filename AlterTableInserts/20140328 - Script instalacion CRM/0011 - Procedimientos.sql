/*
Script generado por Aqua Data Studio 9.0.11 en mar-27-2014 10:15:36 PM
Base de datos: scctest
Esquema: dbo
Objetos: PROCEDURE
*/
DROP PROCEDURE [dbo].[SP_N_CLIENTES_FOLLOW_UP]
GO
DROP PROCEDURE [dbo].[SP_E_CLIENTES_FOLLOW_UP]
GO
DROP PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDTARGET]
GO
DROP PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDSLEAD]
GO
DROP PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDINFORME]
GO
DROP PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDCOTIZACION]
GO
DROP PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_ID]
GO
DROP PROCEDURE [dbo].[SP_A_CLIENTES_FOLLOW_UP]
GO

CREATE PROCEDURE [dbo].[SP_A_CLIENTES_FOLLOW_UP]
@Id bigint,
@FechaFollowUp datetime,
@IdTipoActividadSiguiente int,
@Descripcion nvarchar(4000),
@Activo bit
AS

UPDATE CLIENTES_FOLLOW_UP SET
FechaFollowUp = @FechaFollowUp,
IdTipoActividadSiguiente = @IdTipoActividadSiguiente,
Descripcion = @Descripcion,
activo = @Activo
WHERE Id = @Id

GO
CREATE PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_ID]
@IdCliente bigint

AS

SELECT 
A.Id,
FechaFollowUp ,
B.Id IdActividad,
B.Descripcion Actividad,
B.Alias Alias,
A.Descripcion,
A.FechaCreacion,
C.Id IdUsuario,
C.Nombres,
C.ApellidoPaterno,
C.ApellidoMaterno,
A.IdClienteMaster,
A.IdLlamadaTelefonica,
A.IdInformeVisita,
A.idtarget,
A.activo ,
A.idSLead
FROM CLIENTES_FOLLOW_UP A
LEFT OUTER JOIN VENTAS_TIPO_ACTIVIDAD B
ON A.IdTipoActividadSiguiente = B.Id
INNER JOIN USUARIOS C
ON A.IdUsuario = C.Id
WHERE A.IdClienteMaster = @IdCliente

GO
CREATE PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDCOTIZACION]
	@idCotizacion bigint
AS
begin
	SELECT 
	A.Id,
	FechaFollowUp ,
	B.Id IdActividad,
	B.Descripcion Actividad,
	B.Alias Alias,
	A.Descripcion,
	A.FechaCreacion,
	C.Id IdUsuario,
	C.Nombres,
	C.ApellidoPaterno,
	C.ApellidoMaterno,
	A.IdClienteMaster,
	A.IdLlamadaTelefonica,
	A.IdInformeVisita,
	A.idtarget,
	A.activo ,
	A.idCotizacion
	FROM CLIENTES_FOLLOW_UP A
	LEFT OUTER JOIN VENTAS_TIPO_ACTIVIDAD B
	ON A.IdTipoActividadSiguiente = B.Id
	INNER JOIN USUARIOS C
	ON A.IdUsuario = C.Id
	WHERE A.idCotizacion = @idCotizacion
end

GO
CREATE PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDINFORME]
@IdInforme bigint

AS

SELECT 
A.Id,
FechaFollowUp ,
B.Id IdActividad,
B.Descripcion Actividad,
B.Alias Alias,
A.Descripcion,
A.FechaCreacion,
C.Id IdUsuario,
C.Nombres,
C.ApellidoPaterno,
C.ApellidoMaterno,
A.IdClienteMaster,
A.IdLlamadaTelefonica,
A.IdInformeVisita,
A.idtarget,
A.activo ,
A.idSLead
FROM CLIENTES_FOLLOW_UP A
LEFT OUTER JOIN VENTAS_TIPO_ACTIVIDAD B
ON A.IdTipoActividadSiguiente = B.Id
INNER JOIN USUARIOS C
ON A.IdUsuario = C.Id
WHERE A.IdInformeVisita = @IdInforme
GO
CREATE PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDSLEAD]
@IdSLead bigint

AS

SELECT 
A.Id,
FechaFollowUp ,
B.Id IdActividad,
B.Descripcion Actividad,
B.Alias Alias,
A.Descripcion,
A.FechaCreacion,
C.Id IdUsuario,
C.Nombres,
C.ApellidoPaterno,
C.ApellidoMaterno,
A.IdClienteMaster,
A.IdLlamadaTelefonica,
A.IdInformeVisita,
A.idtarget,
A.activo,
A.idSLead
FROM CLIENTES_FOLLOW_UP A
LEFT OUTER JOIN VENTAS_TIPO_ACTIVIDAD B
ON A.IdTipoActividadSiguiente = B.Id
INNER JOIN USUARIOS C
ON A.IdUsuario = C.Id
WHERE A.idSLead = @IdSLead
GO
CREATE PROCEDURE [dbo].[SP_C_CLIENTES_FOLLOW_UP_POR_IDTARGET]
@IdTarget bigint

AS

SELECT 
A.Id,
FechaFollowUp ,
B.Id IdActividad,
B.Descripcion Actividad,
B.Alias Alias,
A.Descripcion,
A.FechaCreacion,
C.Id IdUsuario,
C.Nombres,
C.ApellidoPaterno,
C.ApellidoMaterno,
A.IdClienteMaster,
A.IdLlamadaTelefonica,
A.IdInformeVisita,
A.idtarget,
A.activo ,
a.idSLead
FROM CLIENTES_FOLLOW_UP A
LEFT OUTER JOIN VENTAS_TIPO_ACTIVIDAD B
ON A.IdTipoActividadSiguiente = B.Id
INNER JOIN USUARIOS C
ON A.IdUsuario = C.Id
WHERE A.idtarget = @IdTarget
GO
CREATE PROCEDURE [dbo].[SP_E_CLIENTES_FOLLOW_UP]
@Id bigint
as
delete from CLIENTES_FOLLOW_UP where id = @id

GO
CREATE PROCEDURE [dbo].[SP_N_CLIENTES_FOLLOW_UP]
@IdInformeVisita bigint,
@IdLlamadaTelefonica bigint,
@FechaFollowUp datetime,
@IdTipoActividadSiguiente int,
@IdClienteMaster bigint,
@Descripcion nvarchar(4000),
@FechaCreacion datetime,
@IdUsuario int,
@IdTarget bigint,
@activo bit,
@idSlead int,
@idCotizacion bigint,
 @id bigint OUTPUT
AS
begin
	IF @IdInformeVisita = -1 SET @IdInformeVisita = NULL
	IF @IdLlamadaTelefonica = -1 SET @IdLlamadaTelefonica= NULL
	IF @IdTarget = -1 SET @IdTarget = NULL
	IF @idSlead  = -1 set @idSlead  = NULL
	IF @idCotizacion  = -1 set @idCotizacion  = NULL

	IF @IdClienteMaster = -1 SET @IdClienteMaster = NULL
	IF @IdTipoActividadSiguiente = -1 SET @IdTipoActividadSiguiente = NULL

	INSERT INTO CLIENTES_FOLLOW_UP(IdInformeVisita,IdLlamadaTelefonica,FechaFollowUp,IdTipoActividadSiguiente,
								   IdClienteMaster,Descripcion,FechaCreacion,IdUsuario,idtarget,activo,idSLead,idCotizacion)
	VALUES(
	@IdInformeVisita,@IdLlamadaTelefonica,@FechaFollowUp,@IdTipoActividadSiguiente,
	@IdClienteMaster,@Descripcion,@FechaCreacion,@IdUsuario,@idtarget,@activo,@idSLead,@idCotizacion
	)
	select @id = SCOPE_IDENTITY()
	select @id
end

GO

