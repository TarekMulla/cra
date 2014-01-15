 
alter PROCEDURE SP_U_PAPERLESS_ASIGNACION_EMPRESA
      @Empresa varchar(20),    
  @IdAsignacion bigint    
AS  
  
if   @Empresa=''
begin
set @Empresa=null
end
update PAPERLESS_ASIGNACION set empresa = @Empresa where Id = @IdAsignacion