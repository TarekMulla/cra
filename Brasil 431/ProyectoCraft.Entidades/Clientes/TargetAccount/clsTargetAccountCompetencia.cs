using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Clientes.TargetAccount
{
    public class clsTargetAccountCompetencia : GlobalObject.NamedObject
    {
        public clsTargetAccountCompetencia(){}

        public clsTargetAccountCompetencia(Int64 id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public DateTime FechaCreacion { get; set; }
    }
}
