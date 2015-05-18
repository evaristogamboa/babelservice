using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class ModificarUnDiccionarioPeticion
	{
        [Required]
	    public Diccionario Diccionario { get; set; }

        #region Constructores

	    /// <summary>
	    /// 
	    /// </summary>
        private ModificarUnDiccionarioPeticion(string ambiente)
	    {
            Diccionario = Diccionario.CrearNuevoDiccionario(ambiente);
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarUnDiccionarioPeticion CrearNuevaInstancia(string ambiente)
	    {
            return new ModificarUnDiccionarioPeticion(ambiente);
	    }

        #endregion
    }
}