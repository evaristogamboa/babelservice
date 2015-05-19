using System;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using appModelosRespuesta = Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using app = Babel.Nucleo.Aplicacion.Fachada;
using NUnit.Framework;
using Should;
using controladores = Babel.Interfaz.WebApi.Controladores;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using NSubstitute;
using webApiModelosRespuesta = Babel.Interfaz.WebApi.Modelos.Respuesta;
using webApiModelosPeticion = Babel.Interfaz.WebApi.Modelos.Peticion;
using Newtonsoft.Json;
using comunes=Babel.Interfaz.WebApi.Modelos.Comunes;
using System.Net.Http.Headers;

namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    public class DiccionarioControladorTest
    {
        #region Propiedades y Variables Globales
        const string diccionariosJson="{ \"diccionarios\": { \"diccionario\": { \"id\": \"a1fa3369bc3f4ebc9cac5677cbaa8114\", \"amb\": \"desarrollo\", \"etiquetas\": { \"etiqueta\": [ { \"id\": \"8a87f8a73df94d909478350b964fc888\", \"nombre\": \"app.common.aceptar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.aceptar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"aceptar\" }, { \"cultura\": \"es-VE\", \"#text\": \"aceptar\" }, { \"cultura\": \"en\", \"#text\": \"accept\" }, { \"cultura\": \"en-US\", \"#text\": \"accept\" } ] } }, { \"id\": \"9a39ad6d62c842bfa8f766417b2b08d0\", \"nombre\": \"app.common.cancelar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.cancelar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"cancelar\" }, { \"cultura\": \"es-VE\", \"#text\": \"cancelar\" }, { \"cultura\": \"en\", \"#text\": \"cancel\" }, { \"cultura\": \"en-US\", \"#text\": \"cancel\" } ] } }, { \"id\": \"165db3e4d705406bbce02738b25c9023\", \"nombre\": \"app.common.usuario\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.usuario\", \"descripcion\": \"Campo de texto usuario\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"usuario\" }, { \"cultura\": \"es-VE\", \"#text\": \"usuario\" }, { \"cultura\": \"en\", \"#text\": \"user\" }, { \"cultura\": \"en-US\", \"#text\": \"user\" } ] } }, { \"id\": \"aaa55616722d410ca5f06f1f10f0b4a2\", \"nombre\": \"app.common.contraseña\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.contraseña\", \"descripcion\": \"Campo de texto contraseña\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"contraseña\" }, { \"cultura\": \"es-VE\", \"#text\": \"contraseña\" }, { \"cultura\": \"en\", \"#text\": \"password\" }, { \"cultura\": \"en-US\", \"#text\": \"password\" } ] } } ] } } } }";

        private const string ambienteTestPrueba = "Prueba";

        private readonly app.IAplicacionMantenimientoDiccionario appMantenimientoDiccionario;
        
        private readonly CrearUnDiccionarioPeticion diccionarioPeticion;

        private readonly appModelosRespuesta.CrearUnDiccionarioRespuesta crearUnDiccionarioRespuesta;

        private readonly Controladores.Diccionarios controlador;
        #endregion

        #region Constructor
        public DiccionarioControladorTest() {

            //diccionarioPeticion  = webApiModelosPeticion.CrearUnDiccionarioPeticion.CrearUnaNuevaPeticion(ambienteTestPrueba);}
            diccionarioPeticion = CrearUnDiccionarioPeticion.CrearNuevaInstancia(ambienteTestPrueba);

            this.appMantenimientoDiccionario = Substitute.For<app.IAplicacionMantenimientoDiccionario>();
                    
            var consultarDiccionarioRespuesta = appModelosRespuesta.ConsultarDiccionariosRespuesta.CrearNuevaInstancia();
            
            crearUnDiccionarioRespuesta = appModelosRespuesta.CrearUnDiccionarioRespuesta.CrearNuevaInstancia(ambienteTestPrueba);

            this.appMantenimientoDiccionario.ConsultarDiccionarios().Returns<appModelosRespuesta.ConsultarDiccionariosRespuesta>(consultarDiccionarioRespuesta);

            this.appMantenimientoDiccionario.CrearUnDiccionario(Arg.Any<CrearUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.CrearUnDiccionarioRespuesta>(crearUnDiccionarioRespuesta);

            controlador = new controladores.Diccionarios(this.appMantenimientoDiccionario);
            controlador.Configuration = new HttpConfiguration();
            controlador.Request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
        }
        #endregion

        #region Pruebas de tipo de instancias
        [Test]
        public void PruebaCreacionControladorEsCorrecta()
        { 
            //Arrange
            //Act
            //Assert
            controlador.ShouldBeType<controladores.Diccionarios>();
        }
#endregion

        #region Pruebas de consultar(GET)
        [Test]
        public void PruebaConsultarTodosLosDiccionariosDebeTraerUnaRespuestaConDiccionariosConListaDeDiccionariosVacio()
        {
            //Arrange
            controlador.Request = new HttpRequestMessage(HttpMethod.Get,"api/diccionarios");
            //Act
            var respuesta = controlador.ObtenerTodosDiccionarios();
            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            JsonConvert.DeserializeObject<webApiModelosRespuesta.ConsultarDiccionariosRespuesta>(respuesta.Content.ReadAsStringAsync().Result).ListaDeDiccionarios.ShouldBeEmpty();
        }

        [Test]
        public void PruebaConsultarUnDiccionarioDebeTraerUnaRespuestaDiccionarioConRelaciones()
        {
            //Arrange
            controlador.Request = new HttpRequestMessage(HttpMethod.Get, "api/diccionario/1");
            
            var diccionario = new comunes.Diccionario();
            diccionario.Ambiente = ambienteTestPrueba;

            controlador.Request.Content = new StringContent(JsonConvert.SerializeObject(diccionario));

            var respuesta = controlador.ConsultarUnDiccionario(controlador.Request);

            respuesta.StatusCode.ShouldEqual(HttpStatusCode.Found);

            //JsonConvert.DeserializeObject<webApiModelosRespuesta.ConsultarUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result).
            
        }
        #endregion

        #region Pruebas de creación(POST)
        [Test]
        public void PruebaCrearUnDiccionarioRetornaDiccionarioConRelaciones() 
        {                
            //Arrange
            controlador.Request = new HttpRequestMessage(HttpMethod.Post, "api/diccionarios");
            var diccionario = new comunes.Diccionario();
            diccionario.Ambiente = ambienteTestPrueba;
            controlador.Request.Content = new StringContent(JsonConvert.SerializeObject(diccionario));
            
            var respuesta = controlador.CrearUnDiccionario(controlador.Request);
            
            //Mockeamos la respuesta de la app
            //var respuesta = this.appMantenimientoDiccionario.CrearUnDiccionario(diccionarioPeticion);

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            JsonConvert.DeserializeObject<webApiModelosRespuesta.CrearUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result).ShouldNotBeNull();
        }
#endregion

        
        
    }

}

