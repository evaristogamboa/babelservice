using System;
using Should;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using Babel.Interfaz.WebApi.Controllers;
using System.Net;
using Babel.Interfaz.WebApi.Models.Response;
using Newtonsoft.Json;

namespace  Babel.Interfaz.WebApi.PruebasUnitarias
{
	[TestFixture]
	public class DiccionarioControllerTest
	{
		private const int id = 1;

		public DiccionarioControllerTest ()
		{
		}

		#region status

		[Test]
		public void PruebaGETDiccionariosOk ()
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage ();
			controller.Configuration = new HttpConfiguration ();
			//Act
			var response = controller.ObtenerTodosLosDiccionarios ();
			//Assert
			Assert.AreEqual (HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public void PruebaGETDiccionarioOkCuandoDiccionarioExiste ()
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionarios"));
			controller.Configuration = new HttpConfiguration ();


			//Act
			var response = controller.ObtenerUnDiccionarioEspecifico (id);
			//Assert
			Assert.AreEqual (HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public void PruebaGETDiccionarioNotFoundCuandoDiccionarioNoExiste ()
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionario/id/1"));
			controller.Configuration = new HttpConfiguration ();


			//Act
			var response = controller.ObtenerUnDiccionarioEspecifico (3);
			//Assert
			Assert.AreEqual (HttpStatusCode.NotFound, response.StatusCode);
		}

		#endregion

		#region contenido

		[Test]
		public void ProbarContenidoDeObtenerDiccionariosEsTipoCorrecto ()
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionarios"));
			controller.Configuration = new HttpConfiguration ();

			//Act
			var response = controller.ObtenerTodosLosDiccionarios ();
			var responseString = response.Content.ReadAsStringAsync ().Result;
			var responseDeserialized = JsonConvert.DeserializeObject<ObtenerTodosLosDiccionariosResponse> (responseString);
			//Assert
			responseDeserialized.ShouldBeType<ObtenerTodosLosDiccionariosResponse> ();
		}

		[Test]
		public void ProbarContenidoDeObtenerUnDiccionarioEsTipoCorrecto ()
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionario/id/1"));
			controller.Configuration = new HttpConfiguration ();

			//Act
			var response = controller.ObtenerUnDiccionarioEspecifico (1);
			var responseString = response.Content.ReadAsStringAsync ().Result;
			var responseDeserialized = JsonConvert.DeserializeObject<ObtenerUnDiccionarioEspecificoResponse> (responseString);
			//Assert
			responseDeserialized.ShouldBeType<ObtenerUnDiccionarioEspecificoResponse> ();
		}

		#endregion
	}
}

