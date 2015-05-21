using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app = Babel.Nucleo.Aplicacion.Modelos;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class ModificarUnDiccionarioRespuesta
    {

        #region Propiedades

        public comunes.Diccionario Diccionario { get; set; }

        public 

        #endregion
       
        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
        ModificarUnDiccionarioRespuesta(app.Respuesta.ModificarUnDiccionarioRespuesta respuestaApp)
	    {
	        Diccionario = new comunes.Diccionario();
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarUnDiccionarioRespuesta CrearNuevaRespuesta(app.Respuesta.ModificarUnDiccionarioRespuesta respuestaApp)
	    {
            return new ModificarUnDiccionarioRespuesta(respuestaApp);
	    }

        #endregion
    }
}
