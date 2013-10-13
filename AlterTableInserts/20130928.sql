
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
 
 if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_TIPO_CARGA' and name = 'DescripcionLarga')
Begin
	alter table PAPERLESS_TIPO_CARGA add DescripcionLarga varchar (20) 	
END