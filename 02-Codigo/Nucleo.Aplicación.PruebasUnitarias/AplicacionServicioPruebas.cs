using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Babel.Nucleo.Dominio.Repositorios;
using NUnit.Framework;
using Should;
using Babel.Nucleo.Aplicacion.Servicios;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using NSubstitute;

namespace Babel.Nucleo.Aplicación.PruebasUnitarias
{
	[TestFixture]
	public class AplicacionServicioPruebas
	{
		private IDiccionarioRepositorio diccionarioRepositorio;
		private const string ambienteTestPrueba = "prueba";

		public AplicacionServicioPruebas() { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();			
			this.diccionarioRepositorio = repositorioMock;
		}
		[SetUp]
		public void Inicializar()
		{
			List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();
           

			List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();
			List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();
			
			Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), ambienteTestPrueba);
			
			Etiqueta etiquetaAceptar = Etiqueta.CrearNuevaEtiqueta(new Guid("8a87f8a7-3df9-4d90-9478-350b964fc888"));
			Etiqueta etiquetaCancelar = Etiqueta.CrearNuevaEtiqueta(new Guid("9a39ad6d-62c8-42bf-a8f7-66417b2b08d0"));
			
			Cultura culturaEs = Cultura.CrearNuevaCultura("es");
			Cultura culturaEsVe = Cultura.CrearNuevaCultura("es-VE");
			Cultura culturaEn = Cultura.CrearNuevaCultura("en");
			Cultura culturaEnUs = Cultura.CrearNuevaCultura("en-US");

			Traduccion traduccionAceptarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "aceptar");
			Traduccion traduccionAceptarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "aceptar");
			Traduccion traduccionAceptarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "accept");
			Traduccion traduccionAceptarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "accept");

			listaDeTraduccionesAceptar.Add(traduccionAceptarEs);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEsVe);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEn);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEnUs);
			
			etiquetaAceptar.IdiomaPorDefecto = "es-VE";
			etiquetaAceptar.Nombre = "app.common.aceptar";
			etiquetaAceptar.Textos = listaDeTraduccionesAceptar;
			etiquetaAceptar.Activo = true;


			Traduccion traduccionCancelarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "cancelar");
			Traduccion traduccionCancelarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "cancelar");
			Traduccion traduccionCancelarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "cancel");
			Traduccion traduccionCancelarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "cancel");

			listaDeTraduccionesCancelar.Add(traduccionCancelarEs);
			listaDeTraduccionesCancelar.Add(traduccionCancelarEsVe);
			listaDeTraduccionesCancelar.Add(traduccionCancelarEn);
			listaDeTraduccionesCancelar.Add(traduccionCancelarEnUs);

			etiquetaCancelar.IdiomaPorDefecto = "es-VE";
			etiquetaCancelar.Nombre = "app.common.cancelar";
			etiquetaCancelar.Textos = listaDeTraduccionesCancelar;
			etiquetaCancelar.Activo = true;


			listaDeEtiquetas.Add(etiquetaAceptar);
			listaDeEtiquetas.Add(etiquetaCancelar);

			diccionario.Ambiente = "desarrollo";
			diccionario.AgregarEtiquetas(listaDeEtiquetas);
		}

		#region ConsultarEtiquetasDeDiccionarioPorIdioma

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaNoEsNull()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =


			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaNoEsVacio()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =


			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
			respuesta.Relaciones.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaElTipoRespuestaAdecuado()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =


			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =


			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
		}


		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaUnaListaDeEtiquetasNoVacia()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =


			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaRelacionesNoVacia()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =


			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.Relaciones.Count.ShouldNotEqual(0);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaNoRetornaErrores()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =


			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		//[Test]
		//public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaLasEtiquetasEnElIdiomaSolicitado()
		//{
		//	//Arrange
		//	ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

		//	peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");
		//	peticion.Idioma = "es-VE";


		//	ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

		//	//respuesta.ListaDeEtiquetas =
		//	//respuesta.Relaciones =
		//	//respuesta.Respuesta =


		//	//Act
		//	AplicacionServicio serviciosApi = new AplicacionServicio();


		//	respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

		//	List<Etiqueta> listaRespuestaEtiqueta = new List<Etiqueta>();

		//	listaRespuestaEtiqueta = respuesta.ListaDeEtiquetas;

		//	var test = (from T in listaRespuestaEtiqueta
		//				where T.Textos.Count() > 1 
		//				select T.Textos).ToList();

		//	var unSoloIdiomaLista = (from R in test
		//							 where  R.
		//		);

			
			



		//	//Assert

			
		//}

		#endregion
	}
}
