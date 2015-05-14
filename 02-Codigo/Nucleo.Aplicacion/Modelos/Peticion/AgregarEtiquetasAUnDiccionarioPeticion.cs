using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class AgregarEtiquetasAUnDiccionarioPeticion
	{
		[Required]
		public List<Etiqueta> ListaDeEtiquetas { get; set; }

		[Required]
		public Guid DiccionarioId { get; set; }

		#region constructores

		private AgregarEtiquetasAUnDiccionarioPeticion()
		{ 
		
		}

		public static AgregarEtiquetasAUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new AgregarEtiquetasAUnDiccionarioPeticion();
		}

		#endregion

		Boolean IsValid()
		{

			if (!(this.ListaDeEtiquetas.GetType().Equals(typeof(List<Etiqueta>))))
			{
				return false;
			}

			if (this.ListaDeEtiquetas.Count() == 0)
			{
				return false;
			}

			if (!(this.DiccionarioId.GetType().Equals(typeof(Guid))))
			{
				return false;
			}

			return true;
		}
	}
}