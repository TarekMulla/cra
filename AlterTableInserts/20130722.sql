
select * from Paperless_IntegracionNetship
drop table PAPERLESS_INT_NETSHIP_TIPO_ERROR
go
create table PAPERLESS_INT_NETSHIP_TIPO_ERROR
(
id bigint not null identity (1,1) primary key,
DescripcionBreve varchar (50),
DescripcionCompleta varchar (100) 
)

go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
(
'Rut en Blanco -> Registro Varios',
'VARIOS cuando el cliente no esté creado en el sistema,si no viene rut , registro debe ser varios'
)
go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('No viene Numero de Consolidada','No viene Numero de Consolidada')
go

insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('Paperless Doble Definicion = null, sino NetShip',
'Será el cliente que tenga paperless, al momento de la carga, sino carga nada queda NetShip')
go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('No se encontro Numero Master','No se encontro Numero Master')
go

insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('Existe una diferencia entre los valores de hbls','Existe una diferencia entre los valores de hbls')
go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values (
'rut no existe, se Crea Cliente tipo Paperless',
'si el rut no existe debe crear un nuevo cliente,de tipo paperless con la info que envia NetShip'
)
go


select  *from PAPERLESS_INT_NETSHIP_TIPO_ERROR