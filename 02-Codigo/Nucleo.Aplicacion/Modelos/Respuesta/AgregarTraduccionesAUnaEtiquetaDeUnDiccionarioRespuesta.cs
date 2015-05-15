using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta
	{
		public List<Traduccion> ListaDeTraducciones { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta()
		{
			Relaciones = new Dictionary<string, Guid> { { "diccionario", Guid.Empty }, { "etiqueta", Guid.Empty } };
			ListaDeTraducciones = new List<Traduccion>();
			Respuesta = new ModeloRespuesta();
		}

		public static AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta CrearNuevaInstancia()
		{
			return new AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta();
		}

		#endregion
	}
}