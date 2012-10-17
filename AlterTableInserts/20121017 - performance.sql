CREATE TABLE  LOG_PERFORMANCE
    (
        Id INT NOT NULL IDENTITY,
        NombreUsuario NVARCHAR(50) not NULL,
        Modulo  NVARCHAR(100) not NULL,
        Accion  NVARCHAR(300) not NULL,
        Tiempo decimal(12,3) not null,
        create_date datetime default getdate(),
        CONSTRAINT PK_LOG_PERFORMANCE PRIMARY KEY (ID)
    )
GO

CREATE PROCEDURE "dbo"."SP_N_LOG_PERFORMANCE"
					@NombreUsuario varchar(50),
					@Modulo VARCHAR(100),
					@Accion	VARCHAR(300),
					@Tiempo decimal(12,3)

AS

INSERT INTO dbo.LOG_PERFORMANCE (NombreUsuario,Modulo,Accion, Tiempo)
VALUES (@NombreUsuario,@Modulo,@Accion,@Tiempo)
SELECT SCOPE_IDENTITY()

RETURN 0