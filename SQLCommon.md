# SQL tipicos #
Aqui se detallaran todos los SQL que se usan comunmente

# Lista de usuarios y sus perfiles #
<pre>
select USUARIOS.*,PERFILES.* from USUARIOS, USUARIOS_PERFILES,PERFILES<br>
where USUARIOS.Id = USUARIOS_PERFILES.ID_USUARIO<br>
and PERFILES.Id = USUARIOS_PERFILES.ID_PERFIL<br>
</pre>