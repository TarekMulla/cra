
--15:34 -16:04  --terminado el script de pasos sin validacion
/*'Resolver Excepciones'--1
'Revisar costos'--2
'Generación y envío de avisos'--3
'Confirmar Máster'--4
'Contactar Cliente'--5
'Recibir Desgloce'--6
'Envío Desglose a Chiel'--7
'Transmisión Previa'--8
'Envío Carta de Desglose'--9
'Transmisión Complementaria'--10
'Confirmacion Naviera'--11
*/

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Revisar Costos')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Revisar Costos',1,1,3,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Revisar Costos',1,1,3,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (2,'Revisar Costos',1,1,3,3,'')
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Generación y Envío de Avisos')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Generación y Envío de Avisos',1,2,4,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Generación y Envío de Avisos',1,2,4,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (3,'Generación y Envío de Avisos',1,2,4,3,'')
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

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Recibir Desglose')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (6,'Recibir Desglose',1,5,7,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (6,'Recibir Desglose',1,5,7,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (6,'Recibir Desglose',1,5,7,3,'')
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

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Confirmación Naviera')
Begin
	insert into PAPERLESS_PASOS_USUARIO2 values (10,'Confirmación Naviera',1,9,null,1,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (10,'Confirmación Naviera',1,9,null,2,'')
	insert into PAPERLESS_PASOS_USUARIO2 values (10,'Confirmación Naviera',1,9,null,3,'')
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

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Recibir Desglose' and pantalla ='')
Begin
	update PAPERLESS_PASOS_USUARIO2 set pantalla = 'AperturaEmbarcadores' where  Descripcion='Recibir Desglose'
End

if exists(select * from PAPERLESS_PASOS_USUARIO2 where Descripcion='Confirmación Naviera' and pantalla ='')
Begin
	update PAPERLESS_PASOS_USUARIO2 set pantalla = 'PresentarManifiesto' where  Descripcion='Confirmación Naviera'
End






--update PAPERLESS_PASOS_USUARIO2 set pantalla='' where pantalla is null



--select * from PAPERLESS_PASOS_USUARIO2 order by idTipoCarga,NumPaso
--sp_helptext SP_C_PAPERLESS_NUMCONSOLIDADO
--select * from PAPERLESS_ASIGNACION order by Id desc

--update PAPERLESS_ASIGNACION set Usuario1 = 44 , Usuario2 =44 where Id=5131
--select * from PAPERLESS_USUARIO2_PASOS_ESTADO  where IdAsignacion = 5131



--delete from PAPERLESS_ASIGNACION where Id > 5120




ALTER TABLE dbo.configuracion
ALTER COLUMN value VARCHAR(100) NOT NULL

go


insert into configuracion values ('Pless_Asig_Fecha_Apertura_Naviera_nombre_String','Transmisión','label asignado a la fecha de apertura navieras',GETDATE())
insert into configuracion values ('Pless_Asig_Fecha_Apertura_Naviera_Validacion_Bool','1','Se agrega la validacion de los -4 dias de la fecha ETA',GETDATE())
insert into configuracion values ('Pless_Asig_Plazo_Embarcadores_String','Plazo Desglose','label asignado a Plazo embarcadores',GETDATE())
insert into configuracion values ('Pless_User2_Contactar_Embarcador_String','Contactar Cliente','cambio label Contactar Embarcador',GETDATE())
insert into configuracion values ('Pless_User2_GridView_Embarcador_String','Cliente','cambio label grilla Embarcador por Cliente',GETDATE())

go


delete from PAPERLESS_PASOS_USUARIO1_V2 where NumPaso = 5
go

update  PAPERLESS_PASOS_USUARIO1_V2 set NumPaso = 5,PasoAnterior=4, PasoSiguiente=6 where NumPaso = 6
update  PAPERLESS_PASOS_USUARIO1_V2 set NumPaso = 6,PasoAnterior=5, PasoSiguiente=7 where NumPaso = 7
update  PAPERLESS_PASOS_USUARIO1_V2 set NumPaso = 7,PasoAnterior=6, PasoSiguiente=8 where NumPaso = 8
update  PAPERLESS_PASOS_USUARIO1_V2 set NumPaso = 8,PasoAnterior=7, PasoSiguiente=9 where NumPaso = 9
update  PAPERLESS_PASOS_USUARIO1_V2 set NumPaso = 9,PasoAnterior=8, PasoSiguiente=10 where NumPaso = 10
update  PAPERLESS_PASOS_USUARIO1_V2 set NumPaso = 10,PasoAnterior=9, PasoSiguiente=null where NumPaso = 11
go




update  PAPERLESS_PASOS_USUARIO2 set NumPaso = 11,PasoAnterior=10, PasoSiguiente=null where NumPaso = 10
go
update  PAPERLESS_PASOS_USUARIO2 set NumPaso = 10,PasoAnterior=9, PasoSiguiente=11 where NumPaso = 9
go
update  PAPERLESS_PASOS_USUARIO2 set NumPaso = 9,PasoAnterior=8, PasoSiguiente=10 where NumPaso = 8
go
update  PAPERLESS_PASOS_USUARIO2 set NumPaso = 8,PasoAnterior=7, PasoSiguiente=9 where NumPaso = 7
go

 insert into PAPERLESS_PASOS_USUARIO2 values (7,'Envío Desglose a Chile',1,6,8,1,'')
 insert into PAPERLESS_PASOS_USUARIO2 values (7,'Envío Desglose a Chile',1,6,8,2,'')
 insert into PAPERLESS_PASOS_USUARIO2 values (7,'Envío Desglose a Chile',1,6,8,3,'')
 go

insert into configuracion values ('DiasAntesFechaApertura',0,'sólo para version de chile',GETDATE())
go