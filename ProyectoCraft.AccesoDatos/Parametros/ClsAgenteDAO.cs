using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.Parametros
{
   public class ClsAgenteDao
    {
       private const String NombreClase = "ClsAgenteDao";


       public static ResultadoTransaccion ObtenerAgentes()
       {
           ResultadoTransaccion res = new ResultadoTransaccion();
           IList<Agente> agentes = new List<Agente>();

           //Abrir Conexion
           var conn = BaseDatos.Conexion();
           try
           {

               var command = new SqlCommand("SP_L_AGENTES", conn);
               command.CommandType = CommandType.StoredProcedure;
               var reader = command.ExecuteReader();
               while (reader.Read())
               {
                   agentes.Add(GetFromDataReader(reader));
               }

               res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
               res.ObjetoTransaccion = agentes;
               res.Descripcion = "Listado de Agentes";

           }
           catch (Exception ex)
           {
               Log.EscribirLog(ex.Message);

               res.Descripcion = ex.Message;
               res.ArchivoError = NombreClase;
               res.MetodoError = MethodBase.GetCurrentMethod().Name;
           }
           finally
           {
               conn.Close();
           }
           return res;

       }


       private static Agente GetFromDataReader(SqlDataReader reader)
       {
           var p = new Agente();
           p.Descripcion = reader["descripcion"].ToString();
           p.Contacto = reader["contacto"].ToString();
           p.Email = reader["email"].ToString();
           p.Alias = reader["alias"].ToString();
           return p;
       }


       public static ResultadoTransaccion CreaAgente(Agente agente)
       {
           var res = new ResultadoTransaccion();
           //Abrir Conexion
           var conn = BaseDatos.Conexion();
           try
           {
               var command = new SqlCommand("SP_N_AGENTES", conn);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@descripcion", agente.Descripcion);
               command.Parameters.AddWithValue("@contacto", agente.Contacto);
               command.Parameters.AddWithValue("@email", agente.Email);
               command.Parameters.AddWithValue("@alias", agente.Alias);

               var foo = command.ExecuteNonQuery();

               res.ObjetoTransaccion = agente;
               res.Descripcion = "El Agente se creo Exitosamente";

           }
           catch (Exception ex)
           {
               Log.EscribirLog(ex.Message);

               res.Descripcion = ex.Message;
               //res.ArchivoError = NombreClase;
               res.MetodoError = MethodBase.GetCurrentMethod().Name;
           }
           finally
           {
               conn.Close();
           }
           return res;
       }


       public static ResultadoTransaccion ActualizaAgente(Agente agente)
       {
           var res = new ResultadoTransaccion();
           //Abrir Conexion
           var conn = BaseDatos.Conexion();
           try
           {

               var command = new SqlCommand("SP_A_AGENTES", conn);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@descripcion", agente.Descripcion);
               command.Parameters.AddWithValue("@contacto", agente.Contacto);
               command.Parameters.AddWithValue("@email", agente.Email);
               command.Parameters.AddWithValue("@alias", agente.Alias);
               var foo = command.ExecuteNonQuery();

               res.ObjetoTransaccion = agente;
               res.Descripcion = "El Agente se actualizo Exitosamente";

           }
           catch (Exception ex)
           {
               Log.EscribirLog(ex.Message);

               res.Descripcion = ex.Message;
               res.ArchivoError = NombreClase;
               res.MetodoError = MethodBase.GetCurrentMethod().Name;
           }
           finally
           {
               conn.Close();
           }
           return res;
       }


       public static ResultadoTransaccion EliminaAgente(Agente agente)
       {
           var res = new ResultadoTransaccion();
           //Abrir Conexion
           var conn = BaseDatos.Conexion();
           try
           {
               var command = new SqlCommand("SP_E_AGENTES", conn);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@descripcion", agente.Descripcion);
               var foo = command.ExecuteNonQuery();

               res.ObjetoTransaccion = agente;
               res.Descripcion = "Se Elimino el Agente Exitosamente";

           }
           catch (Exception ex)
           {
               Log.EscribirLog(ex.Message);

               res.Descripcion = ex.Message;
               res.ArchivoError = NombreClase;
               res.MetodoError = MethodBase.GetCurrentMethod().Name;
           }
           finally
           {
               conn.Close();
           }
           return res;
       }

    }
}
