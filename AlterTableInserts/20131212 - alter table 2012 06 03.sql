alter table CLIENTES_MASTER_TIPO_CLIENTE add idClienteTipoRelacion bigint
go
update CLIENTES_MASTER_TIPO_CLIENTE set idClienteTipoRelacion =14 where Id = 1
go
update CLIENTES_MASTER_TIPO_CLIENTE set idClienteTipoRelacion =12  where Id = 2
go



insert PANEL_CONTROL (NOMBRE,XML_FILE) values ('panel Papperless','panel1.xml')
GO

update PERFILES set ID_PANEL=null
GO

update PERFILES set id_panel = 1 where Id in (
select ID_PERFIL from USUARIO_PERFIL, USUARIOS 
where USUARIO_PERFIL.ID_USUARIO=USUARIOS.Id
and NombreUsuario in ('pcabrera','gjarpa'))
GO
