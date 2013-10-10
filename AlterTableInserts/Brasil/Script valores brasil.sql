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



Insert into PAPERLESS_PASOS_USUARIO1_V2 values (1,'Imprimir docs e tracking',1,null,2,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (2,'Imprimir desova (Santos)',1,1,3,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (3,'Redestinar (Santos)',1,2,4,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (4,'Conferir',1,3,5,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (5,'Transferir RO para consolidada',1,4,6,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (6,'Inserir courier number na consolidada.',1,5,7,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (7,'Inserir terminal de redestinação (Santos)',1,6,8,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (8,'Disponibilizar invoice para financeiro (Intranet)',1,7,9,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (9,'Alimentar planilha de controle de embarque',1,8,10,2,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (10,'Alimentar planilha de erros',1,9,null,2,null)


update PAPERLESS_PASOS_USUARIO1_v2 set pantalla  = 'EnviarAvisoUsuario2' where IdPaso=30
update PAPERLESS_PASOS_USUARIO1_v2 set pantalla  = 'IngresoDeDatos' where IdPaso=21


insert into PAPERLESS_PASOS_USUARIO2 values (1,'Conferencia',1,null,2,2, null)
insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Entry',1,1,3,2,'RegistrarExcepciones')
insert into PAPERLESS_PASOS_USUARIO2 values (3,'Vinculacion',1,2,null,2,'PresentarManifiesto')

update PAPERLESS_TIPO_CARGA set Descripcion = 'LCL/RO' where ID= 2

insert into PAPERLESS_TIPO_CARGA values ('LCL/FH',1)

insert into PAPERLESS_PASOS_USUARIO2 values (1,'Conferencia',1,null,2,4, null)
insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Entry',1,1,3,4,'RegistrarExcepciones')
insert into PAPERLESS_PASOS_USUARIO2 values (3,'Vinculacion',1,2,null,4,'PresentarManifiesto')


Insert into PAPERLESS_PASOS_USUARIO1_V2 values (1,'Imprimir docs e tracking',1,null,2,4,'IngresoDeDatos')
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (2,'Conferir docs',1,1,3,4,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (3,'Gerar consolidada',1,2,4,4,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (4,'Enviar HBL ao cliente',1,3,5,4,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (5,'Redestinar (Santos)',1,4,6,4,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (6,'Aprovar docs para agente',1,5,7,4,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (7,'Inserir courier number na consolidada',1,6,8,4,null)
Insert into PAPERLESS_PASOS_USUARIO1_V2 values (8,'Inserir free time na consolidada',1,7,9,4,'EnviarAvisoUsuario2')


alter PROCEDURE SP_L_PAPERLESS_TIPO_CARGA  
@Activo bit  
  
AS  
  
SELECT   
Id,  
Descripcion,  
Activo  
FROM PAPERLESS_TIPO_CARGA  
WHERE Activo = @Activo  
Order by Descripcion
  