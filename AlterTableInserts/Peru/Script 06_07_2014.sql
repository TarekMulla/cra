
--select * from sysobjects where XTYPE='u' and name like '%pasos%'

--select * from PAPERLESS_PASOS_USUARIO2
--select * from PAPERLESS_USUARIO2_PASOS_ESTADO --marca
--select * from PAPERLESS_TIPO_CARGA

--15:34 -16:04  --terminado el script de pasos sin validacion
/*'Resolver Excepciones'--1
'Revisar costos'--2
'Generación y envío de avisos'--3
'Confirmar Máster'--4
'Contactar Cliente'--5
'Recibir Desgloce'--6
'Transmisión Previa'--7
'Envío Carta de Desglose'--8
'Transmisión Complementaria'--9
'Confirmacion Naviera'--10
*/

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Revisar costos')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Revisar costos',1,1,3,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Revisar costos',1,1,3,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Revisar costos',1,1,3,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Generación y envío de avisos')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Generación y envío de avisos',1,2,4,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Generación y envío de avisos',1,2,4,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Generación y envío de avisos',1,2,4,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Confirmar Máster')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (4,'Confirmar Máster',1,3,5,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (4,'Confirmar Máster',1,3,5,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (4,'Confirmar Máster',1,3,5,3,'')
End


if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Contactar Cliente')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (5,'Contactar Cliente',1,4,6,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (5,'Contactar Cliente',1,4,6,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (5,'Contactar Cliente',1,4,6,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Recibir Desgloce')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (6,'Recibir Desgloce',1,5,7,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (6,'Recibir Desgloce',1,5,7,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (6,'Recibir Desgloce',1,5,7,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Transmisión Previa')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (7,'Transmisión Previa',1,6,8,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (7,'Transmisión Previa',1,6,8,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (7,'Transmisión Previa',1,6,8,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Envío Carta de Desglose')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (8,'Envío Carta de Desglose',1,7,9,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (8,'Envío Carta de Desglose',1,7,9,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (8,'Envío Carta de Desglose',1,7,9,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Transmisión Complementaria')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (9,'Transmisión Complementaria',1,8,10,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (9,'Transmisión Complementaria',1,8,10,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (9,'Transmisión Complementaria',1,8,10,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Confirmacion Naviera')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (10,'Confirmacion Naviera',1,9,null,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (10,'Confirmacion Naviera',1,9,null,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (10,'Confirmacion Naviera',1,9,null,3,'')
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Contactar Embarcador')
Begin
	delete from PAPERLESS_PASOS_USUARIO2 where Descripcion='Contactar Embarcador'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Recibir Apertura Embarcadores')
Begin
	delete from PAPERLESS_PASOS_USUARIO2 where Descripcion='Recibir Apertura Embarcadores'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='AperturaEmbarcadores')
Begin
	delete from PAPERLESS_PASOS_USUARIO2 where Descripcion='AperturaEmbarcadores'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Presentar Manifiesto')
Begin
	delete from PAPERLESS_PASOS_USUARIO2 where Descripcion='Presentar Manifiesto'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='PresentarManifiesto')
Begin
	delete from PAPERLESS_PASOS_USUARIO2 where Descripcion='PresentarManifiesto'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Confirmar Máster' and pantalla ='')
Begin
	update PAPERLESS_PASOS_USUARIO2 set pantalla = 'ConfirmarMaster' where  Descripcion='Confirmar Máster' and pantalla =''
End


if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Contactar Cliente' and pantalla ='')
Begin
	update PAPERLESS_PASOS_USUARIO2 set pantalla = 'ContactarEnbarcador' where  Descripcion='Contactar Cliente'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Recibir Desgloce' and pantalla ='')
Begin
	update PAPERLESS_PASOS_USUARIO2 set pantalla = 'AperturaEmbarcadores' where  Descripcion='Recibir Desgloce'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Confirmacion Naviera' and pantalla ='')
Begin
	update PAPERLESS_PASOS_USUARIO2 set pantalla = 'PresentarManifiesto' where  Descripcion='Confirmacion Naviera'
End






--update PAPERLESS_PASOS_USUARIO2 set pantalla='' where pantalla is null



--select * from PAPERLESS_PASOS_USUARIO2 order by idTipoCarga,NumPaso
--sp_helptext SP_C_PAPERLESS_NUMCONSOLIDADO
--select * from PAPERLESS_ASIGNACION order by Id desc

--update PAPERLESS_ASIGNACION set Usuario1 = 44 , Usuario2 =44 where Id=5131
--select * from PAPERLESS_USUARIO2_PASOS_ESTADO  where IdAsignacion = 5131



--delete from PAPERLESS_ASIGNACION where Id > 5120