using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorEstatusPeticion
	{
		[Required]
		public Guid DiccionarioId { get; set; }

		[Required]
		public bool Estatus { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorEstatusPeticion()
		{
			DiccionarioId = Guid.Empty;
			Estatus = false;
		}

		public static ConsultarEtiquetasDeDiccionarioPorEstatusPeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorEstatusPeticion();
		}

		#endregion
	}
}
