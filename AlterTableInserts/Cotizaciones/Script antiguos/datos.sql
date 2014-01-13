DELETE FROM Cotizacion_Items;
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( '20’ Estándar', '');
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( '20’ Reefer', '');
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( '40’ Estándar', '');
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( '40’ High Cube', '');
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( '40’ Reefer', '');
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( '40’ Reefer High Cube', '');
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( '40’ Open Top', '');
INSERT INTO Cotizacion_Items (Nombre, Descripcion) VALUES ( 'Proyecto u otros', '');


DELETE FROM Cotizacion_Tipos;
INSERT INTO Cotizacion_Tipos (Nombre) VALUES ('Directa');
INSERT INTO Cotizacion_Tipos (Nombre) VALUES ('Solicitud de tarifa');

DELETE FROM COTIZACION_ESTADOS ;
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Ingresado','Vendedor envía solicitud a Pricing');
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('En proceso','Pricing recibe la solicitud');
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Tarifadisponible','Pricing retorna con respuesta'); 
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Enviada al cliente','Respondido a Cliente'); 
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Reevaluación','Rechazada momentáneamente por X motivo');
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Perdido (tarifa)','Rechazada definitivamente 1');
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Perdido (otros)','Rechazada definitivamente 2');
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Cerrado','Cliente cierra con nosotros');
insert into COTIZACION_ESTADOS (Nombre, Descripcion) values ('Cerrado LCL','Cliente cierra con nosotros pero no como FCL');


--por si acaso.
update Cotizacion_Items set Descripcion = '20’ Estándar' where ID = 1
update Cotizacion_Items set Descripcion = '20’ Reefer' where ID = 2
update Cotizacion_Items set Descripcion = '40’ Estándar' where ID = 3
update Cotizacion_Items set Descripcion = '40’ High Cube' where ID = 4
update Cotizacion_Items set Descripcion = '40’ Reefer' where ID = 5
update Cotizacion_Items set Descripcion = '40’ Reefer High Cube' where ID = 6
update Cotizacion_Items set Descripcion = '40’ Open Top' where ID = 7
update Cotizacion_Items set Descripcion = 'Proyecto u otros' where ID = 8


truncate table Cotizacion_Monedas
go


insert into Cotizacion_Monedas values ('USD')
insert into Cotizacion_Monedas values ('EUR')
insert into Cotizacion_Monedas values ('CLP')

go

insert perfiles (nombre,fechacreacion,id_panel) values('Usuario pricing',getdate(),null)
go

insert into usuarios_perfiles (id_usuario,id_perfil,prioridad) values((select top 1 id from dbo.USUARIOS where USUARIOS.NombreUsuario='ywang'),(select max(id) from dbo.PERFILES),0)
GO
insert into usuarios_perfiles (id_usuario,id_perfil,prioridad) values((select top 1 id from dbo.USUARIOS where USUARIOS.NombreUsuario='pbeltran'),(select max(id) from dbo.PERFILES),0)
GO


insert into Cotizacion_ItemsTarifas values ('Transporte Terrestre','Transporte Terrestre')
insert into Cotizacion_ItemsTarifas values ('Transporte Maritimo','Transporte Maritimo')
insert into Cotizacion_ItemsTarifas values ('THC Destino','THC Destino')
insert into Cotizacion_ItemsTarifas values ('Agente','Agente')
insert into Cotizacion_ItemsTarifas values ('Drayage','Drayage')
insert into Cotizacion_ItemsTarifas values ('Gasto de Consolidacion','Gasto de Consolidacion')
go