using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace SCCMultimodal.Cotizaciones {
    public class CotizacionSetting {
        private XmlDocument _xmlDoc;
        public NotificacionesCotizacionesIndirectas NotificacionesIndirectas { set; get; }

        public CotizacionSetting() {
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(Path.Combine(Application.StartupPath, @"Cotizaciones\CotizacionSetting.xml"));
            NotificacionesIndirectas = new NotificacionesCotizacionesIndirectas(_xmlDoc);
        }


    }

    public class NotificacionesCotizacionesIndirectas {
        private readonly XmlDocument _xmlDoc;
        public List<String> Destinatarios { set; get; }
        public String TemplateNuevaCotizacion { set; get; }
        public String TemplateAceptaCotizacion { set; get; }
        public String TemplateIngresoTarifa { set; get; }
        public String SubjectNuevaCotizacion { set; get; }
        public String SubjectAceptaCotizacion { set; get; }
        public String SubjectIngresoTarifa { set; get; }


        public NotificacionesCotizacionesIndirectas(XmlDocument xmlDoc) {
            _xmlDoc = xmlDoc;
            Destinatarios = new List<string>();
            ReadXml();
        }

        private void ReadXml() {
            var nodeDistinatarios = _xmlDoc.SelectNodes("/setting/cotizacionIndirecta/notificaciones/destinatarios/destinatario");
            if (nodeDistinatarios != null)
                foreach (XmlNode nodeDistinatario in nodeDistinatarios) {
                    Destinatarios.Add(nodeDistinatario.InnerText);
                }

            var nodeNuevaCotizacion = _xmlDoc.SelectSingleNode("/setting/cotizacionIndirecta/notificaciones/template/ingreso");
            TemplateNuevaCotizacion = nodeNuevaCotizacion.InnerText;
            SubjectNuevaCotizacion = nodeNuevaCotizacion.Attributes["subject"].InnerText;

            var nodeAceptacionCotizacion = _xmlDoc.SelectSingleNode("/setting/cotizacionIndirecta/notificaciones/template/aceptado");
            TemplateAceptaCotizacion = nodeAceptacionCotizacion.InnerText;
            SubjectAceptaCotizacion = nodeAceptacionCotizacion.Attributes["subject"].InnerText;


            var nodeNuevaTarifa = _xmlDoc.SelectSingleNode("/setting/cotizacionIndirecta/notificaciones/template/ingresoTarifa");
            TemplateIngresoTarifa = nodeNuevaTarifa.InnerText;
            SubjectIngresoTarifa = nodeNuevaTarifa.Attributes["subject"].InnerText;
        }
    }
}
