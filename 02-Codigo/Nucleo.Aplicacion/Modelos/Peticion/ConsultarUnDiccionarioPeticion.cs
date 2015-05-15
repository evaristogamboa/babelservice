using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarUnDiccionarioPeticion
	{
		[Required]
		public Guid DiccionarioId { get; set; }

		#region constructores

		private ConsultarUnDiccionarioPeticion()
		{
			DiccionarioId = Guid.Empty;
		}

		public static ConsultarUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new ConsultarUnDiccionarioPeticion();
		}

		#endregion
	}
}