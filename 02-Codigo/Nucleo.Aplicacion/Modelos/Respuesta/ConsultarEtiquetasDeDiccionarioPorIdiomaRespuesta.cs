using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }
		
		public Guid DiccionarioId { get; set; }


		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta()
		{ 
		
		}

		public static ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta();
		}

		#endregion


	}
}
