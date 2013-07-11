drop table Paperless_IntegracionNetship
go
Create table Paperless_IntegracionNetship
(
IDPaperless bigint not null primary key,
ValorPaperless varchar (20),
ValorNetShip varchar (20),
Mensaje varchar (255),
CreateDate datetime
)
go

Create procedure SP_N_Paperless_IntegracionNetship

@IDPaperless bigint ,
@ValorPaperless varchar (20),
@ValorNetShip varchar (20),
@Mensaje varchar (255)

AS


INSERT INTO Paperless_IntegracionNetship
           (IDPaperless ,
			ValorPaperless ,
			ValorNetShip ,
			Mensaje ,
			CreateDate )

VALUES
           (@IDPaperless ,
			@ValorPaperless ,
			@ValorNetShip ,
			@Mensaje,
			GetDate())
			
SELECT  SCOPE_IDENTITY()

go