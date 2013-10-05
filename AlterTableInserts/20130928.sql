
if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacionDiff')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacionDiff int
END

if not exists(select * from syscolumns where object_name(id) = 'PAPERLESS_ASIGNACION' and name = 'FechaMaximaVinculacion')
Begin
	alter table PAPERLESS_ASIGNACION add FechaMaximaVinculacion datetime
END





/*

update PAPERLESS_PASOS_USUARIO1 set Descripcion = 'Exceções Entry', PasoSiguiente=20 where IdPaso=19
insert into PAPERLESS_PASOS_USUARIO1 values (20,'Envio Do Courier',1,19,null)

update PAPERLESS_PASOS_USUARIO1_V2 set Descripcion='Exceções Entry',PasoSiguiente=20 where IdPaso=19
go
insert into PAPERLESS_PASOS_USUARIO1_V2 values (20,'Envio Do Courier',1,19,null)
go

truncate table PAPERLESS_TIPO_EXCEPCIONES
go 

insert into PAPERLESS_TIPO_EXCEPCIONES values ('Shipper',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ – cnee',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ – notify',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('POL',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('POD',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Navio e viagem',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Número de embalagens',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Tipo de embalagens',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NCM',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Peso',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CBM',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Tipo de container',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Número de container',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Lacre',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Valor de frete/THC/desconsolidação/liberação',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Modalidade de frete/THC/desconsolidação/liberação',1)
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Moeda de frete/THC/desconsolidação/liberação',1)


insert into PAPERLESS_TIPO_RESPONSABILIDAD values ('Sao Paulo',1)
insert into PAPERLESS_TIPO_RESPONSABILIDAD values ('Agente',1)
insert into PAPERLESS_TIPO_RESPONSABILIDAD values ('Otro depto de neutral',1)

*/