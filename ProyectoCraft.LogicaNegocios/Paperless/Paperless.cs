﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.LogicaNegocios.Paperless
{
    public class Paperless
    {
        //TSC PREALERTA
        public static IList<PaperlessPreAlerta> ObtenerPreAlertas(String numconsolidada, String estado, String agente,
                                                              DateTime FechaSalidaDesde, DateTime FechaSalidaHasta,
                                                              DateTime FechaLlegadaDesde, DateTime FechaLlegadaHasta,
                                                              DateTime FechaRecibimientoDesde, DateTime FechaRecibimientoHasta)
        {
            IList<PaperlessPreAlerta> prealertas = AccesoDatos.Paperless.clsPaperlessADO.ObtenerPreAlertas(numconsolidada, estado, agente,
                                                                    FechaSalidaDesde, FechaSalidaHasta,
                                                                    FechaLlegadaDesde, FechaLlegadaHasta,
                                                                    FechaRecibimientoDesde, FechaRecibimientoHasta);
            return prealertas;

        }

        public static IList<PaperlessEstadoPreAlerta> ObtenerEstadosPreAlertaPaperless(Enums.Estado activo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerEstadosPreAlertaPaperless(activo);
        }

        public static PaperlessPreAlerta ObtenerPreAlertaPorNumConsolidada(string numconsolidada)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerPreAlertaPorNumConsolidada(numconsolidada);
        }

        public static ResultadoTransaccion ActualizarPreAlerta(PaperlessPreAlerta info)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ActualizarPreAlerta(info);
        }

        public static ResultadoTransaccion ActualizarPreAlertaNumMaster(string NumConsolidada, PaperlessAsignacion PaperlessAsignacionActual)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ActualizarPreAlertaNumMaster(NumConsolidada, PaperlessAsignacionActual);
        }

        
        public static ResultadoTransaccion GuardarPreAlerta(PaperlessPreAlerta info)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.GuardarPreAlerta(info);
        }

        public static ResultadoTransaccion CambiaEstadoCancelacionPreAlerta(PaperlessPreAlerta info)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.CambiaEstadoCancelacionPreAlerta(info);
        }

        public static IList<PaperlessPreAlerta> ObtenerNumConsolidadas()
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerNumConsolidadas();
        }

        public static PaperlessPreAlerta ObtieneNumConsolidadaPreAlerta(string numconsolidada)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtieneNumConsolidadaPreAlerta(numconsolidada);
        }

        public static clsUsuario RecuperaEmailUsuario(string nombreusuario)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.RecuperaEmailUsuario(nombreusuario);
        }

        public static bool ValidaNumConsolidadoPreAlerta(string numConsolidado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ValidaNumConsolidadoPreAlerta(numConsolidado);
        }

        public static bool ValidaNumConsolidadoPreAlerta2(string numConsolidado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ValidaNumConsolidadoPreAlerta2(numConsolidado);
        }

        public static ResultadoTransaccion CambiaEstadoVinculadoPreAlerta(string numconsolidada)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.CambiaEstadoVinculadoPreAlerta(numconsolidada);
        }
        //FIN TSC PREALERTA


        public static IList<PaperlessNaviera> ObtenerNavieras(Entidades.Enums.Enums.Estado estado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerNavieras(estado);
        }

        public static IList<PaperlessAgente> ObtenerAgentes(Entidades.Enums.Enums.Estado estado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerAgentes(estado);
        }

        public static ResultadoTransaccion CrearAgente(PaperlessAgente agente)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.CrearAgente(agente);
        }

        public static ResultadoTransaccion EliminarAgente(PaperlessAgente agente)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.EliminarAgente(agente);
        }

        public static ResultadoTransaccion EditarAgente(PaperlessAgente agente)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.EditarAgente(agente);
        }

        public static IList<PaperlessNave> ObtenerNaves(Entidades.Enums.Enums.Estado estado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerNaves(estado);
        }

        public static IList<PaperlessPuerto> ObtenerPuertosPaperless()
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerPuertosPaperless();
        }


        public static IList<PaperlessFlujo> ObtenerAsignaciones(DateTime desde, DateTime hasta, Int64 usuario1, Int64 usuario2, string estado, string numconsolidado, string nave
            , DateTime desdeEmbarcadores, DateTime hastaEmbarcadores, DateTime desdeNavieras, DateTime hastaNavieras, string nummaster)
        {
            IList<PaperlessFlujo> asignaciones = AccesoDatos.Paperless.clsPaperlessADO.ObtenerAsignaciones(desde, hasta, usuario1, usuario2,
                estado, numconsolidado, nave, desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras, nummaster);

            if (numconsolidado != "-1")
            {
                List<PaperlessFlujo> lista = new List<PaperlessFlujo>(asignaciones);

                asignaciones = lista.FindAll(delegate(PaperlessFlujo foo)
                {
                    return foo.Asignacion.DataUsuario1.Paso1HousesBLInfo.NumConsolidado.StartsWith(numconsolidado);
                });
            }


            if (usuario2 > 0)
            {
                List<PaperlessFlujo> lista = new List<PaperlessFlujo>(asignaciones);

                asignaciones = lista.FindAll(delegate(PaperlessFlujo foo)
                {
                    return foo.EstadoFlujo != Enums.EstadoPaperless.EnAsignacion &&
                           foo.EstadoFlujo != Enums.EstadoPaperless.AsignadoUsuario1 &&
                           foo.EstadoFlujo != Enums.EstadoPaperless.AceptadoUsuario1 &&
                           foo.EstadoFlujo != Enums.EstadoPaperless.EnProcesoUsuario1 &&
                           foo.EstadoFlujo != Enums.EstadoPaperless.RechazadaUsuario1;
                });
            }

            return asignaciones;

        }


        public static PaperlessAsignacion ObtenerAsignacionPorId(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerAsignacionPorId(IdAsignacion);
        }

        public static ResultadoTransaccion AsignacionGuardaHousesBLInfo(PaperlessUsuario1HouseBLInfo info, Boolean IsNew)
        {
              return AccesoDatos.Paperless.clsPaperlessADO.AsignacionGuardaHousesBLInfo1(info, IsNew);
        }
        

        public static Entidades.GlobalObject.ResultadoTransaccion GuardaPaso1(PaperlessAsignacion Paso1)
        {
            if (Paso1.IsNew)
                return AccesoDatos.Paperless.clsPaperlessADO.GuardaPaso1(Paso1);
            else
                return AccesoDatos.Paperless.clsPaperlessADO.AsignacionActualizarPaso1(Paso1);
        }

        public static ResultadoTransaccion GuardaPaso2(PaperlessAsignacion paso2, PaperlessLogAperturaNavieras LogApertura)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.GuardaPaso2(paso2, LogApertura);
        }

        public static ResultadoTransaccion GuardaPaso3(PaperlessAsignacion paso3)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.GuardaPaso3(paso3);
        }

        public static IList<PaperlessEstado> ObtenerEstadosPaperless(Enums.Estado activo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerEstadosPaperless(activo);
        }

        public static ResultadoTransaccion CambiaEstadoAsignacion(PaperlessAsignacion asignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.CambiaEstadoAsignacion(asignacion);
        }

        public static IList<PaperlessPasos> ListarPasosUsuario1(Enums.Estado activo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarPasosUsuario1(activo);
        }

        public static IList<PaperlessPasosEstado> ListarPasosEstadoUsuario1(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarPasosEstadoUsuario1(IdAsignacion);
        }
        public static IList<PaperlessPasosEstado> ListarPasosEstadoUsuario1V2(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarPasosEstadoUsuario1V2(IdAsignacion);
        }

        public static ResultadoTransaccion PreparaPasosUsuario1(PaperlessAsignacion asignacion, PaperlessProcesoRegistroTiempo inicio)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.PreparaPasosUsuario1(asignacion, inicio);
        }

        public static ResultadoTransaccion PreparaPasosUsuario1V2(PaperlessAsignacion asignacion, PaperlessProcesoRegistroTiempo inicio)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.PreparaPasosUsuario1V2(asignacion, inicio);
        }


        public static ResultadoTransaccion PreparaPasosUsuario2(PaperlessAsignacion asignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.PreparaPasosUsuario2(asignacion);
        }

        public static IList<PaperlessUsuario1HousesBL> Usuario1ObtenerHousesBL(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1ObtenerHousesBL(IdAsignacion);
        }
        public static IList<PaperlessUsuario1HousesBL> ObtenerHousesBLporShippingInstruction(string shipping, string puerto)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerHousesBLporShippingInstruction(shipping, puerto);
        }

        public static ResultadoTransaccion Usuario1GuardaHousesBL(IList<PaperlessUsuario1HousesBL> houses, PaperlessUsuario1HouseBLInfo info, PaperlessPasosEstado paso, Boolean existeConsolidada)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1GuardaHousesBL(houses, info, paso,existeConsolidada);
        }

        public static ResultadoTransaccion Usuario1CambiarEstadoPaso(Entidades.Paperless.PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1CambiarEstadoPaso(paso);
        }

        public static PaperlessUsuario1HouseBLInfo Usuario1ObtenerHousesBLInfo(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1ObtenerHousesBLInfo(IdAsignacion);
        }

        public static ResultadoTransaccion Usuario1MarcarHousesRuteados(IList<PaperlessUsuario1HousesBL> houses, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1MarcarHousesRuteados(houses, paso);
        }

        public static ResultadoTransaccion Usuario1GuardarTipoTransito(IList<PaperlessUsuario1HousesBL> houses, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1GuardarTipoTransito(houses, paso);
        }

        public static IList<PaperlessTipoCliente> ListarTiposCliente(Enums.Estado activo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTiposCliente(activo);
        }

        public static IList<PaperlessTipoTransito> ListarTiposTransitoTransbordo()
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTiposTransitoTransbordo();
        }

        public static IList<PaperlessTipoExcepcion> ListarTiposExcepciones(string tipo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTiposExcepciones(tipo);
        }

        public static IList<PaperlessTipoDisputa> ListarTiposDisputa()
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTiposDisputas();
        }

        public static IList<PaperlessUsuario1HousesBL> RefrescarTiposTransitoTransbordo(List<PaperlessUsuario1HousesBL> houses)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.RefrescarTiposTransitoTransbordo(houses);
        }

        public static IList<PaperlessExcepcion> Usuario1ObtenerExcepciones(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1ObtenerExcepciones(IdAsignacion);
        }

        public static ResultadoTransaccion Usuario1IngresarExcepxiones(IList<PaperlessExcepcion> excepciones, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1IngresarExcepxiones(excepciones, paso);
        }

        public static ResultadoTransaccion Usuario1ActuazarPaso1(IList<PaperlessUsuario1HousesBL> houses, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1ActuazarPaso1(houses, paso);
        }

        public static ResultadoTransaccion Usuario1CambiarEstadoPaso_CambiarEstadoAsignacion(Entidades.Paperless.PaperlessPasosEstado paso,
                                                                                                PaperlessAsignacion asignacion,
                                                                                                PaperlessProcesoRegistroTiempo termino,
                                                                                                PaperlessProcesoRegistroTiempo iniciousuario2
            )
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1CambiarEstadoPaso_CambiarEstadoAsignacion(paso,
                                                                                                           asignacion, termino, iniciousuario2);
        }

        public static IList<PaperlessTipoCarga> ListarTipoCarga(Enums.Estado activo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTipoCarga(activo);
        }
        public static IList<PaperlessTipoCarga> ListarTipoCargaDescripcionLarga(Enums.Estado activo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTipoCargaDescripcionLarga(activo);
        }

        public static IList<PaperlessTipoServicio> ListarTipoServicios(Enums.Estado activo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTipoServicios(activo);
        }

        public static PaperlessProcesoDuracion ObtenerDuracionProcesoPaperless(PaperlessTipoCarga tipocarga)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerDuracionProcesoPaperless(tipocarga);
        }

        public static ResultadoTransaccion Usuario2CambiaEstado_RegistraComienzo(PaperlessProcesoRegistroTiempo inicioUsuario2,PaperlessAsignacion Asignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario2CambiaEstado_RegistraComienzo(inicioUsuario2,Asignacion);
        }


        //private static ResultadoTransaccion Usuario1RegistraComienzo(PaperlessProcesoRegistroTiempo inicio)
        //{
        //    return AccesoDatos.Paperless.clsPaperlessADO.Usuario1RegistraComienzo(inicio);
        //}

        //public static ResultadoTransaccion Usuario1RegistraTermino(PaperlessProcesoRegistroTiempo termino)
        //{
        //    return AccesoDatos.Paperless.clsPaperlessADO.Usuario1RegistraTermino(termino);
        //}

        public static PaperlessProcesoRegistroTiempo ObtenerTiemposProceso(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerTiemposProceso(IdAsignacion);
        }

        public static IList<PaperlessPasosEstado> ListarPasosEstadoUsuario2(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarPasosEstadoUsuario2(IdAsignacion);
        }

        public static ResultadoTransaccion Usuario2IngresarExcepxiones(IList<PaperlessExcepcion> excepciones, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario2IngresarExcepxiones(excepciones, paso);
        }

        public static IList<PaperlessUsuario1HousesBL> ObtenerEmbarcadores(IList<PaperlessUsuario1HousesBL> listparaembarcadores)
        {
            List<PaperlessUsuario1HousesBL> housesembarcadoressource = new List<PaperlessUsuario1HousesBL>(listparaembarcadores);

            listparaembarcadores = housesembarcadoressource.FindAll(delegate(PaperlessUsuario1HousesBL foo)
                                                          {
                                                              return foo.TipoCliente != null && foo.TipoCliente.Nombre.ToUpper() == "EMBARCADOR";
                                                          });
            return listparaembarcadores;
        }

        public static ResultadoTransaccion Usuario2ActualizarHouseBL(IList<PaperlessUsuario1HousesBL> housesbl, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario2ActualizarHouseBL(housesbl, paso);
        }

        public static ResultadoTransaccion Usuario2TerminaProceso(PaperlessAsignacion asignacion, PaperlessPasosEstado paso, PaperlessProcesoRegistroTiempo termino)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario2TerminaProceso(asignacion, paso, termino);
        }

        public static ResultadoTransaccion Usuario2ActualizaPaso(PaperlessAsignacion asignacion, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario2ActualizaPaso(asignacion, paso);
        }

        public static ResultadoTransaccion Usuario1RechazaAsignacion(PaperlessUsuario1Rechaza rechazo)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1RechazaAsignacion(rechazo);
        }

        public static PaperlessUsuario1Rechaza ObtenerRechazoAsignacion(Int64 IdAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerRechazoAsignacion(IdAsignacion);
        }

        public static IList<PaperlessFlujo> ConsultarGestionPaperless(string nummaster, string numconsolidad, DateTime desde, DateTime hasta, Int64 usuario1, Int64 usuario2, string nave, DateTime desdeEmbarcadores, DateTime hastaEmbarcadores, DateTime desdeNavieras, DateTime hastaNavieras)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ConsultarGestionPaperless(nummaster, numconsolidad, desde,
                                                                                   hasta, usuario1, usuario2, nave,
                                                                                   desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras);
        }
        public static bool ValidaNumMaster(string numMaster)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ValidaNumMaster(numMaster);
        }
        public static bool ValidaNumConsolidado(string numConsolidado, string idasignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ValidaNumConsolidado(numConsolidado, idasignacion);
        }

        public static List<PaperlessTipoResponsabilidad> ListarTiposResponsabilidad(string resp)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTiposResponsabilidad(resp);

        }

        public static ResultadoTransaccion Usuario1IngresarExcepxionesV2(IList<PaperlessExcepcion> excepciones, PaperlessPasosEstado pasoSeleccionado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1IngresarExcepxionesV2(excepciones, pasoSeleccionado);
        }

        public static IList<PaperlessExcepcion> RefrescarExcepciones(List<PaperlessExcepcion> excepciones)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.RefrescarExcepciones(excepciones);
        }

        public static ResultadoTransaccion Usuario1GuardaDisputas(IList<PaperlessUsuario1Disputas> disputas, PaperlessAsignacion info, PaperlessPasosEstado pasoSeleccionado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1GuardaDisputas(disputas, info, pasoSeleccionado);
        }

        public static IList<PaperlessUsuario1Disputas> ObtieneDisputas(PaperlessAsignacion paperlessAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtieneDisputas(paperlessAsignacion);
        }
        public static IList<PaperlessCantUsuarios> ObtenerCantidadAsignaciones(string usuario, DateTime desde, DateTime hasta)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerCantidadAsignaciones(usuario, desde, hasta);
        }
        public static  DataTable ObtenerCantidadAsignacionesGrafico(string usuario, DateTime desde, DateTime hasta)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerCantidadAsignacionesGrafico(usuario, desde, hasta);
        }
        public static DataTable ObtenerCantidadAsignacionesGraficoGestionPaperless(DateTime desde, DateTime hasta,
            string usuario, string tipocarga, string EstadoPaperless, string marca)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ObtenerCantidadAsignacionesGraficoGestionPaperless(desde, hasta, usuario,tipocarga,EstadoPaperless,marca);
        }
        public static IList<PaperlessFlujo> ConsultarGestionPaperlessGraficosUsuario1y2(DateTime desde, DateTime hasta,
            string usuario, string tipocarga, string EstadoPaperless, string marca)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ConsultarGestionPaperlessGraficosUsuario1y2(desde,hasta,usuario,tipocarga,EstadoPaperless,marca);
        }
        public static ResultadoTransaccion Usuario1GuardaHousesBLDesdeExcepcion(PaperlessUsuario1HousesBL houses, PaperlessUsuario1HouseBLInfo info, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1GuardaHousesBLDesdeExcepcion(houses, info, paso);
        }
        public static void Usuario1EliminaExcepxion(PaperlessExcepcion excepcion, Int64 idUsuarioUltimaModificacion)
        {
            AccesoDatos.Paperless.clsPaperlessADO.Usuario1EliminaExcepxion(excepcion, idUsuarioUltimaModificacion);
        }
        public static List<PaperlessAgenteCausador> ListarTiposPaperlessAgenteCausador()
        {
            return AccesoDatos.Paperless.clsPaperlessADO.ListarTiposPaperlessAgenteCausador();

        }

        public static IList<PaperlessExcepcionMaster> Usuario1ObtenerExcepcionesMaster(Int64 idAsignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1ObtenerExcepcionesMaster(idAsignacion);
        }
        public static ResultadoTransaccion Usuario1IngresarExcepxionesMaster(IList<PaperlessExcepcionMaster> excepciones, PaperlessPasosEstado pasoSeleccionado)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1IngresarExcepxionesMaster(excepciones, pasoSeleccionado);
        }
        public static void Usuario1EliminaExcepxionMaster(PaperlessExcepcionMaster excepcion, Int64 idUsuarioUltimaModificacion)
        {
            AccesoDatos.Paperless.clsPaperlessADO.Usuario1EliminaExcepxionMaster(excepcion, idUsuarioUltimaModificacion);
        }
        public static ResultadoTransaccion Usuario2IngresarExcepxionesMaster(IList<PaperlessExcepcionMaster> excepciones, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario2IngresarExcepxionesMaster(excepciones, paso);
        }
        public static ResultadoTransaccion Usuario1ActualizaExcepcionV2(IList<PaperlessExcepcion> excepciones, PaperlessPasosEstado paso)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1IngresarExcepxionesV2_Usuario2(excepciones,paso);
        }

        public static ResultadoTransaccion Usuario1GuardaEmpresa(string empresa, long asignacion)
        {
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario1GuardaEmpresa(empresa, asignacion);
        }

        public static List<PaperlessEmpresa> ListarEmpresas(){
            return AccesoDatos.Paperless.clsPaperlessADO.ListarEmpresas();
        }
        public static ResultadoTransaccion Usuario2CambiarEstadoPaso(PaperlessPasosEstado paso){
            return AccesoDatos.Paperless.clsPaperlessADO.Usuario2CambiarEstadoPaso(paso);
        }

    }
}
