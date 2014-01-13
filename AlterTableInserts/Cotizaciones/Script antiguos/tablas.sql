    DROP TABLE
    Cotizacion_Comentarios;
CREATE TABLE
    Cotizacion_Comentarios
    (
        ID BIGINT NOT NULL IDENTITY,
        IdUsuario BIGINT NOT NULL,
        IDCotizacion BIGINT NOT NULL,
        IdTarifa BIGINT,
        Comentario VARCHAR(500) ,
        CreateDate DATETIME DEFAULT GETDATE(),
        IngresadaPorUsuario BIT,
        PRIMARY KEY (ID)
    );
DROP TABLE
    Cotizacion_Cotizaciones;
CREATE TABLE
    Cotizacion_Cotizaciones
    (
        ID BIGINT NOT NULL IDENTITY,
        idCliente BIGINT NOT NULL,
        IdUsuario BIGINT NOT NULL,
        IdTipoCotizacin BIGINT NOT NULL,
        IdEstado BIGINT NOT NULL,
        FechaSolicitud DATETIME DEFAULT GETDATE(),
        IdIncoterm BIGINT NOT NULL,
        PuertoEmbarque VARCHAR(100) ,
        NombreCliente VARCHAR(120),
        POL VARCHAR(300) ,
        POD VARCHAR(300) ,
        NavieraReferencia VARCHAR(500) ,
        TarifaReferencia VARCHAR(300) ,
        Mercaderia VARCHAR(300) ,
        GastosLocales VARCHAR(500) ,
        ProveedorCarga VARCHAR(1000) ,
        Credito VARCHAR(100) ,
        Comentario VARCHAR(2000) ,
        CreateDate DATETIME DEFAULT GETDATE(),
        PRIMARY KEY (ID)
    );
DROP TABLE
    Cotizacion_DetalleTarifa;
CREATE TABLE
    Cotizacion_DetalleTarifa
    (
        ID BIGINT NOT NULL IDENTITY,
        iDTarifa BIGINT NOT NULL,
        idItem BIGINT NOT NULL,
        IdMonda BIGINT NOT NULL,
        Cantidad DECIMAL(18,3) NOT NULL,
        Costo DECIMAL(18,3) NOT NULL,
        Venta DECIMAL(18,3) NOT NULL,
        PRIMARY KEY (ID)
    );
DROP TABLE
    Cotizacion_Estados;
CREATE TABLE
    Cotizacion_Estados
    (
        ID BIGINT NOT NULL IDENTITY,
        Nombre VARCHAR(60) ,
        Descripcion VARCHAR(200) ,
        PRIMARY KEY (ID)
    );
DROP TABLE
    Cotizacion_Items;
CREATE TABLE
    Cotizacion_Items
    (
        ID BIGINT NOT NULL IDENTITY,
        Nombre VARCHAR(60) ,
        Descripcion VARCHAR(200) ,
        PRIMARY KEY (ID)
    );
DROP TABLE
    Cotizacion_Monedas;
CREATE TABLE
    Cotizacion_Monedas
    (
        ID BIGINT NOT NULL IDENTITY,
        Nombre VARCHAR(60) ,
        PRIMARY KEY (ID)
    );
DROP TABLE
    Cotizacion_Tarifas;
CREATE TABLE
    Cotizacion_Tarifas
    (
        ID BIGINT NOT NULL IDENTITY,
        IDCotizacion BIGINT NOT NULL,
        Fecha DATETIME DEFAULT GETDATE() NOT NULL,
        FechaValidezInicio DATETIME,
        FechaValidezFin DATETIME,
        Agente VARCHAR(150) ,
        ComentarioCotizacion VARCHAR(500) ,
        ComentarioInterno VARCHAR(500) ,
        IdEstado BIGINT NOT NULL,
        CreateDate DATETIME DEFAULT GETDATE(),
        PRIMARY KEY (ID)
    );
DROP TABLE
    Cotizacion_Tipos;
CREATE TABLE
    Cotizacion_Tipos
    (
        ID BIGINT NOT NULL IDENTITY,
        Nombre VARCHAR(60) ,
        PRIMARY KEY (ID)
    );
ALTER TABLE
    Cotizacion_Comentarios ADD CONSTRAINT Cotizacion_Comentarios_fk2 FOREIGN KEY (IDCotizacion)
    REFERENCES Cotizacion_Cotizaciones (ID);
ALTER TABLE
    Cotizacion_Comentarios ADD CONSTRAINT Cotizacion_Comentarios_fk1 FOREIGN KEY (IdTarifa)
    REFERENCES Cotizacion_Tarifas (ID);
ALTER TABLE
    Cotizacion_Cotizaciones ADD CONSTRAINT Cotizacion_Cotizaciones_fk1 FOREIGN KEY (IdTipoCotizacin
    ) REFERENCES Cotizacion_Tipos (ID);
ALTER TABLE
    Cotizacion_DetalleTarifa ADD CONSTRAINT Cotizacion_DetalleCotizacion_fk3 FOREIGN KEY (idItem)
    REFERENCES Cotizacion_Items (ID);
ALTER TABLE
    Cotizacion_DetalleTarifa ADD CONSTRAINT Cotizacion_DetalleCotizacion_fk2 FOREIGN KEY (IdMonda)
    REFERENCES Cotizacion_Monedas (ID);
ALTER TABLE
    Cotizacion_DetalleTarifa ADD CONSTRAINT Cotizacion_DetalleCotizacion_fk1 FOREIGN KEY (iDTarifa)
    REFERENCES Cotizacion_Tarifas (ID);
ALTER TABLE
    Cotizacion_Tarifas ADD CONSTRAINT Cotizacion_Tarifas_fk1 FOREIGN KEY (IDCotizacion) REFERENCES
    Cotizacion_Cotizaciones (ID);
ALTER TABLE
    Cotizacion_Tarifas ADD CONSTRAINT Cotizacion_Tarifas_fk2 FOREIGN KEY (IdEstado) REFERENCES
    Cotizacion_Estados (ID);


CREATE TABLE
    Cotizacion_ItemsTarifas
    (
        ID BIGINT NOT NULL IDENTITY,
        Nombre VARCHAR(60) ,
        Descripcion VARCHAR(200) ,
        PRIMARY KEY (ID)
    );
go

ALTER TABLE
    Cotizacion_DetalleTarifa drop CONSTRAINT Cotizacion_DetalleCotizacion_fk3 

ALTER TABLE
    Cotizacion_DetalleTarifa ADD CONSTRAINT Cotizacion_DetalleCotizacion_fk3 FOREIGN KEY (idItem)
    REFERENCES Cotizacion_ItemsTarifas (ID);

go


ALTER TABLE
    Cotizacion_Cotizaciones ADD idUsuarioPricingAsignado bigint
GO

ALTER TABLE
    Cotizacion_Tarifas ADD numero varchar(100)
GO




CREATE TABLE  Cotizacion_CotizacionDirecta_Opciones
    (
        ID BIGINT NOT NULL IDENTITY,
        IDCotizacion BIGINT NOT NULL,
        Fecha DATETIME DEFAULT GETDATE() NOT NULL,
        FechaValidezInicio DATETIME,
        FechaValidezFin DATETIME,
        Naviera varchar(500),
        TiempoTransito varchar(300),
        Agente VARCHAR(150) ,
        ComentarioCotizacion VARCHAR(500),
        ComentarioInterno VARCHAR(500) ,
        IdEstado BIGINT NOT NULL,
        numero VARCHAR(100) ,
        CreateDate DATETIME DEFAULT GETDATE(),
        PRIMARY KEY (ID),
        CONSTRAINT Cotizacion_CotizacionDirecta_Opciones_fk1 FOREIGN KEY (IDCotizacion) REFERENCES  Cotizacion_Cotizaciones (ID),
        CONSTRAINT Cotizacion_CotizacionDirecta_Opciones_fk2 FOREIGN KEY (IdEstado) REFERENCES Cotizacion_Estados (ID)
    );

ALTER TABLE  scc.dbo.Cotizacion_Comentarios ADD IdCotizacionOpcion bigint;
ALTER TABLE  scc.dbo.Cotizacion_Comentarios ADD CONSTRAINT Cotizacion_Comentarios_fk3 FOREIGN KEY  (IdCotizacionOpcion) REFERENCES scc.dbo.Cotizacion_CotizacionDirecta_Opciones (ID)


CREATE TABLE Cotizacion_CotizacionDirecta_Opciones_Detalle
    (
        ID BIGINT NOT NULL IDENTITY,
        IdCotizacionOpcion BIGINT NOT NULL,
        idItem BIGINT NOT NULL,
        IdMoneda BIGINT NOT NULL,
        Cantidad DECIMAL(18,3) NOT NULL,
        Costo DECIMAL(18,3) NOT NULL,
        Venta DECIMAL(18,3) NOT NULL,
        PRIMARY KEY (ID)
    );



CREATE TABLE    Cotizacion_CotizacionDirecta_items
    (
        ID BIGINT NOT NULL IDENTITY,
        Nombre VARCHAR(60) ,
        Descripcion VARCHAR(200) ,
        PRIMARY KEY (ID)
    );
go





ALTER TABLE    scc.dbo.Cotizacion_CotizacionDirecta_Opciones_Detalle ADD CONSTRAINT    Cotizacion_CotizacionDirecta_Opciones_Detalle_fk1 FOREIGN KEY (IdCotizacionOpcion) REFERENCES
    scc.dbo.Cotizacion_CotizacionDirecta_Opciones (ID);
ALTER TABLE
    scc.dbo.Cotizacion_CotizacionDirecta_Opciones_Detalle ADD CONSTRAINT
    Cotizacion_CotizacionDirecta_Opciones_Detalle_fk2 FOREIGN KEY (idItem) REFERENCES
    scc.dbo.Cotizacion_CotizacionDirecta_items (ID)    ;

ALTER TABLE
    scc.dbo.Cotizacion_Cotizaciones ADD CONSTRAINT Cotizacion_Cotizaciones_fk2 FOREIGN KEY
    (IdEstado) REFERENCES scc.dbo.Cotizacion_Estados (ID);

ALTER TABLE
    scc.dbo.Cotizacion_CotizacionDirecta_Opciones_Detalle ADD CONSTRAINT
    Cotizacion_CotizacionDirecta_Opciones_Detalle_fk3 FOREIGN KEY (IdMoneda) REFERENCES
    scc.dbo.Cotizacion_Monedas (ID);

ALTER TABLE
    scc.dbo.Cotizacion_Cotizaciones ADD FechaEstimadaEmbarque VARCHAR(120);
ALTER TABLE
    scc.dbo.Cotizacion_Cotizaciones ADD TipoTransbordo INT();
ALTER TABLE
    scc.dbo.Cotizacion_Cotizaciones ADD ConAgenciamiento bit