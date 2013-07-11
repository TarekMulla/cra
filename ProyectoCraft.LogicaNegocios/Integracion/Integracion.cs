using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Integracion;

namespace ProyectoCraft.LogicaNegocios.Integracion
{
    public class Integracion
    {
        public static IList<IntegracionNetShip> ObtenerHousesBlDesdeNetShip(string NumMaster)
        {
            return AccesoDatos.Integracion.IntegracionADO.ObtieneValoresNetShip(NumMaster);            
        }

        public static void GuardaLogProceso(IntegracionNetShip _int)
        {
            AccesoDatos.Integracion.IntegracionADO.GuardaLogProceso(_int);
        }
    }
}
