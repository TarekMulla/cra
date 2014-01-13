using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.GlobalObject
{
    public class ResultadoTransaccion
    {
        public ResultadoTransaccion()
        {
            Errores = new List<string>();
        }

        public ResultadoTransaccion(string descripcion, Enums.Enums.EstadoTransaccion estado, string metodoerror, string archivoerror)
        {
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.MetodoError = metodoerror;
            this.ArchivoError = archivoerror;
            Errores = new List<string>();
        }

        public string Descripcion { get; set; }

        public IList<string> Errores { get; set; }

        public Enums.Enums.EstadoTransaccion Estado { get; set; }
        public string MetodoError { get; set; }
        public string ArchivoError { get; set; }
        public Enums.Enums.AccionTransaccion Accion { get; set; }
        public object ObjetoTransaccion { get; set; }


    }
}
