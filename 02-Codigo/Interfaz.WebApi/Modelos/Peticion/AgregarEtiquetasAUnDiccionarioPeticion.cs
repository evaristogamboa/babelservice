using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
    public class AgregarEtiquetasAUnDiccionarioPeticion
    {
        

        public app.AgregarEtiquetasAUnDiccionarioPeticion AgregarEtiquetasAUnDiccionario { get; set; }

        public AgregarEtiquetasAUnDiccionarioPeticion(int idDiccionario)
        {
            
            
            this.AgregarEtiquetasAUnDiccionario = app.AgregarEtiquetasAUnDiccionarioPeticion.CrearNuevaInstancia();

            return;
        }

    }
}