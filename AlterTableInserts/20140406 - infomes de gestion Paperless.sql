if  exists(SELECT * FROM sys.objects WHERE name = 'fn_Split' )
Begin
	DROP FUNCTION [dbo].[fn_Split]
END
GO

CREATE  FUNCTION [dbo].[fn_Split](@text varchar(8000), @delimiter varchar(20) = ' ')
RETURNS @Strings TABLE
(   
  position int IDENTITY PRIMARY KEY,
  value varchar(8000)  
)
AS
BEGIN

DECLARE @index int
SET @index = -1

WHILE (LEN(@text) > 0)
  BEGIN 
    SET @index = CHARINDEX(@delimiter , @text) 
    IF (@index = 0) AND (LEN(@text) > 0) 
      BEGIN  
        INSERT INTO @Strings VALUES (@text)
          BREAK 
      END 
    IF (@index > 1) 
      BEGIN  
        INSERT INTO @Strings VALUES (LEFT(@text, @index - 1))  
        SET @text = RIGHT(@text, (LEN(@text) - @index)) 
      END 
    ELSE
      SET @text = RIGHT(@text, (LEN(@text) - @index))
    END
  RETURN
END
GO

if  exists(SELECT * FROM sys.objects WHERE name = 'SP_PAPERLESS_INFORME_ASIGNACION' )
Begin
	DROP PROCEDURE[dbo].[SP_PAPERLESS_INFORME_ASIGNACION]
END
GO

CREATE PROCEDURE SP_PAPERLESS_INFORME_ASIGNACION
	@estados varchar(100)
	,@cargas varchar(100)
	,@empresas varchar(200)
	,@fechaCreacionIni datetime
	,@fechaCreacionFin datetime
	,@fechaEmbarcadorIni datetime
	,@fechaEmbarcadorFin datetime
AS 
BEGIN 
	SELECT 
	PA.Id  as IdAsignacion
	,NumMaster, 
	FechaMaster, 
	PAG.Descripcion  as Agente, 
	PN.Descripcion as Naviera, 
	PNA.Descripcion as Nave, Viaje, 
	NumHousesBL, 
	PTC.Descripcion as TipoCarga, 
	FechaETA, 
	PlazoEmbarcadores, 
	U1.NombreUsuario Usuario1, 
	PARA.Descripcion Importancia, 
	U2.NombreUsuario Usuario2, 
	PE.Descripcion Estado, 
	PINFO.NumConsolidado,  
	PTIEMPOS.ComienzoUsuario1, 
	PTIEMPOS.TerminoUsuario1, 
	PTIEMPOS.ComienzoUsuario2, 
	PTIEMPOS.TerminoUsaurio2, 
	(Select MAX(FechaMarca) 
	from PAPERLESS_USUARIO1_PASOS_ESTADO P1 
	where P1.IdAsignacion = PA.Id) UltimoPasoU1, 
	(Select MAX(FechaMarca) from PAPERLESS_USUARIO2_PASOS_ESTADO P2 
	where P2.IdAsignacion = PA.Id) UltimoPasoU2, 
	PA.FechaCreacion, 
	PA.IdUsuarioCreacion, 
	PA.versionUsuario1 FROM PAPERLESS_ASIGNACION PA 
	INNER JOIN PAPERLESS_AGENTE PAG ON PA.IdAgente = PAG.Id 
	INNER JOIN PAPERLESS_NAVIERA PN ON PA.IdNaviera = PN.Id 
	INNER JOIN PAPERLESS_NAVE PNA ON PA.IdNave = PNA.Id 
	INNER JOIN PAPERLESS_TIPO_CARGA PTC ON PA.IdTipoCarga = PTC.Id 
	INNER JOIN USUARIOS U1 ON PA.Usuario1 = U1.Id 
	INNER JOIN USUARIOS U2 ON PA.Usuario2 = U2.Id 
	INNER JOIN PARAM_PARAMETROS PARA ON PA.IdImportancia = PARA.Id 
	INNER JOIN PAPERLESS_ESTADO PE ON PA.IdEstado = PE.Id  
	LEFT OUTER JOIN PAPERLESS_USUARIO1_HOUSESBL_INFO PINFO ON PA.Id = PINFO.IdAsignacion 
	LEFT OUTER JOIN PAPERLESS_PROCESOS_REGISTRO_TIEMPOS PTIEMPOS ON PA.Id = PTIEMPOS.IdAsignacion  
	WHERE PA.Id > 0  
	and pa.idEstado in (SELECT Value FROM fn_Split(@estados, ','))
	and pa.idTipoCarga in (SELECT Value FROM fn_Split(@cargas, ','))
	and PA.FECHACREACION BETWEEN @fechaCreacionIni and @fechaCreacionFin 
	and PA.PlazoEmbarcadores BETWEEN @fechaEmbarcadorIni and @fechaEmbarcadorFin
	AND pa.empresa  in  (SELECT Value FROM fn_Split(@empresas, ','))
END
GO


if  exists(SELECT * FROM sys.objects WHERE name = 'SP_PAPERLESS_INFORME_EXCEPCIONES_HBL' )
Begin
	DROP PROCEDURE[dbo].[SP_PAPERLESS_INFORME_EXCEPCIONES_HBL]
END
GO
CREATE PROCEDURE SP_PAPERLESS_INFORME_EXCEPCIONES_HBL
	@estados varchar(100)
	,@cargas varchar(100)
	,@empresas varchar(200)
	,@fechaCreacionIni datetime
	,@fechaCreacionFin datetime
	,@fechaEmbarcadorIni datetime
	,@fechaEmbarcadorFin datetime

AS 
BEGIN
	select
	PUH.HouseBL,
	PA.Id as IdAsignacion, 
	NumMaster, 
	FechaMaster, 
	PAG.Descripcion as Agente, 
	PN.Descripcion as Naviera, 
	PNA.Descripcion as Nave, Viaje, 
	PTC.Descripcion as TipoCarga, 
	FechaETA, 
	PlazoEmbarcadores, 
	U1.NombreUsuario Usuario1, 
	U2.NombreUsuario Usuario2,	
	PE.Descripcion Estado, 
	u.NombreUsuario UsuarioUltimaMod,
	Pta.Descripcion as AgenteCausador,
	PTE.Descripcion as TipoExcepcion,
	PUE.comentario,
	PTR.Descripcion as ResponsableExcepcion
	, CASE 
	      WHEN PUE.Resuelto = 1 THEN 'True'
	      else 'False' 
	  end as Resuelto
	,
	CASE 
	      WHEN PUE.TieneExcepciones = 1 THEN 'True'
	      else 'False' 
	  end as TieneExcepcion,
	  PA.FechaCreacion
	--,PUE.*
	--,PTE.*
	--,PTA.*
	 from PAPERLESS_ASIGNACION PA 
	inner join PAPERLESS_USUARIO1_EXCEPCIONES PUE on PA.Id=PUE.IdAsignacion
	inner join PAPERLESS_USUARIO1_HOUSESBL PUH on PUE.IdHouseBL=PUH.Id
	inner join PAPERLESS_TIPO_EXCEPCIONES PTE on PUE.TipoExcepcion=PTE.Id
	inner join USUARIOS u on PUE.UsuarioUltimaMod =u.Id
	INNER JOIN PAPERLESS_NAVIERA PN ON PA.IdNaviera = PN.Id 
	INNER JOIN PAPERLESS_NAVE PNA ON PA.IdNave = PNA.Id 
	INNER JOIN PAPERLESS_TIPO_CARGA PTC ON PA.IdTipoCarga = PTC.Id 
	INNER JOIN USUARIOS U1 ON PA.Usuario1 = U1.Id 
	INNER JOIN USUARIOS U2 ON PA.Usuario2 = U2.Id 
	INNER JOIN PAPERLESS_ESTADO PE ON PA.IdEstado = PE.Id  
	INNER JOIN PAPERLESS_AGENTE PAG ON PA.IdAgente = PAG.Id 
	inner join PAPERLESS_TIPO_AGENTECAUSADOR PTA on PTA.ID=PUE.Causador
	inner join PAPERLESS_TIPO_RESPONSABILIDAD PTR on PTR.Id=PUE.TipoResponsabilidad
	WHERE PA.Id > 0  
	and pa.idEstado in (SELECT Value FROM fn_Split(@estados, ','))
	and pa.idTipoCarga in (SELECT Value FROM fn_Split(@cargas, ','))
	and PA.FECHACREACION BETWEEN @fechaCreacionIni and @fechaCreacionFin 
	and PA.PlazoEmbarcadores BETWEEN @fechaEmbarcadorIni and @fechaEmbarcadorFin
	AND pa.empresa  in  (SELECT Value FROM fn_Split(@empresas, ','))

END
GO

If  exists(SELECT * FROM sys.objects WHERE name = 'SP_PAPERLESS_INFORME_EXCEPCIONES_MASTER' )
Begin
	DROP PROCEDURE[dbo].[SP_PAPERLESS_INFORME_EXCEPCIONES_MASTER]
END
GO
CREATE PROCEDURE SP_PAPERLESS_INFORME_EXCEPCIONES_MASTER
	@estados varchar(100)
	,@cargas varchar(100)
	,@empresas varchar(200)
	,@fechaCreacionIni datetime
	,@fechaCreacionFin datetime
	,@fechaEmbarcadorIni datetime
	,@fechaEmbarcadorFin datetime

AS 
BEGIN
	select
	PA.Id as IdAsignacion,
	NumMaster, 
	FechaMaster, 
	PAG.Descripcion as Agente, 
	PN.Descripcion as Naviera, 
	PNA.Descripcion as Nave, Viaje, 
	PTC.Descripcion as TipoCarga, 
	FechaETA, 
	PlazoEmbarcadores, 
	U1.NombreUsuario Usuario1, 
	U2.NombreUsuario Usuario2,
	PE.Descripcion Estado, 
	u.NombreUsuario UsuarioUltimaMod,
	Pta.Descripcion as AgenteCausador,
	PTE.Descripcion as TipoExcepcion,
	PUM.comentario,
	PTR.Descripcion as ResponsableExcepcion
	, CASE 
	      WHEN PUm.Resuelto = 1 THEN 'True'
	      else 'False' 
	  end as Resuelto
	,
	CASE 
	      WHEN PUM.TieneExcepcion = 1 THEN 'True'
	      else 'False' 
	  end as TieneExcepcion,
	  PA.FechaCreacion
	--,PUE.*
	--,PTE.*
	--,PTA.*
	 from PAPERLESS_ASIGNACION PA 
	inner join PAPERLESS_USUARIO1_EXCEPCIONES_MASTER PUM on PA.Id=PUM.IdAsignacion
	inner join PAPERLESS_TIPO_EXCEPCIONES PTE on PUm.TipoExcepcion=PTE.Id
	inner join USUARIOS u on PUm.UsuarioUltimaModificacion =u.Id
	INNER JOIN PAPERLESS_NAVIERA PN ON PA.IdNaviera = PN.Id 
	INNER JOIN PAPERLESS_NAVE PNA ON PA.IdNave = PNA.Id 
	INNER JOIN PAPERLESS_TIPO_CARGA PTC ON PA.IdTipoCarga = PTC.Id 
	INNER JOIN USUARIOS U1 ON PA.Usuario1 = U1.Id 
	INNER JOIN USUARIOS U2 ON PA.Usuario2 = U2.Id 
	INNER JOIN PAPERLESS_ESTADO PE ON PA.IdEstado = PE.Id  
	INNER JOIN PAPERLESS_AGENTE PAG ON PA.IdAgente = PAG.Id 
	inner join PAPERLESS_TIPO_AGENTECAUSADOR PTA on PTA.ID=PUm.AgenteCausador
	inner join PAPERLESS_TIPO_RESPONSABILIDAD PTR on PTR.Id=PUm.TipoResponsabilidad
	WHERE PA.Id > 0  
	and pa.idEstado in (SELECT Value FROM fn_Split(@estados, ','))
	and pa.idTipoCarga in (SELECT Value FROM fn_Split(@cargas, ','))
	and PA.FECHACREACION BETWEEN @fechaCreacionIni and @fechaCreacionFin 
	and PA.PlazoEmbarcadores BETWEEN @fechaEmbarcadorIni and @fechaEmbarcadorFin
	AND pa.empresa  in  (SELECT Value FROM fn_Split(@empresas, ','))

END
GO



if  exists(select * from syscolumns where object_name(id) = 'PAPERLESS_EMPRESAS' )
Begin
	DROP TABLE [dbo].[PAPERLESS_EMPRESAS]
END
GO

CREATE TABLE [dbo].[PAPERLESS_EMPRESAS](
		[CODIGO] [varchar](70) NOT NULL,
		[NOMBRE] [varchar](70)NOT NULL,
		[createDate] [datetime] NOT NULL default getdate(),
		CONSTRAINT [PK_PAPERLESS_EMPRESAS] PRIMARY KEY CLUSTERED ([CODIGO] ASC)
		WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

INSERT PAPERLESS_EMPRESAS (CODIGO,NOMBRE) VALUES ('Craft','Craft');
INSERT PAPERLESS_EMPRESAS (CODIGO,NOMBRE) VALUES ('Neutral','Neutral');
INSERT PAPERLESS_EMPRESAS (CODIGO,NOMBRE) VALUES ('Slotlog','Slotlog');
INSERT PAPERLESS_EMPRESAS (CODIGO,NOMBRE) VALUES ('Contact','Contact');
GO

if  exists(SELECT * FROM sys.objects WHERE name = 'SP_L_PAPERLESS_EMPRESAS' )
Begin
	DROP PROCEDURE[dbo].[SP_L_PAPERLESS_EMPRESAS]
END
GO
CREATE PROCEDURE SP_L_PAPERLESS_EMPRESAS
AS 
BEGIN
	SELECT * FROM PAPERLESS_EMPRESAS
END
