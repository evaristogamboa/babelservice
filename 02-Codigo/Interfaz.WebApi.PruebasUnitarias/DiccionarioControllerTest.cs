﻿using System;
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
		private const int Id = 1;

		public DiccionarioControllerTest ()
		{
		}

		#region status

		[Test]
		public void PruebaGetDiccionariosOk ()
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage ();
			controller.Configuration = new HttpConfiguration ();
			//Act
			var response = controller.ObtenerTodosLosDiccionarios ();
			
            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
			Assert.AreEqual (HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public void PruebaGetDiccionarioOkCuandoDiccionarioExiste (int id)
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionarios/" + id));
			controller.Configuration = new HttpConfiguration ();


			//Act
			var response = controller.ObtenerUnDiccionarioPorId (Id);

			//Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
			Assert.AreEqual (HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public void PruebaGetDiccionarioNotFoundCuandoDiccionarioNoExiste ()
		{
			//Arrange
			var controller = new DiccionariosController ();
			controller.Request = new HttpRequestMessage (HttpMethod.Get, new Uri ("http://localhost/api/diccionario/id/1"));
			controller.Configuration = new HttpConfiguration ();


			//Act
			var response = controller.ObtenerUnDiccionarioPorId (3);
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
			var response = controller.ObtenerUnDiccionarioPorId (1);
			var responseString = response.Content.ReadAsStringAsync ().Result;
			var responseDeserialized = JsonConvert.DeserializeObject<ObtenerUnDiccionarioEspecificoResponse> (responseString);
			//Assert
			responseDeserialized.ShouldBeType<ObtenerUnDiccionarioEspecificoResponse> ();
		}

		#endregion
	}
}

