
insert into PARAM_PAIS values ('Colombia')
go

insert into PARAM_CIUDAD values (2,'Bogota',null)
insert into PARAM_CIUDAD values (2,'Medellin',null)
go

insert into PARAM_COMUNA  values (14,'Bogota')
insert into PARAM_COMUNA  values (15,'Medellin')
go

delete from VENTAS_TIPOS_TRAFICO
go
insert into VENTAS_TIPOS_TRAFICO values
('Europa - Buenaventura',GETDATE(),'2063-04-08 10:01:39.907')
insert into VENTAS_TIPOS_TRAFICO values
('Asia - Buenaventura',GETDATE(),'2063-04-08 10:01:39.907')
go

insert into usuarios values ('Adriana','Cardenas','','acardenas',1,GETDATE(),5,'acardenas@craft-colgrupajes.com.co',3,3)
insert into usuarios values ('Erika','Martinez','','emartinez',1,GETDATE(),1,'emartinez@craft-colgrupajes.com.co',3,3)
insert into usuarios values ('Jenny','Munar','','ope.asia',1,GETDATE(),19,'ope.asia@craft-colgrupajes.com.co',3,3)
insert into usuarios values ('Oscar','Zamora','','mzamora',1,GETDATE(),18,'mzamora@craft-colgrupajes.com.co',3,3)
insert into usuarios values ('Aura','Gonzalez','','agonzalez',1,GETDATE(),4,'agonzalez@craft-colgrupajes.com.co',3,3)

insert into  USUARIOS_PERFILES values (65,5,0)
insert into  USUARIOS_PERFILES values (66,1,0)
insert into  USUARIOS_PERFILES values (67,19,0)
insert into  USUARIOS_PERFILES values (68,18,0)
insert into  USUARIOS_PERFILES values (69,4,0)


update USUARIOS set Estado = 0 where Id not in (65,66,67,68,69)