using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Repositorios;
using NUnit.Framework;
using Should;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Aplicacion.Servicios;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using NSubstitute;

namespace Babel.Nucleo.Aplicación.PruebasUnitarias
{
    [TestFixture]
    public class AplicacionServicioMantenimientoPruebas
    {
        private IDiccionarioRepositorio diccionarioRepositorio;
        private IDiccionarioRepositorio diccionarioRepositorioModificado;
		private const string ambienteTestPrueba = "desarrollo";
        private const string ambienteModificado = "ambienteModificado";

        private const string ambienteNuevoDiccionario = "Prueba de crear un nuevo diccionario.";
		private Diccionario diccionarioPrueba;
        private Diccionario nuevodiccionario;
        private Diccionario modificarDiccionario;
        private Diccionario diccionarioRespuestaDeCrearUnDiccionario;
        private Diccionario diccionarioRespuestaDeAgregarEtiquetas;
        private Diccionario diccionarioRespuestaDiccionarioEliminado;
        private Diccionario diccionarioRespuestaDiccionarioModificado;
        private Diccionario diccionarioRespuestaEliminarEtiquetasDiccionario;
        private Diccionario diccionarioInicialDeLasPruebas;
		private string nombreIdioma = "en-US";
		private List<Diccionario> listaDeDiccionarios = new List<Diccionario>();
        private List<Etiqueta> listaDeEtiquetasAAgregar = new List<Etiqueta>();

		public AplicacionServicioMantenimientoPruebas()
        { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			diccionarioRepositorio = repositorioMock;
		    diccionarioRespuestaDiccionarioEliminado = DiccionarioVacio();
		    diccionarioRespuestaDiccionarioModificado = DiccionarioModificado();
            diccionarioRespuestaEliminarEtiquetasDiccionario = DiccionarioConUnaEtiquetaEliminada();
            diccionarioRepositorioModificado = repositorioMock;
			diccionarioPrueba = InicializarDiccionario();
		    nuevodiccionario = DiccionarioNuevoCreado();
            //modificarDiccionario = DiccionarioModificado();

            this.diccionarioRespuestaDeCrearUnDiccionario = DiccionarioNuevoCreado();

            this.diccionarioRespuestaDeAgregarEtiquetas = DiccionarioConDosEtiquetasAgregadas();


			listaDeDiccionarios.Add(diccionarioPrueba);

			diccionarioRepositorio.ObtenerUnDiccionario(diccionarioPrueba.Id).Returns(diccionarioPrueba);
			diccionarioRepositorio.ObtenerDiccionarios().Returns(listaDeDiccionarios);

            listaDeEtiquetasAAgregar = EtiquetasAAgregar();

            // Eliminar y Guardar (Modifica)
		    diccionarioRepositorio.SalvarUnDiccionario(diccionarioPrueba).Returns(nuevodiccionario);
		    diccionarioRepositorioModificado.SalvarUnDiccionario(diccionarioPrueba).Returns(modificarDiccionario);
        }


        #region Diccionarios Mocks

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

        private Diccionario DiccionarioVacio()
        {
            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(Guid.Empty, "");
            return diccionario;
        }
        
        private Diccionario DiccionarioModificado()
        {
            // Primer diccionario
            List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

            List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), ambienteModificado);

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

        private Diccionario DiccionarioConUnaEtiquetaEliminada()
        {
            // Primer diccionario
            List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

            List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), ambienteTestPrueba);

            Etiqueta etiquetaAceptar = Etiqueta.CrearNuevaEtiqueta(new Guid("8a87f8a7-3df9-4d90-9478-350b964fc888"));

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
            
            listaDeEtiquetas.Add(etiquetaAceptar);

            diccionario.Ambiente = "desarrollo";
            diccionario.AgregarEtiquetas(listaDeEtiquetas);

            return diccionario;
        }


        private Diccionario DiccionarioNuevoCreado()
        {
            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("5e8e86f5-5845-4dd4-998a-0689ae10c8e9"), ambienteNuevoDiccionario);

            return diccionario;

        }

        private Diccionario DiccionarioConDosEtiquetasAgregadas()
        {
            // Primer diccionario
            List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

            List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesEditar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesEliminar = new List<Traduccion>();

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), ambienteTestPrueba);

            Etiqueta etiquetaAceptar = Etiqueta.CrearNuevaEtiqueta(new Guid("8a87f8a7-3df9-4d90-9478-350b964fc888"));
            Etiqueta etiquetaCancelar = Etiqueta.CrearNuevaEtiqueta(new Guid("9a39ad6d-62c8-42bf-a8f7-66417b2b08d0"));
            Etiqueta etiquetaEditar = Etiqueta.CrearNuevaEtiqueta(new Guid("0260b80b-4ac6-40a6-b5eb-b57916eaab2b"));
            Etiqueta etiquetaEliminar = Etiqueta.CrearNuevaEtiqueta(new Guid("e2850768-35df-46bb-8f79-48b06ba45528"));

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


            Traduccion traduccionEditarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "Editar");
            Traduccion traduccionEditarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "Editar");
            Traduccion traduccionEditarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "Edit");
            Traduccion traduccionEditarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "Edit");

            listaDeTraduccionesEditar.Add(traduccionEditarEs);
            listaDeTraduccionesEditar.Add(traduccionEditarEsVe);
            listaDeTraduccionesEditar.Add(traduccionEditarEn);
            listaDeTraduccionesEditar.Add(traduccionEditarEnUs);

            etiquetaEditar.IdiomaPorDefecto = "es-VE";
            etiquetaEditar.Nombre = "app.common.editar";
            etiquetaEditar.AgregarTraducciones(listaDeTraduccionesEditar);
            etiquetaEditar.Activo = true;


            Traduccion traduccionEliminarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "Editar");
            Traduccion traduccionEliminarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "Editar");
            Traduccion traduccionEliminarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "Edit");
            Traduccion traduccionEliminarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "Edit");

            listaDeTraduccionesEliminar.Add(traduccionEliminarEs);
            listaDeTraduccionesEliminar.Add(traduccionEliminarEsVe);
            listaDeTraduccionesEliminar.Add(traduccionEliminarEn);
            listaDeTraduccionesEliminar.Add(traduccionEliminarEnUs);

            etiquetaEliminar.IdiomaPorDefecto = "es-VE";
            etiquetaEliminar.Nombre = "app.common.eliminar";
            etiquetaEliminar.AgregarTraducciones(listaDeTraduccionesEliminar);
            etiquetaEliminar.Activo = true;


            listaDeEtiquetas.Add(etiquetaAceptar);
            listaDeEtiquetas.Add(etiquetaCancelar);
            listaDeEtiquetas.Add(etiquetaEditar);
            listaDeEtiquetas.Add(etiquetaEliminar);

            diccionario.AgregarEtiquetas(listaDeEtiquetas);

            return diccionario;

        }

        #endregion

        #region Definiciones de Etiquetas Mock
        
        private List<Etiqueta> ListaDeEtiquetaAEliminar()
        {
            List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();
            List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();

            Etiqueta etiquetaCancelar = Etiqueta.CrearNuevaEtiqueta(new Guid("9a39ad6d-62c8-42bf-a8f7-66417b2b08d0"));

            Cultura culturaEs = Cultura.CrearNuevaCultura("es");
            Cultura culturaEsVe = Cultura.CrearNuevaCultura("es-VE");
            Cultura culturaEn = Cultura.CrearNuevaCultura("en");
            Cultura culturaEnUs = Cultura.CrearNuevaCultura("en-US");

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
            listaDeEtiquetas.Add(etiquetaCancelar);

            return listaDeEtiquetas;
        }

        private List<Etiqueta> EtiquetasAAgregar()
        {
            List<Etiqueta> listaDeEtiquetasAAgregar = new List<Etiqueta>();
            List<Traduccion> listaDeTraduccionesEditar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesEliminar = new List<Traduccion>();

            Etiqueta etiquetaEditar = Etiqueta.CrearNuevaEtiqueta(new Guid("0260b80b-4ac6-40a6-b5eb-b57916eaab2b"));
            Etiqueta etiquetaEliminar = Etiqueta.CrearNuevaEtiqueta(new Guid("e2850768-35df-46bb-8f79-48b06ba45528"));

            Cultura culturaEs = Cultura.CrearNuevaCultura("es");
            Cultura culturaEsVe = Cultura.CrearNuevaCultura("es-VE");
            Cultura culturaEn = Cultura.CrearNuevaCultura("en");
            Cultura culturaEnUs = Cultura.CrearNuevaCultura("en-US");

            Traduccion traduccionEditarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "Editar");
            Traduccion traduccionEditarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "Editar");
            Traduccion traduccionEditarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "Edit");
            Traduccion traduccionEditarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "Edit");

            listaDeTraduccionesEditar.Add(traduccionEditarEs);
            listaDeTraduccionesEditar.Add(traduccionEditarEsVe);
            listaDeTraduccionesEditar.Add(traduccionEditarEn);
            listaDeTraduccionesEditar.Add(traduccionEditarEnUs);

            etiquetaEditar.IdiomaPorDefecto = "es-VE";
            etiquetaEditar.Nombre = "app.common.editar";
            etiquetaEditar.AgregarTraducciones(listaDeTraduccionesEditar);
            etiquetaEditar.Activo = true;


            Traduccion traduccionEliminarEs = Traduccion.CrearNuevaTraduccion(culturaEs, "Editar");
            Traduccion traduccionEliminarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "Editar");
            Traduccion traduccionEliminarEn = Traduccion.CrearNuevaTraduccion(culturaEn, "Edit");
            Traduccion traduccionEliminarEnUs = Traduccion.CrearNuevaTraduccion(culturaEnUs, "Edit");

            listaDeTraduccionesEliminar.Add(traduccionEliminarEs);
            listaDeTraduccionesEliminar.Add(traduccionEliminarEsVe);
            listaDeTraduccionesEliminar.Add(traduccionEliminarEn);
            listaDeTraduccionesEliminar.Add(traduccionEliminarEnUs);

            etiquetaEliminar.IdiomaPorDefecto = "es-VE";
            etiquetaEliminar.Nombre = "app.common.eliminar";
            etiquetaEliminar.AgregarTraducciones(listaDeTraduccionesEliminar);
            etiquetaEliminar.Activo = true;

            listaDeEtiquetasAAgregar.Add(etiquetaEditar);
            listaDeEtiquetasAAgregar.Add(etiquetaEliminar);

            return listaDeEtiquetasAAgregar;
        }

        #endregion



        //private Diccionario DiccionarioModificado()
        //{

        //    Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), "pruebaaa");

        //    return diccionario;

        //}


        #region ArrangeYAct

        private CrearUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeCrearUnDiccionario()
        {
            //Arrange
            this.diccionarioRepositorio.SalvarUnDiccionario(diccionarioRespuestaDeCrearUnDiccionario).Returns(diccionarioRespuestaDeCrearUnDiccionario);

            CrearUnDiccionarioPeticion peticion = CrearUnDiccionarioPeticion.CrearNuevaInstancia(ambienteNuevoDiccionario);

            peticion.Ambiente = ambienteNuevoDiccionario;

            CrearUnDiccionarioRespuesta respuesta = CrearUnDiccionarioRespuesta.CrearNuevaInstancia(ambienteNuevoDiccionario);

            //Act
            AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

            respuesta = serviciosApi.CrearUnDiccionario(peticion);

            return respuesta;
        }

        private AgregarEtiquetasAUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta()
        {
            //Arrange
            this.diccionarioInicialDeLasPruebas = InicializarDiccionario();
            this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
            this.diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDeAgregarEtiquetas);

            AgregarEtiquetasAUnDiccionarioPeticion peticion = AgregarEtiquetasAUnDiccionarioPeticion.CrearNuevaInstancia();

            peticion.DiccionarioId = this.diccionarioInicialDeLasPruebas.Id;
            peticion.ListaDeEtiquetas = this.listaDeEtiquetasAAgregar;

            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = AgregarEtiquetasAUnDiccionarioRespuesta.CrearNuevaInstancia();

            //Act
            AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);

            respuesta = serviciosApi.AgregarEtiquetasAUnDiccionario(peticion);

            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ModificarUnDiccionarioRespuesta ArrangeYActModificarDiccionario()
        {
            //Arrange
            diccionarioInicialDeLasPruebas = InicializarDiccionario();
            diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
            diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDiccionarioModificado);

            var peticion = ModificarUnDiccionarioPeticion.CrearNuevaInstancia(string.Empty);
            peticion.Diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), ambienteModificado);

            //Act
            AplicacionServicio servicio = new AplicacionServicio(diccionarioRepositorio);
            var respuesta = servicio.ModificarUnDiccionario(peticion);
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private EliminarUnDiccionarioRespuesta ArrangeYActEliminarUnDiccionario()
        {
            //Arrange
            diccionarioInicialDeLasPruebas = InicializarDiccionario();
            diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
            diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDiccionarioEliminado);

            EliminarUnDiccionarioPeticion peticion = EliminarUnDiccionarioPeticion.CrearNuevaInstancia();
            peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;

            //Act
            AplicacionServicio serviciosApi = new AplicacionServicio(diccionarioRepositorio);
            var respuesta = serviciosApi.EliminarUnDiccionario(peticion);
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private EliminarEtiquetasAUnDiccionarioRespuesta ArrangeYActEliminarEtiquetasAUnDiccionario()
        {
            //Arrange
            diccionarioInicialDeLasPruebas = InicializarDiccionario();
            diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
            diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaEliminarEtiquetasDiccionario);

            EliminarEtiquetasAUnDiccionarioPeticion peticion = EliminarEtiquetasAUnDiccionarioPeticion.CrearNuevaInstancia();
            peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;
            peticion.ListaDeEtiquetas = ListaDeEtiquetaAEliminar();

            //Act
            AplicacionServicio serviciosApi = new AplicacionServicio(diccionarioRepositorio);
            var respuesta = serviciosApi.EliminarEtiquetasAUnDiccionario(peticion);
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ModificarEtiquetasAUnDiccionarioRespuesta ArrangeYActModificarEtiquetasAUnDiccionario()
        {
            //Arrange
            var peticion = ModificarEtiquetasAUnDiccionarioPeticion.CrearNuevaInstancia();
            var diccionario = InicializarDiccionario();

            peticion.DiccionarioId = diccionario.Id;
            peticion.ListaDeEtiquetas = new List<Etiqueta>();
            peticion.ListaDeEtiquetas.AddRange(diccionario.Etiquetas);

            peticion.ListaDeEtiquetas[0].Nombre = "App.YCM.New_0";
            peticion.ListaDeEtiquetas[1].Nombre = "App.YCM.New_1";

            //Act
            AplicacionServicio servicio = new AplicacionServicio(diccionarioRepositorio);
            var respuesta = servicio.ModificarEtiquetasAUnDiccionario(peticion);
            return respuesta;
        }

        #endregion

        #region PRUEBAS UNITARIAS

        #region Crear Diccionario

        [Test]
        public void PruebaDeCrearUnDiccionarioNoEsNull()
        {
            CrearUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeCrearUnDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }
        
        #endregion

        #region Modificar Diccionario

        /// <summary>
        /// Valida que la respuesta que retorna sea de tipo ModificarUnDiccionarioRespuesta
        /// </summary>
        [Test]
        public void PruebaModificarAmbienteDiccionarioRetornaElTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(ModificarUnDiccionarioRespuesta));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarDiccionarioNoRetornaNulo()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarDiccionarioRetornaRelacionesNoVacia()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.Relaciones.Count.ShouldNotEqual(0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarDiccionarioRetornaRespuestaNula()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.Respuesta.ShouldBeNull();
        }

        #endregion

        #region Eliminar Diccionario

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaEliminarDiccionarioNoEsNull()
        {
            var respuesta = ArrangeYActEliminarUnDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaEliminarDiccionarioRetornaTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActEliminarUnDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(EliminarUnDiccionarioRespuesta));
        }

        #endregion

        #region Agregar Etiquetas A Un Diccionario

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioNoEsNull()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioNoEsVacio()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ListaDeEtiquetas.Count().ShouldBeGreaterThan(0);
            respuesta.Relaciones.Count().ShouldNotEqual(0);
            respuesta.Respuesta.ShouldBeNull();
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaElTipoRespuestaAdecuado()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ShouldBeType(typeof(AgregarEtiquetasAUnDiccionarioRespuesta));
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaUnaListaDeEtiquetasQueNoEsVacia()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ListaDeEtiquetas.Count().ShouldBeGreaterThan(0);
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioNoRetornaErrores()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.Respuesta.ShouldBeNull();
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaRelacionesContienenGuidsNoVacios()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

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
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaLosValoresDeRelacionesCorrectos()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

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

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaLosValoresAgregadosALaListaDeEtiquetas()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeTodasLasPruebasDeAgregarEtiquetasAUnDiccionarioRespuesta();

            bool etiquetasAgregadas = true;

            foreach (Etiqueta itemEtiqueta in this.listaDeEtiquetasAAgregar)
            {
                if (!(respuesta.ListaDeEtiquetas.Contains(itemEtiqueta)))
                {
                    etiquetasAgregadas = false;
                    break;
                }
            }

            //Assert
            etiquetasAgregadas.ShouldBeTrue();
        }

        #endregion

        #region Pruebas Modificar Etiquetas A Un Diccionario

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarEtiquetasAUnDiccionarioRetornaTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActModificarEtiquetasAUnDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(ModificarEtiquetasAUnDiccionarioRespuesta));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarEtiquetasAUnDiccionarioNoRetornaNulo()
        {
            var respuesta = ArrangeYActModificarEtiquetasAUnDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        #endregion

        #region Pruebas Eliminar Etiquetas a Un Diccionario

        [Test]
        public void PruebaEliminarEtiquetaDiccionarioNoRetornaNulo()
        {
            var respuesta = ArrangeYActEliminarEtiquetasAUnDiccionario();

            //Assert
            respuesta.ListaDeEtiquetas.Count().ShouldEqual(1);

        }

        #endregion

        #endregion
    }
}
