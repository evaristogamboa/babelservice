using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion
	{
		[Required]
		public Guid DiccionarioId { get; set; }

		[Required]
		public string IdiomaPorDefecto { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion()
		{
			DiccionarioId = Guid.Empty;
			IdiomaPorDefecto = String.Empty;
		}

		public static ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion();
		}

		#endregion
	}
}