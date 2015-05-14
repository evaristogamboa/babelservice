using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class AgregarEtiquetasAUnDiccionarioRespuesta
	{
		public List<Etiqueta> ListaDeEtiquetas { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private AgregarEtiquetasAUnDiccionarioRespuesta()
		{
			this.Relaciones.Add("Diccionario", Guid.Empty);
		}

		public static AgregarEtiquetasAUnDiccionarioRespuesta CrearNuevaInstancia()
		{
			return new AgregarEtiquetasAUnDiccionarioRespuesta();
		}

		#endregion
	}
}