drop table configuracion
go

CREATE TABLE configuracion (
	[key] VARCHAR(150),
	[value]  BIT, 
	[descripction] varchar(500),
	[createdate] DATETIME default getdate(), 
	PRIMARY KEY ([key])
);
go

drop procedure SP_L_configuracion
GO

CREATE Procedure [dbo].[SP_L_configuracion]	
AS
Begin
      SET NOCOUNT ON
      select [key],[value] from configuracion
end  

GO