using System;
using System.Linq;
using NUnit.Framework;
using Newtonsoft.Json;
using Should;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using appModelosPeticion = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using app = Babel.Nucleo.Aplicacion.Fachada;
using appModelosRespuesta = Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using NSubstitute;
using System.Net.Http;
using controladores = Babel.Interfaz.WebApi.Controladores;
using System.Net;
using System.Collections.Generic;


namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    class EtiquetaControladorTest
    {
        #region Variables y propiedades globales

        const string EtiquetaJson = "{ \"etiquetas\": { \"etiqueta\": [ { \"-id\": \"8a87f8a7-3df9-4d90-9478-350b964fc888\", \"-nombre\": \"app.common.aceptar\", \"-activo\": \"true\", \"-default\": \"es-VE\", \"nombre\": \"app.common.aceptar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"-cultura\": \"es\", \"#text\": \"aceptar\" }, { \"-cultura\": \"es-VE\", \"#text\": \"aceptar\" }, { \"-cultura\": \"en\", \"#text\": \"accept\" }, { \"-cultura\": \"en-US\", \"#text\": \"accept\" } ] } }, { \"-id\": \"9a39ad6d-62c8-42bf-a8f7-66417b2b08d0\", \"-nombre\": \"app.common.cancelar\", \"-activo\": \"true\", \"-default\": \"es-VE\", \"nombre\": \"app.common.cancelar\", \"descripcion\": \"Aceptar\", \"traducciones\": { \"traduccion\": [ { \"-cultura\": \"es\", \"#text\": \"cancelar\" }, { \"-cultura\": \"es-VE\", \"#text\": \"cancelar\" }, { \"-cultura\": \"en\", \"#text\": \"cancel\" }, { \"-cultura\": \"en-US\", \"#text\": \"cancel\" } ] } }, { \"-id\": \"165db3e4-d705-406b-bce0-2738b25c9023\", \"-nombre\": \"app.common.usuario\", \"-activo\": \"true\", \"-default\": \"en\", \"nombre\": \"app.common.usuario\", \"descripcion\": \"Campo de texto usuario\", \"traducciones\": { \"traduccion\": [ { \"-cultura\": \"es\", \"#text\": \"usuario\" }, { \"-cultura\": \"es-VE\", \"#text\": \"usuario\" }, { \"-cultura\": \"en\", \"#text\": \"user\" }, { \"-cultura\": \"en-US\", \"#text\": \"user\" } ] } }, { \"-id\": \"aaa55616-722d-410c-a5f0-6f1f10f0b4a2\", \"-nombre\": \"app.common.contraseña\", \"-activo\": \"true\", \"-default\": \"en\", \"nombre\": \"app.common.contraseña\", \"descripcion\": \"Campo de texto contraseña\", \"traducciones\": { \"traduccion\": [ { \"-cultura\": \"es\", \"#text\": \"contraseña\" }, { \"-cultura\": \"es-VE\", \"#text\": \"contraseña\" }, { \"-cultura\": \"en\", \"#text\": \"password\" }, { \"-cultura\": \"en-US\", \"#text\": \"password\" } ] } } ] } }";

        app.IAplicacionMantenimientoDiccionario appMantenimientoDiccionarioEtiquetas;

        private readonly appModelosRespuesta.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta ConsultarEtiquetasPorIdiomaPorDefecto;

        private controladores.EtiquetasController controlador;
        #endregion

        #region Constructor de las pruebas
        public EtiquetaControladorTest()
        {
            // Se inicializa el proxy del NSustitute para posteriormente inyectar los mocks la dependencia
            this.appMantenimientoDiccionarioEtiquetas = Substitute.For<app.IAplicacionMantenimientoDiccionario>();

            //Objeto de respuesta de la aplicación al consultar todas las etiquetas
            this.ConsultarEtiquetasPorIdiomaPorDefecto = appModelosRespuesta.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.CrearNuevaInstancia();

        }
        #endregion

        #region Pruebas de Consulta
        [Test]
        public void PruebaConsultarEtiquetasDeUnDiccionarioPorIdiomaPorDefectoPorDebeRetornarListaDeEtiquetas()
        {
            //Arrange
            var listaEtiquetas = JsonConvert.DeserializeObject<Dictionary<string,Guid>>(EtiquetaJson);
            //this.ConsultarEtiquetasPorIdiomaPorDefecto.ListaDeEtiquetas = new Dictionary<string, Guid>(listaEtiquetas);
            this.appMantenimientoDiccionarioEtiquetas.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto(Arg.Any<appModelosPeticion.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion>()).ReturnsForAnyArgs<appModelosRespuesta.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta>(this.ConsultarEtiquetasPorIdiomaPorDefecto);

            var respuesta = controlador.ConsultarEtiquetasPorIdiomaPorDefecto(controlador.Request,"1");

            respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }
        #endregion

    }
}
