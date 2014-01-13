alter Procedure sp_SCC_HouseBLs
		@NrMaster varchar(30) = NULL
as
Begin

Declare @CodMaster	integer
Declare @NumConso	varchar(10)

--sp_SCC_HouseBLs 'SUDUN24676917008'

--Select @NrMaster = 'SUDUN24676917008'

/*exec sp_SCC_HouseBLs 'MOLU26006285475'
MOLU26006285475
KEVAP136168M
MOLU26006228705
MOLU13500936571
NYKS7340175010
HJSCSHSS39669500
352-13-02557-352644 
HLCURTM130701268
HLCUHAM130709188
NYKS7340175020*/
		
Select	@CodMaster = Ci_Codigo,
		@NumConso = Ci_num		
From	netship.CRAFTCHI.dbo.ConsoImp
where	ci_nrmbl = @NrMaster

select top 10	@NumConso as 'Consolidada',
		Ha_nrHouse as 'House BL',
		UgHI_CneeRUT as 'RUT',
		Case When IsNull(UgHI_CneeRUT,'') <> '' Then UgHI_CneeNome 
			Else 'VARIOS' 
		End as 'Cliente',
		Case cl_tipo
			When 'COLOADER' Then 'Embarcador'
			When 'F. FORWARDER' Then 'Embarcador'
			Else 'Directo'
		End as 'Tipo Cliente',
		Ch_RoutingOrder as 'Ruteado'
From	netship.CRAFTCHI.dbo.Chegada a,
		netship.CRAFTCHI.dbo.HouseAdi h,
		netship.CRAFTCHI.dbo.TUG_HouImpo t,
		netship.CRAFTCHI.dbo.Cliente cl
Where Ha_CodConso = @CodMaster
And ch_codigo = ha_codhouse 
And ha_codhouse  = UgHI_CodHouse
And Cl_Codigo = ch_cliente


End