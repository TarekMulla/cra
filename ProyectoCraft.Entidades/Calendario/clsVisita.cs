using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsVisita: GlobalObject.IdentifiableObject
    {
        public clsVisita()
        {
            Cliente = new clsClienteMaster(true);
            Vendedor = new clsUsuario();
            UsuarioOrganizador = new clsUsuario();
            Asistentes = new List<clsVisitaAsistente>();
            DescripcionCancelacion = "";
            FechaCancelacion = new DateTime(9999,1,1,0,0,0);
            FechaConfirmacion = new DateTime(9999,1,1,0,0,0);
            EsReplanificada = false;
        }

        public string Asunto { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaHoraComienzo { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public Clientes.clsClienteMaster Cliente { get; set; }
        public Usuarios.clsUsuario Vendedor{ get; set; }
        public string Descripcion { get; set; }
        public Parametros.clsItemParametro NivelImportancia { get; set; }
        public bool EsRecurrente { get; set; }
        //public Enums.Enums.VisitaEstadoVista EstadoVista { get; set; }
        public Int16 EstadoVista { get; set; }

        public Int16 StatusUsuario
        {
            get { return 0; }
            
        }
        public Enums.Enums.VisitaEstado EstadoBD { get; set; }
        public Enums.Enums.VisitaEstado EstadoBDOld { get; set; }

        public string EstadoVistaDescripcion
        {
            get
            {
                return Convert.ToString(EstadoBD).Replace("_", " ");
            }
        }

        public Usuarios.clsUsuario UsuarioOrganizador { get; set; }

        public string DescripcionCancelacion { get; set; }        
        public DateTime FechaCancelacion { get; set; }

        public bool EsReplanificada { get; set; }
        public DateTime FechaReplanificacion { get; set; }

        public IList<clsVisitaAsistente> Asistentes { get; set; }

        public IList<clsVisitaAsistente> AsistentesCraft
        {            
            get
            {
                IList<clsVisitaAsistente> list = new List<clsVisitaAsistente>();
                foreach (var asistente in Asistentes)
                {
                    if(asistente.TipoAsistente == Enums.Enums.VisitaTipoAsistente.Usuario)
                        list.Add(asistente);
                }
                return list;
            }
        }

        public IList<clsVisitaAsistente> AsistentesCliente
        {
            get
            {
                IList<clsVisitaAsistente> list = new List<clsVisitaAsistente>();
                foreach (var asistente in Asistentes)
                {
                    if (asistente.TipoAsistente == Enums.Enums.VisitaTipoAsistente.Contacto)
                        list.Add(asistente);
                }
                return list;
            }
        }

        public bool ConfirmadaSinPlanificar { get; set; }

        public clsVisitaInforme Informvisita { get; set; }

        public bool TieneInforme
        {
            get
            {
                return Informvisita != null;
            }
        }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaConfirmacion { get; set; }

        public string EmailAsistentesCraft
        {            
            get
            {
                string emails = "";

                foreach (var asistente in AsistentesCraft)
                {
                    emails += asistente.Usuario.Email + ";";
                }
                return emails;
            }
        }

        public string EmailAsistentesCliente
        {
            get
            {
                string emails = "";

                foreach (var asistente in AsistentesCliente)
                {
                    emails += asistente.Contacto.Email + ";";
                }
                return emails;
            }
        }

        public bool EsReunionInterna { get; set; }

        public bool EnviarConfirmacionACliente { get; set; }

    }
}
