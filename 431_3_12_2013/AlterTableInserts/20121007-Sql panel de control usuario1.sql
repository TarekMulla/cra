insert panel_control (nombre,xml_file) values ('Panel Usuario1','PanelUsuario1.xml')
GO

update perfiles set id_panel=(select max(id) from dbo.PANEL_CONTROL) where nombre='Encargado Documental 1ra Etapa'
GO
