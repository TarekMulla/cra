using ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Indirecta
{
	/// <summary>
	/// Description of ClsCotizacionIndirectaItem.
	/// </summary>
	public class ClsCotizacionIndirectaItem
	{
		public ClsCotizacionIndirectaItem(){}
		
		public static ResultadoTransaccion ObtieneTodos(){
			return ClsCotizacionIndirectaItemDao.ObtieneTodos();
		}
		
	}
}
