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
using webapiModelos=Babel.Interfaz.WebApi.Modelos.Respuesta;
using Newtonsoft.Json;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    public class DiccionarioControladorTest
    {
        
        const string diccionariosJson="{ \"diccionarios\": { \"diccionario\": { \"id\": \"a1fa3369bc3f4ebc9cac5677cbaa8114\", \"amb\": \"desarrollo\", \"etiquetas\": { \"etiqueta\": [ { \"id\": \"8a87f8a73df94d909478350b964fc888\", \"nombre\": \"app.common.aceptar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.aceptar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"aceptar\" }, { \"cultura\": \"es-VE\", \"#text\": \"aceptar\" }, { \"cultura\": \"en\", \"#text\": \"accept\" }, { \"cultura\": \"en-US\", \"#text\": \"accept\" } ] } }, { \"id\": \"9a39ad6d62c842bfa8f766417b2b08d0\", \"nombre\": \"app.common.cancelar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.cancelar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"cancelar\" }, { \"cultura\": \"es-VE\", \"#text\": \"cancelar\" }, { \"cultura\": \"en\", \"#text\": \"cancel\" }, { \"cultura\": \"en-US\", \"#text\": \"cancel\" } ] } }, { \"id\": \"165db3e4d705406bbce02738b25c9023\", \"nombre\": \"app.common.usuario\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.usuario\", \"descripcion\": \"Campo de texto usuario\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"usuario\" }, { \"cultura\": \"es-VE\", \"#text\": \"usuario\" }, { \"cultura\": \"en\", \"#text\": \"user\" }, { \"cultura\": \"en-US\", \"#text\": \"user\" } ] } }, { \"id\": \"aaa55616722d410ca5f06f1f10f0b4a2\", \"nombre\": \"app.common.contraseña\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.contraseña\", \"descripcion\": \"Campo de texto contraseña\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"contraseña\" }, { \"cultura\": \"es-VE\", \"#text\": \"contraseña\" }, { \"cultura\": \"en\", \"#text\": \"password\" }, { \"cultura\": \"en-US\", \"#text\": \"password\" } ] } } ] } } } }";
        private const string ambienteTestPrueba = "Prueba";


        private app.IAplicacionMantenimientoDiccionario appMantenimientoDiccionario;
        private CrearUnDiccionarioPeticion diccionarioPeticion = CrearUnDiccionarioPeticion.CrearNuevaInstancia(ambienteTestPrueba);
        public DiccionarioControladorTest() {
            this.appMantenimientoDiccionario = Substitute.For<app.IAplicacionMantenimientoDiccionario>();
            var consultarDiccionarioRespuesta = appModelosRespuesta.ConsultarDiccionariosRespuesta.CrearNuevaInstancia();
            var crearUnDiccionarioRespuesta = appModelosRespuesta.CrearUnDiccionarioRespuesta.CrearNuevaInstancia(ambienteTestPrueba);
            this.appMantenimientoDiccionario.ConsultarDiccionarios().Returns<appModelosRespuesta.ConsultarDiccionariosRespuesta>(consultarDiccionarioRespuesta);
            this.appMantenimientoDiccionario.CrearUnDiccionario(diccionarioPeticion).Returns<appModelosRespuesta.CrearUnDiccionarioRespuesta>(crearUnDiccionarioRespuesta);

        }

        [Test]
        public void PruebaCreacionControladorEsCorrecta()
        { 
            //Arrange
            var controlador = new controladores.Diccionarios(this.appMantenimientoDiccionario);
            //Act
            //Assert
            controlador.ShouldBeType<controladores.Diccionarios>();
        }
        [Test]
        public void PruebaSolicitarTodosLosDiccionariosDebeTraerUnaRespuestaConDiccionariosConListaDeDiccionariosVacio()
        {
            //Arrange
            var controlador = new controladores.Diccionarios(this.appMantenimientoDiccionario);
            controlador.Configuration = new HttpConfiguration();
            controlador.Request = new HttpRequestMessage(HttpMethod.Get,"api/diccionarios");
            //Act
            var respuesta = controlador.ObtenerTodosDiccionarios();
            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            JsonConvert.DeserializeObject<webapiModelos.ConsultarDiccionariosRespuesta>(respuesta.Content.ReadAsStringAsync().Result).ListaDeDiccionarios.ShouldBeEmpty();
        }

        [Test]
        public void PruebaCrearUnDiccionarioRetornaDiccionarioConRelaciones() 
        {
            //Arrange
            var controlador = new controladores.Diccionarios(this.appMantenimientoDiccionario);
            controlador.Configuration = new HttpConfiguration();
            controlador.Request = new HttpRequestMessage(HttpMethod.Post, "api/diccionarios");
            var diccionarioDominioPrueba = JsonConvert.SerializeObject(Diccionario.CrearNuevoDiccionario(ambienteTestPrueba));
            controlador.Request.Content = new StringContent(diccionarioDominioPrueba);
            
            var respuesta = controlador.CrearUnDiccionario(controlador.Request);
            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            JsonConvert.DeserializeObject<webapiModelos.CrearUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result).ShouldNotBeNull();
        }
    }

}

