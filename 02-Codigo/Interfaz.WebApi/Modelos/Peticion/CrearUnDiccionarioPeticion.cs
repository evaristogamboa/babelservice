using System.Collections.Generic;
using System.Net.Http;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Newtonsoft.Json;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using dominio = Babel.Nucleo.Dominio.Entidades;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion 
	{

        public comunes.Diccionario Diccionario { get; set; }
        public app.CrearUnDiccionarioPeticion AppDiccionarioPeticion { get; set; }
        public string Respuesta { get; set; }

        public CrearUnDiccionarioPeticion(string ambiente)
        {
            AppDiccionarioPeticion = app.CrearUnDiccionarioPeticion.CrearNuevaInstancia(ambiente);
        }

        public static CrearUnDiccionarioPeticion CrearUnaNuevaPeticion(string ambiente)
        {
            return new CrearUnDiccionarioPeticion(ambiente);
        }
        
	}
}
