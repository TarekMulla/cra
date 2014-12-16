using System;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessPuerto : GlobalObject.NamedObject
    {
        public String Codigo { set; get; }
        public String Puerto { set; get; }
        public String Pais { set; get; }
        public Boolean Activo { set; get; }

        //public override string ToString()
        //{
        //    return Nombre;
        //}
    }
}