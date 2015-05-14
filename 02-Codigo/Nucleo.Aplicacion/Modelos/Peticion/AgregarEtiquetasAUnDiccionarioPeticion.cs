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
		private Etiqueta listaDeEtiquetas;

		private Guid diccionarioId;


		#region constructores

		private AgregarEtiquetasAUnDiccionarioPeticion(Etiqueta listaDeEtiquetas, Guid diccionarioId)
		{
			this.listaDeEtiquetas = listaDeEtiquetas;
			this.diccionarioId = diccionarioId;
			
		}

		#endregion

	}
}
