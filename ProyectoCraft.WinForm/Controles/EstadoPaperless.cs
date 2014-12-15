using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace ProyectoCraft.WinForm.Controles
{
    public partial class EstadoPaperless : UserControl
    {
        private EstadoPaperless _instancia;
        public EstadoPaperless Instancia
        {
           get
           {
               if(_instancia == null)
                   _instancia = new EstadoPaperless();

               return _instancia;
           }
            set { _instancia = value; }
        }

        private Entidades.Paperless.PaperlessAsignacion _asignacion;
        public Entidades.Paperless.PaperlessAsignacion AsignacionActual
        {
            get { return _asignacion; }
            set { _asignacion = value; }
        }

        //private DateTime _tiempodt;
        //public DateTime _TiempoCurrentDT
        //{
        //    get { return _tiempodt; }
        //    set { _tiempodt = value; }
        //}

        private TimeSpan _tiempo;
        public TimeSpan _TiempoCurrent
        {
            get { return _tiempo; }
            set { _tiempo = value; }
        }

        private DateTime? _inicio;
        public DateTime? FechaInicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }

        private DateTime? _termino;
        public DateTime? FechaTermino
        {
            get { return _termino; }
            set { _termino = value; }
        }

        private TimeSpan _estimado;
        public TimeSpan TiempoEstimado
        {
            get { return _estimado; }
            set { _estimado = value; }
        }

        private DateTime _plazousuario2;
        public DateTime PlazoUsuario2
        {
            get { return _plazousuario2; }
            set { _plazousuario2 = value; }
        }


        public EstadoPaperless()
        {
            InitializeComponent();
        }

       
        public void ObtenerTiempoEstimadoProcesoUsuario1()
        {
            Entidades.Paperless.PaperlessProcesoDuracion duracion =
                LogicaNegocios.Paperless.Paperless.ObtenerDuracionProcesoPaperless(AsignacionActual.TipoCarga);

            if(duracion != null)
            {
                decimal totalminutos = duracion.Duracion * AsignacionActual.NumHousesBL;

                TimeSpan ts = new TimeSpan(0, Convert.ToInt16(totalminutos), 0);
                lblTiempoEstimado.Text = "Tiempo Estimado Total: " + ts.ToString();

                TiempoEstimado = ts;

                ts = new TimeSpan(0, Convert.ToInt16(duracion.Duracion), 0);
                lblTiempoEstimadoUnidad.Text = "Tiempo Estimado por House: " + ts.ToString();
                
            }
        }

        public void ObtenerTiempoEstimadoProcesoUsuario2()
        {
            PlazoUsuario2 = AsignacionActual.PlazoEmbarcadores.Value;

            TiempoEstimado = PlazoUsuario2 - FechaInicio.Value;

            lblTiempoEstimadoUnidad.Text = "F.Embarcador: " + PlazoUsuario2.ToString();
            //lblTiempoEstimadoUnidad.Visible = true ;
            if (Convert.ToInt16(TiempoEstimado.TotalHours) >= -100)
            {
                TimeSpan ts = new TimeSpan(TiempoEstimado.Days, TiempoEstimado.Hours, TiempoEstimado.Minutes, TiempoEstimado.Seconds);
                lblTiempoEstimado.Text = "Tiempo Estimado Total: " + ts.ToString();
            }
            else
                lblTiempoEstimado.Text = "Tiempo Estimado Total: " + "Fuera de Rango";

        }

        public void ObtenerTiemposProcesoUsuario1()
        {
            Entidades.Paperless.PaperlessProcesoRegistroTiempo tiempo =
                LogicaNegocios.Paperless.Paperless.ObtenerTiemposProceso(AsignacionActual.Id);

            if(tiempo == null) return;
                        
            if (!tiempo.ComienzoUsuario1.HasValue)
            {
                lblFechaInicio.Text = "Inicio el:";
                FechaInicio = null;
            }                
            else
            {
                FechaInicio = tiempo.ComienzoUsuario1.Value;
                lblFechaInicio.Text = "Inicio el: " + tiempo.ComienzoUsuario1.Value.ToString();                
            }
                

            if (tiempo.TerminoUsuario1.HasValue)
            {
                FechaTermino = tiempo.TerminoUsuario1.Value;
                lblFechaTermino.Text = "Termino el: " + tiempo.TerminoUsuario1.Value.ToString();
            }                
            else
            {
                lblFechaTermino.Text = "Termino el:";
                FechaTermino = null;
            }
                


            if(tiempo.ComienzoUsuario1.HasValue)
            {
                DateTime ahora = DateTime.Now;
                DateTime comienzo = tiempo.ComienzoUsuario1.Value;
                
                TimeSpan diff = ahora - comienzo;
                //16/09 - 17/05 = 121.09:33:15.99999
                _TiempoCurrent = diff;

                if(_TiempoCurrent > TiempoEstimado)
                    progressBar1.Value = Convert.ToInt16(TiempoEstimado.TotalSeconds);
                else
                    progressBar1.Value = Convert.ToInt16(_TiempoCurrent.TotalSeconds);

            }
            else
            {
                _TiempoCurrent = new TimeSpan(0, 0, 0);
            }

            if(tiempo.TerminoUsuario1.HasValue)
            {
                timer1.Enabled = false;

                TimeSpan diff = tiempo.TerminoUsuario1.Value - tiempo.ComienzoUsuario1.Value;

                _TiempoCurrent = diff;

                lblTiempo.Text = FormatearTiempoActual();

                MuestraPanelTiempo();

            }

        }

        public void ObtenerTiemposProcesoUsuario2()
        {
            Entidades.Paperless.PaperlessProcesoRegistroTiempo tiempo =
                LogicaNegocios.Paperless.Paperless.ObtenerTiemposProceso(AsignacionActual.Id);

            if (tiempo == null) return;

            if (!tiempo.ComienzoUsuario2.HasValue)
            {
                lblFechaInicio.Text = "Inicio el:";
                FechaInicio = null;
            }
            else
            {
                FechaInicio = tiempo.ComienzoUsuario2.Value;
                lblFechaInicio.Text = "Inicio el: " + tiempo.ComienzoUsuario2.Value.ToString();
            }


            if (tiempo.TerminoUsuario2.HasValue)
            {
                FechaTermino = tiempo.TerminoUsuario2.Value;
                lblFechaTermino.Text = "Termino el: " + tiempo.TerminoUsuario2.Value.ToString();
            }
            else
            {
                lblFechaTermino.Text = "Termino el:";
                FechaTermino = null;
            }

            ObtenerTiempoEstimadoProcesoUsuario2();
            ConfigurarIniciarTiempo(true);

            if (tiempo.ComienzoUsuario2.HasValue)
            {
                DateTime ahora = DateTime.Now;
                DateTime comienzo = tiempo.ComienzoUsuario2.Value;

                TimeSpan diff = ahora - comienzo;

                _TiempoCurrent = diff;

                if (_TiempoCurrent > TiempoEstimado)
                    if (Convert.ToInt32(TiempoEstimado.TotalSeconds)>0)
                        progressBar1.Value = Convert.ToInt32(TiempoEstimado.TotalSeconds);
                    else
                        progressBar1.Value = Convert.ToInt32(TiempoEstimado.TotalSeconds)*-1;
                else
                    progressBar1.Value = Convert.ToInt32(_TiempoCurrent.TotalSeconds);

            }
            else
            {
                _TiempoCurrent = new TimeSpan(0, 0, 0);
            }

            if (tiempo.TerminoUsuario2.HasValue)
            {
                timer1.Enabled = false;

                TimeSpan diff = tiempo.TerminoUsuario2.Value - tiempo.ComienzoUsuario2.Value;

                _TiempoCurrent = diff;

                lblTiempo.Text = FormatearTiempoActual();

                MuestraPanelTiempo();

            }

        }



        public void ConfigurarIniciarTiempo(bool usuario2)
        {
            if(!usuario2)
                if(FechaTermino != null) return;

            timer1.Interval = 1000;
            timer1.Enabled = true;            
            timer1.Start();

            progressBar1.Minimum = 0;
            if (Convert.ToInt32(TiempoEstimado.TotalSeconds)>=0)
                progressBar1.Maximum = Convert.ToInt32(TiempoEstimado.TotalSeconds);
            else
                progressBar1.Maximum = Convert.ToInt32(TiempoEstimado.TotalSeconds)*-1;
            //progressBar1.Maximum = int.Parse(TiempoEstimado.TotalSeconds.ToString());


        }
       
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan time = _TiempoCurrent;
            TimeSpan ts = new TimeSpan(0, 0, 1);
            TimeSpan ahorats = time.Add(ts);
            _TiempoCurrent = ahorats;

            lblTiempo.Text = FormatearTiempoActual();

            if(_TiempoCurrent <= TiempoEstimado)
                progressBar1.Value = Convert.ToInt32(_TiempoCurrent.TotalSeconds);

            MuestraPanelTiempo();

            if (_TiempoCurrent > TiempoEstimado)
            {
                //lblTiempoActual.ForeColor = Color.Red;
                lblTiempo.ForeColor = Color.Red;
            }
            else
            {
                lblTiempo.ForeColor = Color.Green;
            }
                

        }

        private void MuestraPanelTiempo()
        {
            TimeSpan diff = TiempoEstimado - _TiempoCurrent;

            lblEstimado.Visible = false;
            pnlEstimado.Visible = false;
            lblTerminandose.Visible = false;
            pnlTerminandose.Visible = false;
            lblFueraPlazo.Visible = false;
            pnlFueraPlazo.Visible = false;

            if(diff.Minutes > 2)
            {
                lblEstimado.Visible = true;
                pnlEstimado.Visible = true;
            }

            if(diff.Minutes < 2 && (_TiempoCurrent < TiempoEstimado))
            {
                lblTerminandose.Visible = true;
                pnlTerminandose.Visible = true;
            }

            if(_TiempoCurrent > TiempoEstimado)
            {
                lblFueraPlazo.Visible = true;
                pnlFueraPlazo.Visible = true;
            }
        }

        private string FormatearTiempoActual()
        {
            string hora;
            string minuto;
            string segundo;
            string dia;

            if (_TiempoCurrent.Hours > 10)
                hora = _TiempoCurrent.Hours.ToString();
            else
                hora = "0" + _TiempoCurrent.Hours.ToString();

            if (_TiempoCurrent.Minutes > 10)
                minuto = _TiempoCurrent.Minutes.ToString();
            else
                minuto = "0" + _TiempoCurrent.Minutes.ToString();

            if (_TiempoCurrent.Seconds > 10)
                segundo = _TiempoCurrent.Seconds.ToString();
            else
                segundo = "0" + _TiempoCurrent.Seconds.ToString();

            dia=_TiempoCurrent.Days.ToString();

            if (Convert.ToInt32(dia)>0) 
                return dia + "." + hora + ":" + minuto + ":" + segundo;
            else
               return hora + ":" + minuto + ":" + segundo;
        }       
    }
}
