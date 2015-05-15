using System;
using Should;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using Babel.Interfaz.WebApi.Controladores;
using System.Net;
using Babel.Interfaz.WebApi.Modelos;
using Newtonsoft.Json;


namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    public class DiccionariocontroladorTest
    {
        //    private const int Id = 1;
        //    private DiccionariosController controlador;

        //    [SetUp]
        //    public void Iniciador()
        //    {
        //        controlador = new DiccionariosController();
        //    }

        //    #region status

        //    [Test]
        //    public void ProbarGetDiccionariosOk ()
        //    {
        //        //Arrange
        //        controlador.Request = new HttpRequestMessage ();
        //        controlador.Configuration = new HttpConfiguration ();

        //        //Act
        //        var respuesta = controlador.ObtenerTodosLosDiccionarios ();

        //        //Assert
        //        respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
        //    }

        //    [Test]
        //    public void ProbarGetDiccionarioOkCuandoDiccionarioExiste ()
        //    {
        //        //Arrange
        //        controlador.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionarios/" ));
        //        controlador.Configuration = new HttpConfiguration ();

        //        //Act
        //        var respuesta = controlador.ConsultarUnDiccionario (Id);

        //        //Assert
        //        respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
        //    }

        //    [Test]
        //    public void ProbarGetDiccionarioNotFoundCuandoDiccionarioNoExiste ()
        //    {
        //        //Arrange
        //        controlador.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionario/id/1"));
        //        controlador.Configuration = new HttpConfiguration ();

        //        //Act
        //        var respuesta = controlador.ConsultarUnDiccionario(3);

        //        //Assert
        //        respuesta.StatusCode.ShouldEqual(HttpStatusCode.NotFound);
        //    }

        //    [Test]
        //    public void ProbarPostDiccionarioCreatedCuandoDiccionarioNoExiste()
        //    {
        //        //Arrange
        //        controlador.Request = new HttpRequestMessage(HttpMethod.Post, new Uri("http://localhost/api/diccionario/id/2"));

        //        HttpResponseMessage respuesta = null;

        //        respuesta.StatusCode.ShouldEqual(HttpStatusCode.Created);

        //    }

        //    #endregion

        //    #region contenido

        //    [Test]
        //    public void ProbarContenidoDeObtenerDiccionariosEsTipoCorrecto ()
        //    {
        //        //Arrange
        //        controlador.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionarios"));
        //        controlador.Configuration = new HttpConfiguration ();

        //        //Act
        //        var respuesta = controlador.ObtenerTodosLosDiccionarios ();
        //        var textoRespuesta = respuesta.Content.ReadAsStringAsync ().Result;
        //        var respuestaDeserializada = JsonConvert.DeserializeObject<Diccionarios>(textoRespuesta);

        //        //Assert
        //        respuesta.StatusCode.ShouldEqual(HttpStatusCode.OK);
        //        respuestaDeserializada.ShouldBeType<Diccionarios>();
        //    }

        //    [Test]
        //    public void ProbarContenidoDeObtenerUnDiccionarioEsTipoCorrecto ()
        //    {
        //        //Arrange
        //        controlador.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionario/id/1"));
        //        controlador.Configuration = new HttpConfiguration ();

        //        //Act
        //        var respuesta = controlador.ConsultarUnDiccionario(1);
        //        var textorespuesta = respuesta.Content.ReadAsStringAsync ().Result;
        //        var respuestadeserializada = JsonConvert.DeserializeObject<Diccionario> (textorespuesta);

        //        //Assert
        //        respuestadeserializada.ShouldBeType<Diccionario>();
        //    }

        //    #endregion
        //}

    }
}

