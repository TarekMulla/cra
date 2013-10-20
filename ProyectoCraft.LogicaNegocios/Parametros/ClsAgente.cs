using ProyectoCraft.AccesoDatos.Parametros;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Parametros
{
    public class ClsAgente
    {
        public static ResultadoTransaccion CreaAgente(Agente agente)
        {
            return ClsAgenteDao.CreaAgente(agente);
        }

        public static ResultadoTransaccion ActualizaAgente(Agente agente)
        {
            return ClsAgenteDao.ActualizaAgente(agente);
        }

        public  static ResultadoTransaccion EliminaAgente(Agente agente)
        {
            return ClsAgenteDao.EliminaAgente(agente);
        }

        public static  ResultadoTransaccion ObtenerAgentes()
        {
            return ClsAgenteDao.ObtenerAgentes();
        }



    }
}
