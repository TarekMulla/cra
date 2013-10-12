using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.LogicaNegocios.Log;

namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public static class clsClientesMaster
    {
        public static IList<clsClientesProductos> ObtenerProductosPreferidos(Int64 IdCiente)
        {
            return clsClienteMasterADO.ObtenerProductosPreferidos(IdCiente);
        }

        public static IList<clsClienteMaster> ListarClienteMaster(string busqueda, Enums.TipoPersona tipo, Enums.Estado estado, bool MostrarNombreFantasia)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            if (busqueda == "") busqueda = "-1";
            var retorno = clsClienteMasterADO.ListarClienteMaster(busqueda, tipo, estado,MostrarNombreFantasia);
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
            return retorno;

        }


        public static List<clsClienteMaster> ListarCuentasYTarget(Int64 idVendedor){
            var clientesMaster = new List<clsClienteMaster>();
            var cuentas = clsCuentas.ListarCuentas("-1", Base.Usuario.UsuarioConectado.Usuario.Id32, -1, -1);
            foreach (var c in cuentas){
                c.ClienteMaster.Tipo = Enums.TipoPersona.Cuenta;
                clientesMaster.Add(c.ClienteMaster);
            }

            var targets = ListarTarget(idVendedor);
            clientesMaster.AddRange(targets);

            return clientesMaster;
        }

        public static IList<clsClienteMaster> ListarTarget(Int64 idVendedor){

            return clsClienteMasterADO.ListarTarget(idVendedor);
            
        }

        //public static IList<clsClienteMaster> ListarClientesMasterCF(string busqueda, Enums.TipoPersona tipo, Enums.Estado estado)
        //{
        //    if (busqueda == "") busqueda = "-1";

        //    IList<clsClienteMaster> listado = new List<clsClienteMaster>();
        //    listado = clsClienteMasterADO.ListarClienteMaster(busqueda, tipo, estado,);

            
        //    foreach (var list in listado)
        //    {
        //        if (list.Tipo == Enums.TipoPersona.Cuenta)
        //            list.NombreCompañia = list.NombreFantasia;
        //    }    
        

        //    return listado;

        //}

        public static IList<Entidades.Clientes.Contacto.clsContacto> ListrContactos(Entidades.Clientes.clsClienteMaster cliente)
        {
            return clsClienteMasterADO.ListarContactos(cliente);
        }

        public static bool ValidarExisteRut(string rut, Enums.TipoPersona tipo)
        {
            return clsClienteMasterADO.ValidarExisteRut(rut, tipo);
        }
        public static clsClienteMaster ObtenerClienteMasterPorRut(String rut)
        {
            return clsClienteMasterADO.ObtenerClienteMasterPorRut(rut);
        }

        public static clsClienteMaster ObtenerClienteMasterPorId(Int64 IdCliente)
        {
            return clsClienteMasterADO.ObtenerClienteMasterPorId(IdCliente);
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpCliente(Int64 IdCiente)
        {
            return clsClienteMasterADO.ObtenerFollowUpCliente(IdCiente);
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosCliente(Int64 IdCiente) {
            return clsClienteMasterADO.ObtenerFollowUpActivosCliente(IdCiente);
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorInforme(Int64 IdInforme)
        {
            return clsClienteMasterADO.ObtenerFollowUpClientePorInforme(IdInforme);
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorInforme(Int64 IdInforme) {
            return clsClienteMasterADO.ObtenerFollowUpActivosClientePorInforme(IdInforme);
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorLLamada(Int64 IdLlamada) {
            return clsClienteMasterADO.ObtenerFollowUpClientePorLlamada(IdLlamada);
        }       
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorLLamada(Int64 IdLlamada) {
            return clsClienteMasterADO.ObtenerFollowUpActivosClientePorLlamada(IdLlamada);
        }


        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorTarget(Int64 IdTarget) {
            return clsClienteMasterADO.ObtenerFollowUpClientePorTarget(IdTarget);
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorTarget(Int64 IdTarget) {
            return clsClienteMasterADO.ObtenerFollowUpActivosClientePorTarget(IdTarget);
        }


        public static IList<clsClienteFollowUp> ObtenerFollowupClientePorSalesLEad(Int64 idSalesLead) {
            return clsClienteMasterADO.ObtenerFollowUpClientePorSalesLead(idSalesLead);
        }
        public static IList<clsClienteFollowUp> ObtenerFollowupActivosClientePorSalesLEad(Int64 idSalesLead) {
            return clsClienteMasterADO.ObtenerFollowUpActivosClientePorLSalesLead(idSalesLead);
        }

    }
}
