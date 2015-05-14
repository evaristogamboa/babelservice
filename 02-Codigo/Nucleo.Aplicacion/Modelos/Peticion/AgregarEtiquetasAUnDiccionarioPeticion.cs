using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class AgregarEtiquetasAUnDiccionarioPeticion
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }
		
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

	}
}
