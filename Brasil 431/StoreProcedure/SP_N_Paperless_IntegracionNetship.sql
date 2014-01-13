/*drop table Paperless_IntegracionNetship
go
CREATE TABLE [dbo].[PAPERLESS_INTEGRACIONNETSHIP](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IDPaperless] [bigint] NOT NULL,
	[ValorPaperless] [varchar](20) NULL,
	[ValorNetShip] [varchar](20) NULL,
	[Mensaje] [varchar](255) NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

*/

Alter  procedure [dbo].[SP_N_Paperless_IntegracionNetship]  
  
@IDPaperless bigint ,  
@ValorPaperless varchar (20),  
@ValorNetShip varchar (20),  
@Mensaje varchar (255),  
@IDPaperlessTipoError bigint  

 AS   
 INSERT INTO Paperless_IntegracionNetship            
 (IDPaperless ,  
   ValorPaperless ,  
   ValorNetShip ,  
   Mensaje ,  
   CreateDate ,  
   IDPaperlessTipoError)  
 VALUES            
 (@IDPaperless ,  
   @ValorPaperless ,  
   @ValorNetShip ,  
   @Mensaje,    
   GetDate(),    
   @IDPaperlessTipoError)     
   
   SELECT  SCOPE_IDENTITY() 