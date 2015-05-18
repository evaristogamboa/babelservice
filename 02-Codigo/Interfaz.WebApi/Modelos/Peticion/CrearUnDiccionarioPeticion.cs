using Babel.Nucleo.Dominio.Entidades.Diccionario;
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

        private CrearUnDiccionarioPeticion(Diccionario diccionario)
        {
            this.DiccionarioPeticion = app.CrearUnDiccionarioPeticion.CrearNuevaInstancia(diccionario.Ambiente);
            this.DiccionarioPeticion.DiccionarioNuevo = diccionario;
        }

        public static CrearUnDiccionarioPeticion CrearUnaNuevaPeticion(Diccionario diccionario)
        {
            return new CrearUnDiccionarioPeticion(diccionario);
        }

        
	}
}
