using Babel.Nucleo.Dominio.Entidades.Diccionario;
using System.Collections.Generic;



namespace  Babel.Interfaz.WebApi.Models.Response
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