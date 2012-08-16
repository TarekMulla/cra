using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.GlobalObject
{
    public class NamedObject: IdentifiableObject
    {
        private String _name;

        public virtual string Nombre
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
