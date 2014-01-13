
create table usuariosCorregidos
(
IdUsuarioAntiguo int not null,
IdUsuarioNuevo int not null,
tabla varchar (100) not null
)
go

ALTER TABLE usuariosCorregidos ADD PRIMARY KEY (IdUsuarioAntiguo, IdUsuarioNuevo,tabla)
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SP_CorrigeUsuarios]


@IdUsuarioAntiguo  int,
@IdUsuarioNuevo  int


as

declare @existeAntiguo int 
select @existeAntiguo= (select top 1 1 from USUARIOS where Id= @IdUsuarioAntiguo and Estado = 1)
if @existeAntiguo=1 
begin
 update USUARIOS set Estado = 0 where Id =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'USUARIOS')
end



select @existeAntiguo= (select top 1 1 from CALENDARIO_VISITA where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CALENDARIO_VISITA set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CALENDARIO_VISITA')
end


select @existeAntiguo= (select top 1 1 from CALENDARIO_VISITA_ASISTENTE where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CALENDARIO_VISITA_ASISTENTE set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CALENDARIO_VISITA_ASISTENTE')
end


select @existeAntiguo= (select top 1 1 from CALENDARIO_VISITA_INFORME where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CALENDARIO_VISITA_INFORME set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CALENDARIO_VISITA_INFORME')
end



select @existeAntiguo= (select top 1 1 from CALENDARIO_VISITA_INFORME_COMENTARIO where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CALENDARIO_VISITA_INFORME_COMENTARIO set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CALENDARIO_VISITA_INFORME_COMENTARIO')
end


select @existeAntiguo= (select top 1 1 from CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO')
end



select @existeAntiguo= (select top 1 1 from CLIENTES_FOLLOW_UP where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CLIENTES_FOLLOW_UP set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CLIENTES_FOLLOW_UP')
end


select @existeAntiguo= (select top 1 1 from CLIENTES_GASTOS_LOCAL where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CLIENTES_GASTOS_LOCAL set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CLIENTES_GASTOS_LOCAL')
end


select @existeAntiguo= (select top 1 1 from CLIENTES_MASTER where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CLIENTES_MASTER set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CLIENTES_MASTER')
end

select @existeAntiguo= (select top 1 1 from CLIENTES_TARIFADO where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update CLIENTES_TARIFADO set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'CLIENTES_TARIFADO')
end


select @existeAntiguo= (select top 1 1 from DIRECCION_META where IdUsuarioCierra= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update DIRECCION_META set IdUsuarioCierra = @IdUsuarioNuevo where IdUsuarioCierra =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'DIRECCION_META')
end



select @existeAntiguo= (select top 1 1 from DIRECCION_META_OBSERVACIONES where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update DIRECCION_META_OBSERVACIONES set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'DIRECCION_META_OBSERVACIONES')
end


select @existeAntiguo= (select top 1 1 from DIRECCION_SLEAD where IdUsuarioCierra= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update DIRECCION_SLEAD set IdUsuarioCierra = @IdUsuarioNuevo where IdUsuarioCierra =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'DIRECCION_SLEAD')
end


select @existeAntiguo= (select top 1 1 from DIRECCION_SLEAD_OBSERVACIONES where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update DIRECCION_SLEAD_OBSERVACIONES set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'DIRECCION_SLEAD_OBSERVACIONES')
end


select @existeAntiguo= (select top 1 1 from PAPERLESS_ASIGNACION where IdUsuarioCreacion= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update PAPERLESS_ASIGNACION set Usuario1 = @IdUsuarioNuevo where Usuario1 =@IdUsuarioAntiguo
 update PAPERLESS_ASIGNACION set Usuario2 = @IdUsuarioNuevo where Usuario2 =@IdUsuarioAntiguo
 update PAPERLESS_ASIGNACION set IdUsuarioCreacion = @IdUsuarioNuevo where IdUsuarioCreacion =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'PAPERLESS_ASIGNACION')
end


select @existeAntiguo= (select top 1 1 from PAPERLESS_ASIGNACION_RECHAZO where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update PAPERLESS_ASIGNACION_RECHAZO set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'PAPERLESS_ASIGNACION_RECHAZO')
end


select @existeAntiguo= (select top 1 1 from PAPERLESS_LOG_FECHA_APERTURA_NAVIERAS where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update PAPERLESS_LOG_FECHA_APERTURA_NAVIERAS set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'PAPERLESS_LOG_FECHA_APERTURA_NAVIERAS')
end


select @existeAntiguo= (select top 1 1 from TIPO_DESTINO_CARGA where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update TIPO_DESTINO_CARGA set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'TIPO_DESTINO_CARGA')
end



select @existeAntiguo= (select top 1 1 from TIPO_ORIGEN_CARGA where IdUsuario= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update TIPO_ORIGEN_CARGA set IdUsuario = @IdUsuarioNuevo where IdUsuario =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'TIPO_ORIGEN_CARGA')
end



select @existeAntiguo= (select top 1 1 from USUARIOS_PERFILES where ID_USUARIO= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update USUARIOS_PERFILES set ID_USUARIO = @IdUsuarioNuevo where ID_USUARIO =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'USUARIOS_PERFILES')
end


select @existeAntiguo= (select top 1 1 from VENTAS_LLAMADA_TELEFONICA where IdUsuarioCrea= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update VENTAS_LLAMADA_TELEFONICA set IdUsuarioCrea = @IdUsuarioNuevo where IdUsuarioCrea =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'VENTAS_LLAMADA_TELEFONICA')
end

select @existeAntiguo= (select top 1 1 from VENTAS_MAIL where IdUsuarioCrea= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update VENTAS_MAIL set IdUsuarioCrea = @IdUsuarioNuevo where IdUsuarioCrea =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'VENTAS_MAIL')
end


select @existeAntiguo= (select top 1 1 from VENTAS_OPORTUNIDAD where IdUsuarioIngresa= @IdUsuarioAntiguo)
if @existeAntiguo=1 
begin
 update VENTAS_OPORTUNIDAD set IdUsuarioIngresa = @IdUsuarioNuevo where IdUsuarioIngresa =@IdUsuarioAntiguo
 insert into usuariosCorregidos (IdUsuarioAntiguo,IdUsuarioNuevo,tabla) values (@IdUsuarioAntiguo,@IdUsuarioNuevo,'VENTAS_OPORTUNIDAD')
end


go



--select nombreusuario , count(*)  cant from USUARIOS group by NombreUsuario  order by cant desc
--select * from USUARIOS where NombreUsuario like  '%cfernandez%'

--kallendes
exec SP_CorrigeUsuarios 45,48
exec SP_CorrigeUsuarios 46,48
exec SP_CorrigeUsuarios 47,48
--pega
exec SP_CorrigeUsuarios 15,43
exec SP_CorrigeUsuarios 41,43
exec SP_CorrigeUsuarios 42,43
--sveliz	
exec SP_CorrigeUsuarios 17,58
exec SP_CorrigeUsuarios 51,58
--jcortez	
exec SP_CorrigeUsuarios 30,56
--mpuebla
exec SP_CorrigeUsuarios 16,57
--cfernandez
exec SP_CorrigeUsuarios 12,59
go

ALTER TABLE USUARIOS_PERFILES ADD PRIMARY KEY (ID_USUARIO, ID_PERFIL,PRIORIDAD)
go