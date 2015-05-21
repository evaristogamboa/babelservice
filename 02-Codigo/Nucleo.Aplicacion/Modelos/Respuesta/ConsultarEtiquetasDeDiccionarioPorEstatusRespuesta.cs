using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta()
		{
			Relaciones = new Dictionary<string, Guid> { { "diccionario", Guid.Empty } };
			ListaDeEtiquetas = new List<Etiqueta>();
			Respuesta = new ModeloRespuesta();
		}

		public static ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta();
		}

		#endregion
	}
}