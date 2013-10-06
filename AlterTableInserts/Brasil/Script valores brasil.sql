-- Script que sólo aplican para Brasil

update PAPERLESS_PASOS_USUARIO1_v2 set pantalla = 'RegistrarExcepciones' where IdPaso in (19)
update PAPERLESS_PASOS_USUARIO1_v2 set pantalla = 'EnviarAvisoUsuario2' where IdPaso in (20)
update PAPERLESS_PASOS_USUARIO1_v2 set pantalla = null where IdPaso in (2,6,10,11)



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

update PAPERLESS_PASOS_USUARIO2  set Descripcion = 'Exceções Entry', PasoSiguiente=3, pantalla = 'RegistrarExcepciones' where IdPaso = 2
go
insert into PAPERLESS_PASOS_USUARIO2   values (3,'Vinculacion',1,2,null,1,'PresentarManifiesto')
go