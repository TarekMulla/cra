ALTER TABLE usuarios add SemanasCalendarioCompartido bigint
GO

update usuarios set SemanasCalendarioCompartido=3
GO

ALTER PROCEDURE [dbo].[SP_C_CALENDARIO_VISITAS]
@FechaDesde datetime,
@FechaHasta datetime,
@IdEstadoVisita int,
@IdUsuario int,
@IdCategoria int
AS

IF @IdEstadoVisita = -1 set @IdEstadoVisita = NULL
IF @IdUsuario = -1 set @IdUsuario = NULL
IF @IdCategoria = -1 set @IdCategoria = NULL

IF @IdEstadoVisita IS NULL AND @IdCategoria IS NULL
begin	

	select distinct
	CV.Id, 
	CV.Asunto, 
	CV.Ubicacion, 
	CV.FechaHoraComienzo, 
	CV.FechaHoraTermino,
	CV.IdCliente,
	CV.IdVendedor,
	CV.Descripcion, 
	CV.NivelImportancia, 
	CV.EsRecurrente, 
	CV.IdEstado,
	CV.IdUsuario,
	CE.EstadoCalendario
	from dbo.CALENDARIO_VISITA CV
	inner join CALENDARIO_VISITA_ESTADO CE
	on CV.IdEstado = CE.Id
	inner join CALENDARIO_VISITA_ASISTENTE VA
	on VA.IdVisita = CV.Id
    LEFT OUTER JOIN CLIENTES_MASTER CM
    on CV.IdCliente = CM.Id
	WHERE  CV.Id > 0
	AND (
			--Visitas es asistente
			VA.IdUsuario = ISNULL(@IdUsuario,VA.IdUsuario) OR
			--Visitas vendedor principal
			CV.IdVendedor = ISNULL(@IdUsuario,CV.IdVendedor) OR
			--Visitas creadas
			CV.IdUsuario = ISNULL(@IdUsuario,CV.IdUsuario)
		)
	AND CV.IdEstado NOT IN(6) --= ISNULL(@IdEstadoVisita,CV.IdEstado)
	AND CV.FechaHoraComienzo BETWEEN @FechaDesde  and @FechaHasta
end
else if @IdEstadoVisita = 2
      begin
		select distinct
		CV.Id, 
		CV.Asunto, 
		CV.Ubicacion, 
		CV.FechaHoraComienzo, 
		CV.FechaHoraTermino,
		CV.IdCliente,
		CV.IdVendedor,
		CV.Descripcion, 
		CV.NivelImportancia, 
		CV.EsRecurrente, 
		CV.IdEstado,
		CV.IdUsuario,
		CE.EstadoCalendario
		from dbo.CALENDARIO_VISITA CV
		inner join CALENDARIO_VISITA_ESTADO CE
		on CV.IdEstado = CE.Id
		inner join CALENDARIO_VISITA_ASISTENTE VA
		on VA.IdVisita = CV.Id
	    LEFT OUTER JOIN CLIENTES_MASTER CM
        on CV.IdCliente = CM.Id
        LEFT OUTER JOIN CLIENTES_CUENTA CC
        on CM.Id = CC.IdMaster
		WHERE CV.Id > 0
	    AND (
		--Visitas es asistente
			VA.IdUsuario = ISNULL(@IdUsuario,VA.IdUsuario) OR
			--Visitas vendedor principal
			CV.IdVendedor = ISNULL(@IdUsuario,CV.IdVendedor) OR
			--Visitas creadas
			CV.IdUsuario = ISNULL(@IdUsuario,CV.IdUsuario)
			)
		AND CV.IdEstado in(1,2)
        AND CC.IdCategoriaCliente = ISNULL(@IdCategoria,CC.IdCategoriaCliente)
   		AND CV.FechaHoraComienzo BETWEEN @FechaDesde  and @FechaHasta
       end
    else
       begin
		select distinct
		CV.Id, 
		CV.Asunto, 
		CV.Ubicacion, 
		CV.FechaHoraComienzo, 
		CV.FechaHoraTermino,
		CV.IdCliente,
		CV.IdVendedor,
		CV.Descripcion, 
		CV.NivelImportancia, 
		CV.EsRecurrente, 
		CV.IdEstado,
		CV.IdUsuario,
		CE.EstadoCalendario
		from dbo.CALENDARIO_VISITA CV
		inner join CALENDARIO_VISITA_ESTADO CE
		on CV.IdEstado = CE.Id
		inner join CALENDARIO_VISITA_ASISTENTE VA
		on VA.IdVisita = CV.Id
		LEFT OUTER JOIN CLIENTES_MASTER CM
        on CV.IdCliente = CM.Id
        LEFT OUTER JOIN CLIENTES_CUENTA CC
        on CM.Id = CC.IdMaster
		WHERE CV.Id > 0
	    AND (
		--Visitas es asistente
			VA.IdUsuario = ISNULL(@IdUsuario,VA.IdUsuario) OR
			--Visitas vendedor principal
			CV.IdVendedor = ISNULL(@IdUsuario,CV.IdVendedor) OR
			--Visitas creadas
			CV.IdUsuario = ISNULL(@IdUsuario,CV.IdUsuario)
			)
		AND CV.IdEstado = ISNULL(@IdEstadoVisita,CV.IdEstado) AND CV.IdEstado NOT IN(6)
		AND CC.IdCategoriaCliente = ISNULL(@IdCategoria,CC.IdCategoriaCliente )
   		AND CV.FechaHoraComienzo BETWEEN @FechaDesde  and @FechaHasta
   end
GO

ALTER PROCEDURE [dbo].[SP_C_USUARIO_POR_USERNAME]
@UserName nvarchar(50)

As

SELECT     
dbo.USUARIOS.Id, 
dbo.USUARIOS.Nombres, 
dbo.USUARIOS.ApellidoPaterno, 
dbo.USUARIOS.ApellidoMaterno, 
dbo.USUARIOS.NombreUsuario, 
dbo.USUARIOS.Estado, 
dbo.USUARIOS.FechaCreacion, 
dbo.USUARIOS.Email,
dbo.USUARIOS_CARGO.Id AS IdCargo, 
dbo.USUARIOS_CARGO.Descripcion,
dbo.USUARIOS.SemanasCalendarioCompartido
FROM dbo.USUARIOS INNER JOIN
dbo.USUARIOS_CARGO ON dbo.USUARIOS.IdCargo = dbo.USUARIOS_CARGO.Id
WHERE NombreUsuario = @UserName
GO


ALTER TABLE usuarios add SemanasMiCalendario bigint
GO

update usuarios set SemanasMiCalendario=3
GO

ALTER PROCEDURE [dbo].[SP_C_USUARIO_POR_USERNAME]
@UserName nvarchar(50)

As

SELECT     
dbo.USUARIOS.Id, 
dbo.USUARIOS.Nombres, 
dbo.USUARIOS.ApellidoPaterno, 
dbo.USUARIOS.ApellidoMaterno, 
dbo.USUARIOS.NombreUsuario, 
dbo.USUARIOS.Estado, 
dbo.USUARIOS.FechaCreacion, 
dbo.USUARIOS.Email,
dbo.USUARIOS_CARGO.Id AS IdCargo, 
dbo.USUARIOS_CARGO.Descripcion,
dbo.USUARIOS.SemanasCalendarioCompartido,
dbo.USUARIOS.SemanasMiCalendario
FROM dbo.USUARIOS INNER JOIN
dbo.USUARIOS_CARGO ON dbo.USUARIOS.IdCargo = dbo.USUARIOS_CARGO.Id
WHERE NombreUsuario = @UserName
GO
