using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using Babel.Nucleo.Aplicacion.Modelos;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class AgregarEtiquetasAUnDiccionarioRespuesta
	{
			
		public List<Etiqueta> ListaDeEtiquetas { get; set; }
		
		public Guid DiccionarioId { get; set; }

		public ModeloRespuesta Respuesta { get; set; }


		#region constructores

		private AgregarEtiquetasAUnDiccionarioRespuesta()
		{ 
		}

		public static AgregarEtiquetasAUnDiccionarioRespuesta CrearNuevaInstancia()
		{
			return new AgregarEtiquetasAUnDiccionarioRespuesta();
		}

		#endregion
	}
}
