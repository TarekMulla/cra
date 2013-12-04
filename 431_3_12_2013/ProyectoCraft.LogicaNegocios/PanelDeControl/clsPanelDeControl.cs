using System;
using ProyectoCraft.AccesoDatos.PanelDeControl;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.PanelDeControl {
    public class ClsPanelDeControl {
        public static ResultadoTransaccion ExecuteGenericquery(String query) {
            return ClsPanelDeControlDao.ExecuteGenericquery(query);
        }

        public static ResultadoTransaccion ExecuteGenericqueryDataset(String query) {
            return ClsPanelDeControlDao.ExecuteGenericqueryDataset(query);
        }
    }
}
