using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Aplicacion.Modelos;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
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
