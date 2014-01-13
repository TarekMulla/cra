using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Ventas.Traficos;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsVisitaInformeTrafico: GlobalObject.IdentifiableObject
    {
        public clsVisitaInformeTrafico()
        {
            Trafico = new clsTrafico();
        }

        public clsVisitaInformeTrafico(clsTrafico trafico)
        {
            Trafico = trafico;
        }

        

        public Entidades.Ventas.Traficos.clsTrafico Trafico { get; set; }

       
        //public Entidades.Ventas.
            


    }
}
