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
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    public class DiccionarioControladorTest
    {
        #region variables y propiedades globales
        //const string diccionariosJson="{ \"diccionarios\": { \"diccionario\": { \"id\": \"a1fa3369bc3f4ebc9cac5677cbaa8114\", \"amb\": \"desarrollo\", \"etiquetas\": { \"etiqueta\": [ { \"id\": \"8a87f8a73df94d909478350b964fc888\", \"nombre\": \"app.common.aceptar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.aceptar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"aceptar\" }, { \"cultura\": \"es-VE\", \"#text\": \"aceptar\" }, { \"cultura\": \"en\", \"#text\": \"accept\" }, { \"cultura\": \"en-US\", \"#text\": \"accept\" } ] } }, { \"id\": \"9a39ad6d62c842bfa8f766417b2b08d0\", \"nombre\": \"app.common.cancelar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.cancelar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"cancelar\" }, { \"cultura\": \"es-VE\", \"#text\": \"cancelar\" }, { \"cultura\": \"en\", \"#text\": \"cancel\" }, { \"cultura\": \"en-US\", \"#text\": \"cancel\" } ] } }, { \"id\": \"165db3e4d705406bbce02738b25c9023\", \"nombre\": \"app.common.usuario\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.usuario\", \"descripcion\": \"Campo de texto usuario\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"usuario\" }, { \"cultura\": \"es-VE\", \"#text\": \"usuario\" }, { \"cultura\": \"en\", \"#text\": \"user\" }, { \"cultura\": \"en-US\", \"#text\": \"user\" } ] } }, { \"id\": \"aaa55616722d410ca5f06f1f10f0b4a2\", \"nombre\": \"app.common.contraseña\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.contraseña\", \"descripcion\": \"Campo de texto contraseña\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"contraseña\" }, { \"cultura\": \"es-VE\", \"#text\": \"contraseña\" }, { \"cultura\": \"en\", \"#text\": \"password\" }, { \"cultura\": \"en-US\", \"#text\": \"password\" } ] } } ] } } } }";

        private const string AmbienteTestPrueba = "Prueba";

        private comunes.Diccionario diccionario;

        private readonly app.IAplicacionMantenimientoDiccionario appMantenimientoDiccionario;
        
        private readonly CrearUnDiccionarioPeticion diccionarioPeticion;

        private readonly controladores.Diccionarios controlador;

        private readonly appModelosRespuesta.CrearUnDiccionarioRespuesta crearUnDiccionarioRespuesta;

        private readonly appModelosRespuesta.ConsultarUnDiccionarioarioRespuesta consultarUnDiccionarioRespuesta;

        private readonly appModelosRespuesta.ConsultarDiccionariosRespuesta consultarDiccionariosRespuesta;

        #endregion

        #region Constructor de las pruebas
        public DiccionarioControladorTest()
        {
            // Se inicializa el proxy del NSustitute para posteriormente inyectar los mocks la dependencia en el 
            this.appMantenimientoDiccionario = Substitute.For<app.IAplicacionMantenimientoDiccionario>();

            //Objeto de respuesta de la aplicación al consultar todos los diccionarios disponibles
            this.consultarDiccionariosRespuesta = appModelosRespuesta.ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

            //Objeto de respuesta de la aplicación al consultar un diccionario en particular
            this.consultarUnDiccionarioRespuesta = appModelosRespuesta.ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(AmbienteTestPrueba);
            this.consultarUnDiccionarioRespuesta.Diccionario = Diccionario.CrearNuevoDiccionario(new Guid("8a87f8a7-3df9-4d90-9478-350b964fc888"), AmbienteTestPrueba);

            //Objeto de respuesta de la aplicación al crear un nuevo diccionario vacio
            this.crearUnDiccionarioRespuesta = appModelosRespuesta.CrearUnDiccionarioRespuesta.CrearNuevaInstancia(AmbienteTestPrueba);

            

            controlador = new controladores.Diccionarios(this.appMantenimientoDiccionario);
            controlador.Configuration = new HttpConfiguration();
        }
        #endregion

        #region Pruebas de tipos de instancias
        [Test]
        public void PruebaCreacionControladorEsCorrecta()
        { 
            //Assert
            controlador.ShouldBeType<controladores.Diccionarios>();
        }
        #endregion

        #region Pruebas de consultar (GET)
        [Test]
        public void PruebaConsultarTodosLosDiccionariosDebeTraerUnaRespuestaConDiccionariosConListaDeDiccionariosVacio()
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

            controlador.Request = new HttpRequestMessage(HttpMethod.Get, "api/diccionario/8a87f8a7-3df9-4d90-9478-350b964fc888");

            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba,"8a87f8a7-3df9-4d90-9478-350b964fc888");

            //Act
            var respuesta = controlador.ConsultarUnDiccionario(controlador.Request);
            
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
            var respuesta = controlador.ConsultarUnDiccionario(controlador.Request);

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.NotFound);
        }

        [Test]
        public void PruebaConsultarUnDiccionarioDebeTraerRespuestaDiccionarioVacio()
        {
            //Arrange
            controlador.Request = new HttpRequestMessage(HttpMethod.Get, "api/diccionario/165db3e4-d705-406b-bce0-2738b25c9023");
            this.UtilConfigurarMockPeticionHttp(AmbienteTestPrueba, "8a87f8a7-3df9-4d90-9478-350b964fc888");

            //Act
            var respuesta = controlador.ConsultarUnDiccionario(controlador.Request);

            //Assert
            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.ConsultarUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            validarContenidoRespuesta.Diccionario.Etiquetas.ListaEtiquetas.ShouldBeEmpty();
        }
        #endregion

        #region pruebas de creacion (POST)
        [Test]
        public void PruebaCrearUnDiccionarioRetornaDiccionarioConRelaciones() 
        {                
            //Arrange
            this.appMantenimientoDiccionario.CrearUnDiccionario(Arg.Any<CrearUnDiccionarioPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.CrearUnDiccionarioRespuesta>(crearUnDiccionarioRespuesta);

            controlador.Request = new HttpRequestMessage(HttpMethod.Post, "api/diccionarios");
            var diccionario = new comunes.Diccionario();
            diccionario.Ambiente = AmbienteTestPrueba;
            controlador.Request.Content = new StringContent(JsonConvert.SerializeObject(diccionario));
            controlador.Request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            var respuesta = controlador.CrearUnDiccionario(controlador.Request);
            
            //Mockeamos la respuesta de la app
            //var respuesta = this.appMantenimientoDiccionario.CrearUnDiccionario(diccionarioPeticion);

            //Assert
            respuesta.StatusCode.ShouldEqual(HttpStatusCode.Created);
            var validarContenidoRespuesta = JsonConvert.DeserializeObject<webApiModelosRespuesta.CrearUnDiccionarioRespuesta>(respuesta.Content.ReadAsStringAsync().Result);

            validarContenidoRespuesta.DiccionarioNuevo.ShouldNotBeNull();
            //validarContenidoRespuesta.Relaciones.ToArray().ShouldNotBeNull("Todo Diccionario debe tener por lo menos una relacion consigo mismo");
        }
        #endregion

        #region Metodos Privados Utilitarios
        private void UtilConfigurarMockPeticionHttp(string ambientePrueba, string id)
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

