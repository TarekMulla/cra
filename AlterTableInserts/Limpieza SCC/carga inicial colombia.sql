
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