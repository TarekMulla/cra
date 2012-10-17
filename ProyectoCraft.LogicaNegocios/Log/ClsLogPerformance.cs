using ProyectoCraft.AccesoDatos.Log;
using ProyectoCraft.Entidades.Log;

namespace ProyectoCraft.LogicaNegocios.Log {
    public static class ClsLogPerformance {
        public static void Save(LogPerformance logPerformance) {
            ClsLogPerformanceADO.Save(logPerformance);
        }
    }
}
