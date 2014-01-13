using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Emails
{
    public class PlantillaEmail: IdentifiableObject
    {
        public PlantillaEmail() { }

        public Entidades.Enums.Enums.EmailTipoPlantilla TipoEmail { get; set; }
        public string TextoPlantilla { get; set; }
        public Enums.Enums.Estado Estado { get; set; }


    }
}
