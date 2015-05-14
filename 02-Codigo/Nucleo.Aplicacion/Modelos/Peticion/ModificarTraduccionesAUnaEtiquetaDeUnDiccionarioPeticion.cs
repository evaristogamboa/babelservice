using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion
    {

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el identificador del Diccionario de la Etiqueta a la cual se le modificarán las traducciones
        /// </summary>
        public Guid DiccionarioId { get; set; }

        /// <summary>
        /// /// Obtiene o establece el identificador de la Etiqueta a la cual se le modificarán las traducciones
        /// </summary>
        public Guid EtiquetaId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    public List<Traduccion> ListaDeTraduccionesDeEtiquetaDeDiccionario { get; set; }


        #endregion

        #region Constructores

        /// <summary>
        /// 
        /// </summary>
        private ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion CrearNuevaInstancia()
	    {
	        return new ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion();
	    }

        #endregion
    }
}
