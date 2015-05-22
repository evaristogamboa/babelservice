using System;
using System.Linq;
using NUnit.Framework;
using app = Babel.Nucleo.Aplicacion.Fachada;
using appModelosRespuesta = Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using NSubstitute;
using System.Net.Http;
using controladores = Babel.Interfaz.WebApi.Controladores;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;

namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    class EtiquetaControladorTest
    {
        #region Variables y propiedades globales
        app.IAplicacionMantenimientoDiccionario appMantenimientoDiccionarioEtiquetas;

        private readonly appModelosRespuesta.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta ConsultarEtiquetasPorIdiomaPorDefecto;

        private controladores.EtiquetasController controlador;
        #endregion

        #region Constructor de las pruebas
        private EtiquetaControladorTest()
        {
            // Se inicializa el proxy del NSustitute para posteriormente inyectar los mocks la dependencia
            this.appMantenimientoDiccionarioEtiquetas = Substitute.For<app.IAplicacionMantenimientoDiccionario>();

            //Objeto de respuesta de la aplicación al consultar todas las etiquetas
            this.ConsultarEtiquetasPorIdiomaPorDefecto = appModelosRespuesta.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.CrearNuevaInstancia();


        }
        #endregion

        //#region Pruebas de Consulta
        //[Test]
        //public void PruebaConsultarEtiquetasDeUnDiccionarioPorIdiomaPorDefectoPorDebeRetornarListaDeEtiquetas()
        //{
        //    //Arrange
        //    this.appMantenimientoDiccionarioEtiquetas.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto(Arg.Any<ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion>).ReturnsForAnyArgs<appModelosRespuesta.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta>(this.ConsultarEtiquetasPorIdiomaPorDefecto);

        //    var respuesta = controlador.ConsultarEtiquetasPorIdiomaPorDefecto(controlador.Request,"1");

        //    respuesta.StatusCode.
        //}
        //#endregion

    }
}
