using System;
using Should;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using Babel.Interfaz.WebApi.Controladores;
using Newtonsoft.Json;
using Babel.Interfaz.WebApi.Modelos;

namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    class EtiquetasControllerTests
    {
        
        public EtiquetasControllerTests() { 
            
        }

        #region Pruebas de status
        //[Test]
        public void ProbarGetEtiquetasOk ()
        {

        }

        //[Test]
        public void ProbarGetEtiquetasNotFound()
        {

        }

        //[Test]
        public void ProbarGetEtiquetaNotFoundCuandoEtiquetaNoExiste()
        {

        }

        //[Test]
        public void ProbarGetEtiquetaOkCuandoEtiquetaExiste()
        {

        }
        #endregion

        #region Pruebas de contenido Get
        //[Test]
        public void ProbarContenidoDeLasEtiquetasEsElEsperado()
        {
            
        }
        #endregion

        #region Pruebas de creacion
        //[Test]
        public void ProbarPostCrearEtiquetaInexistente()
        {

        }

        public void ProbarPostCrearEtiquetaYaExistente()
        {

        }
        #endregion

        #region Pruebas de modificación
        //[Test]
        public void ProbarPutModificarEtiquetaInexistente()
        {
            
        }

        //[Test]
        public void ProbarPutModificarEtiquetaYaExistente()
        {

        }
        #endregion

        #region Pruebas de Eliminacion
        //[Test]
        public void ProbarDeleteEliminarEtiquetaInexistente()
        {

        }

        //[Test]
        public void ProbarDeleteEliminarEtiquetaYaExistente()
        {

        }
        #endregion
    }
}
