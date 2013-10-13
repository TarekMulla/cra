
if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacionDiff')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacionDiff int
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacion')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacion datetime
END


if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'Resuelto')
Begin
	alter table PAPERLESS_USUARIO1_EXCEPCIONES add Resuelto bit 	
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'Resuelto_user2')
Begin
	alter table PAPERLESS_USUARIO1_EXCEPCIONES add Resuelto_user2 bit 	
END




/*


insert into  PAPERLESS_PASOS_USUARIO1_V2 values (1,	'Ingreso de Datos',	1	,NULL	,2	,2	,'IngresoDeDatos')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (2,	'Crear Manifiesto',	1	,1	,3	,2	,'CrearManifiesto')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (3,	'Cargar Copia BL',	1	,2	,4	,2	,NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (4,	'Facturar'	,		1,	3,	5	,2,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (5,	'Generar/enviar avisos'	,1,	4,	6,	2,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (6,	'Registrar Excepciones'	,1,	5,	7,	2,	'RegistrarExcepciones')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (7,	'Ingreso de MBl a Netship y contable'	,1,	6,	8,	2,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (8,	'Ingreso de invoice a netship y al contable',	1,	7,	9,	2,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (9,	'Imprimir etiquetas y BLS',	1,	8,	10,	2,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (10,	'Envio de disputa',	1,	9,	11,	2,	'EnvioDisputa')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (11,'Enviar Aviso a Usuario', 	1,	10	,NULL,	2	,'EnviarAvisoUsuario2')
go

--FAK

insert into  PAPERLESS_PASOS_USUARIO1_V2 values (1,	'Ingreso de Datos',	1	,NULL	,2	,3	,'IngresoDeDatos')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (2,	'Crear Manifiesto',	1	,1	,3	,3	,'CrearManifiesto')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (3,	'Cargar Copia BL',	1	,2	,4	,3	,NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (4,	'Facturar'	,		1,	3,	5	,3,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (5,	'Generar/enviar avisos'	,1,	4,	6,	3,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (6,	'Registrar Excepciones'	,1,	5,	7,	3,	'RegistrarExcepciones')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (7,	'Ingreso de MBl a Netship y contable'	,1,	6,	8,	3,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (8,	'Ingreso de invoice a netship y al contable',	1,	7,	9,	3,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (9,	'Imprimir etiquetas y BLS',	1,	8,	10,	3,	NULL)
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (10,	'Envio de disputa',	1,	9,	11,	3,	'EnvioDisputa')
go
insert into  PAPERLESS_PASOS_USUARIO1_V2 values (11,'Enviar Aviso a Usuario', 	1,	10	,NULL,	3	,'EnviarAvisoUsuario2')
go

--usuario 2


insert into PAPERLESS_PASOS_USUARIO2 values (1,	'Resolver Excepciones'	,1	,NULL	,2	,2	,'ResolverExcepciones')
insert into PAPERLESS_PASOS_USUARIO2 values (2,	'Contactar Embarcador'	,1	,1,	3,	2,	'ContactarEnbarcador')
insert into PAPERLESS_PASOS_USUARIO2 values (3,	'Recibir Apertura Embarcadores',	1	,2	,4	,2,	'AperturaEmbarcadores')
insert into PAPERLESS_PASOS_USUARIO2 values (4,	'Presentar Manifiesto'	,1	,3	,NULL	,2,	'PresentarManifiesto')


insert into PAPERLESS_PASOS_USUARIO2 values (1,	'Resolver Excepciones'	,1	,NULL	,2	,3	,'ResolverExcepciones')
insert into PAPERLESS_PASOS_USUARIO2 values (2,	'Contactar Embarcador'	,1	,1,	3,	3,	'ContactarEnbarcador')
insert into PAPERLESS_PASOS_USUARIO2 values (3,	'Recibir Apertura Embarcadores',	1	,2	,4	,3,	'AperturaEmbarcadores')
insert into PAPERLESS_PASOS_USUARIO2 values (4,	'Presentar Manifiesto'	,1	,3	,NULL	,3,	'PresentarManifiesto')

*/