using System;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Nubise.Hc.Utils.I18n.Babel.Interfaz.WebApi.Models.Response
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

