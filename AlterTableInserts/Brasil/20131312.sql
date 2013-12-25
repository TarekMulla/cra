
if not exists(select * from PAPERLESS_TIPO_AGENTECAUSADOR where DESCRIPCION = 'AGENTE' )
Begin
	INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('AGENTE',1)
End
  if not exists(select * from PAPERLESS_TIPO_AGENTECAUSADOR where DESCRIPCION = 'COORDENAÇAO' )
Begin
INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('COORDENAÇAO',1)
End

if not exists(select * from PAPERLESS_TIPO_AGENTECAUSADOR where DESCRIPCION = 'PRICING' )
Begin
	INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('PRICING',1)
End
if not exists(select * from PAPERLESS_TIPO_AGENTECAUSADOR where DESCRIPCION = 'SALES (MARCAS)' )
Begin
	INSERT INTO PAPERLESS_TIPO_AGENTECAUSADOR VALUES ('SALES (MARCAS)',1)
End
 
if not exists(select * from PAPERLESS_USUARIO1_EXCEPCIONES where UsuarioCreador = 1)
Begin
	update PAPERLESS_USUARIO1_EXCEPCIONES  set UsuarioCreador=1
End
 
 if not exists(select * from PAPERLESS_USUARIO1_EXCEPCIONES_MASTER where UsuarioCreador = 1)
Begin
	update PAPERLESS_USUARIO1_EXCEPCIONES_MASTER  set UsuarioCreador=1
End
 
--Usuario 1
if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where DESCRIPCION = 'Exceções Entry Master' and idTipoCarga = 2)
Begin
	insert into PAPERLESS_PASOS_USUARIO1_V2 values (19,'Exceções Entry Master',1,18,20,2,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 20,PasoAnterior = 19,PasoSiguiente=21 where  IdPaso=19
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 21,PasoAnterior = 20,PasoSiguiente=null where  IdPaso=20
End


if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where DESCRIPCION = 'Exceções Entry Master' and idTipoCarga = 3)
Begin
	insert into PAPERLESS_PASOS_USUARIO1_V2 values (19,'Exceções Entry Master',1,18,20,3,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 20,PasoAnterior = 19,PasoSiguiente=21 where  IdPaso=57
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 21,PasoAnterior = 20,PasoSiguiente=null where  IdPaso=58
End


if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where DESCRIPCION = 'Exceções Entry Master' and idTipoCarga = 1)
Begin
	insert into PAPERLESS_PASOS_USUARIO1_V2 values (9,'Exceções Entry Master',1,8,10,1,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 10,PasoAnterior = 9,PasoSiguiente=11 where  IdPaso=29
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 11,PasoAnterior = 10,PasoSiguiente=null where  IdPaso=30
End

if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where DESCRIPCION = 'Exceções Entry Master' and idTipoCarga = 4)
Begin
	insert into PAPERLESS_PASOS_USUARIO1_V2 values (7,'Exceções Entry Master',1,6,8,4,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 8,PasoAnterior = 7,PasoSiguiente=9 where  IdPaso=37
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso= 9,PasoAnterior = 8,PasoSiguiente=null where  IdPaso=38
End


--usuario2
if not exists(select * from PAPERLESS_PASOS_USUARIO2  where DESCRIPCION = 'Exceções Master Entry' and idTipoCarga = 1)
Begin
	Insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Master Entry',1,1,3,1,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO2 set NumPaso= 3,PasoAnterior=2,PasoSiguiente=4  where IdPaso=2
	update PAPERLESS_PASOS_USUARIO2 set NumPaso = 4, PasoAnterior = 3  ,PasoSiguiente=null where IdPaso=3
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where  idTipoCarga = 2 and  DESCRIPCION = 'Exceções Master Entry')
Begin
	Insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Master Entry',1,1,3,2,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO2 set NumPaso= 3,PasoAnterior=2,PasoSiguiente=4  where IdPaso=5
	update PAPERLESS_PASOS_USUARIO2 set NumPaso = 4, PasoAnterior = 3  ,PasoSiguiente=null where IdPaso=6
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where  idTipoCarga = 3 and  DESCRIPCION = 'Exceções Master Entry')
Begin
	Insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Master Entry',1,1,3,3,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO2 set NumPaso= 3,PasoAnterior=2,PasoSiguiente=4  where IdPaso=8
	update PAPERLESS_PASOS_USUARIO2 set NumPaso = 4, PasoAnterior = 3  ,PasoSiguiente=null where IdPaso=9
End

if not exists(select * from PAPERLESS_PASOS_USUARIO2 where  idTipoCarga = 4 and  DESCRIPCION = 'Exceções Master Entry')
Begin
	Insert into PAPERLESS_PASOS_USUARIO2 values (2,'Exceções Master Entry',1,1,3,4,'RegistrarExcepcionesMaster')
	update PAPERLESS_PASOS_USUARIO2 set NumPaso= 3,PasoAnterior=2,PasoSiguiente=4  where IdPaso=11
	update PAPERLESS_PASOS_USUARIO2 set NumPaso = 4, PasoAnterior = 3  ,PasoSiguiente=null where IdPaso=12
End


update PAPERLESS_TIPO_RESPONSABILIDAD set Tipo = '0' where Tipo is not null

if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where  idTipoCarga = 1 and  DESCRIPCION = 'Exceções Entry')
Begin
	insert into PAPERLESS_PASOS_USUARIO1_V2  values (10,'Exceções Entry',1,9,11,	1,	'RegistrarExcepciones')
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso=11, PasoAnterior = 10 , PasoSiguiente=12 , pantalla=null where IdPaso= 29
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso=12, PasoAnterior = 11 , PasoSiguiente=null where IdPaso= 30
END

if not exists(select * from PAPERLESS_PASOS_USUARIO1_V2 where  idTipoCarga = 4 and  DESCRIPCION = 'Exceções Entry')
Begin
	insert into PAPERLESS_PASOS_USUARIO1_V2  values (8,'Exceções Entry',1,7,9,	4,	'RegistrarExcepciones')
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso=9, PasoAnterior = 8 , PasoSiguiente=10 , pantalla=null where IdPaso= 37
	update PAPERLESS_PASOS_USUARIO1_V2 set NumPaso=10, PasoAnterior = 9 , PasoSiguiente=null where IdPaso= 38
end

