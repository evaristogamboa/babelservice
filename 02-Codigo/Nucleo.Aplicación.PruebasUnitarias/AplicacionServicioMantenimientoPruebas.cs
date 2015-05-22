﻿using System;
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
		private string nombreIdioma = "en-US";
		private Diccionario diccionarioPrueba;
        private Diccionario nuevodiccionario;
        private Diccionario modificarDiccionario;
        private Diccionario diccionarioRespuestaDeCrearUnDiccionario;
        private Diccionario diccionarioRespuestaDeAgregarEtiquetas;
        private Diccionario diccionarioRespuestaDiccionarioEliminado;
        private Diccionario diccionarioRespuestaDiccionarioModificado;
        private Diccionario diccionarioRespuestaEliminarEtiquetasDiccionario;
        private Diccionario diccionarioInicialDeLasPruebas;
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

            diccionarioRespuestaDeCrearUnDiccionario = DiccionarioNuevoCreado();

            diccionarioRespuestaDeAgregarEtiquetas = DiccionarioConDosEtiquetasAgregadas();


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

        #region Arrange Y Act

        private CrearUnDiccionarioRespuesta ArrangeYActDeCrearUnDiccionario()
        {
            //Arrange
            diccionarioRepositorio.SalvarUnDiccionario(diccionarioRespuestaDeCrearUnDiccionario).Returns(diccionarioRespuestaDeCrearUnDiccionario);

            var peticion = CrearUnDiccionarioPeticion.CrearNuevaInstancia(ambienteNuevoDiccionario);

            peticion.Ambiente = ambienteNuevoDiccionario;

            //Act
            var serviciosApi = new AplicacionServicio(diccionarioRepositorio);

            var respuesta = serviciosApi.CrearUnDiccionario(peticion);

            return respuesta;
        }

        private AgregarEtiquetasAUnDiccionarioRespuesta ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta()
        {
            //Arrange
            diccionarioInicialDeLasPruebas = InicializarDiccionario();
            diccionarioRepositorio.ObtenerUnDiccionario(diccionarioInicialDeLasPruebas.Id).Returns(diccionarioInicialDeLasPruebas);
            diccionarioRepositorio.SalvarUnDiccionario(diccionarioInicialDeLasPruebas).Returns(diccionarioRespuestaDeAgregarEtiquetas);

            AgregarEtiquetasAUnDiccionarioPeticion peticion = AgregarEtiquetasAUnDiccionarioPeticion.CrearNuevaInstancia();

            peticion.DiccionarioId = diccionarioInicialDeLasPruebas.Id;
            peticion.ListaDeEtiquetas = listaDeEtiquetasAAgregar;

            //Act
            var serviciosApi = new AplicacionServicio(diccionarioRepositorio);

            var respuesta = serviciosApi.AgregarEtiquetasAUnDiccionario(peticion);

            return respuesta;
        }

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
            CrearUnDiccionarioRespuesta respuesta = ArrangeYActDeCrearUnDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }
        
        #endregion

        #region Modificar Diccionario

        [Test]
        public void PruebaModificarDiccionarioRetornaElTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(ModificarUnDiccionarioRespuesta));
        }

        [Test]
        public void PruebaModificarDiccionarioNoRetornaNulo()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        [Test]
        public void PruebaModificarDiccionarioRetornaRelacionesNoVacia()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.Relaciones.Count.ShouldNotEqual(0);
        }

        [Test]
        public void PruebaModificarDiccionarioRetornaRespuestaNula()
        {
            var respuesta = ArrangeYActModificarDiccionario();

            //Assert
            respuesta.Respuesta.ShouldBeNull();
        }

        #endregion

        #region Eliminar Diccionario

        [Test]
        public void PruebaEliminarDiccionarioNoEsNull()
        {
            var respuesta = ArrangeYActEliminarUnDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }

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
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioNoEsVacio()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ListaDeEtiquetas.Count().ShouldBeGreaterThan(0);
            respuesta.Relaciones.Count().ShouldNotEqual(0);
            respuesta.Respuesta.ShouldBeNull();
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaElTipoRespuestaAdecuado()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ShouldBeType(typeof(AgregarEtiquetasAUnDiccionarioRespuesta));
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaUnaListaDeEtiquetasDelTipoListaEtiqueta()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ListaDeEtiquetas.ShouldBeType(typeof(List<Etiqueta>));
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaUnaListaDeEtiquetasQueNoEsVacia()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.ListaDeEtiquetas.Count().ShouldBeGreaterThan(0);
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioNoRetornaErrores()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            respuesta.Respuesta.ShouldBeNull();
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaRelacionesContienenGuidsNoVacios()
        {
            AgregarEtiquetasAUnDiccionarioRespuesta respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            //Assert
            var noContieneVacio = respuesta.Relaciones.All(item => item.Value != Guid.Empty);

            noContieneVacio.ShouldBeTrue();
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaLosValoresDeRelacionesCorrectos()
        {
            var respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            var relacionesDiccionarioId = Guid.Empty;

            foreach (var item in respuesta.Relaciones.Where(item => item.Key == "diccionario"))
            {
                relacionesDiccionarioId = item.Value;
            }

            //Assert
            relacionesDiccionarioId.ShouldEqual(diccionarioInicialDeLasPruebas.Id);
        }

        [Test]
        public void PruebaDeAgregarEtiquetasAUnDiccionarioRetornaLosValoresAgregadosALaListaDeEtiquetas()
        {
            var respuesta = ArrangeYActDeAgregarEtiquetasAUnDiccionarioRespuesta();

            var etiquetasAgregadas = listaDeEtiquetasAAgregar.All(itemEtiqueta => respuesta.ListaDeEtiquetas.Contains(itemEtiqueta));

            //Assert
            etiquetasAgregadas.ShouldBeTrue();
        }

        #endregion

        #region Pruebas Modificar Etiquetas A Un Diccionario

        [Test]
        public void PruebaModificarEtiquetasAUnDiccionarioRetornaTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActModificarEtiquetasAUnDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(ModificarEtiquetasAUnDiccionarioRespuesta));
        }

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
