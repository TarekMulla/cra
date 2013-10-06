
if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacionDiff')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacionDiff int
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacion')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacion datetime
END


if not exists(select * from syscolumns where object_name(id) = PAPERLESS_USUARIO1_EXCEPCIONES' and name = 'Resuelto')
Begin
	alter table PAPERLESS_USUARIO1_EXCEPCIONES add Resuelto bit 	
END




/*


*/