﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Mantenedores;


namespace ProyectoCraft.AccesoDatos.Cotizaciones
{
    public class ClsPuertosDao
    {

        private const String NombreClase = "ClsPuertosDao";

        public static ResultadoTransaccion ObtieneTodosLosPuertos()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<Puerto> puertos = new List<Puerto>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try
            {

                SqlCommand command = new SqlCommand("SP_L_Puertos", conn);

                //command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    puertos.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = puertos;
                res.Descripcion = "Se creo la cotizacion Exitosamente";

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

        public static ResultadoTransaccion ObtienePuertoPorCodigo(String codigo)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Puerto puerto = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try
            {

                SqlCommand command = new SqlCommand("SP_L_Puertos_por_codigo", conn);

                //command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codigo", codigo);
                var reader = command.ExecuteReader();
                while (reader.Read())
                    puerto = GetFromDataReader(reader);
                

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = puerto;
                res.Descripcion = "Se creo la cotizacion Exitosamente";

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

        public static ResultadoTransaccion ObtienePuertosPorNaviera(ClsNaviera naviera)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            List<Puerto> puertos = new List<Puerto>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try
            {

                SqlCommand command = new SqlCommand("SP_L_Puertos_por_naviera", conn);

                //command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idNaviera", naviera.Id32);
                var reader = command.ExecuteReader();
                while (reader.Read())
                    puertos.Add(GetFromDataReader(reader));


                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = puertos;
                res.Descripcion = "Se creo la cotizacion Exitosamente";

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

        private static Puerto GetFromDataReader(SqlDataReader reader)
        {
            var p = new Puerto();
            p.Codigo = reader["puerto"].ToString();
            p.Nombre = reader["nombre"].ToString();
            return p;
        }

    }
}