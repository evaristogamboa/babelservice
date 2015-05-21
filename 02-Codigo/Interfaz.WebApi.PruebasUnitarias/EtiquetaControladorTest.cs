using NSubstitute;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using app = Babel.Nucleo.Aplicacion.Fachada;
using appModelosRespuesta = Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using controladores = Babel.Interfaz.WebApi.Controladores;
using webApiModelosRespuesta = Babel.Interfaz.WebApi.Modelos.Respuesta;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    class EtiquetaControladorTest
    {
        #region variables y propiedades globales
        const string diccionariosJson = "{ \"diccionarios\": { \"diccionario\": { \"id\": \"aaa55616-722d-410c-a5f0-6f1f10f0b4a2\", \"amb\": \"desarrollo\", \"etiquetas\": { \"etiqueta\": [ { \"id\": \"bbb55616-722d-410c-a5f0-6f1f10f0b4a2\", \"nombre\": \"app.common.aceptar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.aceptar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"aceptar\" }, { \"cultura\": \"es-VE\", \"#text\": \"aceptar\" }, { \"cultura\": \"en\", \"#text\": \"accept\" }, { \"cultura\": \"en-US\", \"#text\": \"accept\" } ] } }, { \"id\": \"9a39ad6d62c842bfa8f766417b2b08d0\", \"nombre\": \"app.common.cancelar\", \"activo\": \"true\", \"default\": \"es-VE\", \"nombre\": \"app.common.cancelar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"cancelar\" }, { \"cultura\": \"es-VE\", \"#text\": \"cancelar\" }, { \"cultura\": \"en\", \"#text\": \"cancel\" }, { \"cultura\": \"en-US\", \"#text\": \"cancel\" } ] } }, { \"id\": \"165db3e4d705406bbce02738b25c9023\", \"nombre\": \"app.common.usuario\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.usuario\", \"descripcion\": \"Campo de texto usuario\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"usuario\" }, { \"cultura\": \"es-VE\", \"#text\": \"usuario\" }, { \"cultura\": \"en\", \"#text\": \"user\" }, { \"cultura\": \"en-US\", \"#text\": \"user\" } ] } }, { \"id\": \"aaa55616722d410ca5f06f1f10f0b4a2\", \"nombre\": \"app.common.contraseña\", \"activo\": \"true\", \"default\": \"en\", \"nombre\": \"app.common.contraseña\", \"descripcion\": \"Campo de texto contraseña\", \"traducciones\": { \"traduccion\": [ { \"cultura\": \"es\", \"#text\": \"contraseña\" }, { \"cultura\": \"es-VE\", \"#text\": \"contraseña\" }, { \"cultura\": \"en\", \"#text\": \"password\" }, { \"cultura\": \"en-US\", \"#text\": \"password\" } ] } } ] } } } }";
        private const string AmbienteTestPrueba = "desarrollo";
        private comunes.Diccionario diccionario;

        private readonly app.IAplicacionMantenimientoDiccionario appMantenimientoDiccionario;

        private readonly controladores.Diccionarios controlador;

        private readonly appModelosRespuesta.ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta consultarEtiquetaPorNombreDeDiccionarioRespuesta;

        #endregion

        #region Constructor de las pruebas
        public EtiquetaControladorTest()
        {
            // Se inicializa el proxy del NSustitute para posteriormente inyectar los mocks
            this.appMantenimientoDiccionario = Substitute.For<app.IAplicacionMantenimientoDiccionario>();

            ////Se crea el objeto para simular las etiquetas de un diccionario
            //this.ConsultarEtiquetaPorNombreDeDiccionarioRespuesta = appMantenimientoDiccionario.ConsultarEtiquetasDeDiccionarioPorNombre
        }
        #endregion

        #region Pruebas de tipos de instancia
        #endregion

        #region Pruebas de consultar (GET)
        //[Test]
        public void PruebaConsultarLasEtiquetasPorNombreDeUnDiccionarioDebeTraerEtiqueta()
        {
            //Arrange
            controlador.Request = new HttpRequestMessage(HttpMethod.Get, "api/diccionario/165db3e4-d705-406b-bce0-2738b25c9023/etiqueta/nombre/{nombre}");
            //utils.ConfigurarPeticionesHttp(AmbienteTestPrueba);
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
