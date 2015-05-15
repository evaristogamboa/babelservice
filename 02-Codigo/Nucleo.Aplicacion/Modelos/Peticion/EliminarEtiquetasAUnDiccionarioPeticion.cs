using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class EliminarEtiquetasAUnDiccionarioPeticion
	{
		[Required]
		public List<Etiqueta> ListaDeEtiquetas { get; set; }

		[Required]
		public Guid DiccionarioId { get; set; }

		#region constructores

		private EliminarEtiquetasAUnDiccionarioPeticion()
		{
			ListaDeEtiquetas = new List<Etiqueta>();
			DiccionarioId = Guid.Empty;
		}

		public static EliminarEtiquetasAUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new EliminarEtiquetasAUnDiccionarioPeticion();
		}

		#endregion
	}
}