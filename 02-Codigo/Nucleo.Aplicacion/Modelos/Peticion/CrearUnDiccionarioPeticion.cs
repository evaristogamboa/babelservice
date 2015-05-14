using System;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion
	{
		public Diccionario DiccionarioNuevo { get; set; }

		#region Constructores

		private CrearUnDiccionarioPeticion()
		{ 
		
		}

		public static CrearUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new CrearUnDiccionarioPeticion();
		}

		#endregion
	}
}