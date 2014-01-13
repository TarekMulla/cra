using System;
using ProyectoCraft.AccesoDatos.Ventas.Actividades.Llamadas_Telefonicas;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Ventas.Actividades.Llamadas_Telefonicas;

namespace ProyectoCraft.LogicaNegocios.Ventas.Actividades.Llamadas_Telefonicas
{
    public static class ClsLlamataTelefonica
    {
        public static ResultadoTransaccion GuardaLlamadaTelefonica(ClsLlamadaTelefonica ObjLlamada) 
        {
            return clsLlamadaTelefonicaAdo.GuardaLlamada(ObjLlamada);
        }
        public static ResultadoTransaccion EliminarLlamadaTelefonica(long IdLlamada)
        {
            return clsLlamadaTelefonicaAdo.EliminarLlamada(IdLlamada);
        }
        public static ResultadoTransaccion ModificarLlamadaTelefonica(ClsLlamadaTelefonica ObjLlamada)
        {
            return clsLlamadaTelefonicaAdo.ModificarLlamada(ObjLlamada);
        }
        public static ResultadoTransaccion ListarLlamadasTelefonicas(DateTime FechaInicio, DateTime FechaTermino, long IdContacto, long IdClienteMaster, long IdUsuario, int TipoSelect)
        {
            return clsLlamadaTelefonicaAdo.ListarLlamadas(FechaInicio, FechaTermino, IdContacto, IdClienteMaster,IdUsuario,TipoSelect);
        }
        public static ResultadoTransaccion ListarLlamadasTelefonicasRecientes(long IdCliente)
        {
            return clsLlamadaTelefonicaAdo.ListarLlamadasRecientes(IdCliente);
        }
    }
}
