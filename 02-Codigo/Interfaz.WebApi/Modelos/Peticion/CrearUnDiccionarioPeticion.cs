using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion 
	{
        public app.CrearUnDiccionarioPeticion DiccionarioPeticion { get; set; }

        private void CrearUnDiccionarioPeticion()
        {
            this.DiccionarioPeticion = app.Diccionario.CrearNuevoDiccionario();
        }


	}
}
