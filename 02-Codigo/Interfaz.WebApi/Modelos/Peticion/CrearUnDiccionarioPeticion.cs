using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio = Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion 
	{
        public Dominio.Diccionario Diccionario {get;set;}

        private void CrearUnDiccionarioPeticion()
        {
            this.Diccionario = Dominio.Diccionario.CrearNuevoDiccionario();
        }

        public CrearUnDiccionario()
        {
            CrearUnDiccionarioPeticion
        }

	}
}
