using ProyectoCraft.AccesoDatos.LogPerfomance;
using ProyectoCraft.Entidades.Log;

namespace ProyectoCraft.LogicaNegocios.Log {
    public static class ClsLogPerformance {
        public static void Save(LogPerformance logPerformance) {
            var st = new System.Diagnostics.StackTrace();
            logPerformance.Accion = st.GetFrame(1).GetMethod().Name;
            logPerformance.Modulo = st.GetFrame(1).GetMethod().ReflectedType.FullName;
            ClsLogPerformanceADO.Save(logPerformance);
        }
    }
}
