using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta()
		{
			this.Relaciones.Add("Diccionario", Guid.Empty);
		}

		public static ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta();
		}

		#endregion
	}
}
