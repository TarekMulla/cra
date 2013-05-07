
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


insert into usuarios values ('Carolina','Delgado','','cdelgado',1,GETDATE(),16,'servicioalcliente@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (70,16,0)
insert into  USUARIOS_PERFILES values (67,15,0)
go
insert into usuarios values ('Carolina','Amaya','','camaya',1,GETDATE(),17,'operation1.colombia@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (71,17,0)
go
insert into usuarios values ('Yuliana','Calderon','','ycalderon',1,GETDATE(),16,'servicioalcliente1@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (72,17,0)
go
insert into usuarios values ('Angie','Rodriguez','','arodriguez',1,GETDATE(),16,'arodriguez@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (73,17,0)
go
insert into usuarios values ('Katherine','Camargo','','k.camargo',1,GETDATE(),16,'k.camargo@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (74,17,0)
go
insert into usuarios values ('Jose','Castrillon','','jcastrillon',1,GETDATE(),2,'jcastrillon@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (75,2,0)
go

insert into usuarios values ('Lorena','Amya','','aamaya',1,GETDATE(),2,'aamaya@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (76,2,0)
go

insert into usuarios values ('Marcela','Urueña','','muruena',1,GETDATE(),2,'muruena@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (77,2,0)
go

insert into usuarios values ('Silvia','Triana','','striana',1,GETDATE(),2,'striana@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (78,2,0)
go

insert into usuarios values ('Lina','Ochoa','','lochoa',1,GETDATE(),2,'lochoa@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (79,2,0)
go
insert into usuarios values ('Marcela','Suarez','','msuarez',1,GETDATE(),2,'msuarez@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (80,2,0)
go


insert into usuarios values ('Johana','Villamor','','jvillamor',1,GETDATE(),1,'jvillamor@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (81,1,0)
go
insert into usuarios values ('Liliana','Morales','','lmorales',1,GETDATE(),1,'lmorales@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (82,1,0)
go

insert into usuarios values ('Monica','Olaya','','ma.olaya',1,GETDATE(),1,'ma.olaya@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (83,1,0)
go

insert into usuarios values ('Osman','Palacios','','opalacios',1,GETDATE(),1,'opalacios@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (84,1,0)
go

insert into usuarios values ('Delia','Porras','','dporras',1,GETDATE(),1,'dporras@craft-colgrupajes.com.co',3,3)
insert into  USUARIOS_PERFILES values (85,1,0)
go
