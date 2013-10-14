-- Script que sólo aplican para Brasil

--select * from PAPERLESS_PASOS_USUARIO1_v2


update PAPERLESS_PASOS_USUARIO1_v2 set pantalla = 'RegistrarExcepciones' where IdPaso in (19)
update PAPERLESS_PASOS_USUARIO1_v2 set pantalla = 'EnviarAvisoUsuario2' where IdPaso in (20)
update PAPERLESS_PASOS_USUARIO1_v2 set pantalla = null where IdPaso in (2,6,10,11)
go


--update PAPERLESS_PASOS_USUARIO1 set Descripcion = 'Exceções Entry', PasoSiguiente=20 where IdPaso=19
if not exists(select * from PAPERLESS_PASOS_USUARIO1_v2 where IdPaso=20)
Begin
	insert into PAPERLESS_PASOS_USUARIO1_v2 values (20,'Envio Do Courier',1,19,null,null,null)
End

if not exists(select * from PAPERLESS_PASOS_USUARIO1 where IdPaso=20)
Begin
	insert into PAPERLESS_PASOS_USUARIO1 values (20,'Envio Do Courier',1,19,null,null,null)
End

update PAPERLESS_PASOS_USUARIO1_V2 set Descripcion='Exceções Entry',PasoSiguiente=20 where IdPaso=19
go

truncate table PAPERLESS_TIPO_EXCEPCIONES
go 
insert into PAPERLESS_TIPO_EXCEPCIONES values ('HBL FALTANTE',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CBM',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CONSIGNEE',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ HOUSE',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ MASTER',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CONTAINER',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('DATA DO HBL',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('DATA DO MASTER',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('DESCRIÇÃO',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('EMBALAGEM',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('FALTA DE MASTER',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('FINAL DESTINATION',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('FRETE',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('MOEDA',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NCM',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NOMENCLATURA',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NOTIFY',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('ORIGEN',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('PESO',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('PORT OF LOADING',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('PORTO DE DESTINO',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('QUANTIDADE',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('RO INCOMPLETA',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('SHIPPER',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('SI INCOMPLETA',1,'LCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('TAXAS',1,'LCL')
go

insert into PAPERLESS_TIPO_EXCEPCIONES values ('Shipper',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ – cnee',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ – notify',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('POL',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('POD',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Navio e viagem',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Número de embalagens',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Tipo de embalagens',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NCM',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Peso',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CBM',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Tipo de container',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Número de container',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Lacre',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Valor de frete/THC/desconsolidação/liberação',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Modalidade de frete/THC/desconsolidação/liberação',1,'FCL')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('Moeda de frete/THC/desconsolidação/liberação',1,'FCL')
Go

insert into PAPERLESS_TIPO_EXCEPCIONES values ('HBL FALTANTE',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CBM',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CONSIGNEE',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ HOUSE',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CNPJ MASTER',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('CONTAINER',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('DATA DO HBL',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('DATA DO MASTER',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('DESCRIÇÃO',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('EMBALAGEM',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('FALTA DE MASTER',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('FINAL DESTINATION',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('FRETE',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('MOEDA',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NCM',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NOMENCLATURA',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('NOTIFY',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('ORIGEN',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('PESO',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('PORT OF LOADING',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('PORTO DE DESTINO',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('QUANTIDADE',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('RO INCOMPLETA',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('SHIPPER',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('SI INCOMPLETA',1,'FAK')
insert into PAPERLESS_TIPO_EXCEPCIONES values ('TAXAS',1,'FAK')
go

if not exists(select * from PAPERLESS_TIPO_RESPONSABILIDAD where Descripcion='AGENTE')
Begin
--LCL
	insert into PAPERLESS_TIPO_RESPONSABILIDAD values ('AGENTE',1,'LCL')
	insert into PAPERLESS_TIPO_RESPONSABILIDAD values ('COORDENAÇAO',1,'LCL')
	insert into PAPERLESS_TIPO_RESPONSABILIDAD values ('PRICING',1,'LCL')
	insert into PAPERLESS_TIPO_RESPONSABILIDAD values ('SALES (MARCAS)',1,'LCL')
END
if not exists(select * from PAPERLESS_TIPO_RESPONSABILIDAD where Descripcion='Sao Paulo')
Begin
--FCL
INSERT INTO PAPERLESS_TIPO_RESPONSABILIDAD VALUES ('SAO PAULO',1,'FCL')
INSERT INTO PAPERLESS_TIPO_RESPONSABILIDAD VALUES ('AGENTE',1,'FCL')
INSERT INTO PAPERLESS_TIPO_RESPONSABILIDAD VALUES ('OTRO DEPTO DE NEUTRAL',1,'FCL')

END


update PAPERLESS_PASOS_USUARIO2  set Descripcion = 'Exceções Entry', PasoSiguiente=3, pantalla = 'RegistrarExcepciones' where IdPaso = 2
go


update PAPERLESS_TIPO_CARGA set Descripcionlarga ='FCL RO' where Id = 1
update PAPERLESS_TIPO_CARGA set Descripcionlarga ='LCL' where Id = 2
update PAPERLESS_TIPO_CARGA set Descripcionlarga ='FAK' where Id = 3
go

if not exists(select * from PAPERLESS_TIPO_CARGA where descripcionLarga='FCL FHC')
Begin
	Insert into PAPERLESS_TIPO_CARGA values ('FCL',1,'FCL FHC')
End


--select * from PAPERLESS_PASOS_USUARIO1_V2
--select * from PAPERLESS_TIPO_CARGA

if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where idtipocarga=1 and Descripcion ='Imprimir docs e tracking')
BEGIN
	-- Para FCL RO , ID = 1
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (1,'Imprimir docs e tracking',1,null,2,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (2,'Imprimir desova (Santos)',1,1,3,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (3,'Redestinar (Santos)',1,2,4,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (4,'Conferir',1,3,5,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (5,'Transferir RO para consolidada',1,4,6,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (6,'Inserir courier number na consolidada.',1,5,7,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (7,'Inserir terminal de redestinação (Santos)',1,6,8,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (8,'Disponibilizar invoice para financeiro (Intranet)',1,7,9,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (9,'Alimentar planilha de controle de embarque',1,8,10,1,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (10,'Alimentar planilha de erros',1,9,null,1,null)
END

if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where idtipocarga=4 and Descripcion ='Imprimir docs e tracking')
BEGIN
-- Para FCL FHC , ID = 4
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (1,'Imprimir docs e tracking',1,null,2,4,'IngresoDeDatos')
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (2,'Conferir docs',1,1,3,4,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (3,'Gerar consolidada',1,2,4,4,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (4,'Enviar HBL ao cliente',1,3,5,4,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (5,'Redestinar (Santos)',1,4,6,4,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (6,'Aprovar docs para agente',1,5,7,4,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (7,'Inserir courier number na consolidada',1,6,8,4,null)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (8,'Inserir free time na consolidada',1,7,9,4,'EnviarAvisoUsuario2')
END

--select * from PAPERLESS_PASOS_USUARIO1_v2

--update PAPERLESS_PASOS_USUARIO1_v2 set pantalla  = 'EnviarAvisoUsuario2' where IdPaso=30
--update PAPERLESS_PASOS_USUARIO1_v2 set pantalla  = 'IngresoDeDatos' where IdPaso=21
update PAPERLESS_PASOS_USUARIO2 set idtipocarga = 1
go
--select * from PAPERLESS_PASOS_USUARIO2
truncate table PAPERLESS_PASOS_USUARIO2 
go 

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where idtipocarga=1 and Descripcion ='Conferencia')
BEGIN
	insert into PAPERLESS_PASOS_USUARIO2 values (1,'Conferencia',1,null,2,1, null)
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Entry',1,1,3,1,'RegistrarExcepciones')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Vinculacion',1,2,null,1,'PresentarManifiesto')
END

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where idtipocarga=2 and Descripcion ='Conferencia')
BEGIN
	insert into PAPERLESS_PASOS_USUARIO2 values (1,'Conferencia',1,null,2,2, null)
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Entry',1,1,3,2,'RegistrarExcepciones')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Vinculacion',1,2,null,2,'PresentarManifiesto')
END
if not exists(select * from PAPERLESS_PASOS_USUARIO2 where idtipocarga=3 and Descripcion ='Conferencia')
BEGIN
	insert into PAPERLESS_PASOS_USUARIO2 values (1,'Conferencia',1,null,2,3, null)
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Entry',1,1,3,3,'RegistrarExcepciones')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Vinculacion',1,2,null,3,'PresentarManifiesto')
END

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where idtipocarga=4 and Descripcion ='Conferencia')
BEGIN
	insert into PAPERLESS_PASOS_USUARIO2 values (1,'Conferencia',1,null,2,4, null)
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Entry',1,1,3,4,'RegistrarExcepciones')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Vinculacion',1,2,null,4,'PresentarManifiesto')
END



if not exists(select * from sysobjects  where name ='SP_L_PAPERLESS_TIPO_CARGA')
	BEGIN
	exec ('
		create PROCEDURE SP_L_PAPERLESS_TIPO_CARGA  
		@Activo bit  	  
		AS  	  
		SELECT  distinct  
		Id,  
		Descripcion,  
		Activo  
		FROM PAPERLESS_TIPO_CARGA  
		WHERE Activo = @Activo    ')
	END
Else 
	BEGIN
		exec ('alter PROCEDURE SP_L_PAPERLESS_TIPO_CARGA  
		@Activo bit  	  
		AS  	  
		SELECT  distinct  
		Id,  
		Descripcion,  
		Activo  
		FROM PAPERLESS_TIPO_CARGA  
		WHERE Activo = @Activo  ')  
	END

if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where idtipocarga=3 and Descripcion ='Pasta ok na planilla')
BEGIN
	--select * from PAPERLESS_PASOS_USUARIO1_V2
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (1,	'Pasta ok na planilla'	,1	,NULL	,2	,3	,'IngresoDeDatos')
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (2,	'Colocar dasta no pos it do mbl'	,1	,1	,3	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (3,	'Enviar pre-alerta para Sao Paulo'	,1	,2	,4	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (4,	'Enviar pre-alerta ao porto (o/portos)'	,1	,3	,5	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (5,	'Free time Santos (RF 5 dias Dry 7 dias)',	1,	4,	6,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (6,	'Dispoonibilizar invoices ao financiero',	1,	5,	7,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (7,	'Redestinar ao terminal (Santos)',	1	,6	,8	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (8,	'Fechamento da RO',	1,	7,	9,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (9,	'Conferir os documentos',	1	,8	,10	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (10,	'Carimbo de DTA no HBL (Santos)'	,1	,9	,11	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (11,	'Enviar hbls para Dpto DTA (Santos)'	,1	,10	,12	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (12,	'Verificar se ha carga IMO',	1,	11,	13,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (13,	'Solicitar ficha de emergencia',	1,	12,	14,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (14,	'Colocar pre-alerta na pasta confirmacao de embarque',	1,	13,	15,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (15,	'Disponibilizar pre-alerta na rede',	1,	14,	16,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (16,	'Cobrar Invoice',	1,	15,	17,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (17,	'Verificar trasbordo',	1	,16	,18	,3	,NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (18,	'Aprovar documentacao ao agente',	1,	17,	19,	3,	NULL)
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (19,	'Exceções Entry',	1,	18,	20,	3	,'RegistrarExcepciones')
	Insert into PAPERLESS_PASOS_USUARIO1_V2 values (20,	'Envio Do Courier',	1,	19,	NULL,	3,	'EnviarAvisoUsuario2')
End

if not exists(select * from sysobjects  where name ='SP_L_PAPERLESS_TIPO_CARGA_DESCRIPCION_LARGA')
	BEGIN
	exec ('
			CREATE PROCEDURE SP_L_PAPERLESS_TIPO_CARGA_DESCRIPCION_LARGA  
			@Activo bit  
			  
			AS  
			  
			SELECT  distinct  
			Id,  
			Descripcion,  
			Activo  ,
			DescripcionLarga
			FROM PAPERLESS_TIPO_CARGA  
			WHERE Activo = @Activo ') 
  END
Else
exec ('		Alter PROCEDURE SP_L_PAPERLESS_TIPO_CARGA_DESCRIPCION_LARGA  
			@Activo bit  
			  
			AS  
			  
			SELECT  distinct  
			Id,  
			Descripcion,  
			Activo  ,
			DescripcionLarga
			FROM PAPERLESS_TIPO_CARGA  
			WHERE Activo = @Activo ') 
			
			
Update PAPERLESS_PASOS_USUARIO1_V2 set pantalla='IngresoDeDatos' where NumPaso=1
go
Update PAPERLESS_PASOS_USUARIO1_V2 set pantalla='EnviarAvisoUsuario2' where PasoSiguiente is null
go
Update PAPERLESS_PASOS_USUARIO1_V2 set pantalla='RegistrarExcepciones' where Descripcion='Exceções Entry'
go
Update PAPERLESS_PASOS_USUARIO1_V2 set idtipocarga=2 where idtipocarga is null
go
--select * from PAPERLESS_PASOS_USUARIO1_V2
--select * from paperless_tipo_carga --2=3

update PAPERLESS_PASOS_USUARIO1_v2 set pantalla = 'RegistrarExcepciones' where IdPaso in (29)
go