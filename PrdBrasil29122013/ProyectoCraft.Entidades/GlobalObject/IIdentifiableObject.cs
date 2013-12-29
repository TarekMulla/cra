using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.GlobalObject
{
    public interface IIdentifiableObject
    {
        int CompareTo(object obj);
        bool Equals(object obj);
        int GetHashCode();
        long Id { get; set; }
        int Id32 { get; set; }
        void Initialize();
        bool IsNew { get; }

    }
}
