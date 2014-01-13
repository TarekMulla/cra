/*
 * Created by SharpDevelop.
 * User: vhspiceros
 * Date: 24/07/2013
 * Time: 22:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta
{
	/// <summary>
	/// Description of ClsCotizacionIndirectaItem.
	/// </summary>
	public class ClsCotizacionIndirectaItemDao{
		private const String NombreClase = "ClsCotizacionIndirectaItemDAO";
		
		public ClsCotizacionIndirectaItemDao(){	}
		
		public static ResultadoTransaccion ObtieneTodos() {
			
			var res = new ResultadoTransaccion();
			var CotizacionIndirectaItems = new List<CotizacionIndirectaItem>();
			//Abrir Conexion
			var conn = BaseDatos.Conexion();
			try {

				var command = new SqlCommand("SP_L_COTIZACION_INDIRECTA_ITEMS", conn);
				command.CommandType = CommandType.StoredProcedure;
				var reader = command.ExecuteReader();
				while (reader.Read())
					CotizacionIndirectaItems.Add(GetFromDataReader(reader));
				

				res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
				res.ObjetoTransaccion = CotizacionIndirectaItems;
				res.Descripcion = "Se Listaron todas las items de las cotizaciones indirectas Exitosamente";

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

		private static CotizacionIndirectaItem GetFromDataReader(SqlDataReader reader) {
			var item = new CotizacionIndirectaItem();
			item.Id = Convert.ToInt16(reader["id"]);
			item.Id32 = Convert.ToInt32(reader["id"]);
			item.Nombre = reader["nombre"].ToString();
			item.Descripcion = reader["descripcion"].ToString();
			item.Activo = Convert.ToBoolean(reader["activo"]);
			return item;
		}
	}
}