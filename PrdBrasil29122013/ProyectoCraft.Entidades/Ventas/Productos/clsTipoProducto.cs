using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Ventas.Productos
{
    public class clsTipoProducto: GlobalObject.NamedObject
    {
        public string ExpoImpo { get; set; }
        public string Activo { get; set; }

        public bool EsLCL
        {
            get
            {
                if (Nombre.Contains("LCL"))
                    return true;

                return false;
            }
        }

        public bool EsFCL
        {
            get
            {
                if (Nombre.Contains("FCL"))
                    return true;

                return false;
            }
        }

        public bool EsAereo
        {
            get
            {
                if (Nombre.Contains("Aereo"))
                    return true;

                return false;
            }
        }
    }
}
