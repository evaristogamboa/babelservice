using System;
using System.Data;
using System.Linq;
using WebAPITraduccion.Models;

namespace WebApiTraduccion.Utils.TraduccionController
{
	public class ObtenerTodosLosIdiomas
	{
		private TraduccionFactory traduccionFactory;
		private ObtenerTodosLosIdiomasResponse listaTraducciones;

		public ObtenerTodosLosIdiomas(TraduccionFactory traduccionFactory, ObtenerTodosLosIdiomasResponse listaTraducciones)
		{
			this.traduccionFactory = traduccionFactory;
			this.listaTraducciones = listaTraducciones;
		}
		public ObtenerTodosLosIdiomasResponse GenerarRespuesta(DataTable dtTraducciones)
		{
			throw new NotImplementedException();
		}
	}
}