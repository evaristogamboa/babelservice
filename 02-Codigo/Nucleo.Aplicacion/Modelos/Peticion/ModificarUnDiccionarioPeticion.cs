using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ModificarUnDiccionarioPeticion
	{
        /// <summary>
        /// 
        /// </summary>
	    public Guid DiccionarioId { get; set; }

        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
        private ModificarUnDiccionarioPeticion()
	    {
	        
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarUnDiccionarioPeticion CrearNuevaInstancia()
	    {
            return new ModificarUnDiccionarioPeticion();
	    }

        #endregion
    }
}
