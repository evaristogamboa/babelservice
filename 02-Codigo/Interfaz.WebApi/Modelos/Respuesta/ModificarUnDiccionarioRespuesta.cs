using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class ModificarUnDiccionarioRespuesta
    {

        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        public Guid DiccionarioId { get; set; }

        #endregion
       
        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
        private ModificarUnDiccionarioRespuesta()
	    {
	        
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarUnDiccionarioRespuesta CrearNuevaInstancia()
	    {
            return new ModificarUnDiccionarioRespuesta();
	    }

        #endregion

	}
}
