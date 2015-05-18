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

		private CrearUnDiccionarioPeticion(string ambiente)
		{
            DiccionarioNuevo = Diccionario.CrearNuevoDiccionario(ambiente);
		}

        public static CrearUnDiccionarioPeticion CrearNuevaInstancia(string ambiente)
		{
            return new CrearUnDiccionarioPeticion(ambiente);
		}

		#endregion
	}
}