drop table PAPERLESS_INT_NETSHIP_TIPO_ERROR
go
create table PAPERLESS_INT_NETSHIP_TIPO_ERROR
(
id bigint not null identity (1,1) primary key,
DescripcionBreve varchar (50),
DescripcionCompleta varchar (100) ,
Activo bit
)

go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
(
'Rut en Blanco -> Registro Varios',
'VARIOS cuando el cliente no est� creado en el sistema,si no viene rut , registro debe ser varios',
1
)
go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('No viene Numero de Consolidada','No viene Numero de Consolidada',
1)
go

insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('Paperless Doble Definicion = null, sino NetShip',
'Ser� el cliente que tenga paperless, al momento de la carga, sino carga nada queda NetShip',
1)
go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('No se encontro Numero Master','No se encontro Numero Master',
1)
go

insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values 
('Existe una diferencia entre los valores de hbls','Existe una diferencia entre los valores de hbls',
1)
go
insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values (
'rut no existe, se Crea Cliente tipo Paperless',
'si el rut no existe debe crear un nuevo cliente,de tipo paperless con la info que envia NetShip',
1
)
go


alter table PAPERLESS_INTEGRACIONNETSHIP add IDPaperlessTipoError bigint
go
ALTER TABLE
    PAPERLESS_INTEGRACIONNETSHIP ADD CONSTRAINT PAPERLESS_INTEGRACIONNETSHIP_IDPaperlessTipoError FOREIGN KEY (IDPaperlessTipoError)
    REFERENCES PAPERLESS_INT_NETSHIP_TIPO_ERROR (ID);
go

Insert into PAPERLESS_INT_NETSHIP_TIPO_ERROR values ('Resumen','Resumen de la carga',0)

go
update PAPERLESS_INT_NETSHIP_TIPO_ERROR set Activo= 0

go

update PAPERLESS_INT_NETSHIP_TIPO_ERROR set Activo= 1  where id in (7,3)

go