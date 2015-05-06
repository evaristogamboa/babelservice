using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario;
using System.Collections.Generic;
using System.Net.Http;


namespace  Nubise.Hc.Utils.I18n.Babel.Interfaz.WebApi.Models.Response
{
	public class ObtenerTodosLosDiccionariosResponse
	{
		public List<Diccionario> diccionarios{ get; set; }

		public ObtenerTodosLosDiccionariosResponse ()
		{
			this.diccionarios = new List<Diccionario> ();
		}


	}

}