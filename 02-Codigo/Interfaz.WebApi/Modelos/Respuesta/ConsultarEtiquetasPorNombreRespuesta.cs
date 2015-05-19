using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Aplicacion.Modelos;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
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
		
		}

		public static ConsultarEtiquetasPorNombreRespuesta CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasPorNombreRespuesta();
		}

		#endregion
	}
}
