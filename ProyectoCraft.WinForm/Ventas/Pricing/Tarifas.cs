using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Ventas.pricing;
using negocio = ProyectoCraft.LogicaNegocios.Ventas.pricing;
using entidad = ProyectoCraft.Entidades.Ventas.Pricing;

namespace SCCMultimodal.Ventas.Pricing
{
    public class Tarifa : IdentifiableObject
    {
        public Tarifa()
        {
            Comentarios = new List<Comentario>();
            Historials = new List<Historial>();
        }
        
        public clsUsuario Usuario { set; get; }
        public clsClienteMaster Cliente { set; get; }
        public DateTime FechaSolicitud { set; get; }
        public String LugarPick { set; get; }
        public String PuertoDestino { set; get; }
        public String Incoterms { set; get; }
        public String Unidad { set; get; }
        public String Naviera { set; get; }
        public String Mercaderia { set; get; }
        public String TarifaReferencia { set; get; }
        public String Proveedor { set; get; }
        public String Estado { set; get; }
        public List<Comentario> Comentarios { set; get; }
        public List<Historial> Historials { set; get; }

        public static List<Tarifa> GenerateList()
        {
            var list = new List<Tarifa>();
            var tarifa = new Tarifa();
            tarifa.Id = 1;
            tarifa.Id32 = 1;
            tarifa.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            tarifa.Cliente = new clsClienteMaster(true);
            tarifa.Cliente.NombreCompañia = "cliente1";
            tarifa.FechaSolicitud = DateTime.Now;
            tarifa.LugarPick = "lugar Pick UP";
            tarifa.PuertoDestino = "Puerto Destino";
            tarifa.Incoterms = "incoterms";
            tarifa.Unidad = "unidad";
            tarifa.Naviera = "Naviera";
            tarifa.Mercaderia = "Mercaderia";
            tarifa.TarifaReferencia = "Tarifa Referencia";
            tarifa.Proveedor = "proveedor";

            tarifa.Estado = "Ingresada";
            tarifa.Comentarios.Add(new Comentario
            {
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now,
                Observacion = "este es un comentario"
            });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now, Observacion = "Se ingresa al sistema" });
            list.Add(tarifa);

            tarifa = new Tarifa();
            tarifa.Id = 2;
            tarifa.Id32 = 2;
            tarifa.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            tarifa.Cliente = new clsClienteMaster(true);
            tarifa.Cliente.NombreCompañia = "cliente2";
            tarifa.FechaSolicitud = DateTime.Now.AddDays(-4);
            tarifa.LugarPick = "lugar Pick UP2";
            tarifa.PuertoDestino = "Puerto Destino2";
            tarifa.Incoterms = "incoterms2";
            tarifa.Unidad = "unidad2";
            tarifa.Naviera = "Naviera2";
            tarifa.Mercaderia = "Mercaderia2";
            tarifa.TarifaReferencia = "Tarifa Referencia2";
            tarifa.Proveedor = "proveedor2";

            tarifa.Estado = "Tarifa ingresada";
            tarifa.Comentarios.Add(new Comentario
            {
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now.AddDays(-4),
                Observacion = "este es un comentario de la tarifa2"
            });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-4), Observacion = "Se ingresa al sistema" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-2), Observacion = "Se ingresa tarifa" });
            list.Add(tarifa);

            tarifa = new Tarifa();
            tarifa.Id = 3;
            tarifa.Id32 = 3;
            tarifa.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            tarifa.Cliente = new clsClienteMaster(true);
            tarifa.Cliente.NombreCompañia = "cliente3";
            tarifa.FechaSolicitud = DateTime.Now.AddDays(-4);
            tarifa.LugarPick = "lugar Pick UP3";
            tarifa.PuertoDestino = "Puerto Destino3";
            tarifa.Incoterms = "incoterms3";
            tarifa.Unidad = "unidad3";
            tarifa.Naviera = "Naviera3";
            tarifa.Mercaderia = "Mercaderia3";
            tarifa.TarifaReferencia = "Tarifa Referencia3";
            tarifa.Proveedor = "proveedor3";

            tarifa.Estado = "Enviada al cliente";
            tarifa.Comentarios.Add(new Comentario
            {
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now.AddDays(-4),
                Observacion = "este es un comentario de la tarifa3"
            });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-4), Observacion = "Se ingresa al sistema" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-2), Observacion = "Se ingresa tarifa" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-1), Observacion = "Se Envia al cliente" });
            list.Add(tarifa);

            tarifa = new Tarifa();
            tarifa.Id = 4;
            tarifa.Id32 = 4;
            tarifa.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            tarifa.Cliente = new clsClienteMaster(true);
            tarifa.Cliente.NombreCompañia = "cliente4";
            tarifa.FechaSolicitud = DateTime.Now.AddDays(-4);
            tarifa.LugarPick = "lugar Pick UP4";
            tarifa.PuertoDestino = "Puerto Destino4";
            tarifa.Incoterms = "incoterms4";
            tarifa.Unidad = "unidad4";
            tarifa.Naviera = "Naviera4";
            tarifa.Mercaderia = "Mercaderia4";
            tarifa.TarifaReferencia = "Tarifa Referencia4";
            tarifa.Proveedor = "proveedor4";

            tarifa.Estado = "Ganada";
            tarifa.Comentarios.Add(new Comentario
            {
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now.AddDays(-4),
                Observacion = "este es un comentario de la tarifa4"
            });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-4), Observacion = "Se ingresa al sistema" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-2), Observacion = "Se ingresa tarifa" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-1), Observacion = "Se Envia al cliente" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-1), Observacion = "Se cambia a estado Exitoso" });
            list.Add(tarifa);

            tarifa = new Tarifa();
            tarifa.Id = 5;
            tarifa.Id32 = 5;
            tarifa.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            tarifa.Cliente = new clsClienteMaster(true);
            tarifa.Cliente.NombreCompañia = "cliente5";
            tarifa.FechaSolicitud = DateTime.Now.AddDays(-4);
            tarifa.LugarPick = "lugar Pick UP5";
            tarifa.PuertoDestino = "Puerto Destino5";
            tarifa.Incoterms = "incoterms5";
            tarifa.Unidad = "unidad5";
            tarifa.Naviera = "Naviera5";
            tarifa.Mercaderia = "Mercaderia5";
            tarifa.TarifaReferencia = "Tarifa Referencia5";
            tarifa.Proveedor = "proveedor5";

            tarifa.Estado = "Cerrado Sin feedback";
            tarifa.Comentarios.Add(new Comentario
            {
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now.AddDays(-4),
                Observacion = "este es un comentario de la tarifa4"
            });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-4), Observacion = "Se ingresa al sistema" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-2), Observacion = "Se ingresa tarifa" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-1), Observacion = "Se Envia al cliente" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-1), Observacion = "Se cambia a estado Cerrado sin Feedback" });
            list.Add(tarifa);

            tarifa = new Tarifa();
            tarifa.Id = 5;
            tarifa.Id32 = 5;
            tarifa.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            tarifa.Cliente = new clsClienteMaster(true);
            tarifa.Cliente.NombreCompañia = "cliente5";
            tarifa.FechaSolicitud = DateTime.Now.AddDays(-4);
            tarifa.LugarPick = "lugar Pick UP5";
            tarifa.PuertoDestino = "Puerto Destino5";
            tarifa.Incoterms = "incoterms5";
            tarifa.Unidad = "unidad5";
            tarifa.Naviera = "Naviera5";
            tarifa.Mercaderia = "Mercaderia5";
            tarifa.TarifaReferencia = "Tarifa Referencia5";
            tarifa.Proveedor = "proveedor5";

            tarifa.Estado = "Rechazado por cliente";
            tarifa.Comentarios.Add(new Comentario
            {
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now.AddDays(-4),
                Observacion = "este es un comentario de la tarifa4"
            });

            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-4), Observacion = "Se ingresa al sistema" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-2), Observacion = "Se ingresa tarifa" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-1), Observacion = "Se Envia al cliente" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-0.5), Observacion = "Se cambia a estado a Cerrado Rechazado" });
            list.Add(tarifa);

            tarifa = new Tarifa();
            tarifa.Id = 7;
            tarifa.Id32 = 7;
            tarifa.Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario;
            tarifa.Cliente = new clsClienteMaster(true);
            tarifa.Cliente.NombreCompañia = "cliente5";
            tarifa.FechaSolicitud = DateTime.Now.AddDays(-4);
            tarifa.LugarPick = "lugar Pick UP5";
            tarifa.PuertoDestino = "Puerto Destino5";
            tarifa.Incoterms = "incoterms5";
            tarifa.Unidad = "unidad5";
            tarifa.Naviera = "Naviera5";
            tarifa.Mercaderia = "Mercaderia5";
            tarifa.TarifaReferencia = "Tarifa Referencia5";
            tarifa.Proveedor = "proveedor5";

            tarifa.Estado = "Cerrado Rechazado";
            tarifa.Comentarios.Add(new Comentario
            {
                Usuario = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now.AddDays(-4),
                Observacion = "este es un comentario de la tarifa4"
            });

            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-4), Observacion = "Se ingresa al sistema" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-2), Observacion = "Se ingresa tarifa" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-1), Observacion = "Se Envia al cliente" });
            tarifa.Historials.Add(new Historial { Fecha = DateTime.Now.AddDays(-0.5), Observacion = "Se cambia a estado a Cerrado Rechazado" });
            list.Add(tarifa);
            return list;
        }
   
    }

    public class Comentario
    {
        public clsUsuario Usuario { set; get; }
        public DateTime Fecha { set; get; }
        public String Observacion { set; get; }
    }

    public class Historial
    {
        public DateTime Fecha { set; get; }
        public String Observacion { set; get; }
    }
}