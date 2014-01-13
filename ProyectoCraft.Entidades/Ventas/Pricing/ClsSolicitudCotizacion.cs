using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.Entidades.Ventas.Pricing
{

    public class ClsTipoTransbordo : NamedObject { }

    public abstract class ClsSolicitudCotizacion : IdentifiableObject
    {
        public String Numero
        {
            get { return String.Format("{0:d4}", Id32); }
        }

        public clsUsuario Usuario { set; get; }
        public clsClienteMaster Cliente { set; get; }
        public DateTime FechaSolicitud { set; get; }
        public clsIncoTerm IncoTerm { set; get; }
        public String PuertoEmbarque { set; get; }
        public String POL { set; get; }
        public String POD { set; get; }
        public String NavieraReferencia { set; get; }
        public String TarifaReferencia { set; get; }
        public String Mercaderia { set; get; }
        public String GastosLocales { set; get; }
        public String ProveedorCarga { set; get; }
        public String Comentario { set; get; }
        public DateTime FechaCreacion { set; get; }
        public ClsEstado.Estado Estado { set; get; }
        public List<ClsDetalleSolicitud> DetalleSolicitud { set; get; }
        public ClsTipoTransbordo TipoTransabordo { get; set; }
        public abstract ClsTipoCotizacion.Tipo Tipo { get; }
        public List<ClsCometarioHistorial> ComentariosHitoriales { set; get; }
        public abstract Int32 CantidadDeOpciones { get; }
        public abstract List<ClsSolicitudCotizacionOpcionesDisplay> OpcionesDisplays { get; } 
    }



    [Serializable]
    public class ClsSolicitudCotizacionIndirecta : ClsSolicitudCotizacion
    {
        public clsUsuario UsuarioAsignadoPricing { set; get; }
        public List<ClsSolicitudCotizacionInDirectaOpciones> Opciones { set; get; }

        public ClsSolicitudCotizacionIndirecta()
        {
            Opciones = new List<ClsSolicitudCotizacionInDirectaOpciones>();
        }

        public override ClsTipoCotizacion.Tipo Tipo
        {
            get { return ClsTipoCotizacion.Tipo.SolicitudDeTarifa; }
        }

        public override int CantidadDeOpciones
        {
            get { return Opciones.Count; }
        }

        public override List<ClsSolicitudCotizacionOpcionesDisplay> OpcionesDisplays{
            get { var list = new List<ClsSolicitudCotizacionOpcionesDisplay>();
                foreach (var op in Opciones){
                    var foo = new ClsSolicitudCotizacionOpcionesDisplay();
                    foo.Id = op.Id;
                    foo.Id32 = op.Id32;
                    foo.Fecha = op.Fecha;
                    foo.FechaCreacion = op.FechaCreacion;
                    foo.Fecha = op.Fecha;
                    foo.FechaValidezInicio = op.FechaValidezInicio;
                    foo.FechaValidezFin = op.FechaValidezFin;
                    foo.Agente = op.Agente;
                    foo.Naviera = op.Naviera;
                }
                return list;
            }
        }

        public void AddTarifa(ClsSolicitudCotizacionInDirectaOpciones opcion)
        {

            Opciones.Add(opcion);
            if (String.IsNullOrEmpty(opcion.Numero))
                opcion.Numero = string.Format("{0:d4}-{1:d3}", Id32, Opciones.Count);
        }
    }

    [Serializable]
    public class ClsSolicitudCotizacionDirecta : ClsSolicitudCotizacion
    {

        public List<ClsSolicitudCotizacionDirectaOpciones> Opciones { set; get; }

        public override ClsTipoCotizacion.Tipo Tipo
        {
            get { return ClsTipoCotizacion.Tipo.Directa; }
        }

        public List<ClsSolicitudCotizacionDirectaOpciones> OpcionesDirecta { set; get; }
        public void ClsSolicitudCotizacion()
        {
            Opciones = new List<ClsSolicitudCotizacionDirectaOpciones>();
        }
        public override int CantidadDeOpciones
        {
            get
            {
                if (Opciones == null)
                    Opciones = new List<ClsSolicitudCotizacionDirectaOpciones>();

                return Opciones.Count;
            }
        }

        public void AddOpcion(ClsSolicitudCotizacionDirectaOpciones opcion)
        {

            if (Opciones == null)
                Opciones = new List<ClsSolicitudCotizacionDirectaOpciones>();

            Opciones.Add(opcion);
            if (String.IsNullOrEmpty(opcion.Numero))
                opcion.Numero = string.Format("{0:d4}-{1:d3}", Id32, Opciones.Count);
        }
        
        public override List<ClsSolicitudCotizacionOpcionesDisplay> OpcionesDisplays
        {
            get
            {
                var list = new List<ClsSolicitudCotizacionOpcionesDisplay>();
                foreach (var op in Opciones)
                {
                    var foo = new ClsSolicitudCotizacionOpcionesDisplay();
                    foo.Id = op.Id;
                    foo.Id32 = op.Id32;
                    foo.Fecha = op.Fecha;
                    foo.FechaCreacion = op.FechaCreacion;
                    foo.Fecha = op.Fecha;
                    foo.FechaValidezInicio = op.FechaValidezInicio;
                    foo.FechaValidezFin = op.FechaValidezFin;
                    foo.Agente = op.Agente;
                    foo.Naviera = op.Naviera;
                }
                return list;
            }
        }

    }

    public abstract class ClsSolicitudCotizacionOpciones : IdentifiableObject
    {
        public String Numero { set; get; }
        public String Naviera { set; get; }
        public DateTime Fecha { set; get; }
        public DateTime FechaValidezInicio { set; get; }
        public DateTime FechaValidezFin { set; get; }
        public String Agente { set; get; }
        public String Comentario { set; get; }
        public String ComentarioInterno { set; get; }
        public DateTime FechaCreacion { set; get; }
        public ClsEstado.Estado Estado { set; get; }
        public clsUsuario CreadoPor { set; get; }
        public List<ClsCometarioHistorial> ComentariosHitoriales { set; get; }

    }
    public class ClsSolicitudCotizacionOpcionesDisplay : ClsSolicitudCotizacionOpciones
    {

    }

    public class ClsSolicitudCotizacionInDirectaOpciones : ClsSolicitudCotizacionOpciones
    {
        public List<ClsSolicitudCotizacionInDirectaOpcionesDetalle> Detalle { set; get; }
    }

    public class ClsSolicitudCotizacionDirectaOpciones : ClsSolicitudCotizacionOpciones
    {
        public List<ClsSolicitudCotizacionDirectaOpcionesDetalle> Detalle { set; get; }
    }

    public abstract class ClsSolicitudCotizacionOpcionesDetalle : IdentifiableObject
    {
        public Decimal Cantidad { set; get; }
        public Decimal Costo { set; get; }
        public Decimal Venta { set; get; }
        public ClsMonedas Moneda { set; get; }

    }

    public class ClsSolicitudCotizacionDirectaOpcionesDetalle : ClsSolicitudCotizacionOpcionesDetalle
    {
        public ClsSolicitudCotizacionDirectaOpcionesItem Item { set; get; }
        public ClsSolicitudCotizacionDirectaOpcionesDetalle()
        {
            Item = new ClsSolicitudCotizacionDirectaOpcionesItem();
        }
    }

    public class ClsSolicitudCotizacionInDirectaOpcionesDetalle : ClsSolicitudCotizacionOpcionesDetalle
    {
        public ClsSolicitudCotizacionInDirectaOpcionesItem Item { set; get; }
    }

    public abstract class ClsSolicitudCotizacionOpcionesItem : IdentifiableObject
    {
        public Decimal Cantidad { set; get; }
        public Decimal Costo { set; get; }
        public Decimal Venta { set; get; }
        public ClsMonedas Moneda { set; get; }
        public ClsItem Item { set; get; }
    }


    public class ClsSolicitudCotizacionDirectaOpcionesItem : ClsSolicitudCotizacionOpcionesItem
    {
        public ClsSolicitudCotizacionDirectaOpcionesItem()
        {
            Item = new ClsItem();
            Moneda = new ClsMonedas();
        }
    }

    public class ClsSolicitudCotizacionInDirectaOpcionesItem : ClsSolicitudCotizacionOpcionesItem
    {
    }


    public abstract class ClsCometarioHistorial : IdentifiableObject
    {
        public DateTime Fecha { set; get; }
        public Boolean EsHistorial { set; get; }
        public ClsEstado EstadoAntiguo { set; get; }
        public ClsEstado EstadoNuevo { set; get; }
        public String Comentario { set; get; }
        public clsUsuario USuario { set; get; }
    }

}
