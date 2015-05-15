using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion
	{
		[Required]
		public Diccionario DiccionarioNuevo { get; set; }

		#region Constructores

		private CrearUnDiccionarioPeticion()
		{
			DiccionarioNuevo = Diccionario.CrearNuevoDiccionario();
		}

		public static CrearUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new CrearUnDiccionarioPeticion();
		}

		#endregion
	}
}