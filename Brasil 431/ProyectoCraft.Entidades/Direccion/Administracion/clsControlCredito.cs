using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Tarifado;
using ProyectoCraft.Entidades.Clientes.Cuenta;

namespace ProyectoCraft.Entidades.Direccion.Administracion
{
    public class clsCreditoCliente: IdentifiableObject
    {
        public clsClienteMaster ObjCuenta { get; set; }
        public clsTipoMoneda ObjMoneda { get; set; }
        public double MontoLineaCredito { get; set; }
        public clsCuentaclasificacion ObjCuentaClasificacion { get; set; }
        public string Vendedor { get; set; }
        public string TipoCliente { get; set; }
    }
    public class clsRegistroGrilla
    {
        private string _cliente;
        private string _rut;
        private string _tipocliente;
        private double _deuda_mb;
        private double _deuda_om;
        private double _docu_mb;
        private double _docu_om;
        private double _facturar_mb;
        private double _facturar_om;
        private double _totaldeuda_us;
        private double _totalcredito_us;
        private double _riesgo;
        private string _tiporegistro;

        ArrayList _ArregloDetalle = null;

        public string Cliente 
        {
            get 
            { 
                return _cliente; 
            }
            set 
            { 
                _cliente = value; 
            }
        }
        public string Rut
        {
            get
            {
                return _rut;
            }
            set
            {
                _rut = value;
            }
        }
        public string TipoCliente
        {
            get
            {
                return _tipocliente;
            }
            set
            {
                _tipocliente = value;
            }
        }
        public double DeudaMB
        {
            get
            {
                return _deuda_mb;
            }
            set
            {
                _deuda_mb = value;
            }
        }
        public double DeudaOM
        {
            get
            {
                return _deuda_om;
            }
            set
            {
                _deuda_om = value;
            }
        }
        public double DocuMB
        {
            get
            {
                return _docu_mb;
            }
            set
            {
                _docu_mb = value;
            }
        }
        public double DocuOM
        {
            get
            {
                return _docu_om;
            }
            set
            {
                _docu_om = value;
            }
        }
        public double FacturarMB
        {
            get
            {
                return _facturar_mb;
            }
            set
            {
                _facturar_mb = value;
            }
        }
        public double FacturarOM
        {
            get
            {
                return _facturar_om;
            }
            set
            {
                _facturar_om = value;
            }
        }
        public double TotalDeudaUS
        {
            get
            {
                return _totaldeuda_us;
            }
            set
            {
                _totaldeuda_us = value;
            }
        }
        public double TotalCreditoUS
        {
            get
            {
                return _totalcredito_us;
            }
            set
            {
                _totalcredito_us = value;
            }
        }
        public double Riesgo
        {
            get
            {
                return _riesgo;
            }
            set
            {
                _riesgo = value;
            }
        }
        public string TipoRegistro
        {
            get
            {
                return _tiporegistro;
            }
            set
            {
                _tiporegistro = value;
            }
        }

        public ArrayList ArregloDetalle 
        {
            get 
            {
                return _ArregloDetalle; 
            }
            set 
            {
                _ArregloDetalle = value; 
            }
        }
    }
    public class ClsArrRegistrosGrilla : ArrayList
    {
        //public NestedRecords()
        //{
        //    this.Add(new clsControlCredito("Customers", new ChildRecordsProducts()));
        //    this.Add(new clsControlCredito("Products", new ChildRecordsProducts()));
        //    this.Add(new clsControlCredito("Shippers", new ChildRecordsProducts()));
        //}
        //public virtual new clsControlCredito this[int index]
        //{
        //    get 
        //    { 
        //        return (clsControlCredito)(base[index]); 
        //    }
        //}
    }
    public class clsArregloDetGrilla : ArrayList
    {
        //public ChildRecordsProducts()
        //{
        //    ObjetoDetalle Obj = new ObjetoDetalle();

        //    Obj.nombre = "Leo";
        //    Obj.apellido = "Kutscher";
        //    Obj.edad = 5;

        //    this.Add(Obj);
        //}
    }
    public class ClsDetalleGrilla
    {
        public string Moneda { get; set; }
        public double MontoDeuda { get; set; }
        public double MontoDocumentos { get; set; }
        public double MontoFacturar { get; set; }
        public double MDeudaMB { get; set; }
        public double MDeudaUSD { get; set; }
        public double MDocuMB { get; set; }
        public double MDocuUSD { get; set; }
        public double MFacMB { get; set; }
        public double MFacUSD { get; set; }
    }
}
