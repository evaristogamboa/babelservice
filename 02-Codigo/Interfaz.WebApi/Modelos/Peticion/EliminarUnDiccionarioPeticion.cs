﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using System.Net.Http;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class EliminarUnDiccionarioPeticion
	{

        public comunes.Diccionarios Diccionario { get; set; }
        public app.EliminarUnDiccionarioPeticion AppDiccionarioPeticion { get; set; }

        private EliminarUnDiccionarioPeticion(HttpRequestMessage peticionHttp)
        {
            //Diccionario = JsonConvert.des
            this.AppDiccionarioPeticion = app.EliminarUnDiccionarioPeticion.CrearNuevaInstancia();
            //this.AppDiccionarioPeticion.DiccionarioId = 
        }

        public static EliminarUnDiccionarioPeticion CrearUnaNuevaPeticionDeEliminar(HttpRequestMessage peticionHttp)
        {
            return new EliminarUnDiccionarioPeticion(peticionHttp);
        }
    }
}
