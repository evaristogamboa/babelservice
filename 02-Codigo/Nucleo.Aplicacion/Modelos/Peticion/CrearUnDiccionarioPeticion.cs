using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion
	{
		[Required]
		public string Ambiente { get; set; }

		#region Constructores

		private CrearUnDiccionarioPeticion(string ambiente)
		{
            Ambiente = ambiente;
		}

        public static CrearUnDiccionarioPeticion CrearNuevaInstancia(string ambiente)
		{
            return new CrearUnDiccionarioPeticion(ambiente);
		}

		#endregion
	}
}