
if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacionDiff')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacionDiff int
END