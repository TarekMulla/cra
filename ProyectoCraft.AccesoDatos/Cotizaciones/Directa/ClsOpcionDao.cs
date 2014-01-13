using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.AccesoDatos.Parametros;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Mantenedores;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa {
    public class ClsOpcionDao {
        private const String NombreClase = "ClsOpcionDao";
        private static List<ClsNaviera> _navieras;
        public static ResultadoTransaccion ObtieneOpciones(Int32 idCotizacion) {
            var res = new ResultadoTransaccion();
            var opciones = new List<Opcion>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {

                SqlCommand command = new SqlCommand("SP_L_COTIZACION_DIRECTA_OPCIONES_POR_ID_COTIZACION", conn);
                command.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    var opcion = GetFromDataReader(reader);
                    ClsPuertoDao.ObtienePuertos(opcion);
                    opciones.Add(opcion);
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = opciones;
                res.Descripcion = "Se creo la cotizacion Exitosamente";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }

        private static Opcion GetFromDataReader(SqlDataReader reader) {
            var opcion = new Opcion();
            opcion.Numero = reader["numero"].ToString();
            opcion.Id = Convert.ToInt16(reader["id"]);
            opcion.Id32 = Convert.ToInt32(reader["id"]);

            var idNaviera = Convert.ToInt32(reader["Naviera"]);
            if (_navieras == null)
                _navieras = ClsNavierasDAO.ListarNavieras() as List<ClsNaviera>;

            opcion.Naviera = _navieras.Find(foo => foo.Id32 == idNaviera);

            opcion.TiempoTransito = reader["tiempoTransito"].ToString();
            opcion.FechaValidezInicio = Convert.ToDateTime(reader["fechaValidezInicio"]);
            opcion.FechaValidezFin = Convert.ToDateTime(reader["fechaValidezFin"]);
          
           opcion.Detalles =  ClsOpcionDetalleDao.ObtieneDetalle(opcion.Id32).ObjetoTransaccion as List<DetalleOpcion>;

            var idEstado = Convert.ToInt32(reader["COTIZACION_DIRECTA_ESTADOS_id"]);


            opcion.Usuario = Usuarios.clsUsuarioADO.ObtenerTransaccionUsuarioPorId(Convert.ToInt32(reader["idUsuario"])).ObjetoTransaccion as clsUsuario;


            return opcion;

        }


    }
}
