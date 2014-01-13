create Procedure [dbo].[SP_N_COTIZACION_DIRECTA_OPCIONES_PUERTOS]
      @puerto varchar(10) 
           ,@cotizacion_directa_opciones_id bigint 
           ,@tipo varchar(5)
           ,@id bigint OUTPUT
as 
begin
INSERT INTO .[dbo].[COTIZACION_DIRECTA_OPCIONES_PUERTOS]
           ([puerto]
           ,[cotizacion_directa_opciones_id]
           ,[tipo])
     VALUES
           (@puerto
           ,@cotizacion_directa_opciones_id
           ,@tipo)

select @id = SCOPE_IDENTITY()
select @id;
end

GO


