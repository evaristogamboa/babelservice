using System;
using System.Net;
using System.Text;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using Babel.Interfaz.WebApi.Controladores;
using Should;
namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    class EtiquetasControllerTests
    {
        private const int Id = 1;
        private Etiquetas controlador;

        [SetUp]
        public void Iniciador()
        {
            controlador = new Etiquetas();
        }

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
        public void ProbarPostCrearEtiquetasInexistenteAUnDiccionario()
        {
            //Arrange
            controlador.Request = new HttpRequestMessage(HttpMethod.Post,"http://Diccionario/1/Etiqueta/");
            controlador.Configuration = new HttpConfiguration();
            controlador.Request.Content = new StringContent("{\n  \"etiquetas\": {\n    \"etiqueta\": [\n      {\n        \"-id\": \"8a87f8a7-3df9-4d90-9478-350b964fc888\",\n        \"-nombre\": \"app.common.aceptar\",\n        \"-activo\": \"true\",\n        \"-default\": \"es-VE\",\n        \"nombre\": \"app.common.aceptar\",\n        \"descripcion\": \"Aceptar\",\n        \"traducciones\": {\n          \"traduccion\": [\n            {\n              \"-cultura\": \"es\",\n              \"#text\": \"aceptar\"\n            },\n            {\n              \"-cultura\": \"es-VE\",\n              \"#text\": \"aceptar\"\n            },\n            {\n              \"-cultura\": \"en\",\n              \"#text\": \"accept\"\n            },\n            {\n              \"-cultura\": \"en-US\",\n              \"#text\": \"accept\"\n            }\n          ]\n        }\n      },\n      {\n        \"-id\": \"9a39ad6d-62c8-42bf-a8f7-66417b2b08d0\",\n        \"-nombre\": \"app.common.cancelar\",\n        \"-activo\": \"true\",\n        \"-default\": \"es-VE\",\n        \"nombre\": \"app.common.cancelar\",\n        \"descripcion\": \"Aceptar\",\n        \"traducciones\": {\n          \"traduccion\": [\n            {\n              \"-cultura\": \"es\",\n              \"#text\": \"cancelar\"\n            },\n            {\n              \"-cultura\": \"es-VE\",\n              \"#text\": \"cancelar\"\n            },\n            {\n              \"-cultura\": \"en\",\n              \"#text\": \"cancel\"\n            },\n            {\n              \"-cultura\": \"en-US\",\n              \"#text\": \"cancel\"\n            }\n          ]\n        }\n      }\n    ]\n  }\n}", Encoding.UTF8,
                                    "application/json");

            //Act
            var respuesta = controlador.AgregarEtiquetasAUnDiccionario("1",controlador.Request);
            
            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            respuesta.Content.ReadAsStringAsync().Result.ShouldEqual("{\n    \"etiquetas\": {\n        \"etiqueta\": [\n            {\n                \"-id\": \"8a87f8a7-3df9-4d90-9478-350b964fc888\",\n                \"-nombre\": \"app.common.aceptar\",\n                \"-activo\": \"true\",\n                \"-default\": \"es-VE\",\n                \"nombre\": \"app.common.aceptar\",\n                \"descripcion\": \"Aceptar\",\n                \"traducciones\": {\n                    \"traduccion\": [\n                        {\n                            \"-cultura\": \"es\",\n                            \"#text\": \"aceptar\"\n                        },\n                        {\n                            \"-cultura\": \"es-VE\",\n                            \"#text\": \"aceptar\"\n                        },\n                        {\n                            \"-cultura\": \"en\",\n                            \"#text\": \"accept\"\n                        },\n                        {\n                            \"-cultura\": \"en-US\",\n                            \"#text\": \"accept\"\n                        }\n                    ]\n                }\n            },\n            {\n                \"-id\": \"9a39ad6d-62c8-42bf-a8f7-66417b2b08d0\",\n                \"-nombre\": \"app.common.cancelar\",\n                \"-activo\": \"true\",\n                \"-default\": \"es-VE\",\n                \"nombre\": \"app.common.cancelar\",\n                \"descripcion\": \"Aceptar\",\n                \"traducciones\": {\n                    \"traduccion\": [\n                        {\n                            \"-cultura\": \"es\",\n                            \"#text\": \"cancelar\"\n                        },\n                        {\n                            \"-cultura\": \"es-VE\",\n                            \"#text\": \"cancelar\"\n                        },\n                        {\n                            \"-cultura\": \"en\",\n                            \"#text\": \"cancel\"\n                        },\n                        {\n                            \"-cultura\": \"en-US\",\n                            \"#text\": \"cancel\"\n                        }\n                    ]\n                }\n            }\n        ]\n    },\n    \"relaciones\": []\n}");
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
