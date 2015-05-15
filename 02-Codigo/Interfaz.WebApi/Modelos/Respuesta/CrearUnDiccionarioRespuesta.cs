using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Aplicacion.Modelos;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class CrearUnDiccionarioRespuesta
	{
		public Diccionario DiccionarioNuevo { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private CrearUnDiccionarioRespuesta()
		{
			this.Relaciones.Add("Diccionario", Guid.Empty);
		}

		public static CrearUnDiccionarioRespuesta CrearNuevaInstancia()
		{
			return new CrearUnDiccionarioRespuesta();
		}

		#endregion
	}
}