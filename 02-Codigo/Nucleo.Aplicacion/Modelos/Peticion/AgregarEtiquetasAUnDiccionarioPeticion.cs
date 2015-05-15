using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

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
			ListaDeEtiquetas = new List<Etiqueta>();
			DiccionarioId = Guid.Empty;
		}

		public static AgregarEtiquetasAUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new AgregarEtiquetasAUnDiccionarioPeticion();
		}

		#endregion
	}
}