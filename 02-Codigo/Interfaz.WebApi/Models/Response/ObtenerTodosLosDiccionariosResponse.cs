using Babel.Nucleo.Dominio.Entidades.Diccionario;
using System.Collections.Generic;



namespace  Babel.Interfaz.WebApi.Models.Response
{
	public class ObtenerTodosLosDiccionariosResponse
	{
		public List<Diccionario> Diccionarios{ get; set; }

		public ObtenerTodosLosDiccionariosResponse ()
		{
			this.Diccionarios = new List<Diccionario> ();
		}


	}

}