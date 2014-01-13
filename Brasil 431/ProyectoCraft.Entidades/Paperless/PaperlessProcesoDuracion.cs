using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessProcesoDuracion: GlobalObject.IdentifiableObject
    {
        public PaperlessProcesoDuracion(){}

        public Int64 IdAsignacion { get; set; }
        public PaperlessTipoCarga TipoCarga { get; set; }
        public decimal Duracion { get; set; }
        public bool Activo { get; set; }
        public decimal TiempoAlerta { get; set; }
        //public DateTime Inicio { get; set; }
        //public DateTime Termino { get; set; }
    }
}
