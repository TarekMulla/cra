Create procedure  SP_N_NAVIERA_PUERTO_RELACION
 
@idnaviera int
,@relacionPuertos varchar(200)
AS
--declare @idnaviera  int
--Declare @relacionPuertos varchar(200) = 'CNHUA,CNNGB,CNSHA,CNSHK,CNTAO,CNXGG,CNYTN,ESBIO,HKHKG,TRIZM,TWKEL,USHOU,VNHPH'
Declare @individual varchar(20) = null

--select @idnaviera=1
delete from NAVIERA_PUERTO where  idNaviera=@idnaviera
	 
WHILE LEN(@relacionPuertos) > 0
BEGIN
    IF PATINDEX('%,%',@relacionPuertos) > 0
    BEGIN
        SET @individual = SUBSTRING(@relacionPuertos, 0, PATINDEX('%,%',@relacionPuertos))
        SELECT @individual
        insert into NAVIERA_PUERTO values (@idnaviera,@individual)

        SET @relacionPuertos = SUBSTRING(@relacionPuertos, LEN(@individual + ',') + 1, LEN(@relacionPuertos))
    END
    ELSE
    BEGIN
        SET @individual = @relacionPuertos
        SET @relacionPuertos = NULL
        SELECT @individual
        insert into NAVIERA_PUERTO values (@idnaviera,@individual)
    END
END