 alter Procedure [dbo].[SP_L_PAPERLESS_INTEGRACIONNETSHIP]   
    @IDPaper bigint   AS  
 Begin         
SET NOCOUNT ON    
 select IDPaperless, Valorpaperless, valorNetShip, Mensaje, CreateDate   
from PAPERLESS_INTEGRACIONNETSHIP  PPint
Inner Join PAPERLESS_INT_NETSHIP_TIPO_ERROR TipoError on PPint.IDPaperlessTipoError  =TipoError.id
where IDPaperless = @IDPaper      and Activo=1
End