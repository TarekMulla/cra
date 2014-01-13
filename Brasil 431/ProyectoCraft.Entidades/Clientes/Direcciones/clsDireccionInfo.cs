using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Clientes.Direcciones
{
    public class clsDireccionInfo : ItemCollection<clsDireccion>
    {
        public clsDireccionInfo()
        {
            IdInfo = 0;
        }
        public clsDireccionInfo(Int64 idinfo)
        {
            this.IdInfo = idinfo;
        }
        public Int64 IdInfo { get; set; }

        public IList<clsDireccion> DireccionesActivas()
        {
            IList<clsDireccion> direcciones = new List<clsDireccion>();

            foreach (var item in Items)
            {
                if(!item.IsDeleted)
                    direcciones.Add(item);
            }

            return direcciones;
        }
    }
}
