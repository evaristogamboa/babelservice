using System;
using System.Linq;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion
	{
		public Guid DiccionarioId { get; set; }

		public string Idioma { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion()
		{ 
		
		}

		public static ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion();
		}

		#endregion
	}
}
