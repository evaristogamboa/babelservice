using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class EliminarUnDiccionarioRespuesta
	{
        #region Propiedades

        /// <summary>
        /// Obtiene o establece el identificador del Diccionario a eliminar
        /// </summary>
        public List<Diccionario> ListaDeDiccionarios { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// 
        /// </summary>
	    private EliminarUnDiccionarioRespuesta()
	    {
            ListaDeDiccionarios = new List<Diccionario>();
			Respuesta = new ModeloRespuesta();
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