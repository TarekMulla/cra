insert into PARAM_PAIS values ('Brasil')
go

insert into  PARAM_CIUDAD values (2, 'Sao Paulo',null)
insert into  PARAM_CIUDAD values (2, 'Santos',null)
go

insert into PARAM_COMUNA values (14,'Sao Paulo')
insert into PARAM_COMUNA values (14,'Santos')
go

delete from VENTAS_TIPOS_TRAFICO
go
insert into VENTAS_TIPOS_TRAFICO values 
('Europa - Santos', GETDATE(),'2063-04-08 10:01:39.907')
insert into VENTAS_TIPOS_TRAFICO values 	
('Asia - Santos', GETDATE(),'2063-04-08 10:01:39.907')

go



insert into usuarios values ('Ingryd','Kauffmann','','IKauffmann',1,GETDATE(),1,'ikauffmann@craft.com.br',3,3)
insert into usuarios values ('Maher','Nimri','','MNimri',1,GETDATE(),1,'mnimri@craft.com.br',3,3)
insert into usuarios values ('Lucas','Vingilis','','LVingilis',1,GETDATE(),1,'lvingilis@craft.com.br',3,3)
insert into usuarios values ('Bruno','Crelier','','BCrelier',1,GETDATE(),1,'bruno.crelier@agneutral.com.br',3,3)
update usuarios   set IdCargo = 5 where Id = 68
insert into usuarios values ('Paulo','Ricardo','','PRicardo',1,GETDATE(),4,'paulo.ricardo@craft.com.br',3,3)
insert into usuarios values ('Pedro','Custodio','','PCustodio',1,GETDATE(),1,'pcustodio@craft.com.br',3,3)
insert into usuarios values ('Sergio','Rodrigues','','SRodrigues',1,GETDATE(),5,'sergio.rodrigues@craft.com.br',3,3)
insert into usuarios values ('Raymond','Koch','','RKoch',1,GETDATE(),2,'raymond.koch@craft.com.br',3,3)

go

insert into  USUARIOS_PERFILES values (65,1,0)
insert into  USUARIOS_PERFILES values (66,1,0)
insert into  USUARIOS_PERFILES values (67,1,0)
insert into  USUARIOS_PERFILES values (68,5,0)
insert into  USUARIOS_PERFILES values (69,4,0)
insert into  USUARIOS_PERFILES values (70,1,0)
insert into  USUARIOS_PERFILES values (71,5,0)
insert into  USUARIOS_PERFILES values (72,2,0)
go
update USUARIOS set Estado = 0 where Id not in (65,66,67,68,69,70,71,72)
go
