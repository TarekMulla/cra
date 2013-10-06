using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using Microsoft.Office.Interop.Outlook;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Emails;
using SCCMultimodal.Utils;
using Exception = System.Exception;

namespace ProyectoCraft.WinForm.Utils
{
    public static class EnvioEmail
    {
        private static Application oApp;
        private static _NameSpace oNameSpace;
        private static MAPIFolder oOutboxFolder;

        /*
        public static ResultadoTransaccion EnviarHTmlEmail(string toValue, string subjectValue, string bodyValue)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                oApp = new Application();
                oNameSpace = oApp.GetNamespace("MAPI");
                oOutboxFolder = oNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
                _MailItem oMailItem = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);
                oMailItem.To = toValue;
                oMailItem.Subject = subjectValue;
                if (oMailItem.HTMLBody.IndexOf("</BODY>") > -1)
                    oMailItem.HTMLBody = oMailItem.HTMLBody.Replace("</BODY>", bodyValue);

                oMailItem.SaveSentMessageFolder = oOutboxFolder;
                oMailItem.BodyFormat = OlBodyFormat.olFormatHTML;

                oMailItem.Send();

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                res.Descripcion = ex.Message;
                res.Estado = Enums.EstadoTransaccion.Rechazada;

                Log.EscribirLog(ex.Message);
            }

            return res;

        }
        */
        /// <summary>
        /// Metodo para el envio de Email desde el Modulo Calendario
        /// </summary>
        /// <param name="toValue">Email del receptor</param>
        /// <param name="subjectValue">Asunto del Email</param>
        /// <param name="bodyValue">Cuerpo del Email</param>        
        public static ResultadoTransaccion EnviarEmail(string toValue, string subjectValue, string bodyValue)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                oApp = new Application();
                oNameSpace = oApp.GetNamespace("MAPI");
                oOutboxFolder = oNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
                _MailItem oMailItem = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);
                oMailItem.To = toValue;
                oMailItem.Subject = subjectValue;
                oMailItem.Body = bodyValue;
                oMailItem.SaveSentMessageFolder = oOutboxFolder;
                oMailItem.BodyFormat = OlBodyFormat.olFormatRichText;

                oMailItem.Send();

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                res.Descripcion = ex.Message;
                res.Estado = Enums.EstadoTransaccion.Rechazada;

                Log.EscribirLog(ex.Message);
            }

            return res;

        }

        public static ResultadoTransaccion MailEnBorrador(string toValue, string subjectValue, string bodyValue)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                oApp = new Application();
                oNameSpace = oApp.GetNamespace("MAPI");
                oOutboxFolder = oNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderDrafts);
                _MailItem oMailItem = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);
                oMailItem.To = toValue;
                oMailItem.Subject = subjectValue;
                oMailItem.Body = bodyValue;
                //oMailItem.SaveSentMessageFolder = oOutboxFolder;
                
                oMailItem.BodyFormat = OlBodyFormat.olFormatRichText;

                oMailItem.Save();

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                res.Descripcion = ex.Message;
                res.Estado = Enums.EstadoTransaccion.Rechazada;

                Log.EscribirLog(ex.Message);
            }

            return res;

        }       
    }

}
