using System;
using System.Collections.Generic;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class ModificarEtiquetasAUnDiccionarioRespuesta
	{

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el identificador del Diccionario al cual se le moficarán las Etiquetas
        /// </summary>
        public Guid DiccionarioId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Etiqueta> ListaDeEtiquetaDeDiccionario { get; set; }

        #endregion

        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
        private ModificarEtiquetasAUnDiccionarioRespuesta()
	    {
	        
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
