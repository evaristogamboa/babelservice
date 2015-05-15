using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ModificarUnDiccionarioRespuesta
    {
        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        public Diccionario Diccionario { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

        #endregion
       
        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
        private ModificarUnDiccionarioRespuesta()
	    {
			Relaciones = new Dictionary<string, Guid> { { "diccionario", Guid.Empty } };
			Respuesta = new ModeloRespuesta();
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
