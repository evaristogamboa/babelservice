using System;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Models.Response
{
	public class ObtenerUnDiccionarioEspecificoResponse
	{
		public Diccionario Diccionario{ get; set; }

		public ObtenerUnDiccionarioEspecificoResponse ()
		{
			this.Diccionario = Diccionario.CrearNuevoDiccionario ();
		}
	}
}

