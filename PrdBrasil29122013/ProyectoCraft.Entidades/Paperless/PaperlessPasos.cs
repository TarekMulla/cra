using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessPasos: GlobalObject.NamedObject
    {
        public PaperlessPasos()
        {
            //PasoAnterior = new PaperlessPasos();
            //PasoSiguiente = new PaperlessPasos();
        }

        public int NumPaso { get; set; }
        public bool Activo { get; set; }
        public PaperlessPasos PasoAnterior { get; set; }
        public PaperlessPasos PasoSiguiente { get; set; }


    }
}
