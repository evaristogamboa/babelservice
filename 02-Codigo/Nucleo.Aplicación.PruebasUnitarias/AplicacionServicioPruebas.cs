using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Repositorios;
using NUnit.Framework;
using Should;
using Babel.Nucleo.Aplicacion.Servicios;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using NSubstitute;
using Newtonsoft.Json;
using NSubstitute.Core;

namespace Babel.Nucleo.Aplicación.PruebasUnitarias
{
	[TestFixture]
	public class AplicacionServicioPruebas
	{
		private IDiccionarioRepositorio diccionarioRepositorio;

		private const string ambienteTestPrueba = "desarrollo";
		private const string consultarDiccionarioPorIdioma = "en-US";
		private const string consultarEtiquetaPorNombre = "cancelar";
		private const string consultarEtiquetasPorNombre = "app";

		private Diccionario diccionarioPrueba;
		private List<Diccionario> listaDeDiccionarios = new List<Diccionario>();

		public AplicacionServicioPruebas() { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			this.diccionarioRepositorio = repositorioMock;
			this.diccionarioPrueba = InicializarDiccionario();

			this.listaDeDiccionarios.Add(this.diccionarioPrueba);

			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioPrueba.Id).Returns(diccionarioPrueba);
			this.diccionarioRepositorio.ObtenerDiccionarios().Returns(this.listaDeDiccionarios);
		}

		private Diccionario InicializarDiccionario()
		{
			// Primer diccionario
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
			etiquetaAceptar.AgregarTraducciones(listaDeTraduccionesAceptar);
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
			etiquetaCancelar.AgregarTraducciones(listaDeTraduccionesCancelar);
			etiquetaCancelar.Activo = true;


			listaDeEtiquetas.Add(etiquetaAceptar);
			listaDeEtiquetas.Add(etiquetaCancelar);

			diccionario.Ambiente = "desarrollo";
			diccionario.AgregarEtiquetas(listaDeEtiquetas);

			return diccionario;

		}

		private ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = consultarDiccionarioPorIdioma;

			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			return respuesta;
		}

		private ConsultarDiccionariosRespuesta ArrangeYActDeTodasLasPruebasDeConsultarDiccionarios()
		{
			//Arrange
			ConsultarDiccionariosRespuesta respuesta = ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

           //Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarDiccionarios();

			return respuesta;
		}

		private ConsultarUnDiccionarioarioRespuesta ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario()
		{
			//Arrange
			ConsultarUnDiccionarioPeticion peticion = ConsultarUnDiccionarioPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioPrueba.Id;

			ConsultarUnDiccionarioarioRespuesta respuesta = ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(String.Empty);

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarUnDiccionario(peticion);

			return respuesta;
		}

		private ConsultarEtiquetasDeDiccionarioPorNombreRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorNombrePeticion peticion = ConsultarEtiquetasDeDiccionarioPorNombrePeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Nombre = consultarEtiquetaPorNombre;

			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorNombreRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorNombre(peticion);

			return respuesta;
		}

		private ConsultarEtiquetasPorNombreRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre()
		{
			//Arrange
			ConsultarEtiquetasPorNombrePeticion peticion = ConsultarEtiquetasPorNombrePeticion.CrearNuevaInstancia();

			peticion.Nombre = consultarEtiquetasPorNombre;

			ConsultarEtiquetasPorNombreRespuesta respuesta = ConsultarEtiquetasPorNombreRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasPorNombre(peticion);

			return respuesta;
		}


		#region ConsultarEtiquetasDeDiccionarioPorIdioma

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaNoEsNull()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaNoEsVacio()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
			respuesta.Relaciones.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaElTipoRespuestaAdecuado()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			//Assert
			respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaUnaListaDeEtiquetasNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
			
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaRelacionesNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			//Assert
			respuesta.Relaciones.Count.ShouldNotEqual(0);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaNoRetornaErrores()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaLasEtiquetasEnElIdiomaSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			Boolean traduccionDiferenteDelIdioma = false;

			foreach (Etiqueta item in respuesta.ListaDeEtiquetas)
			{
				foreach (Traduccion tra in item.Textos)
				{
					if (tra.Cultura.CodigoIso != consultarDiccionarioPorIdioma)
					{
						traduccionDiferenteDelIdioma = true;
						break;
					}
				}
			}

			//Assert
			traduccionDiferenteDelIdioma.ShouldBeFalse();

		}

		#endregion


		#region ConsultarDiccionarios

		[Test]
		public void PruebaDeConsultarDiccionariosNoEsNull()
		{
			ConsultarDiccionariosRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarDiccionarios();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarDiccionariosNoEsVacio()
		{
			ConsultarDiccionariosRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarDiccionarios();

			//Assert
			respuesta.ListaDeDiccionarios.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarDiccionariosNoRetornaErrores()
		{
			ConsultarDiccionariosRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarDiccionarios();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarDiccionariosRetornaElTipoRespuestaAdecuado()
		{
			ConsultarDiccionariosRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarDiccionarios();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarDiccionariosRespuesta));
		}

		[Test]
		public void PruebaDeConsultarDiccionariosRetornaUnaListaDeDiccionariosDelTipoListaDiccionario()
		{
			ConsultarDiccionariosRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarDiccionarios();

			//Assert
			respuesta.ListaDeDiccionarios.ShouldBeType(typeof(List<Diccionario>));
		}

		[Test]
		public void PruebaDeConsultarDiccionariosRetornaUnaListaDeDiccionariosNoVacia()
		{
			ConsultarDiccionariosRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarDiccionarios();

			//Assert
			respuesta.ListaDeDiccionarios.Count.ShouldNotEqual(0);
		}

		#endregion


		#region ConsultarUnDiccionario

		[Test]
		public void PruebaDeConsultarUnDiccionarioNoEsNull()
		{
			ConsultarUnDiccionarioarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarUnDiccionarioNoEsVacio()
		{
			ConsultarUnDiccionarioarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario();

			//Assert
			//respuesta.Diccionario.Id.ShouldNotBeNull();
			respuesta.Relaciones.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarUnDiccionarioNoRetornaErrores()
		{
			ConsultarUnDiccionarioarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarUnDiccionarioRetornaElTipoRespuestaAdecuado()
		{
			ConsultarUnDiccionarioarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarUnDiccionarioarioRespuesta));
		}

		[Test]
		public void PruebaDeConsultarUnDiccionarioRetornaUnDiccionarioDelTipoDiccionario()
		{
			ConsultarUnDiccionarioarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario();

			//Assert
			respuesta.Diccionario.ShouldBeType(typeof(Diccionario));
		}

		#endregion


		#region ConsultarEtiquetasDeDiccionarioPorNombre

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreNoEsNull()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreNoEsVacio()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
			respuesta.Relaciones.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreRetornaElTipoRespuestaAdecuado()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarEtiquetasDeDiccionarioPorNombreRespuesta));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreRetornaUnaListaDeEtiquetasNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);

		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreRetornaRelacionesNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.Relaciones.Count.ShouldNotEqual(0);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreNoRetornaErrores()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreRetornaLasEtiquetasConElNombreSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			respuesta.ListaDeEtiquetas.Count().ShouldEqual(1);
		}

		#endregion


		#region ConsultarEtiquetasPorNombre

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreNoEsNull()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreNoEsVacio()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ListaDeDiccionarios.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreRetornaElTipoRespuestaAdecuado()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarEtiquetasPorNombreRespuesta));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ListaDeDiccionarios.ShouldBeType(typeof(List<Diccionario>));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreRetornaUnaListaDeEtiquetasNoVacia()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ListaDeDiccionarios.Count.ShouldNotEqual(0);

		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreNoRetornaErrores()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreRetornaUnDiccionarioConLasEtiquetasConElNombreSolicitado()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ListaDeDiccionarios.Count().ShouldEqual(1);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreRetornaUnDiccionarioConDosEtiquetas()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ListaDeDiccionarios[0].Etiquetas.Count().ShouldEqual(2);
		}


		#endregion
	}
}