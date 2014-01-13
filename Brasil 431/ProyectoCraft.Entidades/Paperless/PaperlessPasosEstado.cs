using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessPasosEstado
    {
        public PaperlessPasosEstado()
        {
            Paso = new PaperlessPasos();
        }

        public Int64 IdAsignacion { get; set; }
        public PaperlessPasos Paso { get; set; }
        public Int64 IdPasoEstado { get; set; }
        public bool Estado { get; set; }
        public String Pantalla { set; get; }
    }

}
