using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Integracion;

namespace ProyectoCraft.LogicaNegocios.Integracion
{
    public class Integracion
    {
        public static IList<IntegracionNetShip> ObtenerHousesBlDesdeNetShip(string NumMaster, string StoreProcedureName)
        {
            return AccesoDatos.Integracion.IntegracionADO.ObtieneValoresNetShip(NumMaster, StoreProcedureName);            
        }

        public static void GuardaLogProceso(IntegracionNetShip _int)
        {
            AccesoDatos.Integracion.IntegracionADO.GuardaLogProceso(_int);
        }
        public static IList<PaperlessIntegracionNetShipLog>  ObtieneLogPaperlessNetShip(Int32 idPaperless)
        {
            return AccesoDatos.Integracion.IntegracionADO.ObtieneLogPaperlessNetShip(idPaperless);            
        }
    }
}
