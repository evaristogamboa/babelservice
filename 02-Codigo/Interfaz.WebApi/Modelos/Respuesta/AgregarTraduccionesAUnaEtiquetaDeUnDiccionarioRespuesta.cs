using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Aplicacion.Modelos;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta
	{
		public List<Traduccion> ListaDeTraducciones { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta()
		{
			this.Relaciones.Add("Diccionario", Guid.Empty);
			this.Relaciones.Add("Etiqueta", Guid.Empty);
		}

		public static AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta CrearNuevaInstancia()
		{
			return new AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta();
		}

		#endregion
	}
}