using System;
using System.Linq;
using System.Collections.Generic;
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
			ListaDeDiccionarios = new List<Diccionario>();
			Respuesta = new ModeloRespuesta();
		}

		public static ConsultarDiccionariosRespuesta CrearNuevaInstancia()
		{
			return new ConsultarDiccionariosRespuesta();
		}

		#endregion
	}
}