Create Procedure sp_SCC_HouseBLs_Neutral
            @NrMaster varchar(30) = NULL
as
Begin
 
Declare @CodMaster      integer
Declare @NumConso varchar(10)
 
--sp_SCC_HouseBLs 'HLCURTM130713895'
 
--Select @NrMaster = 'SUDUN24676917008'
 
Create table #Salida(
NumConso varchar(20) null,
Ha_nrHouse varchar(50) null ,
UgHI_CneeRUT varchar(20) null,
UgHI_CneeNome varchar(80) null,
cl_tipo varchar(20) null,
Ch_RoutingOrder varchar(20),
CotaNum varchar(30) null,
Origem varchar(50) null)
           
Select      @CodMaster = Ci_Codigo,
            @NumConso = Ci_num          
From  Neutral.dbo.ConsoImp
where ci_nrmbl = @NrMaster
 
Insert into #Salida
select      @NumConso as 'Consolidada',
            Ha_nrHouse as 'House BL',
            IsNull(Cl_Cgc,'') as 'RUT',
            Case When IsNull(Cl_Cgc,'') <> '' Then Cl_Fanta
                  Else 'VARIOS'
            End as 'Cliente',
            Case IsNull(cl_tipo,'')
                  When 'COLOADER' Then 'Embarcador'
                  When 'F. FORWARDER' Then 'Embarcador'
                  Else 'Directo'
            End as 'Tipo Cliente',
            Ch_RoutingOrder as 'Ruteado',
            '',
            Po_nome
From  Neutral.dbo.HouseAdi h
Inner Join Neutral.dbo.Chegada a on (ch_codigo = ha_codhouse)
Inner Join Neutral.dbo.Portos p on (Po_Codigo = ch_origem)
Left Outer Join Neutral.dbo.Cliente cl on (Cl_Codigo = Ch_Cnee)
Where Ha_CodConso = @CodMaster
 
Update      #Salida
Set         CotaNum = Cti_CotaNum
From  Neutral.dbo.CotaImpGeral
Where Cti_NumHBL = Ha_nrHouse Collate SQL_Latin1_General_CP1_CI_AS
 
Select      NumConso as 'Consolidada',
            Ha_nrHouse as 'House BL',
            UgHI_CneeRUT as 'RUT',
            UgHI_CneeNome as 'Cliente',
            cl_tipo as 'Tipo Cliente',
            Ch_RoutingOrder as Ruteado,
            CotaNum as 'Shipping Instruction',
            Origem as 'Puerto'
From #Salida
 
End