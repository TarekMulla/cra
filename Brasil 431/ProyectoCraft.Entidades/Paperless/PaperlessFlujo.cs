using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessFlujo
    {
        public PaperlessFlujo()
        {
            Asignacion = new PaperlessAsignacion();
        }

        public PaperlessAsignacion Asignacion { get; set; }


        public Enums.Enums.EstadoPaperless EstadoFlujo { get; set; }
        public string EstadoFlujoDescripcion { get; set; }


    }
}
