using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion
	{
		[Required]
		public Guid DiccionarioId { get; set; }

		[Required]
		public string Idioma { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion()
		{
			DiccionarioId = Guid.Empty;
			Idioma = string.Empty;
		}

		public static ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion();
		}

		#endregion
	}
}
