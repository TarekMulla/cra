Create Procedure [dbo].[SP_L_Paperless_IntegracionNetship]

    @IDPaper bigint
	
AS

Begin
      
SET NOCOUNT ON
 

select IDPaperless, Valorpaperless, valorNetShip, Mensaje, CreateDate 
from Paperless_IntegracionNetship 
where IDPaperless = @IDPaper  


End