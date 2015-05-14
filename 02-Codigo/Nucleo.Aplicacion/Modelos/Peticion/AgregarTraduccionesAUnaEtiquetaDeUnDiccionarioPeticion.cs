using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }
		
		public Guid DiccionarioId { get; set; }


		#region constructores

		private AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion()
		{ 
		
		}

		public static AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion();
		}

		#endregion
	}
}
