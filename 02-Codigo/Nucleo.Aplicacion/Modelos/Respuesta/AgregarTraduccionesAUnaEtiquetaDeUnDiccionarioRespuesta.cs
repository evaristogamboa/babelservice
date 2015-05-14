using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }
		
		public Guid DiccionarioId { get; set; }

		#region constructores

		private AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta()
		{ 
		
		}

		public static AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta CrearNuevaInstancia()
		{
			return new AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta();
		}

		#endregion
	}
}
