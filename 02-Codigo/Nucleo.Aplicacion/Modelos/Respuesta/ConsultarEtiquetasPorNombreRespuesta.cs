using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	/// <summary>
	/// Luego de consultar el nombre de la etiqueta enviado en todos los diccionarios,
	/// se debe retornar la lista de diccionarios con todas las coincidencias del nombre de la etiqueta.
	/// </summary>
	public class ConsultarEtiquetasPorNombreRespuesta
	{
		public List<Diccionario> ListaDeDiccionarios { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarEtiquetasPorNombreRespuesta()
		{
			ListaDeDiccionarios = new List<Diccionario>();
			Respuesta = new ModeloRespuesta();
		}

		public static ConsultarEtiquetasPorNombreRespuesta CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasPorNombreRespuesta();
		}

		#endregion
	}
}