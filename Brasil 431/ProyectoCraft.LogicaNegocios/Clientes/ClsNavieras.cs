using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Mantenedores;

namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public static class ClsNavieras
    {
        public static IList<ClsNaviera> ListarNavieras(bool Activo)
        {
            return AccesoDatos.Parametros.ClsNavierasDAO.ListarNavieras(Activo);                     
        }
        public static IList<ClsNaviera> ListarNavieras()
        {
            return AccesoDatos.Parametros.ClsNavierasDAO.ListarNavieras();
        }

        public static ResultadoTransaccion ActualizarNaviera(Int64 id, string nombre,string relacionPuertos)
        {
            return AccesoDatos.Parametros.ClsNavierasDAO.ActualizarNaviera(id,nombre,relacionPuertos);
        }
        public static ResultadoTransaccion NuevaNaviera( string nombre,string relacionPuertos)
        {
            return AccesoDatos.Parametros.ClsNavierasDAO.NuevaNaviera(nombre,relacionPuertos);
        }
        public static ResultadoTransaccion EliminaNaviera(Int64 id)
        {
            return AccesoDatos.Parametros.ClsNavierasDAO.EliminaNaviera(id);
        }
        public static IList<ClsNaviera> BuscarNavieraPorTextoLike(string naviera)
        {
            return AccesoDatos.Parametros.ClsNavierasDAO.BuscarNavieraPorTextoLike(naviera);                     
        }
        
    }
}
