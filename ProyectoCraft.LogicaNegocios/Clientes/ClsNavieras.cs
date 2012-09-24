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
            return AccesoDatos.Parametros.ClsNavierasADO.ListarNavieras(Activo);                     
        }

        public static ResultadoTransaccion ActualizarNaviera(Int64 id, string nombre)
        {
            return AccesoDatos.Parametros.ClsNavierasADO.ActualizarNaviera(id,nombre);
        }
        public static ResultadoTransaccion NuevaNaviera( string nombre)
        {
            return AccesoDatos.Parametros.ClsNavierasADO.NuevaNaviera(nombre);
        }
        public static ResultadoTransaccion EliminaNaviera(Int64 id)
        {
            return AccesoDatos.Parametros.ClsNavierasADO.EliminaNaviera(id);
        }
    }
}
