using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ConsultarDiccionariosRespuesta
	{
		public List<Diccionario> ListaDeDiccionarios { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarDiccionariosRespuesta()
		{
		}

		public static ConsultarDiccionariosRespuesta CrearNuevaInstancia()
		{
			return new ConsultarDiccionariosRespuesta();
		}

		#endregion
	}
}
