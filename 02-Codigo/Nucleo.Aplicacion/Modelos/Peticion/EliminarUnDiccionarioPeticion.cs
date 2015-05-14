using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class EliminarUnDiccionarioPeticion
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
	    private EliminarUnDiccionarioPeticion()
	    {
	        
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    public static EliminarUnDiccionarioPeticion CrearNuevaInstancia()
	    {
	        return new EliminarUnDiccionarioPeticion();
	    }

        #endregion

    }
}
