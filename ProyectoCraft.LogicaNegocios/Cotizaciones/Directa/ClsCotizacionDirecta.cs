using System;
using System.Collections.Generic;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.AccesoDatos.Cotizaciones;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.AccesoDatos.Direccion.Metas;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa {
    public class ClsCotizacionDirecta {
        public static IList<ITableable> ListarTodasLasCotizacionesPorUsuario(clsUsuario usuario,DateTime desde) {
            var lista = (List<ITableable>)ClsCotizacionDao.ListarTodasLasCotizacionesDirectasPorUsuario(usuario,desde);
            lista.Sort((foo, bar) => bar.Id32.CompareTo(foo.Id32));
            return lista;
        }

        public static IList<ITableable> ListarTodasLasCotizaciones(DateTime desde) {
            var lista = (List<ITableable>)ClsCotizacionDao.ListarTodasLasCotizacionesDirectas(desde);
            lista.Sort((foo, bar) => bar.Id32.CompareTo(foo.Id32));
            return lista;
        }

        public static ResultadoTransaccion Crear(CotizacionDirecta cotizacionDirecta) {
            var resultado = ClsCotizacionDirectaDao.Crear(cotizacionDirecta);
            var log = CreaLog(cotizacionDirecta, EnumTipoLogCotizacionDirecta.IngresoCotizacion);
            return resultado;
        }

        public static ResultadoTransaccion Modificar(CotizacionDirecta cotizacionDirecta) {
            var resultado = ClsCotizacionDirectaDao.Modificar(cotizacionDirecta);
            var log = CreaLog(cotizacionDirecta, EnumTipoLogCotizacionDirecta.Modificacion);
            return resultado;
        }

        public static ResultadoTransaccion ObtieneCotizacionDirecta(Int32 id) {
            return ClsCotizacionDirectaDao.ObtieneCotizacionDirecta(id);
        }

        private static LogCotizacionesDirecta CreaLog(CotizacionDirecta cotizacionDirecta, EnumTipoLogCotizacionDirecta tipo) {
            var logCot = new LogCotizacionesDirecta {
                CotizacionDirecta = cotizacionDirecta,
                Usuario = Base.Usuario.UsuarioConectado.Usuario,
                Fecha = DateTime.Now,
                Tipo = tipo
            };
            return logCot;
        }

    
        public static ResultadoTransaccion GuardarFollowUps(CotizacionDirecta cotizacionDirecta){
            var followDataBqse = clsClienteMasterADO.ObtenerFollowUpClientePorIDCotizacion(cotizacionDirecta.Id32);
           // return ClsCotizacionDirectaDao.GuardarFollowups(followDataBqse, cotizacionDirecta);

            return ClsCotizacionDirectaDao.GuardarFollowUps(followDataBqse,cotizacionDirecta);
        }
    }

}
