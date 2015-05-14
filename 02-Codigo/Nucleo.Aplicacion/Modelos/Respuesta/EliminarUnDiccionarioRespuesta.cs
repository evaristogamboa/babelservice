using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class EliminarUnDiccionarioRespuesta
	{

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el identificador del Diccionario a eliminar
        /// </summary>
        private Diccionario DiccionarioId { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// 
        /// </summary>
	    private EliminarUnDiccionarioRespuesta()
	    {
	        
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static EliminarUnDiccionarioRespuesta CrearNuevaInstancia()
	    {
            return new EliminarUnDiccionarioRespuesta();
	    }

        #endregion
	}
}
