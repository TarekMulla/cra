if not exists (select * from configuracion where [key]='Paperless_BtnMantNavieras_Enabled' )
	Begin
		insert into configuracion values ('Paperless_BtnMantNavieras_Enabled',1,'Habilitar el boton de Mantenedor de Navieras en la pantalla de paperless asignacion',GETDATE())
	end
	
if not exists (select * from configuracion where [key]='paperless_chk_paso1_Ruteado_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_chk_paso1_Ruteado_Enabled',1) 
End

if not exists (select * from configuracion where [key]='paperless_chk_paso1_Shipping_instruction_enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_chk_paso1_Shipping_instruction_enabled',1) 
End

if not exists (select * from configuracion where [key]='paperless_chk_Paso1_Tipo_de_cliente_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_chk_Paso1_Tipo_de_cliente_Enabled',1) 
End

if not exists (select * from configuracion where [key]='paperless_chklist_Fcl_FH_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_chklist_Fcl_FH_Enabled',1) 
End

if not exists (select * from configuracion where [key]='paperless_chklist_FCL_RO_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_chklist_FCL_RO_Enabled',1) 
End

if not exists (select * from configuracion where [key]='paperless_chkList_LCL_Estandar_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_chkList_LCL_Estandar_Enabled',1) 
End

if not exists (select * from configuracion where [key]='paperless_GraficosAsignacionUsuario1y2_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value],[descripction]) VALUES('paperless_GraficosAsignacionUsuario1y2_Enabled',1,'Habilitacion de graficos para Usuario 1 y 2, se habilita con 1 y deshabilita con 0') 
End
Else
Begin
	update configuracion set descripction = 'Habilitacion de graficos para Usuario 1 y 2, se habilita con 1 y deshabilita con 0' where 
[key]='paperless_GraficosAsignacionUsuario1y2_Enabled'
End

if not exists (select * from configuracion where [key]='paperless_txtfechaAperturaNavieras_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_txtfechaAperturaNavieras_Enabled',1) 
End

if not exists (select * from configuracion where [key]='paperless_txtfechaMaximaVinculacion_Enabled' )
Begin
	INSERT INTO [dbo].[configuracion]([key],[value]) VALUES('paperless_txtfechaMaximaVinculacion_Enabled',1) 
End

if not exists (select * from configuracion where [key]='Semaforos_Brasil_Enabled' )
Begin
	Insert into configuracion values  ('Semaforos_Brasil_Enabled', 1, '', GETDATE()) 
End

if not exists (select * from configuracion where [key]='Paperless_ParcialBrasil' )
Begin
	Insert into configuracion values  ('Paperless_ParcialBrasil', 1, 'Carga la version piloto de brasil en el SCC', GETDATE())
End

if not exists (select * from configuracion where [key]='Paperless_Mail_Finalizacion_Etapa1LCL' )
Begin
	insert into configuracion values ('Paperless_Mail_Finalizacion_Etapa1LCL',1,'Correo de finalizacion del usuario 1 , se debe agregar el correo en el App.config y los mails deben estar separados por ;',GETDATE())
End

if not exists (select * from configuracion where [key]='Paperless_Mail_Finalizacion_Etapa1FCL' )
Begin
	insert into configuracion values ('Paperless_Mail_Finalizacion_Etapa1FCL',1,'Correo de finalizacion del usuario 1 , se debe agregar el correo en el App.config y los mails deben estar separados por ;',GETDATE())
End

if not exists (select * from configuracion where [key]='Paperless_Usuario1_Valida_Num_Consolidado' )
Begin
	insert into configuracion values ('Paperless_Usuario1_Valida_Num_Consolidado',1,'Flag para validar el numero de consolidado en el usuario 1',GETDATE())
End

if not exists (select * from configuracion where [key]='Paperless_ExcepcionesBrasil_Usuario1' )
Begin
	insert into configuracion values ('Paperless_ExcepcionesBrasil_Usuario1',1,'Carga las excepciones del Paperless para Brasil',GETDATE())
End

