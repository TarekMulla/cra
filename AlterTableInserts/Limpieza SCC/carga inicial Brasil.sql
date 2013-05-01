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