using System;
using System.Linq;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ConsultarUnDiccionarioPeticion
	{
		public Guid DiccionarioId { get; set; }

		#region constructores

		private ConsultarUnDiccionarioPeticion()
		{ 
		
		}

		public static ConsultarUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new ConsultarUnDiccionarioPeticion();
		}

		#endregion
	}
}