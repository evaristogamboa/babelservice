using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class EliminarUnDiccionarioPeticion
    {
        #region Propiedades

        /// <summary>
        /// Obtiene o establece el identificador del Diccionario a eliminar
        /// </summary>
        [Required]
		public Guid DiccionarioId { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// 
        /// </summary>
	    private EliminarUnDiccionarioPeticion()
	    {
			DiccionarioId = Guid.Empty;
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