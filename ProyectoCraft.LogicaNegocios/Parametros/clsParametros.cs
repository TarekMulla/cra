using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using  ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.AccesoDatos.Parametros;

namespace ProyectoCraft.LogicaNegocios.Parametros
{
    public static class clsParametros
    {
        public static clsParametrosInfo ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro Parametro)
        {
            return clsParametrosDAO.ListarParametrosPorTipo(Parametro);
        }

        public static IList<Entidades.Tarifado.clsTipoMoneda> ListarMonedas()
        {
            return clsParametrosDAO.ListarMonedas();
        }

        public static IList<Entidades.Ventas.Productos.clsTipoProducto> ListarProductos(string Activo)
        {
            return clsParametrosDAO.ListarProductos(Activo);
        }


        public static IList<clsPais> ListarPaises()
        {
            return clsParametrosDAO.ListarPaises();
        }

        public static IList<clsCiudad> ListarCiudades(Int64 idPais)
        {
            return clsParametrosDAO.ListarCiudades(idPais);
        }

        public static IList<clsComuna> ListarComunas(Int64 idCiudad)
        {
            return clsParametrosDAO.ListarComunas(idCiudad);
        }
        public static ResultadoTransaccion CrearComuna(Int64 IdCiudad, string Comuna, string pais)
        {
            var val = clsParametrosDAO.CrearComuna(IdCiudad,Comuna, pais);
            return  val;
        }
        public static ResultadoTransaccion ActualizarComuna(Int64 IdComuna,Int64 IdCiudad, string Descripcion)
        {
            var val = clsParametrosDAO.Actualizarcomuna(IdComuna,IdCiudad, Descripcion);
            return val;
        }

        public static IList<clsTipoOrigenCarga> ListarTiposOrigenCarga(string descripcion)
        {
            return clsTipoOrigenDestinoCargaDAO.ListarTiposOrigenCarga(descripcion);
        }

        public static IList<clsTipoDestinoCarga> ListarTiposDestinoCarga(string descripcion)
        {
            return clsTipoOrigenDestinoCargaDAO.ListarTiposDestinoCarga(descripcion);
        }

        public static clsItemParametro ListarTiposCompentecias() {
            throw new NotImplementedException();
        }
    }
}
