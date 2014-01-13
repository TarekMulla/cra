using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Emails;

namespace ProyectoCraft.LogicaNegocios.Emails
{
    public static class clsEmails
    {
        public static PlantillaEmail ObtenerPlantillaPorTipo(Entidades.Enums.Enums.EmailTipoPlantilla tipo)
        {
            return AccesoDatos.Emails.EmailsADO.ObtenerPlantillaPorTipo(tipo);
        }

    }
}
