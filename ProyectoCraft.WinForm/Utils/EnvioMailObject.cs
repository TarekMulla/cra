using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.Office.Interop.Outlook;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Emails;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.WinForm.Utils;
using ProyectoCraft.Base.Log;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Exception = System.Exception;

namespace SCCMultimodal.Utils {
    public class EnvioMailObject {
        public IList<string> emailPersonas;
        private static Application oApp;
        private static _NameSpace oNameSpace;
        private static MAPIFolder oOutboxFolder;

        public EnvioMailObject() {
            emailPersonas = new List<string>();
        }

        public ResultadoTransaccion EnviarEmail(string toValue, string subjectValue, string bodyValue) {
            if (!emailPersonas.Contains(toValue)) {
                emailPersonas.Add(toValue);
                return EnvioEmail.EnviarEmail(toValue, subjectValue, bodyValue);
            }
            return null;
        }

        public ResultadoTransaccion EnviarEmailComentarioEnInforme(clsVisita visita, clsInformeComentario comentario,
                                                                   bool EsVendedor, clsUsuario usuario) {
            string EmailAviso =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailComentarioInformeVisita");
            string espectativas = "";
            string EmailBody = "";
            string productos = "";
            string traficos = "";
            string asistentescliente = "";
            string asistentescraft = "";
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                foreach (var producto in visita.Informvisita.Productos) {
                    productos += producto.Producto.Nombre + " / ";
                }

                foreach (var trafico in visita.Informvisita.Traficos) {
                    traficos += trafico.Trafico.Nombre + " / ";
                }

                foreach (var asistente in visita.AsistentesCraft) {
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                        asistentescraft += asistente.Usuario.NombreCompleto + "\n";
                }

                foreach (var asistente in visita.AsistentesCliente) {
                    asistentescliente += asistente.Contacto.NombreCompleto + "\n";
                }

                StringBuilder sb = new StringBuilder(EmailAviso);
                sb.Replace("[USUARIO]", visita.Vendedor.NombreCompleto);
                sb.Replace("[USUARIOCOMENTADOR]", comentario.Usuario.NombreCompleto);
                if (visita.Cliente.NombreFantasia.Trim() != "")
                    sb.Replace("[CLIENTE]", visita.Cliente.NombreFantasia);
                else
                    sb.Replace("[CLIENTE]", visita.Cliente.NombreCompañia);

                sb.Replace("[COMENTARIO]", comentario.Comentario);

                sb.Replace("[ASUNTO]", visita.Asunto);
                sb.Replace("[UBICACION]", visita.Ubicacion);
                sb.Replace("[INICIO]", visita.FechaHoraComienzo.ToString());
                sb.Replace("[TERMINO]", visita.FechaHoraTermino.ToString());
                sb.Replace("[ASISTENTESCLIENTE]", asistentescliente);
                sb.Replace("[ASISTENTESCRAFT]", asistentescraft);
                sb.Replace("[PRODUCTOS]", productos);
                sb.Replace("[TRAFICOS]", traficos);
                if (visita.Informvisita.FollowUp.FechaFollowUp != null)
                    sb.Replace("[FOLLOWUP]", visita.Informvisita.FollowUp.FechaFollowUp.Value.ToShortDateString());

                if (visita.Informvisita.OtroTema)
                    sb.Replace("[OTROS]", "SI");
                else
                    sb.Replace("[OTROS]", "NO");

                if (visita.Informvisita.TieneEspectativaCierre)
                    espectativas = " SI (" + visita.Informvisita.EspectativaCierre + "%)";
                else
                    espectativas = " NO  ";

                sb.Replace("[ESPECTATIVAS]", espectativas);

                sb.Replace("[RESUMEN]", visita.Informvisita.ResumenVisita);
                sb.Replace("[SALTO]", "\n");

                EmailBody = sb.ToString();
                string asunto = "Comentario a Informe de Visita: " + visita.Cliente.NombreFantasia;

                if (!EsVendedor)
                    EnviarEmail(visita.Vendedor.Email, asunto, EmailBody);
                else
                    EnviarEmail(usuario.Email, asunto, EmailBody);

                LogEnviarEmail(Enums.VisitaTipoEmail.ComentarioAInformeVisita, visita, EmailBody, asunto);

                foreach (var productoscustomer in visita.Cliente.ProductosPreferidos) {
                    if (productoscustomer.Customer != null) {
                        sb.Replace(visita.Vendedor.NombreCompleto, productoscustomer.Customer.NombreCompleto);
                        EmailBody = sb.ToString();
                        EnviarEmail(productoscustomer.Customer.Email, asunto, EmailBody);
                    }
                }


                res.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
            }
            return res;

        }

        public ResultadoTransaccion LogEnviarEmail(Enums.VisitaTipoEmail tipo, clsVisita Visita, string cuerpo,
                                                   string asunto) {
            ResultadoTransaccion res = new ResultadoTransaccion();

            clsEmail email = new clsEmail();
            email.Asunto = Visita.Asunto;
            email.Ubicacion = Visita.Ubicacion;
            email.Cuerpo = cuerpo;
            email.Emisor = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Email;
            email.Receptores = Visita.EmailAsistentesCraft;
            email.FechaEmision = DateTime.Now;
            email.Visita = Visita;
            email.TipoEmail = tipo;

            res = ProyectoCraft.LogicaNegocios.Calendarios.clsCalendarios.LogEmailVisita(email);

            return res;
        }

        public ResultadoTransaccion EnviarEmailComentarioRespondidoPorVendedor(clsVisita visita,
                                                                               clsInformeComentario comentario) {
            IList<clsInformeComentario> lista = new List<clsInformeComentario>();
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                lista =
                    ProyectoCraft.LogicaNegocios.Calendarios.clsCalendarios.ListarComentariosVisita(
                        visita.Informvisita.Id);

                foreach (var comment in lista) {
                    if (comment.Usuario.Id != visita.Vendedor.Id) {
                        EnviarEmailVendedorRespondeComentarioEnInforme(visita, comentario, true, comment.Usuario);
                    }
                }

                //Enviar comentario a customers
                foreach (var producto in visita.Cliente.ProductosPreferidos) {
                    if (producto.Customer != null) {
                        EnviarEmailVendedorRespondeComentarioEnInforme(visita, comentario, false, producto.Customer);
                    }
                }

            } catch (Exception ex) {
                res.Descripcion = ex.Message;
                res.Estado = Enums.EstadoTransaccion.Rechazada;

            }

            return res;
        }

        public ResultadoTransaccion EnviarEmailVendedorRespondeComentarioEnInforme(clsVisita visita,
                                                                                   clsInformeComentario comentario,
                                                                                   bool EsVendedor, clsUsuario usuario) {

            string EmailAviso =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailComentarioInformeVisita");
            string espectativas = "";
            string EmailBody = "";
            string productos = "";
            string traficos = "";
            string asistentescliente = "";
            string asistentescraft = "";
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                foreach (var producto in visita.Informvisita.Productos) {
                    productos += producto.Producto.Nombre + " / ";
                }

                foreach (var trafico in visita.Informvisita.Traficos) {
                    traficos += trafico.Trafico.Nombre + " / ";
                }

                foreach (var asistente in visita.AsistentesCraft) {
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                        asistentescraft += asistente.Usuario.NombreCompleto + "\n";
                }

                foreach (var asistente in visita.AsistentesCliente) {
                    asistentescliente += asistente.Contacto.NombreCompleto + "\n";
                }

                StringBuilder sb = new StringBuilder(EmailAviso);
                sb.Replace("[USUARIO]", usuario.NombreCompleto);
                sb.Replace("[USUARIOCOMENTADOR]", visita.Vendedor.NombreCompleto);
                if (visita.Cliente.NombreFantasia.Trim() != "")
                    sb.Replace("[CLIENTE]", visita.Cliente.NombreFantasia);
                else
                    sb.Replace("[CLIENTE]", visita.Cliente.NombreCompañia);

                sb.Replace("[COMENTARIO]", comentario.Comentario);

                sb.Replace("[ASUNTO]", visita.Asunto);
                sb.Replace("[UBICACION]", visita.Ubicacion);
                sb.Replace("[INICIO]", visita.FechaHoraComienzo.ToString());
                sb.Replace("[TERMINO]", visita.FechaHoraTermino.ToString());
                sb.Replace("[ASISTENTESCLIENTE]", asistentescliente);
                sb.Replace("[ASISTENTESCRAFT]", asistentescraft);
                sb.Replace("[PRODUCTOS]", productos);
                sb.Replace("[TRAFICOS]", traficos);
                if (visita.Informvisita.FollowUp.FechaFollowUp != null)
                    sb.Replace("[FOLLOWUP]", visita.Informvisita.FollowUp.FechaFollowUp.Value.ToShortDateString());

                if (visita.Informvisita.OtroTema)
                    sb.Replace("[OTROS]", "SI");
                else
                    sb.Replace("[OTROS]", "NO");

                if (visita.Informvisita.TieneEspectativaCierre)
                    espectativas = " SI (" + visita.Informvisita.EspectativaCierre + "%)";
                else
                    espectativas = " NO  ";

                sb.Replace("[ESPECTATIVAS]", espectativas);

                sb.Replace("[RESUMEN]", visita.Informvisita.ResumenVisita);
                sb.Replace("[SALTO]", "\n");

                EmailBody = sb.ToString();
                string asunto = "Comentario a Informe de Visita: " + visita.Cliente.NombreFantasia;

                if (!EsVendedor) {
                    EnviarEmail(visita.Vendedor.Email, asunto, EmailBody);
                } else {
                    EnviarEmail(usuario.Email, asunto, EmailBody);
                }

                LogEnviarEmail(Enums.VisitaTipoEmail.ComentarioAInformeVisita, visita, EmailBody, asunto);

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
            }
            return res;

        }

        public void EnviarEmailInformeVisita(clsVisitaInforme informe, clsVisita VisitaActual) {

            string EmailBody = "";
            string productos = "";
            string traficos = "";
            string RecFijos = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFijo");
            string RecLCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeLCL");
            string RecFCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFCL");
            string RecAereo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeAereo");
            string EmailInforme = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeVisita");
            string espectativas = "";

            try {
                foreach (var producto in informe.Productos) {
                    productos += producto.Producto.Nombre + " / ";
                }

                foreach (var trafico in informe.Traficos) {
                    traficos += trafico.Trafico.Nombre + " / ";
                }

                foreach (var asistente in VisitaActual.AsistentesCraft) {
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia) {
                        StringBuilder sb = new StringBuilder(EmailInforme);
                        sb.Replace("[ASISTENTE]", asistente.Usuario.NombreCompleto);

                        if (VisitaActual.Cliente == null) {
                            sb.Replace("[CLIENTE]", "");
                        } else {
                            if (VisitaActual.Cliente.NombreFantasia.Trim() != "")
                                sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreFantasia);
                            else
                                sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreCompañia);
                        }


                        sb.Replace("[PRODUCTOS]", productos);
                        sb.Replace("[TRAFICOS]", traficos);

                        if (informe.TieneEspectativaCierre)
                            espectativas = " SI (" + informe.EspectativaCierre + "%)";
                        else
                            espectativas = " NO  ";

                        sb.Replace("[ESPECTATIVAS]", espectativas);
                        if (informe.FollowUp.FechaFollowUp != null)
                            sb.Replace("[FOLLOWUP] ", informe.FollowUp.FechaFollowUp.Value.ToShortDateString());
                        sb.Replace("[RESUMEN]", informe.ResumenVisita);
                        sb.Replace("[SALTO]", "\n");

                        EmailBody = sb.ToString();
                        string asunto = "Informe Visita: " + VisitaActual.Asunto;

                        EnviarEmail(asistente.Usuario.Email, asunto, EmailBody);

                        LogEnviarEmail(Enums.VisitaTipoEmail.InformeVisitaConfirmados, VisitaActual, EmailBody, asunto);

                    }
                }

                //Enviar informe a Customers Services
                foreach (var producto in VisitaActual.Cliente.ProductosPreferidos) {
                    if (producto.Customer != null) {
                        StringBuilder sb = new StringBuilder(EmailInforme);
                        sb.Replace("[ASISTENTE]", producto.Customer.NombreCompleto);

                        if (VisitaActual.Cliente == null) {
                            sb.Replace("[CLIENTE]", "");
                        } else {
                            if (VisitaActual.Cliente.NombreFantasia.Trim() != "")
                                sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreFantasia);
                            else
                                sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreCompañia);
                        }


                        sb.Replace("[PRODUCTOS]", productos);
                        sb.Replace("[TRAFICOS]", traficos);

                        if (informe.TieneEspectativaCierre)
                            espectativas = " SI (" + informe.EspectativaCierre + "%)";
                        else
                            espectativas = " NO  ";

                        sb.Replace("[ESPECTATIVAS]", espectativas);
                        if (informe.FollowUp.FechaFollowUp != null)
                            sb.Replace("[FOLLOWUP] ", informe.FollowUp.FechaFollowUp.Value.ToShortDateString());
                        sb.Replace("[RESUMEN]", informe.ResumenVisita);
                        sb.Replace("[SALTO]", "\n");

                        EmailBody = sb.ToString();
                        string asunto = "Informe Visita: " + VisitaActual.Asunto;


                        EnviarEmail(producto.Customer.Email, asunto, EmailBody);
                        LogEnviarEmail(Enums.VisitaTipoEmail.InformeVisitaConfirmados, VisitaActual, EmailBody, asunto);

                    }
                }


                //Receptores Fijos
                string[] fijos = RecFijos.Split(';');
                string[] lcl = RecLCL.Split(';');
                string[] fcl = RecFCL.Split(';');
                string[] aereo = RecAereo.Split(';');

                foreach (var fijo in fijos) {
                    clsUsuario usuario = ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ObtenerUsuarioPorEmail(fijo);
                    if (usuario != null) {
                        EnviarInformeReceptoresFijos(VisitaActual, usuario, productos, traficos,
                                                     Enums.VisitaTipoEmail.InformeVisitaFijos);
                    }
                }

                bool esLCL = false;
                bool esFCL = false;
                bool esAereo = false;

                foreach (var prod in VisitaActual.Informvisita.Productos) {
                    if (prod.Producto.EsLCL)
                        esLCL = true;
                    if (prod.Producto.EsFCL)
                        esFCL = true;
                    if (prod.Producto.EsAereo)
                        esAereo = true;
                }

                //busacr productos clientes

                IList<ProyectoCraft.Entidades.Clientes.clsClientesProductos> productoscliente = null;

                if (VisitaActual.Cliente == null)
                    productoscliente = new List<clsClientesProductos>();
                else
                    productoscliente =
                        ProyectoCraft.LogicaNegocios.Clientes.clsClientesMaster.ObtenerProductosPreferidos(
                            VisitaActual.Cliente.Id);

                foreach (var prod in productoscliente) {

                    if (!esLCL)
                        if (prod.Producto.EsLCL) esLCL = true;

                    if (!esFCL)
                        if (prod.Producto.EsFCL) esFCL = true;

                    if (!esAereo)
                        if (prod.Producto.EsAereo) esAereo = true;
                }

                if (esLCL) {
                    foreach (var fijo in lcl) {
                        clsUsuario usuario =
                            ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ObtenerUsuarioPorEmail(fijo);
                        if (usuario != null) {
                            EnviarInformeReceptoresFijos(VisitaActual, usuario, productos, traficos,
                                                         Enums.VisitaTipoEmail.InformeVisitaEncNegocio);
                        }
                    }
                }

                if (esFCL) {
                    foreach (var fijo in fcl) {
                        clsUsuario usuario =
                            ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ObtenerUsuarioPorEmail(fijo);
                        if (usuario != null) {
                            EnviarInformeReceptoresFijos(VisitaActual, usuario, productos, traficos,
                                                         Enums.VisitaTipoEmail.InformeVisitaEncNegocio);
                        }
                    }
                }

                if (esAereo) {
                    foreach (var fijo in aereo) {
                        clsUsuario usuario =
                            ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ObtenerUsuarioPorEmail(fijo);
                        if (usuario != null) {
                            EnviarInformeReceptoresFijos(VisitaActual, usuario, productos, traficos,
                                                         Enums.VisitaTipoEmail.InformeVisitaEncNegocio);
                        }
                    }
                }

                //Enviar Email a Customers
                foreach (var customer in productoscliente) {
                    if (customer.Customer != null) {
                        EnviarInformeReceptoresFijos(VisitaActual, customer.Customer, productos, traficos,
                                                     Enums.VisitaTipoEmail.InformeVisitaCustomerService);
                    }
                }

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
            }
        }

        private void EnviarInformeReceptoresFijos(clsVisita VisitaActual, clsUsuario usuario, string productos,
                                                  string traficos, Enums.VisitaTipoEmail tipo) {


            string EmailInforme =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeVisitaRecFijos");
            string espectativas = "";
            string EmailBody = "";

            try {
                StringBuilder sb = new StringBuilder(EmailInforme);
                sb.Replace("[USUARIO]", usuario.NombreCompleto);

                if (VisitaActual.Vendedor == null)
                    sb.Replace("[VENDEDOR]", "");
                else
                    sb.Replace("[VENDEDOR]", VisitaActual.Vendedor.NombreCompleto);

                if (VisitaActual.Cliente == null) {
                    sb.Replace("[CLIENTE]", "");
                } else {
                    if (VisitaActual.Cliente.NombreFantasia.Trim() != "")
                        sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreFantasia);
                    else
                        sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreCompañia);
                }


                sb.Replace("[INICIO]", VisitaActual.FechaHoraComienzo.ToString());
                sb.Replace("[TERMINO]", VisitaActual.FechaHoraTermino.ToString());
                sb.Replace("[ASUNTO]", VisitaActual.Asunto);
                sb.Replace("[PRODUCTOS]", productos);
                sb.Replace("[TRAFICOS]", traficos);

                if (VisitaActual.Informvisita.TieneEspectativaCierre)
                    espectativas = " SI (" + VisitaActual.Informvisita.EspectativaCierre + "%)";
                else
                    espectativas = " NO  ";

                sb.Replace("[ESPECTATIVAS]", espectativas);
                if (VisitaActual.Informvisita.FollowUp.FechaFollowUp != null)
                    sb.Replace("[FOLLOWUP]", VisitaActual.Informvisita.FollowUp.FechaFollowUp.Value.ToShortDateString());
                sb.Replace("[RESUMEN]", VisitaActual.Informvisita.ResumenVisita);
                sb.Replace("[SALTO]", "\n");

                EmailBody = sb.ToString();
                string asunto = "Registro de Informe de Visita: " + VisitaActual.Asunto;


                EnviarEmail(usuario.Email, asunto, EmailBody);

                LogEnviarEmail(tipo, VisitaActual, EmailBody, asunto);

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
            }

        }

        public ResultadoTransaccion EnviarAvisoInformeRequiereRespuesta(IList<clsUsuario> usuarios, clsVisita visita) {

            string EmailAviso =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailAvisoInformRequiereRespuesta");
            string espectativas = "";
            string EmailBody = "";
            string productos = "";
            string traficos = "";
            string asistentescliente = "";
            string asistentescraft = "";
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                foreach (var producto in visita.Informvisita.Productos) {
                    productos += producto.Producto.Nombre + " / ";
                }

                foreach (var trafico in visita.Informvisita.Traficos) {
                    traficos += trafico.Trafico.Nombre + " / ";
                }

                foreach (var asistente in visita.AsistentesCraft) {
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                        asistentescraft += asistente.Usuario.NombreCompleto + "\n";
                }

                foreach (var asistente in visita.AsistentesCliente) {
                    asistentescliente += asistente.Contacto.NombreCompleto + "\n";
                }


                foreach (var usuario in usuarios) {
                    StringBuilder sb = new StringBuilder(EmailAviso);
                    sb.Replace("[USUARIO]", usuario.NombreCompleto);
                    sb.Replace("[VENDEDOR]", visita.Vendedor.NombreCompleto);
                    if (visita.Cliente.NombreFantasia.Trim() != "")
                        sb.Replace("[CLIENTE]", visita.Cliente.NombreFantasia);
                    else
                        sb.Replace("[CLIENTE]", visita.Cliente.NombreCompañia);

                    sb.Replace("[ASUNTO]", visita.Asunto);
                    sb.Replace("[UBICACION]", visita.Ubicacion);
                    sb.Replace("[INICIO]", visita.FechaHoraComienzo.ToString());
                    sb.Replace("[TERMINO]", visita.FechaHoraTermino.ToString());
                    sb.Replace("[ASISTENTESCLIENTE]", asistentescliente);
                    sb.Replace("[ASISTENTESCRAFT]", asistentescraft);


                    sb.Replace("[PRODUCTOS]", productos);
                    sb.Replace("[TRAFICOS]", traficos);
                    if (visita.Informvisita.FollowUp.FechaFollowUp != null)
                        sb.Replace("[FOLLOWUP]", visita.Informvisita.FollowUp.FechaFollowUp.Value.ToShortDateString());

                    if (visita.Informvisita.OtroTema)
                        sb.Replace("[OTROS]", "SI");
                    else
                        sb.Replace("[OTROS]", "NO");

                    if (visita.Informvisita.TieneEspectativaCierre)
                        espectativas = " SI (" + visita.Informvisita.EspectativaCierre + "%)";
                    else
                        espectativas = " NO  ";

                    sb.Replace("[ESPECTATIVAS]", espectativas);

                    sb.Replace("[RESUMEN]", visita.Informvisita.ResumenVisita);
                    sb.Replace("[SALTO]", "\n");

                    EmailBody = sb.ToString();
                    string asunto = "Solicitud de Respuesta a Informe de Visita: " + visita.Cliente.NombreFantasia;


                    EnviarEmail(usuario.Email, asunto, EmailBody);

                    LogEnviarEmail(Enums.VisitaTipoEmail.AvisoInformeRequiereRespuesta, visita, EmailBody, asunto);



                    res.Estado = Enums.EstadoTransaccion.Aceptada;
                }
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
            }
            return res;

        }

        public ResultadoTransaccion EnviarMailPaperlessRechazoAsignacion(
            ProyectoCraft.Entidades.Paperless.PaperlessAsignacion asignacion) {

            ResultadoTransaccion resultado = new ResultadoTransaccion();
            string EmailAviso =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailPaperlessRechazoAsignacion");
            string EmailBody = "";
            try {
                StringBuilder sb = new StringBuilder(EmailAviso);
                sb.Replace("[USUARIO]", asignacion.UsuarioCreacion.NombreCompleto);
                sb.Replace("[USUARIO1]", asignacion.Usuario1.NombreCompleto);
                sb.Replace("[NUMMASTER]", asignacion.NumMaster);
                sb.Replace("[FECHAASIGNACION]", asignacion.FechaCreacion.ToShortDateString());
                sb.Replace("[SALTO]", "\n");

                EmailBody = sb.ToString();
                EnviarEmail(asignacion.UsuarioCreacion.Email, "Asignacion Rechazada N° Master " + asignacion.NumMaster,
                            EmailBody);

                resultado.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
            }

            return resultado;
        }

        public ResultadoTransaccion EnviarMailPaperlessUsuario2TerminaProceso(
            ProyectoCraft.Entidades.Paperless.PaperlessAsignacion asignacion,
            ProyectoCraft.Entidades.Paperless.PaperlessUsuario1HouseBLInfo info) {
            string EmailAviso =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailPaperlessConfirmacionTerminoProceso");
            string EmailBody = "";
            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                List<ProyectoCraft.Entidades.Usuarios.clsUsuario> usuarios = new List<clsUsuario>();

                IList<clsUsuario> supdocumental;
                res = ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado,
                                                                                       Enums.CargosUsuarios.
                                                                                           SupervisorDocumental);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    usuarios.AddRange((IList<clsUsuario>)res.ObjetoTransaccion);

                res = ProyectoCraft.LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado,
                                                                                       Enums.CargosUsuarios.
                                                                                           SupervisorDeProcesos);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                    usuarios.AddRange((IList<clsUsuario>)res.ObjetoTransaccion);


                //Usuario conectado y que envia el email
                usuarios.Add(ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario);

                //res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.e);

                foreach (var usuarioaviso in usuarios) {
                    StringBuilder sb = new StringBuilder(EmailAviso);
                    sb.Replace("[USUARIOAVISO]", usuarioaviso.NombreCompleto);
                    sb.Replace("[NUMCONSOLIDADO]", info.NumConsolidado);
                    sb.Replace("[FECHAASIGNACION]", asignacion.FechaCreacion.ToShortDateString());
                    sb.Replace("[NUMMASTER]", asignacion.NumMaster);
                    sb.Replace("[FECHAMASTER]",
                               asignacion.FechaMaster.ToString(
                                   System.Configuration.ConfigurationSettings.AppSettings.Get(
                                       "FechaMasterPaperlessFormato")));
                    //sb.Replace("[FECHAMASTER]", asignacion.FechaMaster.ToShortDateString());
                    sb.Replace("[AGENTE]", asignacion.Agente.Nombre);
                    sb.Replace("[NAVIERA]", asignacion.Naviera.Nombre);
                    sb.Replace("[NAVE]", asignacion.Nave.Nombre);
                    sb.Replace("[VIAJE]", asignacion.Viaje);
                    sb.Replace("[NHOUSESBL]", asignacion.NumHousesBL.ToString());
                    sb.Replace("[TIPOCARGA]", asignacion.TipoCarga.Nombre);
                    if (asignacion.FechaETA != null)
                        sb.Replace("[FECHAETA]",
                                   asignacion.FechaETA.Value.ToString(
                                       System.Configuration.ConfigurationSettings.AppSettings.Get(
                                           "FechaFormatoEtaPaperless")));
                    //asignacion.FechaETA.Value.ToShortDateString());

                    if (asignacion.AperturaNavieras.HasValue)
                        sb.Replace("[APERTUANAVIERAS]", asignacion.AperturaNavieras.Value.ToShortDateString());
                    else
                        sb.Replace("[APERTUANAVIERAS]", "");

                    if (asignacion.PlazoEmbarcadores != null)
                        sb.Replace("[PLAZOEMBARCADORES]", asignacion.PlazoEmbarcadores.Value.ToShortDateString());
                    else
                        sb.Replace("[PLAZOEMBARCADORES]", "");

                    sb.Replace("[USUARIO1]", asignacion.Usuario1.NombreCompleto);
                    sb.Replace("[USUARIO2]", asignacion.Usuario2.NombreCompleto);

                    sb.Replace("[IMPORTANCIA]", asignacion.ImportanciaUsuario1.Nombre);
                    sb.Replace("[OBSERVACION]", asignacion.ObservacionUsuario2);
                    sb.Replace("[SALTO]", "\n");
                    EmailBody = sb.ToString();
                    string asunto = "Proceso Documental Finalizado. N°Consolidado: " + info.NumConsolidado;

                    EnviarEmail(usuarioaviso.Email, asunto, EmailBody);
                }

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarMailAvisoNewObservacionSalesLeadGerente(clsUsuario ObjEmisor,
                                                                                  clsUsuario ObjDestinatario,
                                                                                  clsUsuario ObjAsignadorTarget,
                                                                                  string DestinatariosCopia,
                                                                                  DateTime Fecha, string Observaciones,
                                                                                  string nombreSalesLead) {
            string Asunto = "";
            string EmailBody = "";
            string EmailAviso = "";
            string Destinatarios = "";
            string MailCopiaAsignadorObs = "";
            string MailCopiaOtrosUsuariosObs = "";

            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                EmailAviso = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailNewObservacion");
                Asunto = System.Configuration.ConfigurationSettings.AppSettings.Get("AsuntoEmailNewObservacionSLead");

                StringBuilder sb = new StringBuilder(Asunto);
                sb.Replace("[USUARIO_ENVIA]", ObjEmisor.Nombre);
                sb.Replace("[FECHA]", Fecha.ToString());
                sb.Replace("[SLEAD]", nombreSalesLead);
                sb = sb.Replace("[SALTO]", "\n");
                Asunto = sb.ToString();

                StringBuilder sb2 = new StringBuilder(EmailAviso);
                sb2.Replace("[DESTINATARIO]", ObjDestinatario.Nombre);
                sb2.Replace("[OBSERVACION]", Observaciones);
                sb2.Replace("[USUARIO_ENVIA]", ObjEmisor.Nombre);
                sb2 = sb2.Replace("[SALTO]", "\n");
                EmailBody = sb2.ToString();

                Destinatarios = ObjDestinatario.Email;

                EnviarEmail(Destinatarios, Asunto, EmailBody);
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarMaiSalesLead(ClsSalesLead salesLead) {


            var res = new ResultadoTransaccion();
            try {
                oApp = new Application();
                oNameSpace = oApp.GetNamespace("MAPI");
                oOutboxFolder = oNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
                var mail = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);


                var body = CrearCuerpoMailSalesLead(salesLead,
                                                    Path.Combine(System.Windows.Forms.Application.StartupPath,
                                                                 @"mailSalesLead\template.html"));
                if (!string.IsNullOrEmpty(mail.HTMLBody) && mail.HTMLBody.ToLower().Contains("</body>")) {
                    var imagePath = Path.Combine(System.Windows.Forms.Application.StartupPath,
                                                 @"mailSalesLead\logo.png");


                    mail.Subject = "New Sales Lead";

                    //mail.To = salesLead.Agente.Email;
                    mail.To = salesLead.Agente.Email;


                    //CONTENT-ID
                    const string schemaPrAttachContentId = @"http://schemas.microsoft.com/mapi/proptag/0x3712001E";
                    var contentId = Guid.NewGuid().ToString();

                    mail.Attachments.Add(imagePath, OlAttachmentType.olEmbeddeditem, mail.HTMLBody.Length, Type.Missing);
                    mail.Attachments[mail.Attachments.Count].PropertyAccessor.SetProperty(schemaPrAttachContentId,
                                                                                          contentId);

                    //Create and add banner
                    body = body.Replace("[logo]", string.Format(@"<img src=""cid:{1}"" />", "", contentId));

                    if (mail.HTMLBody.IndexOf("</BODY>") > -1)
                        mail.HTMLBody = mail.HTMLBody.Replace("</BODY>", body);

                    mail.Display(true);
                }
            } catch (Exception e) {
                res.Descripcion = e.Message;
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                Log.EscribirLog(e.Message);
            }
            return res;
        }

        public String CrearCuerpoMailSalesLead(ClsSalesLead salesLead, String templatePath) {

            var streamReader = new StreamReader(templatePath);
            var text = streamReader.ReadToEnd();
            streamReader.Close();
            var body = ReplaceObjectsMailSalesLead(salesLead, text);
            return body;
        }

        public String ReplaceObjectsMailSalesLead(ClsSalesLead salesLead, String template) {
            var nombreVendedor = salesLead.Asignacion.VendedorAsignado.NombreCompleto;
            var emailVendedor = salesLead.Asignacion.VendedorAsignado.Email;

            var en = new CultureInfo("en-US");
            template = template.Replace("[fecha]", DateTime.Now.ToString("D", en));

            template = template.Replace("[AGENTE_NOMBRE]", salesLead.Agente.Contacto);

            template = template.Replace("[NOMBRE_VENDEDOR]", nombreVendedor);
            template = template.Replace("[EMAIL_VENDEDOR]", emailVendedor);
            template = template.Replace("[SL_REFERENCE]", salesLead.Reference);
            template = template.Replace("[SL_DATE]", salesLead.FechaApertura.ToString());
            template = template.Replace("[SL_STATUS]", salesLead.EstadoSLead.ToString());

            /*shipper*/
            template = template.Replace("[SHIPPER_NAME]", salesLead.ShipperNombre);
            template = template.Replace("[SHIPPER_ADDRESS]", salesLead.ShipperNombre);
            template = template.Replace("[SHIPPER_ZIP_CODE]", salesLead.ShipperZipCode);
            template = template.Replace("[SHIPPER_CITY]", salesLead.ShipperCiudad);
            template = template.Replace("[SHIPPER_CONTACT]", salesLead.ShipperContacto);
            template = template.Replace("[SHIPPER_E_MAIL]", salesLead.ShipperEmail);
            template = template.Replace("[SHIPPER_WEB_PAGE]", salesLead.ShipperWeb);

            /*CONSIGNEE */
            template = template.Replace("[CONSIGNEE_NAME]", salesLead.ConsigNombre);
            template = template.Replace("[CONSIGNEE_ADDRESS]", salesLead.ConsigDireccion);
            template = template.Replace("[CONSIGNEE_CITY]", salesLead.Consigciudad);
            template = template.Replace("[CONSIGNEE_TELEPHONE]", salesLead.ConsigTelefono);
            template = template.Replace("[CONSIGNEE_CONTACT]", salesLead.ConsigContacto);

            /* competencias */
            var txtCompetencias = String.Empty;
            if (salesLead.Competencias != null)
                foreach (var competencia in salesLead.Competencias)
                    txtCompetencias = txtCompetencias + "<li>" + competencia.Descripcion + "</li>";

            template = template.Replace("[COMPETITION]", txtCompetencias);
            template = template.Replace("[COMMODITY]", salesLead.GlosaCommodity);

            var txtTerminosCompra = String.Empty;
            if (salesLead.TerminosCompra != null)
                foreach (var termCompra in salesLead.TerminosCompra)
                    txtTerminosCompra = txtTerminosCompra + "<li>" + termCompra.Nombre + "</li>";

            template = template.Replace("[SALES TERMS]", txtTerminosCompra);
            template = template.Replace("[TRANSPORT]", "");
            template = template.Replace("[FCL EQUIPMENT]", "");
            template = template.Replace("[POL]", salesLead.Pol);
            template = template.Replace("[POD]", salesLead.Pod);
            template = template.Replace("[CARRIER / AIRLINE]", salesLead.CarrierAirline);
            template = template.Replace("[SHIPMENTS PER MONTH]", salesLead.EmbarquesPorMes.ToString());



            template = template.Replace("[AEREO_QTTY]",
                                        String.Format("{0} / {1}", salesLead.AereoCantidad, salesLead.AereoMedida.Nombre));
            template = template.Replace("[FCL_QTTY]",
                                        String.Format("{0} / {1}", salesLead.FCLCantidad, salesLead.FCLMedida.Nombre));
            template = template.Replace("[LCL_QTTY]",
                                        String.Format("{0} / {1}", salesLead.LCLCantidad, salesLead.LCLMedida.Nombre));


            template = template.Replace("[LAST SHIPMENT]", salesLead.FechaUltimoEmbarque.ToString("yyyy-MM-dd"));
            return template;
        }

        public ResultadoTransaccion ModificarVisitaOutlook(clsVisita VisitaActual, DateTime inicio, DateTime termino) {
            Application outlookApp = new Application();
            MAPIFolder calendar = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            Items calendarItems = calendar.Items;

            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                foreach (AppointmentItem item in calendarItems) {
                    if (item.UserProperties["IdVisitaSCC"] != null) {
                        if (item.UserProperties["IdVisitaSCC"].Value.ToString() == VisitaActual.Id.ToString()) {
                            item.Start = VisitaActual.FechaHoraComienzo;
                            item.End = VisitaActual.FechaHoraTermino;

                            bool existe = false;
                            int count = 1;

                            //asistentes eliminados
                            foreach (Recipient asisEmail in item.Recipients) {
                                existe = false;
                                foreach (var asisVisita in VisitaActual.AsistentesCraft) {
                                    if (asisEmail.Address == asisVisita.Usuario.Email) {
                                        existe = true;
                                        break;
                                    }
                                }

                                if (existe == false)
                                    asisEmail.Delete();

                                count++;
                            }

                            //asistentes agregados
                            foreach (var asisVisita in VisitaActual.AsistentesCraft) {
                                if (VisitaActual.UsuarioOrganizador.Id != asisVisita.Usuario.Id) {
                                    existe = false;
                                    foreach (Recipient asisEmail in item.Recipients) {
                                        if (asisEmail.Address == asisVisita.Usuario.Email)
                                            existe = true;
                                    }

                                    if (!existe) {
                                        Recipient rec = item.Recipients.Add(asisVisita.Usuario.Email);
                                        rec.Type = (int)OlMeetingRecipientType.olRequired;
                                    }
                                }
                            }

                            ((_AppointmentItem)item).Send();


                            LogEnviarEmail(Enums.VisitaTipoEmail.Replanificacion, VisitaActual,
                                           ((_AppointmentItem)item).Body, VisitaActual.Asunto);

                            break;
                        }
                    }
                }
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarMailPaperlessAsignacionUsuario1(
            ProyectoCraft.Entidades.Paperless.PaperlessAsignacion asignacion) {
            string EmailAvisousuario1 =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailPaperlessAsignacionUsuario1");
            string EmailAvisousuario2 =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailPaperlessAsignacionUsuario2");
            string EmailBody = "";
            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                StringBuilder sb = new StringBuilder(EmailAvisousuario1);
                sb.Replace("[USUARIO1]", asignacion.Usuario1.NombreCompleto);
                sb.Replace("[FECHAASIGNACION]", asignacion.FechaCreacion.ToShortDateString());
                sb.Replace("[NUMMASTER]", asignacion.NumMaster);
                //sb.Replace("[FECHAMASTER]", asignacion.FechaMaster.ToShortDateString());
                sb.Replace("[FECHAMASTER]",
                           asignacion.FechaMaster.ToString(
                               System.Configuration.ConfigurationSettings.AppSettings.Get("FechaMasterPaperlessFormato")));
                sb.Replace("[AGENTE]", asignacion.Agente.Nombre);
                sb.Replace("[NAVIERA]", asignacion.Naviera.Nombre);
                sb.Replace("[NAVE]", asignacion.Nave.Nombre);
                sb.Replace("[VIAJE]", asignacion.Viaje);
                sb.Replace("[NHOUSESBL]", asignacion.NumHousesBL.ToString());
                sb.Replace("[TIPOCARGA]", asignacion.TipoCarga.Nombre);
                if (asignacion.FechaETA != null)
                    sb.Replace("[FECHAETA]",
                               asignacion.FechaETA.Value.ToString(
                                   System.Configuration.ConfigurationSettings.AppSettings.Get("FechaFormatoEtaPaperless")));
                //asignacion.FechaETA.Value.ToShortDateString());

                if (asignacion.AperturaNavieras.HasValue)
                    sb.Replace("[APERTUANAVIERAS]", asignacion.AperturaNavieras.Value.ToShortDateString());
                else
                    sb.Replace("[APERTUANAVIERAS]", "");

                if (asignacion.PlazoEmbarcadores != null)
                    sb.Replace("[PLAZOEMBARCADORES]", asignacion.PlazoEmbarcadores.Value.ToShortDateString());
                else
                    sb.Replace("[PLAZOEMBARCADORES]", "");

                sb.Replace("[IMPORTANCIA]", asignacion.ImportanciaUsuario1.Nombre);
                sb.Replace("[USUARIOCONTRAPARTE]", asignacion.Usuario2.NombreCompleto);
                sb.Replace("[OBSERVACION]", asignacion.ObservacionUsuario1);
                sb.Replace("[SALTO]", "\n");
                EmailBody = sb.ToString();
                string asunto = "Nueva asignacion de Proceso Documental";

                //Enviar a Usuario 1

                EnviarEmail(asignacion.Usuario1.Email, asunto, EmailBody);



                //Enviar a USuario 2)
                sb = new StringBuilder(EmailAvisousuario2);
                sb.Replace("[USUARIO1]", asignacion.Usuario2.NombreCompleto);
                sb.Replace("[FECHAASIGNACION]", asignacion.FechaCreacion.ToShortDateString());
                sb.Replace("[NUMMASTER]", asignacion.NumMaster);
                sb.Replace("[FECHAMASTER]",
                           asignacion.FechaMaster.ToString(
                               System.Configuration.ConfigurationSettings.AppSettings.Get("FechaMasterPaperlessFormato")));
                //sb.Replace("[FECHAMASTER]", asignacion.FechaMaster.ToShortDateString());//

                sb.Replace("[AGENTE]", asignacion.Agente.Nombre);
                sb.Replace("[NAVIERA]", asignacion.Naviera.Nombre);
                sb.Replace("[NAVE]", asignacion.Nave.Nombre);
                sb.Replace("[VIAJE]", asignacion.Viaje);
                sb.Replace("[NHOUSESBL]", asignacion.NumHousesBL.ToString());
                sb.Replace("[TIPOCARGA]", asignacion.TipoCarga.Nombre);
                if (asignacion.FechaETA != null)
                    sb.Replace("[FECHAETA]",
                               asignacion.FechaETA.Value.ToString(
                                   System.Configuration.ConfigurationSettings.AppSettings.Get("FechaFormatoEtaPaperless")));
                //asignacion.FechaETA.Value.ToShortDateString());

                if (asignacion.AperturaNavieras.HasValue)
                    sb.Replace("[APERTUANAVIERAS]", asignacion.AperturaNavieras.Value.ToShortDateString());
                else
                    sb.Replace("[APERTUANAVIERAS]", "");

                if (asignacion.PlazoEmbarcadores != null)
                    sb.Replace("[PLAZOEMBARCADORES]", asignacion.PlazoEmbarcadores.Value.ToShortDateString());
                else
                    sb.Replace("[PLAZOEMBARCADORES]", "");

                sb.Replace("[IMPORTANCIA]", asignacion.ImportanciaUsuario1.Nombre);
                sb.Replace("[USUARIOCONTRAPARTE]", asignacion.Usuario1.NombreCompleto);
                sb.Replace("[OBSERVACION]", asignacion.ObservacionUsuario1);
                sb.Replace("[SALTO]", "\n");
                EmailBody = sb.ToString();

                EnviarEmail(asignacion.Usuario2.Email, asunto, EmailBody);

                //LogEnviarEmail(Enums.VisitaTipoEmail.ComentarioAInformeVisita, asignacion, EmailBody, asunto);

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarEmailVisitaPlanificacion(clsVisita VisitaActual, bool confirmada,
                                                                   bool aNombreDe) {
            ResultadoTransaccion resEmail = new ResultadoTransaccion();
            ResultadoTransaccion resLog = new ResultadoTransaccion();

            clsEmail email = new clsEmail();
            email.Asunto = VisitaActual.Asunto;
            email.Ubicacion = VisitaActual.Ubicacion;
            email.Cuerpo = VisitaActual.Descripcion;
            email.Emisor = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Email;
            email.Receptores = VisitaActual.EmailAsistentesCraft;
            email.FechaEmision = DateTime.Now;
            email.Visita = VisitaActual;

            if (!confirmada) {
                email.TipoEmail = Enums.VisitaTipoEmail.Planificacion;
            } else {
                email.TipoEmail = Enums.VisitaTipoEmail.ConfirmacionSinPlanificacion;
                VisitaActual.Descripcion += "\n" +
                                            "Esta visita ya ha sido confirmada por el Organizador. Debe aceptarla para agregarla a su calendario Outlook.";
            }

            //Enviar citacion a asistentes
            resEmail = CrearConvocatoriaReunion(VisitaActual, confirmada, aNombreDe, false);
            resLog = ProyectoCraft.LogicaNegocios.Calendarios.clsCalendarios.LogEmailVisita(email);

            return resEmail;
        }

        public ResultadoTransaccion CrearConvocatoriaReunion(clsVisita visita, bool Confirmada, bool aNombreDe,
                                                             bool AvisoVendedor) {
            Application outlookApp = new Application();
            AppointmentItem agendaMeeting = (AppointmentItem)outlookApp.CreateItem(OlItemType.olAppointmentItem);
            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                if (agendaMeeting != null) {
                    agendaMeeting.UserProperties.Add("IdVisitaSCC", OlUserPropertyType.olInteger, true,
                                                     OlFormatInteger.olFormatIntegerPlain);
                    agendaMeeting.UserProperties["IdVisitaSCC"].Value = visita.Id;
                    agendaMeeting.MeetingStatus = OlMeetingStatus.olMeeting;
                    agendaMeeting.Location = visita.Ubicacion;
                    agendaMeeting.Subject = visita.Asunto;
                    agendaMeeting.Body = visita.Descripcion;

                    agendaMeeting.Start = visita.FechaHoraComienzo;
                    agendaMeeting.End = visita.FechaHoraTermino;

                    TimeSpan diff;
                    diff = visita.FechaHoraTermino - visita.FechaHoraComienzo;

                    agendaMeeting.Duration = Convert.ToInt16(diff.TotalMinutes);

                    foreach (var asistente in visita.AsistentesCraft) {
                        if (!aNombreDe) {
                            if (visita.UsuarioOrganizador.Id != asistente.Usuario.Id) {
                                Recipient rec = agendaMeeting.Recipients.Add(asistente.Usuario.Email);
                                rec.Type = (int)OlMeetingRecipientType.olRequired;
                            }
                        } else {
                            if (visita.EsReunionInterna) {
                                if (visita.UsuarioOrganizador.Id != asistente.Usuario.Id) {
                                    Recipient rec = agendaMeeting.Recipients.Add(asistente.Usuario.Email);
                                    rec.Type = (int)OlMeetingRecipientType.olRequired;
                                }
                            } else {
                                if (visita.UsuarioOrganizador.Id != asistente.Usuario.Id &&
                                    visita.Vendedor.Id != asistente.Usuario.Id) {
                                    Recipient rec = agendaMeeting.Recipients.Add(asistente.Usuario.Email);
                                    rec.Type = (int)OlMeetingRecipientType.olRequired;
                                }

                                if (visita.Vendedor.Id == asistente.Usuario.Id)
                                    agendaMeeting.Body = BodyAvisoVendedorVisitaOrganizada(visita);
                            }
                        }
                    }

                    foreach (var producto in visita.Cliente.ProductosPreferidos) {
                        if (producto.Customer != null) {
                            Recipient rec = agendaMeeting.Recipients.Add(producto.Customer.Email);
                            rec.Type = (int)OlMeetingRecipientType.olRequired;
                        }
                    }
                    ((_AppointmentItem)agendaMeeting).Send();

                    res.Estado = Enums.EstadoTransaccion.Aceptada;

                }
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }

            return res;
        }

        public string BodyAvisoVendedorVisitaOrganizada(clsVisita VisitaActual) {
            string EmailOrganizada = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailVisitaOrganizada");

            string EmailBody = "";
            string asistentescraft = "";
            string asistentescliente = "";


            try {
                foreach (var asistente in VisitaActual.AsistentesCraft) {
                    asistentescraft += asistente.Usuario.NombreCompleto + "\n";
                }

                foreach (var asistente in VisitaActual.AsistentesCliente) {
                    asistentescliente += asistente.Contacto.NombreCompleto + "\n";
                }


                StringBuilder sb = new StringBuilder(EmailOrganizada);
                sb.Replace("[VENDEDOR]", VisitaActual.Vendedor.NombreCompleto);
                sb.Replace("[ORGANIZADOR]", VisitaActual.UsuarioOrganizador.NombreCompleto);
                if (VisitaActual.Cliente.NombreFantasia.Trim() != "")
                    sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreFantasia);
                else
                    sb.Replace("[CLIENTE]", VisitaActual.Cliente.NombreCompañia);
                sb.Replace("[ASUNTO]", VisitaActual.Asunto);
                sb.Replace("[UBICACION]", VisitaActual.Ubicacion);
                sb.Replace("[INICIO]", VisitaActual.FechaHoraComienzo.ToString());
                sb.Replace("[TERMINO]", VisitaActual.FechaHoraTermino.ToString());
                sb.Replace("[IMPORTANCIA]", VisitaActual.NivelImportancia.Nombre);
                sb.Replace("[DESCRIPCION]", VisitaActual.Descripcion);
                sb.Replace("[ASISTENTESCLIENTE]", asistentescliente);
                sb.Replace("[ASISTENTESCRAFT]", asistentescraft);
                sb.Replace("[SALTO]", "\n");

                EmailBody = sb.ToString();




            } catch (Exception ex) { }
            return EmailBody;

        }

        public ResultadoTransaccion EnviarEmailVisitaConfirmada(clsVisita VisitaActual) {
            string EmailConfirmada = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailVisitaConfirmada");

            string EmailBody = "";
            string asistentes = "";
            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                foreach (var asistente in VisitaActual.AsistentesCraft) {
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                        asistentes += asistente.Usuario.NombreCompleto + "\n";
                }

                //Enviar confirmacion a asistentes confirmados
                foreach (var asistente in VisitaActual.AsistentesCraft) {
                    if (asistente.Usuario.Id != VisitaActual.Vendedor.Id) {
                        if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia) {
                            StringBuilder sb = new StringBuilder(EmailConfirmada);
                            sb.Replace("[NOMBREASISTENTE]", asistente.Usuario.NombreCompleto);
                            sb.Replace("[NOMBREFANTASIA]", VisitaActual.Cliente.NombreCompañia);
                            sb.Replace("[ASUNTO]", VisitaActual.Asunto);
                            sb.Replace("[UBICACION]", VisitaActual.Ubicacion);
                            sb.Replace("[COMIENZO]", VisitaActual.FechaHoraComienzo.ToString());
                            sb.Replace("[TERMINO]", VisitaActual.FechaHoraTermino.ToString());
                            sb.Replace("[EJECUTIVO]", VisitaActual.Vendedor.NombreCompleto);
                            sb.Replace("[IMPORTANCIA]", VisitaActual.NivelImportancia.Nombre);
                            sb.Replace("[DESCRIPCION]", VisitaActual.Descripcion);
                            sb.Replace("[ASISTENTES]", asistentes);
                            sb.Replace("[SALTO]", "\n");

                            EmailBody = sb.ToString();

                            EnviarEmail(asistente.Usuario.Email, VisitaActual.Asunto, EmailBody);

                            LogEnviarEmail(Enums.VisitaTipoEmail.ConfirmacionAsistentesCraft, VisitaActual, EmailBody,
                                           VisitaActual.Asunto);
                        }

                    }
                }

                //Enviar email a customers
                foreach (var producto in VisitaActual.Cliente.ProductosPreferidos) {
                    if (producto.Customer != null) {
                        StringBuilder sb = new StringBuilder(EmailConfirmada);
                        sb.Replace("[NOMBREASISTENTE]", producto.Customer.NombreCompleto);
                        sb.Replace("[NOMBREFANTASIA]", VisitaActual.Cliente.NombreCompañia);
                        sb.Replace("[ASUNTO]", VisitaActual.Asunto);
                        sb.Replace("[UBICACION]", VisitaActual.Ubicacion);
                        sb.Replace("[COMIENZO]", VisitaActual.FechaHoraComienzo.ToString());
                        sb.Replace("[TERMINO]", VisitaActual.FechaHoraTermino.ToString());
                        sb.Replace("[EJECUTIVO]", VisitaActual.Vendedor.NombreCompleto);
                        sb.Replace("[IMPORTANCIA]", VisitaActual.NivelImportancia.Nombre);
                        sb.Replace("[DESCRIPCION]", VisitaActual.Descripcion);
                        sb.Replace("[ASISTENTES]", asistentes);
                        sb.Replace("[SALTO]", "\n");

                        EmailBody = sb.ToString();

                        EnviarEmail(producto.Customer.Email, VisitaActual.Asunto, EmailBody);

                        LogEnviarEmail(Enums.VisitaTipoEmail.ConfirmacionAsistentesCraft, VisitaActual, EmailBody,
                                       VisitaActual.Asunto);
                    }
                }

                //a asistentes no confirmados cancelar la visita
                bool seelimino = false;
                Application outlookApp = new Application();
                MAPIFolder calendar = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
                Items calendarItems = calendar.Items;
                foreach (AppointmentItem item in calendarItems) {
                    if (item.UserProperties["IdVisitaSCC"] != null) {
                        if (item.UserProperties["IdVisitaSCC"].Value.ToString() == VisitaActual.Id.ToString()) {
                            bool existe = false;
                            int count = 1;
                            //asistentes eliminados
                            foreach (Recipient asisEmail in item.Recipients) {
                                existe = false;
                                foreach (var asisVisita in VisitaActual.AsistentesCraft) {
                                    if (asisEmail.Address == asisVisita.Usuario.Email &&
                                        asisVisita.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia) {
                                        existe = true;
                                        break;
                                    }
                                }

                                if (existe == false) {
                                    asisEmail.Delete();
                                    seelimino = true;
                                }

                                count++;
                            }

                            if (seelimino)
                                ((_AppointmentItem)item).Send();
                        }
                    }
                }

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }

            return res;
        }

        public ResultadoTransaccion EnviarEmailVisitaConfirmadaReunionInterna(clsVisita VisitaActual) {
            string EmailConfirmada =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailVisitaConfirmadaReunionInterna");

            string EmailBody = "";
            string asistentes = "";
            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                foreach (var asistente in VisitaActual.AsistentesCraft) {
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                        asistentes += asistente.Usuario.NombreCompleto + "\n";
                }

                //Enviar confirmacion a asistentes confirmados
                foreach (var asistente in VisitaActual.AsistentesCraft) {
                    if (asistente.Usuario.Id != VisitaActual.UsuarioOrganizador.Id) {
                        if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia) {
                            StringBuilder sb = new StringBuilder(EmailConfirmada);
                            sb.Replace("[NOMBREASISTENTE]", asistente.Usuario.NombreCompleto);
                            sb.Replace("[ASUNTO]", VisitaActual.Asunto);
                            sb.Replace("[UBICACION]", VisitaActual.Ubicacion);
                            sb.Replace("[COMIENZO]", VisitaActual.FechaHoraComienzo.ToString());
                            sb.Replace("[TERMINO]", VisitaActual.FechaHoraTermino.ToString());
                            sb.Replace("[ORGANIZADOR]", VisitaActual.UsuarioOrganizador.NombreCompleto);
                            sb.Replace("[IMPORTANCIA]", VisitaActual.NivelImportancia.Nombre);
                            sb.Replace("[DESCRIPCION]", VisitaActual.Descripcion);
                            sb.Replace("[ASISTENTES]", asistentes);
                            sb.Replace("[SALTO]", "\n");

                            EmailBody = sb.ToString();

                            EnviarEmail(asistente.Usuario.Email, VisitaActual.Asunto, EmailBody);

                            LogEnviarEmail(Enums.VisitaTipoEmail.ConfirmacionAsistentesCraft, VisitaActual, EmailBody,
                                           VisitaActual.Asunto);
                        }

                    }
                }

                //a asistentes no confirmados cancelar la visita
                bool seelimino = false;
                Application outlookApp = new Application();
                MAPIFolder calendar = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
                Items calendarItems = calendar.Items;
                foreach (AppointmentItem item in calendarItems) {
                    if (item.UserProperties["IdVisitaSCC"] != null) {
                        if (item.UserProperties["IdVisitaSCC"].Value.ToString() == VisitaActual.Id.ToString()) {
                            bool existe = false;
                            int count = 1;
                            //asistentes eliminados
                            foreach (Recipient asisEmail in item.Recipients) {
                                existe = false;
                                foreach (var asisVisita in VisitaActual.AsistentesCraft) {
                                    if (asisEmail.Address == asisVisita.Usuario.Email &&
                                        asisVisita.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia) {
                                        existe = true;
                                        break;
                                    }
                                }

                                if (existe == false) {
                                    asisEmail.Delete();
                                    seelimino = true;
                                }

                                count++;
                            }

                            if (seelimino)
                                ((_AppointmentItem)item).Send();
                        }
                    }
                }

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }

            return res;
        }

        public ResultadoTransaccion EnviarEmailVisitaConfirmadaCliente(clsVisita VisitaActual) {
            string EmailConfirmada =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailVisitaConfirmadaCliente");

            string EmailBody = "";
            string asistentes = "";
            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                foreach (var asistente in VisitaActual.AsistentesCraft) {
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                        asistentes += asistente.Usuario.NombreCompleto + "\n";
                }

                //Enviar confirmacion a Cliente
                foreach (var asistente in VisitaActual.AsistentesCliente) {
                    StringBuilder sb = new StringBuilder(EmailConfirmada);

                    sb = sb.Replace("[NOMBRECOMPAÑIA]", VisitaActual.Cliente.NombreCompañia);
                    sb = sb.Replace("[NOMBREFANTASIA]", VisitaActual.Cliente.NombreFantasia);
                    sb = sb.Replace("[NOMBRECONTACTO]", asistente.Contacto.NombreCompleto);
                    sb = sb.Replace("[EJECUTIVO]", VisitaActual.Vendedor.NombreCompleto);
                    sb = sb.Replace("[ASUNTO]", VisitaActual.Asunto);
                    sb = sb.Replace("[UBICACION]", VisitaActual.Ubicacion);
                    sb = sb.Replace("[COMIENZO]", VisitaActual.FechaHoraComienzo.ToString());
                    sb = sb.Replace("[TERMINO]", VisitaActual.FechaHoraTermino.ToString());
                    sb = sb.Replace("[DESCRIPCION]", VisitaActual.Descripcion);
                    sb = sb.Replace("[ASISTENTES]", asistentes);
                    sb = sb.Replace("[SALTO]", "\n");

                    EmailBody = sb.ToString();

                    EnviarEmail(asistente.Contacto.Email, "Visita de CRAFT MULTIMODAL", EmailBody);

                    LogEnviarEmail(Enums.VisitaTipoEmail.ConfirmacionAsistentesCliente, VisitaActual, EmailBody,
                                   VisitaActual.Asunto);
                }

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }

            return res;
        }

        public ResultadoTransaccion EnviarEmailVisitaCancelada(clsVisita VisitaActual) {
            Application outlookApp = new Application();
            MAPIFolder calendar = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            Items calendarItems = calendar.Items;
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                foreach (AppointmentItem item in calendarItems) {

                    if (item.UserProperties["IdVisitaSCC"] != null) {
                        if (item.UserProperties["IdVisitaSCC"].Value.ToString() == VisitaActual.Id.ToString()) {
                            item.MeetingStatus = OlMeetingStatus.olMeetingCanceled;
                            item.Body = VisitaActual.Descripcion;

                            VisitaActual.Asunto = "CANCELADA: " + item.Subject;

                            ((_AppointmentItem)item).Send();
                            ((_AppointmentItem)item).Delete();


                            LogEnviarEmail(Enums.VisitaTipoEmail.Cancelacion, VisitaActual, VisitaActual.Descripcion,
                                           VisitaActual.Asunto);

                            break;
                        }
                    }
                }

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarMailPaperlessUsuario2ConfirmacionUsuario1(
            ProyectoCraft.Entidades.Paperless.PaperlessAsignacion asignacion) {
            string EmailAviso =
                System.Configuration.ConfigurationSettings.AppSettings.Get("EmailPaperlessConfirmacionAUsuario2");
            string EmailBody = "";
            ResultadoTransaccion res = new ResultadoTransaccion();

            try {
                StringBuilder sb = new StringBuilder(EmailAviso);
                sb.Replace("[USUARIO2]", asignacion.Usuario2.NombreCompleto);
                sb.Replace("[USUARIO1]", asignacion.Usuario1.NombreCompleto);
                sb.Replace("[FECHAASIGNACION]", asignacion.FechaCreacion.ToShortDateString());
                sb.Replace("[NUMMASTER]", asignacion.NumMaster);
                //sb.Replace("[FECHAMASTER]", asignacion.FechaMaster.ToShortDateString());
                sb.Replace("[FECHAMASTER]",
                           asignacion.FechaMaster.ToString(
                               System.Configuration.ConfigurationSettings.AppSettings.Get("FechaMasterPaperlessFormato")));
                sb.Replace("[AGENTE]", asignacion.Agente.Nombre);
                sb.Replace("[NAVIERA]", asignacion.Naviera.Nombre);
                sb.Replace("[NAVE]", asignacion.Nave.Nombre);
                sb.Replace("[VIAJE]", asignacion.Viaje);
                sb.Replace("[NHOUSESBL]", asignacion.NumHousesBL.ToString());
                sb.Replace("[TIPOCARGA]", asignacion.TipoCarga.Nombre);
                if (asignacion.FechaETA != null)
                    sb.Replace("[FECHAETA]",
                               asignacion.FechaETA.Value.ToString(
                                   System.Configuration.ConfigurationSettings.AppSettings.Get("FechaFormatoEtaPaperless")));
                //asignacion.FechaETA.Value.ToShortDateString());

                if (asignacion.AperturaNavieras.HasValue)
                    sb.Replace("[APERTUANAVIERAS]", asignacion.AperturaNavieras.Value.ToShortDateString());
                else
                    sb.Replace("[APERTUANAVIERAS]", "");

                if (asignacion.PlazoEmbarcadores != null)
                    sb.Replace("[PLAZOEMBARCADORES]", asignacion.PlazoEmbarcadores.Value.ToShortDateString());
                else
                    sb.Replace("[PLAZOEMBARCADORES]", "");

                sb.Replace("[IMPORTANCIA]", asignacion.ImportanciaUsuario1.Nombre);
                sb.Replace("[OBSERVACION]", asignacion.ObservacionUsuario2);
                sb.Replace("[SALTO]", "\n");
                EmailBody = sb.ToString();
                string asunto = "Confirmacion de Proceso Documental de Usuario 1ra Etapa";

                EnviarEmail(asignacion.Usuario2.Email, asunto, EmailBody);

                //LogEnviarEmail(Enums.VisitaTipoEmail.ComentarioAInformeVisita, asignacion, EmailBody, asunto);

                res.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarAsignacionTargets(IList<clsMeta> ListaProspectos, clsUsuario objUserEmisor) {
            string EmailDestinatario = "";
            string Asunto = "";
            string EmailBody = "";
            string EmailAviso = "";
            string CopiaLCL = "";
            string CopiaFCL = "";
            string CopiaAereo = "";
            string CopiaFijo = "";
            string ListaProductos = "";
            string ListaTraficos = "";
            string ListaCompetencia = "";

            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                EmailAviso = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailAsignacionTarget");
                Asunto = System.Configuration.ConfigurationSettings.AppSettings.Get("AsuntoEmailAsignacionTarget");
                CopiaFijo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFijo");
                CopiaLCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeLCL");
                CopiaFCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFCL");
                CopiaAereo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeAereo");

                foreach (clsMeta Target in ListaProspectos) {
                    StringBuilder sb = new StringBuilder(EmailAviso);
                    sb.Replace("[VENDEDOR]", Target.ObjMetaAsignacion.ObjVendedorAsignado.Nombre);
                    sb.Replace("[FECHA]", Target.FechaApertura.ToLongDateString());
                    sb.Replace("[Codigo_TARGET]", Target.IdNumMeta);
                    sb.Replace("[FECHA_FOLLOWUP]", Target.FechaRevision.ToLongDateString());
                    sb.Replace("[USUARIO_ENVIA]", objUserEmisor.Nombre);
                    if (Target.GlosaClienteTarget != "") {
                        sb.Replace("[CLIENTE]", Target.GlosaClienteTarget);
                        sb.Replace("[TIPO_TARGET]", "Nueva Cuenta");
                    } else {
                        sb.Replace("[CLIENTE]", Target.ObjClienteMaster.NombreFantasia);
                        sb.Replace("[TIPO_TARGET]", "Nuevo Tráfico");
                    }
                    sb.Replace("[COMMODITY]", Target.GlosaCommodity);
                    sb.Replace("[TIPO_CONTENEDOR]", Target.ObjTipoContenedor.Nombre);
                    sb.Replace("[FOLLOOW_UP]", Target.FechaRevision.ToShortDateString());
                    sb.Replace("[SHIPPER]", Target.Shipper);
                    sb.Replace("[PRIORIDAD]", Target.Prioridad.ToString());
                    sb = sb.Replace("[SALTO]", "\n");

                    EmailDestinatario = Target.ObjMetaAsignacion.ObjVendedorAsignado.Email + ";" + objUserEmisor.Email;
                    if (CopiaFijo != "") {
                        EmailDestinatario = EmailDestinatario + ";" + CopiaFijo;
                    }

                    foreach (clsTipoProducto Producto in Target.ObjTipoProducto) {
                        if (Producto.EsAereo) {
                            EmailDestinatario = EmailDestinatario + ";" + CopiaAereo;
                        }
                        if (Producto.EsFCL) {
                            EmailDestinatario = EmailDestinatario + ";" + CopiaFCL;
                        }
                        if (Producto.EsLCL) {
                            EmailDestinatario = EmailDestinatario + ";" + CopiaLCL;
                        }
                        if (ListaProductos == "") {
                            ListaProductos = ListaProductos + " " + Producto.Nombre;
                        } else {
                            ListaProductos = ListaProductos + Environment.NewLine + " " + Producto.Nombre;
                        }
                    }
                    foreach (clsMetaGlosasTrafico Trafico in Target.ObjMetaGlosasTrafico) {
                        if (ListaTraficos == "") {
                            ListaTraficos = ListaTraficos + " " + Trafico.Glosa;
                        } else {
                            ListaTraficos = ListaTraficos + Environment.NewLine + " " + Trafico.Glosa;
                        }
                    }
                    foreach (clsMetaCompetencia Competencia in Target.ObjMetaCompetencia) {
                        if (ListaCompetencia == "") {
                            ListaCompetencia = ListaCompetencia + " " + Competencia.Descripcion;
                        } else {
                            ListaCompetencia = ListaCompetencia + Environment.NewLine + " " + Competencia.Descripcion;
                        }
                    }
                    sb.Replace("[PRODUCTOS]", ListaProductos);
                    sb.Replace("[TRAFICOS]", ListaTraficos);
                    sb.Replace("[COMPETENCIA]", ListaCompetencia);
                    EmailBody = sb.ToString();
                    EnviarEmail(EmailDestinatario, Asunto, EmailBody);
                }
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarAsignacionSalesLead(IList<ClsSalesLead> ListaProspectos,
                                                              clsUsuario objUserEmisor) {

            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                var Asunto = System.Configuration.ConfigurationSettings.AppSettings.Get("AsuntoEmailAsignacionSLead");
                foreach (var saleslead in ListaProspectos) {

                    var emailBody = CrearCuerpoMailSalesLead(saleslead,
                                                             Path.Combine(System.Windows.Forms.Application.StartupPath,
                                                                          @"mailSalesLead\templateAsignacion.html"));
                    emailBody = emailBody.Replace("[FECHA_ESPANOL]", DateTime.Now.ToString("yyyy-MM-dd"));
                    emailBody = emailBody.Replace("[FECHA_FOLLOWUP]", saleslead.FechaRevision.ToString("yyyy-MM-dd"));
                    emailBody = emailBody.Replace("[USUARIO_ENVIA]", saleslead.UsuarioAsignador.NombreCompleto);
                    emailBody = emailBody.Replace("[VENDEDOR]", saleslead.Asignacion.VendedorAsignado.NombreCompleto);

                    EnviarHTmlEmail(saleslead.Asignacion.VendedorAsignado.Email, Asunto, emailBody);
                }
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarHTmlEmail(string toValue, string subjectValue, string bodyValue) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
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
            } catch (Exception ex) {
                res.Descripcion = ex.Message;
                res.Estado = Enums.EstadoTransaccion.Rechazada;

                Log.EscribirLog(ex.Message);
            }

            return res;

        }

        public ResultadoTransaccion EnviarMailAvisoNewObservacionGerente(clsUsuario ObjEmisor,
                                                                         clsUsuario ObjDestinatario,
                                                                         clsUsuario ObjAsignadorTarget,
                                                                         string DestinatariosCopia, DateTime Fecha,
                                                                         string Observaciones, string NombreTarget) {
            string Asunto = "";
            string EmailBody = "";
            string EmailAviso = "";
            string Destinatarios = "";
            string MailCopiaAsignadorObs = "";
            string MailCopiaOtrosUsuariosObs = "";

            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                EmailAviso = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailNewObservacion");
                Asunto = System.Configuration.ConfigurationSettings.AppSettings.Get("AsuntoEmailNewObservacion");
                MailCopiaAsignadorObs =
                    System.Configuration.ConfigurationSettings.AppSettings.Get("MailCopiaAsignadorObs");
                MailCopiaOtrosUsuariosObs =
                    System.Configuration.ConfigurationSettings.AppSettings.Get("MailCopiaOtrosUsuariosObs");

                StringBuilder sb = new StringBuilder(Asunto);
                sb.Replace("[USUARIO_ENVIA]", ObjEmisor.Nombre);
                sb.Replace("[FECHA]", Fecha.ToString());
                sb.Replace("[TARGET]", NombreTarget);
                sb = sb.Replace("[SALTO]", "\n");
                Asunto = sb.ToString();

                StringBuilder sb2 = new StringBuilder(EmailAviso);
                sb2.Replace("[DESTINATARIO]", ObjDestinatario.Nombre);
                sb2.Replace("[OBSERVACION]", Observaciones);
                sb2.Replace("[USUARIO_ENVIA]", ObjEmisor.Nombre);
                sb2 = sb2.Replace("[SALTO]", "\n");
                EmailBody = sb2.ToString();

                Destinatarios = DestinatariosCopia;
                if (!Destinatarios.Contains(ObjDestinatario.Email))
                    Destinatarios = Destinatarios + ";" + ObjDestinatario.Email;
                if (MailCopiaOtrosUsuariosObs == "S" && DestinatariosCopia.Trim() != "") {
                    if (!Destinatarios.Contains(DestinatariosCopia))
                        Destinatarios = Destinatarios + ";" + DestinatariosCopia;
                }
                if (MailCopiaAsignadorObs == "S" && ObjAsignadorTarget.Email != "") {
                    if (!Destinatarios.Contains(ObjAsignadorTarget.Email))
                        Destinatarios = Destinatarios + ";" + ObjAsignadorTarget.Email;
                }

                EnviarEmail(Destinatarios, Asunto, EmailBody);
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarMailAvisoCancelacionTarget(clsUsuario UsuarioAsigna, clsMeta Target,
                                                                     string Observacion) {
            string EmailDestinatario = "";
            string Asunto = "";
            string EmailBody = "";
            string EmailAviso = "";
            string NombreDestinatario = "";
            string CopiaFijo = "";
            string CopiaLCL = "";
            string CopiaFCL = "";
            string CopiaAereo = "";

            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                EmailAviso = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailCancelaTarget");
                Asunto = System.Configuration.ConfigurationSettings.AppSettings.Get("AsuntoEmailCancelaTarget");
                EmailDestinatario = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailAsignadorTarget");
                NombreDestinatario = System.Configuration.ConfigurationSettings.AppSettings.Get("NombreAsignadorTarget");
                CopiaFijo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFijo");
                CopiaLCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeLCL");
                CopiaFCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFCL");
                CopiaAereo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeAereo");

                StringBuilder sb = new StringBuilder(Asunto);
                sb = sb.Replace("[SALTO]", "\n");
                Asunto = sb.ToString();

                StringBuilder sb2 = new StringBuilder(EmailAviso);
                sb2.Replace("[OBSERVACION]", Observacion);
                if (Target.GlosaClienteTarget != "") {
                    sb2.Replace("[TARGET]", Target.GlosaClienteTarget);
                } else {
                    sb2.Replace("[TARGET]", Target.ObjClienteMaster.NombreFantasia);
                }
                sb2 = sb2.Replace("[SALTO]", "\n");
                EmailBody = sb2.ToString();

                EmailDestinatario = EmailDestinatario + ";" + UsuarioAsigna.Email;
                if (CopiaFijo != "") {
                    EmailDestinatario = EmailDestinatario + ";" + CopiaFijo;
                }
                //foreach (clsTipoProducto Producto in Target.ObjTipoProducto)
                //{
                //    if (Producto.EsAereo)
                //    {
                //        EmailDestinatario = EmailDestinatario + ";" + CopiaAereo;
                //    }
                //    if (Producto.EsFCL)
                //    {
                //        EmailDestinatario = EmailDestinatario + ";" + CopiaFCL;
                //    }
                //    if (Producto.EsLCL)
                //    {
                //        EmailDestinatario = EmailDestinatario + ";" + CopiaLCL;
                //    }
                //}

                EnviarEmail(EmailDestinatario, Asunto, EmailBody);
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarMailAvisoCierreTarget(clsUsuario UsuarioAsigna, clsMeta Target,
                                                                string Observacion) {
            string EmailDestinatario = "";
            string Asunto = "";
            string EmailBody = "";
            string EmailAviso = "";
            string NombreDestinatario = "";
            string CopiaFijo = "";
            string CopiaLCL = "";
            string CopiaFCL = "";
            string CopiaAereo = "";

            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                EmailAviso = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailCierreTarget");
                Asunto = System.Configuration.ConfigurationSettings.AppSettings.Get("AsuntoEmailCierreTarget");
                EmailDestinatario = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailAsignadorTarget");
                NombreDestinatario = System.Configuration.ConfigurationSettings.AppSettings.Get("NombreAsignadorTarget");
                CopiaFijo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFijo");
                CopiaLCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeLCL");
                CopiaFCL = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeFCL");
                CopiaAereo = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailInformeAereo");

                StringBuilder sb = new StringBuilder(Asunto);
                sb = sb.Replace("[SALTO]", "\n");
                Asunto = sb.ToString();

                StringBuilder sb2 = new StringBuilder(EmailAviso);
                sb2.Replace("[DESTINATARIO]", NombreDestinatario);
                sb2.Replace("[OBSERVACION]", Observacion);
                if (Target.GlosaClienteTarget != "") {
                    sb2.Replace("[TARGET]", Target.GlosaClienteTarget);
                } else {
                    sb2.Replace("[TARGET]", Target.ObjClienteMaster.NombreFantasia);
                }
                sb2 = sb2.Replace("[SALTO]", "\n");
                EmailBody = sb2.ToString();

                EmailDestinatario = EmailDestinatario + ";" + UsuarioAsigna.Email;
                if (CopiaFijo != "") {
                    EmailDestinatario = EmailDestinatario + ";" + CopiaFijo;
                }

                EnviarEmail(EmailDestinatario, Asunto, EmailBody);
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public ResultadoTransaccion EnviarMailAvisoNewObservacionVendedor(clsUsuario ObjEmisor,
                                                                          clsUsuario ObjDestinatario, DateTime Fecha,
                                                                          string Observaciones, string NombreTarget,
                                                                          string DestinatariosCopia) {
            string Asunto = "";
            string EmailBody = "";
            string EmailAviso = "";
            string MailCopiaAsignadorObs = "";
            string MailCopiaOtrosUsuariosObs = "";
            string Destinatarios = "";



            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                EmailAviso = System.Configuration.ConfigurationSettings.AppSettings.Get("EmailNewObservacion");
                Asunto = System.Configuration.ConfigurationSettings.AppSettings.Get("AsuntoEmailNewObservacion");
                MailCopiaAsignadorObs =
                    System.Configuration.ConfigurationSettings.AppSettings.Get("MailCopiaAsignadorObs");
                MailCopiaOtrosUsuariosObs =
                    System.Configuration.ConfigurationSettings.AppSettings.Get("MailCopiaOtrosUsuariosObs");




                StringBuilder sb = new StringBuilder(Asunto);
                sb.Replace("[USUARIO_ENVIA]", ObjEmisor.Nombre);
                sb.Replace("[FECHA]", Fecha.ToString());
                sb.Replace("[TARGET]", NombreTarget);
                sb = sb.Replace("[SALTO]", "\n");
                Asunto = sb.ToString();

                StringBuilder sb2 = new StringBuilder(EmailAviso);
                sb2.Replace("[DESTINATARIO]", ObjDestinatario.Nombre);
                sb2.Replace("[OBSERVACION]", Observaciones);
                sb2.Replace("[USUARIO_ENVIA]", ObjEmisor.Nombre);
                sb2 = sb2.Replace("[SALTO]", "\n");
                EmailBody = sb2.ToString();

                Destinatarios = DestinatariosCopia;
                if (!Destinatarios.Contains(ObjDestinatario.Email)) {
                    Destinatarios = Destinatarios + ";" + ObjDestinatario.Email;
                }
                if (MailCopiaOtrosUsuariosObs == "S" && DestinatariosCopia.Trim() != "" &&
                    !Destinatarios.Contains(ObjDestinatario.Email)) {
                    Destinatarios = Destinatarios + ";" + DestinatariosCopia;
                }
                if (MailCopiaAsignadorObs == "S" && ObjDestinatario.Email != "" &&
                    !Destinatarios.Contains(ObjDestinatario.Email)) {
                    Destinatarios = Destinatarios + ";" + ObjDestinatario.Email;
                }
                EnviarEmail(Destinatarios, Asunto, EmailBody);
            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;

                Log.EscribirLog(ex.Message);
            }
            return res;
        }


        public ResultadoTransaccion EnviarMailCotizacionDirecta(String subject, String html, List<String> pathAdjuntos) {
            var res = new ResultadoTransaccion();
            try {
                oApp = new Application();
                oNameSpace = oApp.GetNamespace("MAPI");
                oOutboxFolder = oNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
                var mail = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);
                mail.Subject = subject;
                mail.HTMLBody = html;

                //mail.Attachments.Add(foo, OlAttachmentType.olByValue, mail.HTMLBody.Length, Type.Missing);
                if (pathAdjuntos != null)
                    foreach (var adj in pathAdjuntos)
                        mail.Attachments.Add((object)adj, OlAttachmentType.olEmbeddeditem, 1, (object)"Attachment");

                mail.Save();
                mail.Display(false);

            } catch (Exception e) {
                res.Descripcion = e.Message;
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                Log.EscribirLog(e.Message);
            }
            return res;
        }

        public String GeneratePdfFromHtml(String html, String numero) {

            //var document = new Document(PageSize.A4, 5, 5, 5, 5);
            var document = new Document(PageSize.A4, 50, 25, 15, 10);
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();
            var contents = html;
            contents = contents.Replace("<hr />", "____________________________________________________________________________________________________________________");

            var styles = new StyleSheet();
            styles.LoadTagStyle("body", "face", "Arial");
            styles.LoadTagStyle("body", "size", "7px");
            styles.LoadTagStyle("body", "background-color", "#000000");

            var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), styles);

            foreach (var parsedHtmlElement in parsedHtmlElements)
                document.Add(parsedHtmlElement);

            document.Close();


            byte[] content = output.ToArray();

            var pathPDf = Path.GetTempPath() + "cotizacion_" + numero + ".pdf";
            using (FileStream fs = File.Create(pathPDf)) {
                fs.Write(content, 0, (int)content.Length);
            }

            return pathPDf;
        }

        public void EnviarMail(List<string> destinatarios, string subject, string body) {
            try {
                oApp = new Application();
                oNameSpace = oApp.GetNamespace("MAPI");
                oOutboxFolder = oNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
                var mail = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);
                foreach (var destinatario in destinatarios)
                    mail.Recipients.Add(destinatario);

                mail.Subject = subject;
                mail.HTMLBody = body;

                mail.Save();
                mail.Display(false);
                mail.Send();

            } catch (Exception e) {
                Log.EscribirLog(e.Message);
            }
        }
    }
}
