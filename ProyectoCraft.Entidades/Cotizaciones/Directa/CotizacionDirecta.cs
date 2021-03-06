﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.Entidades.Cotizaciones.Directa {

    public class CotizacionDirecta : IdentifiableObject, ITableable {
        public CotizacionDirecta() {
            Opciones = new List<Opcion>();
            Comentarios = new List<Comentario>();
            GastosLocalesList = new List<GastoLocal>();
            FollowUps = new List<clsClienteFollowUp>();
        }

        public String Producto { set; get; }
        public String Numero {
            get {
                return String.Format("{0:d4}", Id32);
            }
        }
        public clsUsuario Usuario { set; get; }
        public clsClienteMaster Cliente { set; get; }
        public clsTarget Target { set; get; }
        public String NombreCliente { set; get; }
        public DateTime FechaSolicitud { set; get; }
        public clsIncoTerm IncoTerm { set; get; }
        public String Commodity { set; get; }
        [Obsolete("no usar")]
        public Decimal? GastosLocales { set; get; }
        public String CondicionFija { set; get; }
        public String CondicionVariable { set; get; }
        public List<Opcion> Opciones { set; get; }
        public Estado Estado { set; get; }
        public String EstadoDescripcion { get { return Estado.Nombre; } }
        public String ProveedorCarga { set; get; }
        public String Observaciones { set; get; }
        public String ObservacionesFijas { set; get; }
        public List<Comentario> Comentarios { set; get; }
        public List<GastoLocal> GastosLocalesList { set; get; }

        public string Tipo {
            get { return "Directa"; }
        }

        public bool Seleccionado { set; get; }

        public List<ITableableOpcion> OpcionesView {
            get {
                return Opciones.Cast<ITableableOpcion>().ToList();
            }
        }

        public DateTime? NextFollowup { get; set; }

        public int FollowUpIcon {
            get {
                if (NextFollowup == null)
                    return 100;

                var rojo = 10;
                var foo = ConfigurationManager.AppSettings["indicardorCotizacionesRojo"];
                if (foo != null)
                    rojo = (int)Convert.ToInt64(foo);

                var amarillo = 5;
                foo = ConfigurationManager.AppSettings["indicardorCotizacionesAmarillo"];
                if (foo != null)
                    amarillo = (int)Convert.ToInt64(foo);

                //COLOR ROJO
                if (NextFollowup.Value > DateTime.Now.AddDays(rojo))
                    return 3;
                //COLOR AMARILLO
                if (NextFollowup.Value > DateTime.Now.AddDays(amarillo))
                    return 2;
                //COLOR VERDE
                return 1;
            }
        }

        public int CantidadOpciones {
            get {
                return Opciones == null ? 0 : Opciones.Count;
            }
        }

        public bool PermiteCopiar { get { return true; } }

        public Int32 CopiadoDe { get; set; }
        public IList<clsClienteFollowUp> FollowUps { get; set; }


        public String GenerateHtmlPreviewAndBody(String startupPath) {
            return RenderHtml(Path.Combine(startupPath, @"cotizaciones\TemplateCotizacionPreview.html"));
            //return renderHtml(Path.Combine(startupPath, @"cotizaciones\Copy of TemplateCotizacionPreview.html"));
        }

        public String GenerateHTMLforPDF(String startupPath) {
            return RenderHtml(Path.Combine(startupPath, @"cotizaciones\TemplateCotizacionMailPDF.html"));
        }

        private String RenderHtml(String path) {
            var xmldoc = new XmlDocument();
            xmldoc.Load(path);

            path = path.Replace("\\TemplateCotizacionPreview.html", "");
            path = path.Replace("\\TemplateCotizacionMailPDF.html", "");
            var stringXml = xmldoc.InnerXml;

            var cl = new CultureInfo("es-CL");
            path = path.Replace("\\", "/");
            stringXml = stringXml.Replace("[baseUrl]", "file://" + path + "/");

            stringXml = stringXml.Replace("[fecha]", FechaSolicitud.ToString("D", cl));
            stringXml = stringXml.Replace("[numCotzacion]", Numero);
            stringXml = stringXml.Replace("[commodity]", Commodity);
            stringXml = stringXml.Replace("[incoterm]", IncoTerm.Codigo);

            var glString = string.Empty;
            foreach (var gl in GastosLocalesList) {
                glString += String.Format(@"<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                    gl.Descripcion, gl.Monto.ToString("c0", new CultureInfo("es-CL")),
                                            "+ IVA");
            }
            if (GastosLocalesList.Count == 0)
                glString = String.Format(@"<tr><td>Sin Gastos Locales</td></tr>");

            glString = "<table>" + glString + "</table>";

            // var gastosLocales = (GastosLocales == 0 || GastosLocales == null) ? "Sin Gastos Locales" : GastosLocales.Value.ToString("c0", new CultureInfo("es-CL")) + "  + IVA";


            stringXml = stringXml.Replace("[gastosLocales]", glString);
            stringXml = stringXml.Replace("[observaciones]", ObservacionesFijas.Replace(Environment.NewLine, "<br/>"));

            stringXml = stringXml.Replace("[ObservacionesOpcionales]", Observaciones.Replace(Environment.NewLine, "<br/>"));

            stringXml = stringXml.Replace("[vendedor]", Usuario.NombreCompleto);
            stringXml = stringXml.Replace("[cargo]", Usuario.Cargo.Nombre);
            xmldoc.InnerXml = stringXml;

            var alternativaNode = xmldoc.SelectSingleNode("//*[@id='alternativas']");
            var originalAlternativa = alternativaNode.InnerXml;
            var alternativasXml = String.Empty;
            var i = 1;
            foreach (var opcion in Opciones) {
                var templateAlternativaXml = originalAlternativa;
                templateAlternativaXml = templateAlternativaXml.Replace("[numOpcion]", i.ToString());
                templateAlternativaXml = templateAlternativaXml.Replace("[naviera]", opcion.Naviera.Nombre);
                templateAlternativaXml = templateAlternativaXml.Replace("[validezIni]", opcion.FechaValidezInicio.ToString("d \\de MMMM ", cl));
                templateAlternativaXml = templateAlternativaXml.Replace("[validezFin]", opcion.FechaValidezFin.ToString("d \\de MMMM \\de yyyy ", cl));
                templateAlternativaXml = templateAlternativaXml.Replace("[TiempoTransito]", opcion.TiempoTransito);

                var text = opcion.TiposServicio.Nombre;
                if (opcion.TipoVia != null && !String.IsNullOrEmpty(opcion.TipoVia.Nombre))
                    text += "    / <b>Vía</b> " + opcion.TipoVia.Nombre;
                templateAlternativaXml = templateAlternativaXml.Replace("[servicio]", text);


                var pod = opcion.Pod.Aggregate(string.Empty, (current, puerto) => current + puerto.Nombre + Environment.NewLine);
                var pol = opcion.Pol.Aggregate(string.Empty, (current, puerto) => current + puerto.Nombre + Environment.NewLine);
                if (pod.Length > 0)
                    pod = pod.Substring(0, pod.Length - 1);
                if (pol.Length > 0)
                    pol = pol.Substring(0, pol.Length - 1);
                templateAlternativaXml = templateAlternativaXml.Replace("[pod]", pod.Replace(Environment.NewLine, " / "));
                templateAlternativaXml = templateAlternativaXml.Replace("[pol]", pol.Replace(Environment.NewLine, " / "));
                var detalleString = String.Empty;
                foreach (var detalle in opcion.Detalles) {
                    detalleString += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                                                  detalle.Unidad.Nombre, detalle.Moneda.Codigo,
                                                  detalle.Venta.ToString("N2"), detalle.Concepto.Nombre);


                }
                templateAlternativaXml = templateAlternativaXml.Replace("[detalle]", detalleString);
                alternativasXml += templateAlternativaXml;
                i++;
            }
            alternativaNode.InnerXml = alternativasXml;

            if (File.Exists(String.Format("{0}/imagesCotizaciones/firmas/{1}.png", path, Usuario.NombreUsuario)))
                xmldoc.InnerXml = xmldoc.InnerXml.Replace("[firma]", Usuario.NombreUsuario + ".png");
            else
                xmldoc.InnerXml = xmldoc.InnerXml.Replace("[firma]", "general.png");

            return xmldoc.InnerXml;
        }

    }
}