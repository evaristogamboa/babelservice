using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion
	{
		[Required]
		public Guid DiccionarioId { get; set; }

		[Required]
		public string Descripcion { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion()
		{
			DiccionarioId = Guid.Empty;
			Descripcion = string.Empty;
		}

		public static ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion();
		}

		#endregion
	}
}