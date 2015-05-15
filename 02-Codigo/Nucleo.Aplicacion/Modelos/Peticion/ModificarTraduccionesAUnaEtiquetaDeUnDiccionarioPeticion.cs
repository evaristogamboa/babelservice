using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion
    {
        #region Propiedades

        /// <summary>
        /// Obtiene o establece el identificador del Diccionario de la Etiqueta a la cual se le modificarán las traducciones
        /// </summary>
		[Required]
        public Guid DiccionarioId { get; set; }

        /// <summary>
        /// /// Obtiene o establece el identificador de la Etiqueta a la cual se le modificarán las traducciones
        /// </summary>
		[Required]
		public Guid EtiquetaId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		[Required]
		public List<Traduccion> ListaDeTraducciones { get; set; }


        #endregion

        #region Constructores

        /// <summary>
        /// 
        /// </summary>
        private ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion()
        {
			DiccionarioId = Guid.Empty;
			EtiquetaId = Guid.Empty;
			ListaDeTraducciones = new List<Traduccion>();
		}

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