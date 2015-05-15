using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta
	{
        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    public List<Traduccion> ListaDeTraducciones { get; set; }


        #endregion

        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
	    private ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta()
	    {
	        Relaciones = new Dictionary<string, Guid> {{"diccionario", Guid.Empty}, {"etiqueta", Guid.Empty}};
			ListaDeTraducciones = new List<Traduccion>();
			Respuesta = new ModeloRespuesta();
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta CrearNuevaInstancia()
	    {
            return new ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta();
	    }

        #endregion
	}
}