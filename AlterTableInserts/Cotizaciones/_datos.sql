INSERT INTO COTIZACION_TIPOS_TRANSBORDOS (nombre, createDate) VALUES ('Sin Transbordo', getdate());
INSERT INTO COTIZACION_TIPOS_TRANSBORDOS (nombre, createDate) VALUES ('Con Transbordo', getdate());
INSERT INTO COTIZACION_TIPOS_TRANSBORDOS (nombre, createDate) VALUES ('Ambos', getdate());
go

DELETE FROM COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS ;
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Ingresado','Vendedor envía solicitud a Pricing');
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('En proceso','Pricing recibe la solicitud');
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Tarifadisponible','Pricing retorna con respuesta'); 
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Enviada al cliente','Respondido a Cliente'); 
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Reevaluación','Rechazada momentáneamente por X motivo');
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Perdido (tarifa)','Rechazada definitivamente 1');
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Perdido (otros)','Rechazada definitivamente 2');
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Cerrado','Cliente cierra con nosotros');
insert into COTIZACION_SOLICITUD_COTIZACIONES_ESTADOS (Nombre, Descripcion) values ('Cerrado LCL','Cliente cierra con nosotros pero no como FCL');

Go

insert into COTIZACION_INDIRECTA_ITEMS values ('Transporte Terrestre','Transporte Terrestre',1)
insert into COTIZACION_INDIRECTA_ITEMS values ('Transporte Maritimo','Transporte Maritimo',1)
insert into COTIZACION_INDIRECTA_ITEMS values ('THC Destino','THC Destino',1)
insert into COTIZACION_INDIRECTA_ITEMS values ('Agente','Agente',1)
insert into COTIZACION_INDIRECTA_ITEMS values ('Drayage','Drayage',1)
insert into COTIZACION_INDIRECTA_ITEMS values ('Gasto de Consolidacion','Gasto de Consolidacion',1)
go


insert into COTIZACION_DIRECTA_ITEMS values ('Transporte Terrestre','Transporte Terrestre',1)
insert into COTIZACION_DIRECTA_ITEMS values ('Transporte Maritimo','Transporte Maritimo',1)
insert into COTIZACION_DIRECTA_ITEMS values ('THC Destino','THC Destino',1)
insert into COTIZACION_DIRECTA_ITEMS values ('Agente','Agente',1)
insert into COTIZACION_DIRECTA_ITEMS values ('Drayage','Drayage',1)
insert into COTIZACION_DIRECTA_ITEMS values ('Gasto de Consolidacion','Gasto de Consolidacion',1)