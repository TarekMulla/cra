alter table  PAPERLESS_USUARIO1_EXCEPCIONES add  UsuarioUltimaMod bigint
go
alter table  PAPERLESS_USUARIO1_EXCEPCIONES add  Estado bit
  go


  CREATE TABLE PAPERLESS_TIPO_AGENTECAUSADOR
  (
  ID BIGINT IDENTITY  NOT NULL PRIMARY KEY,
  DESCRIPCION VARCHAR (200),
  ACTIVO BIT
  )

GO

  

INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('AGENTE',1)
INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('COORDENAÇAO',1)
INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('PRICING',1)
INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('SALES (MARCAS)',1)

go
 alter table PAPERLESS_USUARIO1_EXCEPCIONES add Causador int

go
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