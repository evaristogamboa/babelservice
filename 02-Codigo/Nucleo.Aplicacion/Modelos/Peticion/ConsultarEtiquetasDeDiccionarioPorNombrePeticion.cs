using System;
using System.Linq;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorNombrePeticion
	{
		public Guid DiccionarioId { get; set; }

		public string Nombre { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorNombrePeticion()
		{ 
		
		}

		public static ConsultarEtiquetasDeDiccionarioPorNombrePeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorNombrePeticion();
		}

		#endregion
	}
}