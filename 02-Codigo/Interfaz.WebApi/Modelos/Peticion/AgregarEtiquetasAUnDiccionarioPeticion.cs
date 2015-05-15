using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Dominio = Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
    public class AgregarEtiquetasAUnDiccionarioPeticion
    {
        
        public app.AgregarEtiquetasAUnDiccionarioPeticion AgregarEtiquetasAUnDiccionario { get; set; }

        public AgregarEtiquetasAUnDiccionarioPeticion(string idDiccionario,List<Dominio.Etiqueta> nuevasEtiquetas)
        {
    
            this.AgregarEtiquetasAUnDiccionario = app.AgregarEtiquetasAUnDiccionarioPeticion.CrearNuevaInstancia();

            this.AgregarEtiquetasAUnDiccionario.DiccionarioId = idDiccionario;

            return;
        }

    }
}