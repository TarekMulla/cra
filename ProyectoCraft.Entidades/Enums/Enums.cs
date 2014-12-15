using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace ProyectoCraft.Entidades.Enums {
    public class Enums {
        public enum TipoPersona {
            Todos = -1,
            Target = 1,
            Cuenta = 2,
            CuentaPaperless = 3,
            Comercial = 4
        }

        public enum EstadoTarget {
            Habilitado = 1,
            Calificado = 2,
            Descalificado = 0,
        }

        public enum Estado {
            Todos = -1,
            Habilitado = 1,
            Deshabilitado = 0,
        }

        public enum Sexo {
            Masculino = 1,
            Femenino = 2

        }

        public enum Dias {
            Lunes = 1,
            Martes = 2,
            Miercoles = 3,
            Jueves = 4,
            Viernes = 5,
            Sabado = 6,
            Domingo = 7,
        }

        public enum Jornadas {
            Mañana = 1,
            Tarde = 2,
            Noche = 3,
        }

        public enum TipoParametro {
            TipoSaludo = 1,
            SectorEconomico = 2,
            TipoRelacion = 3,
            MotivoInteres = 4,
            OrigenClientePotencial = 5,
            FormasContacto = 6,
            EstadosClientes = 7,
            TipoDireccion = 8,
            DestinoDireccion = 9,
            ZonaVentas = 10,
            CategoriaCliente = 11,
            TiposRol = 12,
            EstadoCivil = 13,
            Sexo = 14,
            Dias = 15,
            Jornada = 16,
            NivelInteres = 17,
            SectorDireccion = 18,
            UnidadMedidaVolumen = 19,
            TipoMotivoDescalificacion = 20,
            TipoDepartamentoContacto = 21,
            ImportanciaVisita = 22,
            UnidadMedidaLCL = 23,
            UnidadMedidaFCL = 24,
            UnidadMedidaAereo = 25,
            TerminioCompra = 26,

            TipoContenedor = 27,
            Prioridad = 28,
            PaperlessImportanciaUsuario1 = 29,
            Incoterms = 30,
            TipoCompentencia = 31,

            CotizacionDirectaObsertvacionFija = 32,
            Any = 99
        }

        public enum EstadoTransaccion {
            Aceptada = 1,
            Rechazada = 2
        }

        public enum AccionTransaccion {
            Insertar = 1,
            Actualizar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public enum TipoAccionFormulario {
            Nuevo = 1,
            Editar = 2,
            Eliminar = 3,
            Consultar = 4,
            CambiarEstado = 5
        }

        public enum TipoActividadUsuario {
            Creo = 1,
            Edito = 2,
            Elimino = 3,
            Asigno = 4,
            Desasigno = 5
        }

        public enum CargosUsuarios {
            Todos = -1,
            Vendedor = 1,
            CustomerService = 2,
            Supervidor = 3,
            GerenteVentas = 4,
            GerenteGeneral = 5,
            SupervisorDeAdministración = 6,
            Auditor = 7,
            SupervisorDeFinanzas = 8,
            AtenciónDePublico = 9,
            Cajero = 10,
            Asesor = 11,
            SupervisorDeVentasAereo = 12,
            JefeDeOperaciones = 13,
            EncargadoDeOperaciones = 14,
            SupervisorDocumental = 15,
            EncargadoDocumental1raEtapa = 16,
            EncargadoDocumental2daEtapa = 17,
            SupervisorDeProcesos = 18,
            EncargadoDeProceso = 19,
            UsuarioSalesLead = 20,
        }

        public enum TipoCondicionComercial {
            Flete = 1,
            GastosLocales = 2
        }

        public enum EstadoCondicionComercial {
            Guardado = 1,
            EnviadoAutorizar = 2,
            Autorizado = 3,
            Rechazado = 4
        }

        public enum VisitaNivelImportancia {
            Baja = 1,
            Media = 2,
            Alta = 3,
            Urgente = 4,
        }

        //public enum VisitaEstadoBD
        //{
        //    Todas = -1,
        //    Pendiente = 1,
        //    Realizada = 2,
        //    Cancelada = 3,
        //    NoRealizada = 4,
        //    PendienteRegistro = 5,
        //    CreadaIncompleta = 6,

        //}

        public enum VisitaEstado {
            Todas = -1,
            Incompleta = 1,
            Planificada_Por_confirmar = 2,
            Confirmada = 3,
            Realizada_Informe_Pendiente = 4,
            Realizada_Con_Informe = 5,
            Cancelada = 6,
            No_Realizada = 7,
            Realizada_Con_Informe_Fuera_De_Plazo = 8
        }



        public enum VisitaEstadoVista {
            Pendiente = 3,
            Realizada = 2,
            Cancelada = 11,
            NoRealizada = 1,
            PendienteRegistro = 4,
            CreadaIncompleta = 10,
        }

        public enum VisitaEstadoAsistente {
            Pendiente = 1,
            ConfirmoAsistencia = 2,
            ConfirmoNoAsistencia = 3
        }

        public enum VisitaTipoAsistente {
            Usuario = 1,
            Contacto = 2,
        }

        public enum VisitaTipoEmail {
            Planificacion = 1,
            ConfirmacionSinPlanificacion = 2,
            ConfirmacionAsistentesCraft = 3,
            ConfirmacionAsistentesCliente = 4,
            InformeVisitaConfirmados = 5,
            InformeVisitaFijos = 6,
            InformeVisitaEncNegocio = 7,
            Replanificacion = 8,
            Cancelacion = 9,
            AvisoVendedorVisitaOrganizada = 10,
            InformeVisitaCustomerService = 11,
            AvisoInformeRequiereRespuesta = 12,
            ComentarioAInformeVisita = 13
        }

        public enum EmailTipoPlantilla {
            VisitaPlanificada = 1,
            VisitaPlanificadaModificada = 2,
            VisitaConfirmada = 3,
            VisitaReplanificada = 4,
            VisitaCancelada = 5,
            InformeVisita = 6,
        }

        public enum TipoCalendario {
            MiCalendario = 1,
            CalendarioCompartido = 2,
        }


        //public enum EstadoTargetAccount
        //{
        //    Asignado = 0,
        //    Informacion_General_Completa = 1,
        //    Contacto_Telefonico_Completo = 2,
        //    Visitado = 3,
        //}

        public enum EstadosMetas {
            Propuesta = 1,
            Revision = 2,
            Asignado = 3,
            Informacion_General = 4,
            Contacto_Telefonico = 5,
            Visita = 6,
            Cancelado = 7,
            Cierre = 8,
            Perdida = 9,
        }


        public enum EstadoPaperless {
            Nuevo = 1,
            //InformacionGeneral = 2,
            //FechasPlazos = 3,
            //Prealerta = 4,
            EnAsignacion = 2,
            AsignadoUsuario1 = 3,
            AceptadoUsuario1 = 4,
            EnProcesoUsuario1 = 5,
            EnviadoUsuario2 = 6,
            EnProcesoUsuario2 = 7,
            ProcesoTerminado = 8,
            EnviadoMercante=10,
            RechazadaUsuario1 = 9,
            AceptadoUsuario2 = 11,
            RechazadaUsuario2 =12,
        }

        public enum TipoUsuario
        {
            Usuario1 = 1,
            Usuario2 = 2,
        }

        public enum PaperlessTipoReciboAperturaEmbarcador {
            NoDefinido = 0,
            Mail = 1,
            Papel = 2,
            NoRecibida = 3,
        }
        
        public enum UsuariosCargo {
            Vendedor = 1,
            Customer_Service = 2,
            Supervisor = 3,
            Gerente_Administración_y_Finanzas = 4,
            Gerente_General = 5,
            Supervisor_de_Administración = 6,
            Auditor = 7,
            Supervisor_de_Finanzas = 8,
            Atención_de_Publico = 9,
            Cajero = 10,
            Asesor = 11,
            Supervisor_de_Ventas_Aereo = 12,
            Jefe_de_Operaciones = 13,
            Encargado_de_Operaciones = 14,
            Supervisor_Documental = 15,
            Encargado_Documental_1ra_Etapa = 16,
            Encargado_Documental_2da_Etapa = 17,
            Supervisor_Procesos = 18,
            Encargado_Procesos = 19,
            Usuario_Sales_Lead = 20,
            Encargado_Contabilidad=21,
            AdministradorDatosMaestros=22,
            Administrador= 23,

        }
        public enum EstadosSLead {
            Asignado = 1,
            Seguimiento = 2,
            Cancelada = 3,
            Cierre = 4,
            Perdida = 5,
        }
        public enum EstadosCotizacion
        {
            Ingresado = 1,
            EnProceso = 2,
            TarifaDisponible = 3,
            Enviadacliente = 4,
            Reevaluacion = 5,
            PerdidoTarifa = 6,
            PerdidoOtros = 7,
            Cerrado = 8,
            CerradoLCL = 9,
            Eliminado = 10,
        }

    }
}
