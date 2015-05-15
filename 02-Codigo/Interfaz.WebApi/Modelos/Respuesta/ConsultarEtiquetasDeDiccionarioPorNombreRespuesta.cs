using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Aplicacion.Modelos;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class ConsultarEtiquetasDeDiccionarioPorNombreRespuesta
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorNombreRespuesta()
		{
			this.Relaciones.Add("Diccionario", Guid.Empty);
		}

		public static ConsultarEtiquetasDeDiccionarioPorNombreRespuesta CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorNombreRespuesta();
		}

		#endregion
	}
}
