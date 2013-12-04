using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Clientes.Target
{
    public class clsEmpresaCompetencia: GlobalObject.NamedObject
    {
        public clsEmpresaCompetencia(){}

        public clsEmpresaCompetencia(Int64 id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public DateTime FechaCreacion { get; set; }



    }
}
