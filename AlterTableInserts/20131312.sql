if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'UsuarioUltimaMod')
Begin
	alter table  PAPERLESS_USUARIO1_EXCEPCIONES add  UsuarioUltimaMod bigint
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'Estado')
Begin
	alter table  PAPERLESS_USUARIO1_EXCEPCIONES add  Estado bit
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'Causador')
Begin
	 alter table PAPERLESS_USUARIO1_EXCEPCIONES add Causador int
END


if not exists(select * from sysobjects where object_name(id) = 'PAPERLESS_TIPO_AGENTECAUSADOR')
begin
CREATE TABLE PAPERLESS_TIPO_AGENTECAUSADOR
  (
  ID BIGINT IDENTITY  NOT NULL PRIMARY KEY,
  DESCRIPCION VARCHAR (200),
  ACTIVO BIT
  )
end
  
  
if not exists(select * from sysobjects where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES_MASTER')
begin
	create table PAPERLESS_USUARIO1_EXCEPCIONES_MASTER
	(
	 ID bigint primary key  not null identity,
	 Idasignacion bigint, 
	 Idhousebl bigint,
	 TieneExcepcion bit,
	 Tipoexcepcion int,
	 Tiporesponsabilidad int,
	 Comentario varchar (200),
	 Resuelto bit,
	 Estado bit,
	 UsuarioUltimaModificacion Bigint ,
	 AgenteCausador int )
 end
