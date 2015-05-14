using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ModificarEtiquetasAUnDiccionarioPeticion
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
        private ModificarEtiquetasAUnDiccionarioPeticion()
	    {
	        
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    public static ModificarEtiquetasAUnDiccionarioPeticion CrearNuevaInstancia()
	    {
	        return new ModificarEtiquetasAUnDiccionarioPeticion();
	    }

        #endregion

    }
}
