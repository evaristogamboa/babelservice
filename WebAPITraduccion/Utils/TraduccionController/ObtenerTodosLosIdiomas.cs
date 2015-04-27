using System;
using System.Data;
using System.Linq;
using WebAPEtiqueta.Models;

namespace WebApEtiqueta.Utils.EtiquetaController
{
	public class ObtenerTodosLosIdiomas
	{
		private EtiquetaFactory EtiquetaFactory;
		private ObtenerTodosLosIdiomasResponse listaEtiquetaes;

		public ObtenerTodosLosIdiomas(EtiquetaFactory EtiquetaFactory, ObtenerTodosLosIdiomasResponse listaEtiquetaes)
		{
			this.EtiquetaFactory = EtiquetaFactory;
			this.listaEtiquetaes = listaEtiquetaes;
		}
		public ObtenerTodosLosIdiomasResponse GenerarRespuesta(DataTable dtEtiquetaes)
		{
			throw new NotImplementedException();
		}
	}
}