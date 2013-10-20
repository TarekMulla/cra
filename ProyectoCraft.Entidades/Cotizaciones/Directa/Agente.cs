using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Cotizaciones.Directa
{
    public class Agente : IdentifiableObject
    {
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
    }
}
