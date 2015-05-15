using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorNombrePeticion
	{
		[Required]
		public Guid DiccionarioId { get; set; }

		[Required]
		public string Nombre { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorNombrePeticion()
		{
			DiccionarioId = Guid.Empty;
			Nombre = string.Empty;
		}

		public static ConsultarEtiquetasDeDiccionarioPorNombrePeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorNombrePeticion();
		}

		#endregion
	}
}