using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ModificarEtiquetasAUnDiccionarioRespuesta
	{
        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Etiqueta> ListaDeEtiquetas { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

        #endregion

        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
        private ModificarEtiquetasAUnDiccionarioRespuesta()
	    {
			Relaciones = new Dictionary<string, Guid> { { "diccionario", Guid.Empty }, { "etiqueta", Guid.Empty } };
			ListaDeEtiquetas = new List<Etiqueta>();
			Respuesta = new ModeloRespuesta();
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarEtiquetasAUnDiccionarioRespuesta CrearNuevaInstancia()
	    {
	        return new ModificarEtiquetasAUnDiccionarioRespuesta();
	    }

        #endregion
	}
}