using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
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
	    private ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta()
	    {
	        Relaciones = new Dictionary<string, Guid> {{"diccionario", Guid.Empty}, {"etiqueta", Guid.Empty}};
            ListaDeTraduccionesDeEtiquetaDeDiccionario = new List<Traduccion>();
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
