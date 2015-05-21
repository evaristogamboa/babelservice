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
		private const string consultarEtiquetaPorDescripcion = "aceptar";
		private const string consultarEtiquetaPorIdiomaPorDefecto = "es-VE";
		private const bool consultarEtiquetaPorEstatus = true;
		private Guid idEtiquetaAEliminarDosTraducciones = new Guid("9a39ad6d-62c8-42bf-a8f7-66417b2b08d0");

		private Diccionario diccionarioInicialDeLasPruebas;
		private Diccionario diccionarioRespuestaDeAgregarTraducciones;
		private Diccionario diccionarioRespuestaDeModificarTraducciones;
		private Diccionario diccionarioRespuestaDeEliminarTodasLasTraducciones;
		private Diccionario diccionarioRespuestaDeElimnarDosTraducciones;

		private List<Traduccion> listaDeTraduccionesAAgregar = new List<Traduccion>();
		private List<Traduccion> listaDeTraduccionesAModificar = new List<Traduccion>();
		private List<Traduccion> listaDeTraduccionesAEliminar = new List<Traduccion>();

		public AplicacionServicioPruebas() { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			this.diccionarioRepositorio = repositorioMock;


			this.diccionarioRespuestaDeAgregarTraducciones = DiccionarioConTraduccionesDeLaEtiquetaAceptarAgregadas();

			this.diccionarioRespuestaDeModificarTraducciones = DiccionarioConTraduccionesDeLaEtiquetaAceptarModificadas();

			this.diccionarioRespuestaDeEliminarTodasLasTraducciones = DiccionarioConTodasLasTraduccionesDeLaEtiquetaAceptarEliminadas();
			this.diccionarioRespuestaDeElimnarDosTraducciones = DiccionarioConDosTraduccionesDeLaEtiquetaCancelarEliminadas();

		

			this.listaDeTraduccionesAEliminar = TraduccionesAEliminar();
			this.listaDeTraduccionesAModificar = TraduccionesAModificar();
			this.listaDeTraduccionesAAgregar = TraduccionesAAgregar();
		}


		#region Definiciones de diccionarios Mocks

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
			etiquetaAceptar.Descripcion = "Traducciones del botón aceptar.";
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
			etiquetaCancelar.Descripcion = "Traducciones del botón cancelar.";
			etiquetaCancelar.AgregarTraducciones(listaDeTraduccionesCancelar);
			etiquetaCancelar.Activo = true;


			listaDeEtiquetas.Add(etiquetaAceptar);
			listaDeEtiquetas.Add(etiquetaCancelar);

			diccionario.AgregarEtiquetas(listaDeEtiquetas);

			return diccionario;

		}


		private Diccionario DiccionarioConTraduccionesDeLaEtiquetaAceptarAgregadas()
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
			Cultura culturaFr = Cultura.CrearNuevaCultura("fr");
			Cultura culturaFrFr = Cultura.CrearNuevaCultura("fr-FR");

			Traduccion traduccionAceptarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "aceptar");
			Traduccion traduccionAceptarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "aceptar");
			Traduccion traduccionAceptarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "accept");
			Traduccion traduccionAceptarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "accept");
			Traduccion traduccionAceptarFr = Traduccion.CrearNuevaTraduccion(culturaFr, "francés en francés neutral");
			Traduccion traduccionAceptarFrFr = Traduccion.CrearNuevaTraduccion(culturaFrFr, "francés en francés de Francia");

			listaDeTraduccionesAceptar.Add(traduccionAceptarEs);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEsVe);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEn);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEnUs);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFr);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFrFr);

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

			diccionario.AgregarEtiquetas(listaDeEtiquetas);

			return diccionario;

		}

		private Diccionario DiccionarioConTraduccionesDeLaEtiquetaAceptarModificadas()
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
			Cultura culturaFr = Cultura.CrearNuevaCultura("fr");
			Cultura culturaFrFr = Cultura.CrearNuevaCultura("fr-FR");

			Traduccion traduccionAceptarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "aceptar");
			Traduccion traduccionAceptarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "aceptar");
			Traduccion traduccionAceptarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "accept in english neutral");
			Traduccion traduccionAceptarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "accept in english US");
			Traduccion traduccionAceptarFr = Traduccion.CrearNuevaTraduccion(culturaFr, "francés en francés neutral");
			Traduccion traduccionAceptarFrFr = Traduccion.CrearNuevaTraduccion(culturaFrFr, "francés en francés de Francia");

			listaDeTraduccionesAceptar.Add(traduccionAceptarEs);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEsVe);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEn);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEnUs);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFr);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFrFr);

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

			diccionario.AgregarEtiquetas(listaDeEtiquetas);

			return diccionario;

		}

		private Diccionario DiccionarioConTodasLasTraduccionesDeLaEtiquetaAceptarEliminadas()
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

			diccionario.AgregarEtiquetas(listaDeEtiquetas);

			return diccionario;
		}

		private Diccionario DiccionarioConDosTraduccionesDeLaEtiquetaCancelarEliminadas()
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
			etiquetaAceptar.AgregarTraducciones(listaDeTraduccionesAceptar);
			etiquetaAceptar.Activo = true;


			Traduccion traduccionCancelarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "cancelar");
			Traduccion traduccionCancelarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "cancelar");

			listaDeTraduccionesCancelar.Add(traduccionCancelarEs);
			listaDeTraduccionesCancelar.Add(traduccionCancelarEsVe);

			etiquetaCancelar.IdiomaPorDefecto = "es-VE";
			etiquetaCancelar.Nombre = "app.common.cancelar";
			etiquetaCancelar.AgregarTraducciones(listaDeTraduccionesCancelar);
			etiquetaCancelar.Activo = true;


			listaDeEtiquetas.Add(etiquetaAceptar);
			listaDeEtiquetas.Add(etiquetaCancelar);

			diccionario.AgregarEtiquetas(listaDeEtiquetas);

			return diccionario;

		}

		#endregion

        #region Definiciones de traducciones Mocks

		private List<Traduccion> TraduccionesAAgregar()
		{
			List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();

			//Cultura culturaEs = Cultura.CrearNuevaCultura("es");
			//Cultura culturaEsVe = Cultura.CrearNuevaCultura("es-VE");
			Cultura culturaFr = Cultura.CrearNuevaCultura("fr");
			Cultura culturaFrFr = Cultura.CrearNuevaCultura("fr-FR");

			//Traduccion traduccionAceptarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "aceptar");
			//Traduccion traduccionAceptarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "aceptar");
			Traduccion traduccionAceptarFr = Traduccion.CrearNuevaTraduccion(culturaFr, "francés en francés neutral");
			Traduccion traduccionAceptarFrFr = Traduccion.CrearNuevaTraduccion(culturaFrFr, "francés en francés de Francia");

			//listaDeTraduccionesAceptar.Add(traduccionAceptarEs);
			//listaDeTraduccionesAceptar.Add(traduccionAceptarEsVe);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFr);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFrFr);

			return listaDeTraduccionesAceptar;
		}

		private List<Traduccion> TraduccionesAModificar()
		{
			List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();

			Cultura culturaEn = Cultura.CrearNuevaCultura("en");
			Cultura culturaEnUs = Cultura.CrearNuevaCultura("en-US");
			Cultura culturaFr = Cultura.CrearNuevaCultura("fr");
			Cultura culturaFrFr = Cultura.CrearNuevaCultura("fr-FR");

			Traduccion traduccionAceptarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "accept in english neutral");
			Traduccion traduccionAceptarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "accept in english US");
			Traduccion traduccionAceptarFr = Traduccion.CrearNuevaTraduccion(culturaFr, "francés en francés neutral");
			Traduccion traduccionAceptarFrFr = Traduccion.CrearNuevaTraduccion(culturaFrFr, "francés en francés de Francia");

			listaDeTraduccionesAceptar.Add(traduccionAceptarEn);
			listaDeTraduccionesAceptar.Add(traduccionAceptarEnUs);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFr);
			listaDeTraduccionesAceptar.Add(traduccionAceptarFrFr);

			return listaDeTraduccionesAceptar;
		}

		private List<Traduccion> TraduccionesAEliminar()
		{
			List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();

			Cultura culturaEn = Cultura.CrearNuevaCultura("en");
			Cultura culturaEnUs = Cultura.CrearNuevaCultura("en-US");

			Traduccion traduccionCancelarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "cancel");
			Traduccion traduccionCancelarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "cancel");


			listaDeTraduccionesCancelar.Add(traduccionCancelarEn);
			listaDeTraduccionesCancelar.Add(traduccionCancelarEnUs);

			return listaDeTraduccionesCancelar;
		}

		#endregion


		#region Métodos inicializadores de las pruebas (Arrange y Act)

		private ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);

			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;
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
			List<Diccionario> listaDeDiccionarios = new List<Diccionario>();
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			listaDeDiccionarios.Add(this.diccionarioInicialDeLasPruebas);
			this.diccionarioRepositorio.ObtenerDiccionarios().Returns(listaDeDiccionarios);

			ConsultarDiccionariosRespuesta respuesta = ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

           //Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarDiccionarios();

			return respuesta;
		}

		private ConsultarUnDiccionarioarioRespuesta ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);

			ConsultarUnDiccionarioPeticion peticion = ConsultarUnDiccionarioPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;

			ConsultarUnDiccionarioarioRespuesta respuesta = ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(String.Empty);

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarUnDiccionario(peticion);

			return respuesta;
		}

		private ConsultarEtiquetasDeDiccionarioPorNombreRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);

			ConsultarEtiquetasDeDiccionarioPorNombrePeticion peticion = ConsultarEtiquetasDeDiccionarioPorNombrePeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;
			peticion.Nombre = consultarEtiquetaPorNombre;

			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorNombreRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorNombre(peticion);

			return respuesta;
		}

		private ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);

			ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion peticion = ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;
			peticion.Descripcion = consultarEtiquetaPorDescripcion;

			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorDescripcion(peticion);

			return respuesta;
		}

		private ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);

			ConsultarEtiquetasDeDiccionarioPorEstatusPeticion peticion = ConsultarEtiquetasDeDiccionarioPorEstatusPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;
			peticion.Estatus = consultarEtiquetaPorEstatus;

			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorEstatus(peticion);

			return respuesta;
		}

		private ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);

			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;
			peticion.IdiomaPorDefecto = consultarEtiquetaPorIdiomaPorDefecto;

			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto(peticion);

			return respuesta;
		}

		private ConsultarEtiquetasPorNombreRespuesta ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre()
		{
			//Arrange
			List<Diccionario> listaDeDiccionarios = new List<Diccionario>();
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			listaDeDiccionarios.Add(this.diccionarioInicialDeLasPruebas);
			this.diccionarioRepositorio.ObtenerDiccionarios().Returns(listaDeDiccionarios);

			ConsultarEtiquetasPorNombrePeticion peticion = ConsultarEtiquetasPorNombrePeticion.CrearNuevaInstancia();

			peticion.Nombre = consultarEtiquetasPorNombre;

			ConsultarEtiquetasPorNombreRespuesta respuesta = ConsultarEtiquetasPorNombreRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ConsultarEtiquetasPorNombre(peticion);

			return respuesta;
		}

		private AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
			this.diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDeAgregarTraducciones);

			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion = AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = this.diccionarioInicialDeLasPruebas.Id;
			peticion.EtiquetaId = this.diccionarioInicialDeLasPruebas.Etiquetas.FirstOrDefault().Id;
			peticion.ListaDeTraducciones = this.listaDeTraduccionesAAgregar;

			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.AgregarTraduccionesAUnaEtiquetaDeUnDiccionario(peticion);

			return respuesta;
		}

		private ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
			this.diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDeModificarTraducciones);

			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion = ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = this.diccionarioInicialDeLasPruebas.Id;
			peticion.EtiquetaId = this.diccionarioInicialDeLasPruebas.Etiquetas.FirstOrDefault().Id;
			peticion.ListaDeTraducciones = this.listaDeTraduccionesAModificar;

			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.ModificarTraduccionesAUnaEtiquetaDeUnDiccionario(peticion);

			return respuesta;
		}

		private EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionario()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
			this.diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDeEliminarTodasLasTraducciones);

			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion = EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = this.diccionarioInicialDeLasPruebas.Id;
			peticion.EtiquetaId = this.diccionarioInicialDeLasPruebas.Etiquetas.FirstOrDefault().Id;
			peticion.ListaDeTraducciones = this.diccionarioInicialDeLasPruebas.Etiquetas.FirstOrDefault().Textos.ToList<Traduccion>();
			
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.EliminarTraduccionesAUnaEtiquetaDeUnDiccionario(peticion);

			return respuesta;
		}

		private EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionario()
		{
			//Arrange
			this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
			this.diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDeElimnarDosTraducciones);

			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion = EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = this.diccionarioInicialDeLasPruebas.Id;
			peticion.EtiquetaId = idEtiquetaAEliminarDosTraducciones;
			peticion.ListaDeTraducciones = this.listaDeTraduccionesAEliminar;

			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

			respuesta = serviciosApi.EliminarTraduccionesAUnaEtiquetaDeUnDiccionario(peticion);

			return respuesta;
		}

		#endregion


		#region Pruebas de todos los métodos de consultar


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
			respuesta.Diccionario.Id.ShouldNotEqual(Guid.Empty);
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

		[Test]
		public void PruebaDeConsultarUnDiccionarioRetornaRelacionesContienenGuidsNoVacios()
		{
			ConsultarUnDiccionarioarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeConsultarUnDiccionarioRetornaLasEtiquetasDelDiccionarioSolicitado()
		{
			ConsultarUnDiccionarioarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarUnDiccionario();

			Guid relacionesDiccionarioId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
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

			bool diccionarioCorrecto = true;

			foreach (Diccionario itemDiccionario in respuesta.ListaDeDiccionarios)
			{
				if (itemDiccionario.Etiquetas.Where(e => e.Nombre.Contains(consultarEtiquetasPorNombre)).Count() != itemDiccionario.Etiquetas.Count())
				{
					diccionarioCorrecto = false;
					break;
				}
			}

			//Assert
			respuesta.ListaDeDiccionarios.Count().ShouldEqual(1);
			diccionarioCorrecto.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasPorNombreRetornaUnDiccionarioConDosEtiquetas()
		{
			ConsultarEtiquetasPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasPorNombre();

			//Assert
			respuesta.ListaDeDiccionarios[0].Etiquetas.Count().ShouldEqual(2);
		}

		#endregion


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
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaRelacionesContienenGuidsNoVacios()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			//Assert
			noContieneVacio.ShouldBeTrue();
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

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaLasEtiquetasDelDiccionarioSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdioma();

			Guid relacionesDiccionarioId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
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
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreRetornaRelacionesContienenGuidsNoVacios()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
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
			respuesta.ListaDeEtiquetas.Where(e => e.Nombre.Contains(consultarEtiquetaPorNombre)).Count().ShouldEqual(respuesta.ListaDeEtiquetas.Count());
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorNombreRetornaLasEtiquetasDelDiccionarioSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorNombreRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorNombre();

			Guid relacionesDiccionarioId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
		}

		#endregion


		#region ConsultarEtiquetasDeDiccionarioPorDescripcion

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionNoEsNull()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionNoEsVacio()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
			respuesta.Relaciones.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionRetornaElTipoRespuestaAdecuado()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionRetornaUnaListaDeEtiquetasNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);

		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionRetornaRelacionesNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.Relaciones.Count.ShouldNotEqual(0);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionRetornaRelacionesContienenGuidsNoVacios()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionNoRetornaErrores()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionRetornaLasEtiquetasConLaDescripcionSolicitada()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			//Assert
			respuesta.ListaDeEtiquetas.Count().ShouldEqual(1);
			respuesta.ListaDeEtiquetas.Where(e => e.Descripcion.Contains(consultarEtiquetaPorDescripcion)).Count().ShouldEqual(respuesta.ListaDeEtiquetas.Count());
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorDescripcionRetornaLasEtiquetasDelDiccionarioSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorDescripcion();

			Guid relacionesDiccionarioId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
		}

		#endregion


		#region ConsultarEtiquetasDeDiccionarioPorEstatus

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusNoEsNull()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusNoEsVacio()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
			respuesta.Relaciones.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusRetornaElTipoRespuestaAdecuado()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusRetornaUnaListaDeEtiquetasNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);

		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusRetornaRelacionesNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.Relaciones.Count.ShouldNotEqual(0);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusRetornaRelacionesContienenGuidsNoVacios()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusNoRetornaErrores()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusRetornaLasEtiquetasConLaDescripcionSolicitada()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			//Assert
			respuesta.ListaDeEtiquetas.Count().ShouldEqual(2);
			respuesta.ListaDeEtiquetas.Where(e => e.Activo.Equals(consultarEtiquetaPorEstatus)).Count().ShouldEqual(respuesta.ListaDeEtiquetas.Count());
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorEstatusRetornaLasEtiquetasDelDiccionarioSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorEstatus();

			Guid relacionesDiccionarioId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
		}

		#endregion


		#region ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoNoEsNull()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoNoEsVacio()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);
			respuesta.Relaciones.Count.ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRetornaElTipoRespuestaAdecuado()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.ShouldBeType(typeof(ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRetornaUnaListaDeEtiquetasNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.ListaDeEtiquetas.Count.ShouldNotEqual(0);

		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRetornaRelacionesNoVacia()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.Relaciones.Count.ShouldNotEqual(0);
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRetornaRelacionesContienenGuidsNoVacios()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoNoRetornaErrores()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRetornaLasEtiquetasConElIdiomaPorDefectoSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			//Assert
			respuesta.ListaDeEtiquetas.Count().ShouldEqual(2);
			respuesta.ListaDeEtiquetas.Where(e => e.IdiomaPorDefecto.Contains(consultarEtiquetaPorIdiomaPorDefecto)).Count().ShouldEqual(respuesta.ListaDeEtiquetas.Count());
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRetornaLasEtiquetasDelDiccionarioSolicitado()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto();

			Guid relacionesDiccionarioId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
		}

		#endregion

		#endregion


		#region Pruebas de agregar, eliminar y modificar traducciones a una etiqueta de un diccionario

		#region AgregarTraduccionesAUnaEtiquetaDeUnDiccionario

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioNoEsNull()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioNoEsVacio()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.Count().ShouldBeGreaterThan(0);
			respuesta.Relaciones.Count().ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaElTipoRespuestaAdecuado()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ShouldBeType(typeof(AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta));
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaUnaListaDeTraduccionesDelTipoListaTraducciones()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.ShouldBeType(typeof(List<Traduccion>));
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaUnaListaDeTraduccionesQueNoEsVacia()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.Count().ShouldBeGreaterThan(0);
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioNoRetornaErrores()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaRelacionesContienenGuidsNoVacios()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaLosValoresDeRelacionesCorrectos()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			Guid relacionesDiccionarioId = Guid.Empty;
			Guid relacionesEtiquetaId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}

				if (item.Key == "etiqueta")
				{
					relacionesEtiquetaId = item.Value;
				}
			}
			
			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
			relacionesEtiquetaId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Etiquetas.FirstOrDefault().Id);
		}

		[Test]
		public void PruebaDeAgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaLosValoresAgregadosALaListaDeTraducciones()
		{
			AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			bool traduccionesAgregadas = true;

			foreach (Traduccion itemTraduccion in this.listaDeTraduccionesAAgregar)
			{
				if (!(respuesta.ListaDeTraducciones.Contains(itemTraduccion)))
				{
					traduccionesAgregadas = false;
					break;
				}
			}

			//Assert
			traduccionesAgregadas.ShouldBeTrue();
		}

		#endregion


		#region ModificarTraduccionesAUnaEtiquetaDeUnDiccionario

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioNoEsNull()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioNoEsVacio()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.Count().ShouldBeGreaterThan(0);
			respuesta.Relaciones.Count().ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaElTipoRespuestaAdecuado()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ShouldBeType(typeof(ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta));
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaUnaListaDeTraduccionesDelTipoListaTraducciones()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.ShouldBeType(typeof(List<Traduccion>));
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaUnaListaDeTraduccionesQueNoEsVacia()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.Count().ShouldBeGreaterThan(0);
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioNoRetornaErrores()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaRelacionesContienenGuidsNoVacios()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaLosValoresDeRelacionesCorrectos()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			Guid relacionesDiccionarioId = Guid.Empty;
			Guid relacionesEtiquetaId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}

				if (item.Key == "etiqueta")
				{
					relacionesEtiquetaId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
			relacionesEtiquetaId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Etiquetas.FirstOrDefault().Id);
		}

		[Test]
		public void PruebaDeModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaLosValoresModificadosDeLaListaDeTraducciones()
		{
			ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeModificarLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			bool traduccionesModificadas = true;

			foreach (Traduccion itemTraduccion in this.listaDeTraduccionesAModificar)
			{
				if (!(respuesta.ListaDeTraducciones.Contains(itemTraduccion)))
				{
					traduccionesModificadas = false;
					break;
				}
			}

			//Assert
			traduccionesModificadas.ShouldBeTrue();
		}

		#endregion


		#region EliminarTraduccionesAUnaEtiquetaDeUnDiccionario

		[Test]
		public void PruebaDeEliminarTraduccionesAUnaEtiquetaDeUnDiccionarioNoEsNull()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ShouldNotBeNull();
		}

		[Test]
		public void PruebaDeEliminarTraduccionesAUnaEtiquetaDeUnDiccionarioNoEsVacio()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.Count().ShouldBeGreaterThanOrEqualTo(0);
			respuesta.Relaciones.Count().ShouldNotEqual(0);
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeEliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaElTipoRespuestaAdecuado()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ShouldBeType(typeof(EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta));
		}

		[Test]
		public void PruebaDeEliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaUnaListaDeTraduccionesDelTipoListaTraducciones()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.ShouldBeType(typeof(List<Traduccion>));
		}

		[Test]
		public void PruebaDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaUnaListaDeEtiquetasVacia()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.Count.ShouldEqual(0);

		}

		[Test]
		public void PruebaDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaUnaListaDeEtiquetasQueNoEsVacia()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.ListaDeTraducciones.Count().ShouldEqual(2);
		}

		[Test]
		public void PruebaDeEliminarTraduccionesAUnaEtiquetaDeUnDiccionarioNoRetornaErrores()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeEliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaRelacionesContienenGuidsNoVacios()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionario();

			//Assert
			bool noContieneVacio = true;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Value == Guid.Empty)
				{
					noContieneVacio = false;
					break;
				}
			}

			noContieneVacio.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaLosValoresDeRelacionesCorrectos()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionario();

			Guid relacionesDiccionarioId = Guid.Empty;
			Guid relacionesEtiquetaId = Guid.Empty;

			foreach (KeyValuePair<string, Guid> item in respuesta.Relaciones)
			{
				if (item.Key == "diccionario")
				{
					relacionesDiccionarioId = item.Value;
				}

				if (item.Key == "etiqueta")
				{
					relacionesEtiquetaId = item.Value;
				}
			}

			//Assert
			relacionesDiccionarioId.ShouldEqual(this.diccionarioInicialDeLasPruebas.Id);
			relacionesEtiquetaId.ShouldEqual(idEtiquetaAEliminarDosTraducciones);
		}

		[Test]
		public void PruebaDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionarioNoRetornaLosValoresEliminadosDeLaListaDeTraducciones()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarDosTraduccionesAUnaEtiquetaDeUnDiccionario();

			bool traduccionesEliminadas = true;

			foreach (Traduccion itemTraduccion in this.listaDeTraduccionesAEliminar)
			{
				if (respuesta.ListaDeTraducciones.Contains(itemTraduccion))
				{
					traduccionesEliminadas = false;
					break;
				}
			}

			//Assert
			traduccionesEliminadas.ShouldBeTrue();
		}

		[Test]
		public void PruebaDeEliminarTodasTraduccionesAUnaEtiquetaDeUnDiccionarioRetornaLaListaDeTraduccionesVacia()
		{
			EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeEliminarTodasLasTraduccionesAUnaEtiquetaDeUnDiccionario();

			bool traduccionesEliminadas = true;

			foreach (Traduccion itemTraduccion in (this.diccionarioInicialDeLasPruebas.Etiquetas.FirstOrDefault().Textos.ToList<Traduccion>()))
			{
				if (respuesta.ListaDeTraducciones.Contains(itemTraduccion))
				{
					traduccionesEliminadas = false;
					break;
				}
			}

			//Assert
			traduccionesEliminadas.ShouldBeTrue();
			respuesta.ListaDeTraducciones.Count().ShouldEqual(0);
		}

		#endregion

		#endregion
	}
}