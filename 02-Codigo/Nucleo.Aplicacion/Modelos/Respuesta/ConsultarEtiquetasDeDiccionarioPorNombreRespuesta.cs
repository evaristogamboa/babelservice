using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ConsultarEtiquetasDeDiccionarioPorNombreRespuesta
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorNombreRespuesta()
		{
			Relaciones = new Dictionary<string, Guid> { { "diccionario", Guid.Empty }};
			ListaDeEtiquetas = new List<Etiqueta>();
			Respuesta = new ModeloRespuesta();
		}

		public static ConsultarEtiquetasDeDiccionarioPorNombreRespuesta CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorNombreRespuesta();
		}

		#endregion
	}
}