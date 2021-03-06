﻿using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using Should;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using app = Babel.Nucleo.Aplicacion.Fachada;
using appModelosRespuesta = Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using controladores = Babel.Interfaz.WebApi.Controladores;
using webApiModelosRespuesta = Babel.Interfaz.WebApi.Modelos.Respuesta;

namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    public class DiccionarioControladorTest
    {
        #region variables y propiedades globales
        const string diccionariosJson="{ \"diccionarios\": { \"diccionario\": { \"id\": \"a1fa3369bc3f4ebc9cac5677cbaa8114\", \"amb\": \"desarrollo\", \"etiquetas\": { \"etiqueta\": [ { \"id\": \"8a87f8a73df94d909478350b964fc888\", \"nombre\": \"app.common.aceptar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.aceptar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"aceptar\" }, { \"cultura\": \"es-VE\", \"#text\": \"aceptar\" }, { \"cultura\": \"en\", \"#text\": \"accept\" }, { \"cultura\": \"en-US\", \"#text\": \"accept\" } ] } }, { \"id\": \"9a39ad6d62c842bfa8f766417b2b08d0\", \"nombre\": \"app.common.cancelar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.cancelar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"cancelar\" }, { \"cultura\": \"es-VE\", \"#text\": \"cancelar\" }, { \"cultura\": \"en\", \"#text\": \"cancel\" }, { \"cultura\": \"en-US\", \"#text\": \"cancel\" } ] } }, { \"id\": \"165db3e4d705406bbce02738b25c9023\", \"nombre\": \"app.common.usuario\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.usuario\", \"descripcion\": \"Campo de texto usuario\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"usuario\" }, { \"cultura\": \"es-VE\", \"#text\": \"usuario\" }, { \"cultura\": \"en\", \"#text\": \"user\" }, { \"cultura\": \"en-US\", \"#text\": \"user\" } ] } }, { \"id\": \"aaa55616722d410ca5f06f1f10f0b4a2\", \"nombre\": \"app.common.contraseña\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.contraseña\", \"descripcion\": \"Campo de texto contraseña\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"contraseña\" }, { \"cultura\": \"es-VE\", \"#text\": \"contraseña\" }, { \"cultura\": \"en\", \"#text\": \"password\" }, { \"cultura\": \"en-US\", \"#text\": \"password\" } ] } } ] } } } }";

        private const string AmbienteTestPrueba = "Prueba";

        private comunes.Diccionario diccionario;

        private readonly app.IAplicacionMantenimientoDiccionario appMantenimientoDiccionario;
        
        private readonly CrearUnDiccionarioPeticion diccionarioPeticion;

        private readonly controladores.DiccionariosController controlador;
        private HttpResponseMessage respuesta;

        private readonly appModelosRespuesta.CrearUnDiccionarioRespuesta crearUnDiccionarioRespuesta;
        private readonly appModelosRespuesta.ConsultarUnDiccionarioarioRespuesta consultarUnDiccionarioRespuesta;
        private readonly appModelosRespuesta.ConsultarDiccionariosRespuesta consultarDiccionariosRespuesta;
        private readonly appModelosRespuesta.ModificarUnDiccionarioRespuesta modificarUnDiccionarioRespuesta;
        private readonly appModelosRespuesta.EliminarUnDiccionarioRespuesta eliminarDiccionarioRespuesta;

        #endregion

        #region Constructor de las pruebas
        public DiccionarioControladorTest()
        {
            // Se inicializa el proxy del NSustitute para posteriormente inyectar los mocks la dependencia
            this.appMantenimientoDiccionario = Substitute.For<app.IAplicacionMantenimientoDiccionario>();

            //Objeto de respuesta de la aplicación al consultar todos los diccionarios disponibles
            this.consultarDiccionariosRespuesta = appModelosRespuesta.ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

            //Objeto de respuesta de la aplicación al consultar un diccionario en particular
            this.consultarUnDiccionarioRespuesta = appModelosRespuesta.ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(AmbienteTestPrueba);
            this.consultarUnDiccionarioRespuesta.Diccionario = Diccionario.CrearNuevoDiccionario(new Guid("8a87f8a7-3df9-4d90-9478-350b964fc888"), AmbienteTestPrueba);

            //Objeto de respuesta de la aplicación al crear un nuevo diccionario vacio
            this.crearUnDiccionarioRespuesta = appModelosRespuesta.CrearUnDiccionarioRespuesta.CrearNuevaInstancia(AmbienteTestPrueba);

            //Objeto de respuesta de la aplicacion al modificar un diccionario en particular
            this.modificarUnDiccionarioRespuesta = appModelosRespuesta.ModificarUnDiccionarioRespuesta.CrearNuevaInstancia();
            
            //Objeto de respuesta de la aplicacion al eliminar un diccionario
            this.eliminarDiccionarioRespuesta = appModelosRespuesta.EliminarUnDiccionarioRespuesta.CrearNuevaInstancia();

            // Se crea una nueva instancia del controlador inyectandole la interfaz con los metodos mock que se configuraran en las pruebas
            controlador = new controladores.DiccionariosController(this.appMantenimientoDiccionario);
            controlador.Configuration = new HttpConfiguration();
        }
        #endregion

        #region Pruebas de tipos de instancias
        [Test]
        public void PruebaCreacionControladorEsCorrecta()
        { 
            //Assert
            controlador.ShouldBeType<controladores.DiccionariosController>();
        }
        #endregion

        #region Pruebas de consultar (GET)
        [Test]
        public void PruebaConsultarTodosLosDiccionariosDebeTraerUnaRespuestaConListaDeDiccionariosVacio()
        {
            //Arrange
            this.appMantenimientoDiccionario.ConsultarDiccionarios().Returns<appModelosRespuesta.ConsultarDiccionariosRespuesta>(consultarDiccionariosRespuesta);

            controlador.Request = new HttpRequestMessage(HttpMethod.Get,"api/diccionarios");
            //Act
            var respuesta = controlador.ObtenerTodosDiccionarios();
            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            JsonConvert.DeserializeObject<webApiModelosRespuesta.ConsultarDiccionariosRespuesta>(respuesta.Content.ReadAsStringAsync().Result).ListaDeDiccionarios.ShouldBeEmpty();
        }

        [Test]
        public void PruebaConsultarUnDiccionarioDebeTraerUnaRespuestaConDiccionarioYSusRelacionesSiAplica()
        {
            //Arrange
            this.appMantenimientoDiccionario.ConsultarUnDiccionario(Arg.Any<ConsultarUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.ConsultarUnDiccionarioarioRespuesta>(consultarUnDiccionarioRespuesta);

            controlador.Request = new HttpRequestMessage(HttpMethod.Get, "http:/localhost:80/api/diccionario/8a87f8a7-3df9-4d90-9478-350b964fc888");

            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba,"8a87f8a7-3df9-4d90-9478-350b964fc888");

            //Act
            var respuesta = controlador.ConsultarUnDiccionario(controlador.Request, "8a87f8a7-3df9-4d90-9478-350b964fc888");
            
            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.ConsultarUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            validarContenidoRespuesta.Diccionario.ShouldNotBeNull();
            validarContenidoRespuesta.Relaciones.ShouldNotBeEmpty();

        }

        [Test]
        public void PruebaConsultarUnDiccionarioDebeTraerRespuestaDiccionarioNoEncontrado()
        {
            this.appMantenimientoDiccionario.ConsultarUnDiccionario(Arg.Any<ConsultarUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.ConsultarUnDiccionarioarioRespuesta>(consultarUnDiccionarioRespuesta);

            controlador.Request = new HttpRequestMessage(HttpMethod.Get, "api/diccionario/9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba,"9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            //Act
            var respuesta = controlador.ConsultarUnDiccionario(controlador.Request, "9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.NotFound);
        }

        [Test]
        public void PruebaConsultarUnDiccionarioDebeTraerRespuestaDiccionarioVacio()
        {
            //Arrange
            controlador.Request = new HttpRequestMessage(HttpMethod.Get, "http:/localhost:80/api/diccionario/165db3e4-d705-406b-bce0-2738b25c9023");
            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba, "8a87f8a7-3df9-4d90-9478-350b964fc888");

            //Act
            var respuesta = controlador.ConsultarUnDiccionario(controlador.Request, "8a87f8a7-3df9-4d90-9478-350b964fc888");
            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.ConsultarUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            //Assert
            validarContenidoRespuesta.Diccionario.Etiquetas.ListaEtiquetas.ShouldBeEmpty();
        }
        #endregion

        #region Pruebas de creacion (POST)
        [Test]
        public void PruebaCrearUnDiccionarioRetornaDiccionarioConRelaciones() 
        {                
            //Arrange
            this.appMantenimientoDiccionario.CrearUnDiccionario(Arg.Any<CrearUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.CrearUnDiccionarioRespuesta>(crearUnDiccionarioRespuesta);

            controlador.Request = new HttpRequestMessage(HttpMethod.Post, "api/diccionarios");
            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba);
            
            //Act
            var respuesta = controlador.CrearUnDiccionario(controlador.Request);
            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.CrearUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.Created);
            validarContenidoRespuesta.DiccionarioNuevo.ShouldNotBeNull();

        }

        [Test]
        public void PruebaCrearUnDiccionarioRetornaDiccionarioNoCreado()
        {
            //Arrange
            this.crearUnDiccionarioRespuesta.DiccionarioNuevo = null;
            this.appMantenimientoDiccionario.CrearUnDiccionario(Arg.Any<CrearUnDiccionarioPeticion>()).Returns(crearUnDiccionarioRespuesta);

            controlador.Request = new HttpRequestMessage(HttpMethod.Post, "api/diccionarios");
            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba);

            //Act
            var respuesta = controlador.CrearUnDiccionario(controlador.Request);
            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.CrearUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            //Assert
            validarContenidoRespuesta.DiccionarioNuevo.ShouldBeNull();

        }
        #endregion

        #region Pruebas de modificación (PUT)
        [Test]
        public void PruebaModificarUnDiccionarioDebeTraerRespuestaDiccionarioModificado()
        {
            //Arrange
            this.modificarUnDiccionarioRespuesta.Diccionario = Diccionario.CrearNuevoDiccionario(new Guid("9a39ad6d-62c8-42bf-a8f7-66417b2b08d0"), AmbienteTestPrueba);
            this.appMantenimientoDiccionario.ModificarUnDiccionario(Arg.Any<ModificarUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.ModificarUnDiccionarioRespuesta>(modificarUnDiccionarioRespuesta);


            controlador.Request = new HttpRequestMessage(HttpMethod.Put, "api/diccionario/9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");
            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba,"9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            //Act
            var respuesta = controlador.ModificarUnDiccionario(controlador.Request, "9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");
            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.ModificarUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
            validarContenidoRespuesta.Diccionario.Ambiente.ShouldEqual(AmbienteTestPrueba);

        }

        [Test]
        public void PruebaModificarUnDiccionarioDebeTraerRespuestaDiccionarioNoModificadoNoEncontrado()
        {
            //Arrange
            this.modificarUnDiccionarioRespuesta.Diccionario = Diccionario.CrearNuevoDiccionario(new Guid("9a39ad6d-62c8-42bf-a8f7-66417b2b08d0"), AmbienteTestPrueba);
            this.modificarUnDiccionarioRespuesta.Diccionario = null;
            this.appMantenimientoDiccionario.ModificarUnDiccionario(Arg.Any<ModificarUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.ModificarUnDiccionarioRespuesta>(modificarUnDiccionarioRespuesta);


            controlador.Request = new HttpRequestMessage(HttpMethod.Put, "api/diccionario/9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");
            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba, "9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            //Act
            var respuesta = controlador.ModificarUnDiccionario(controlador.Request, "9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.NotFound);
        }

        #endregion

        #region Pruebas de eliminación (DELETE)
        [Test]
        public void PruebaEliminarUnDiccionarioRetornaDiccionarioEliminado()
        {
            //Arrange
            //this.eliminarDiccionarioRespuesta.ListaDeDiccionarios = JsonConvert.SerializeObject<(diccionariosJson);
            this.appMantenimientoDiccionario.EliminarUnDiccionario(Arg.Any<EliminarUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.EliminarUnDiccionarioRespuesta>(eliminarDiccionarioRespuesta);

            controlador.Request = new HttpRequestMessage(HttpMethod.Delete, "api/diccionario/9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");
            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba, "9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            //Act
            respuesta = controlador.EliminarUnDiccionario(controlador.Request, "9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }

        [Test]
        public void PruebaEliminarUnDiccionarioRetornaDiccionarioEliminadoYListaDeDiccionariosVacia()
        {
            this.PruebaEliminarUnDiccionarioRetornaDiccionarioEliminado();

            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.EliminarUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            validarContenidoRespuesta.ListaDiccionarios.ShouldNotBeNull();
            validarContenidoRespuesta.ListaDiccionarios.Count.ShouldEqual(0);
        }

        #endregion

        #region Metodos Privados Utilitarios
        private void UtilConfigurarMockPeticionHttp(string ambientePrueba, string id = "8a87f8a7-3456-4d90-9478-350b964fc888")
        {
            diccionario = new comunes.Diccionario();
            diccionario.Ambiente = ambientePrueba;
            diccionario.Id = new Guid(id);
            controlador.Request.Content = new StringContent(JsonConvert.SerializeObject(diccionario));
            controlador.Request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
        }
        #endregion

    }

}

