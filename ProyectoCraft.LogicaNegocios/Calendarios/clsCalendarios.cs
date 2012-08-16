using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Calendarios
{
    public static class clsCalendarios
    {
        public static ResultadoTransaccion GuardarVisita(clsVisita visita)
        {
            visita.FechaHoraTermino.AddSeconds(-1);

            
            if (visita.IsNew)
                return AccesoDatos.Calendarios.clsCalendarioADO.GuardarVisita(visita);
            else
                return AccesoDatos.Calendarios.clsCalendarioADO.ActualizarVisita(visita);
        }

        public static IList<clsClienteMaster> ListarCuentasPorPlanificar(Int16 Categoria, Int64 idUsuario)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarCuentasPorPlanificar(Categoria, idUsuario);
        }

        public static IList<clsClienteMaster> ListarTargetsPorPlanificar(Int64 IdUsuario)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarTargetsPorPlanificar(IdUsuario);
        }


        public static IList<clsVisita> ListarVisitas(DateTime fechadesde, DateTime fechahasta, Int16 estado, Int64 idusuario, Int16 idCategoria)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarVisitas(fechadesde, fechahasta, estado,idusuario,idCategoria);
        }

        public static IList<clsVisita> ListarVisitasTarget(DateTime fechadesde, DateTime fechahasta, Int16 estado, Int64 idUsuario)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarVisitasTarget(fechadesde, fechahasta, estado,
                                                                                idUsuario);
        }

        public static clsVisita ObtenerVisitaPorId(Int64 IdVisita)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ObtenerVisitaPorId(IdVisita);
        }

        public static ResultadoTransaccion EliminarVisita(clsVisita visita)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.EliminarVisita(visita);
        }

        public static ResultadoTransaccion ValidarUsuarioEnOtraVisita(clsVisita visita)
        {
            ResultadoTransaccion resSalida = new ResultadoTransaccion();

            foreach (var asistente in visita.Asistentes)
            {
                if(asistente.TipoAsistente == Entidades.Enums.Enums.VisitaTipoAsistente.Usuario && asistente.IsNew)
                {
                    ResultadoTransaccion resultado =
                        AccesoDatos.Calendarios.clsCalendarioADO.ValidarUsuarioEnOtraVisita(asistente.Usuario,
                                                                                            visita.FechaHoraComienzo.AddSeconds(1),
                                                                                            visita.FechaHoraTermino.AddSeconds(-1), visita.Id);
                    if(resultado.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                    {
                        resSalida.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;

                        clsVisita otraVisita = (clsVisita) resultado.ObjetoTransaccion;

                        if(otraVisita != null)
                        {
                            resSalida.Errores.Add(asistente.Usuario.NombreCompleto);
                            resSalida.Descripcion = "El asistente " + asistente.Usuario.NombreCompleto + " tiene otra visita programada en este horario ";
                            resSalida.ObjetoTransaccion = true;
                        }
                        else
                        {
                            resSalida.Errores = new List<string>();
                            resSalida.Descripcion = "";
                            resSalida.ObjetoTransaccion = true;
                        }

                        //if ((bool)resultado.ObjetoTransaccion)
                        //{
                        //    resSalida.Descripcion = "El asistente " + asistente.Usuario.NombreCompleto + " tiene otra visita programada en este horario ";
                        //    resSalida.ObjetoTransaccion = true;
                        //}
                        //else
                        //{
                        //    resSalida.Descripcion = "";
                        //    resSalida.ObjetoTransaccion = true;
                        //}Entidades.Usuarios.clsUsuario usuario, DateTime inicio, DateTime termino, Int64 IdVisita
                    }
                    else
                    {
                        resSalida = resultado;
                    }
                }
            }

            return resSalida;
        }

        public static ResultadoTransaccion GuardarInformeVisita(clsVisitaInforme informe)
        {
            if (informe.IsNew)
                return AccesoDatos.Calendarios.clsCalendarioADO.GuardarInformeVisita(informe);
            else
                return AccesoDatos.Calendarios.clsCalendarioADO.ActualizarInformeVisita(informe);
        }

        public static ResultadoTransaccion ObtenerInformeVisitaPor(Int64 IdInforme, Int64 IdVisita)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ObtenerInformeVisitaPor(IdInforme, IdVisita);
        }

        public static ResultadoTransaccion ListarAsistentesConTopeDeHorario(Entidades.Usuarios.clsUsuario usuario, DateTime inicio, DateTime termino, Int64 IdVisita)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ValidarUsuarioEnOtraVisita(usuario, inicio, termino,
                                                                                       IdVisita);
        }


        #region "Informe"

        public static IList<clsVisita> ListarVisitasInforme(Int64 IdVendedor, Int64 IdCliente,DateTime fechadesde, DateTime fechahasta, Int64 estado)
        {                        
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarVisitasInforme(IdVendedor, IdCliente, fechadesde,
                                                                                 fechahasta, estado);
        }

        public static IList<clsVisitaEstado> ListarVisitaEstados()
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarVisitaEstados();
        }

        #endregion


        public static ResultadoTransaccion ProcesoActualizarEstados()
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ProcesoActualizarEstados();
        }

        public static ResultadoTransaccion LogEmailVisita(Entidades.Emails.clsEmail email)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.LogEmailVisita(email);
        }

        public static ResultadoTransaccion AgregarComentarioInformeVisita(clsInformeComentario comentario)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.AgregarComentarioInformeVisita(comentario);
        }

        public static IList<clsInformeComentario> ListarComentariosVisita(Int64 IdVisita)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarComentariosVisita(IdVisita);
        }

        public static IList<clsInformeRespuestaUsuario> ListarUsuariosParaRespuestaInforme(clsVisitaInforme informe)
        {
            return AccesoDatos.Calendarios.clsCalendarioADO.ListarUsuariosParaRespuestaInforme(informe);
        }

    }
}
