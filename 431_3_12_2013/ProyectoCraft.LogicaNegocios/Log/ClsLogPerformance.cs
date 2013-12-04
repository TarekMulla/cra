using System;
using ProyectoCraft.AccesoDatos.LogPerfomance;
using ProyectoCraft.Entidades.Log;

namespace ProyectoCraft.LogicaNegocios.Log {
    public static class ClsLogPerformance {
        public static void Save(LogPerformance logPerformance) {
            var st = new System.Diagnostics.StackTrace();
            if (String.IsNullOrEmpty(logPerformance.Accion))
                logPerformance.Accion = st.GetFrame(1).GetMethod().Name;
            if (String.IsNullOrEmpty(logPerformance.Modulo))
                logPerformance.Modulo = st.GetFrame(1).GetMethod().ReflectedType.FullName;
            ClsLogPerformanceADO.Save(logPerformance);
        }
    }
}
