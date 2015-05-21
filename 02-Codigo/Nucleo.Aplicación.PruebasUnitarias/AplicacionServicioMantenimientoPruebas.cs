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
		private Diccionario diccionarioPrueba;
        private Diccionario nuevodiccionario;
        private Diccionario modificarDiccionario;
        private Diccionario diccionarioRespuestaDiccionarioEliminado;
        private Diccionario diccionarioRespuestaDiccionarioModificado;
        private Diccionario diccionarioRespuestaEliminarEtiquetasDiccionario;
        private Diccionario diccionarioInicialDeLasPruebas;
		private string nombreIdioma = "en-US";
		private List<Diccionario> listaDeDiccionarios = new List<Diccionario>();

		public AplicacionServicioMantenimientoPruebas()
        { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			diccionarioRepositorio = repositorioMock;
		    diccionarioRespuestaDiccionarioEliminado = ListaDiccionarioVacia();
		    diccionarioRespuestaDiccionarioModificado = ListaDiccionarioModificado();
            diccionarioRespuestaEliminarEtiquetasDiccionario = ListaEliminarUnaEtiquetaDiccionario();
            diccionarioRepositorioModificado = repositorioMock;
			diccionarioPrueba = InicializarDiccionario();
		    nuevodiccionario = NuevoDiccionario();
            //modificarDiccionario = DiccionarioModificado();


			listaDeDiccionarios.Add(diccionarioPrueba);

			diccionarioRepositorio.ObtenerUnDiccionario(diccionarioPrueba.Id).Returns(diccionarioPrueba);
			diccionarioRepositorio.ObtenerDiccionarios().Returns(listaDeDiccionarios);

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

        private Diccionario ListaDiccionarioVacia()
        {
            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(Guid.Empty, "");
            return diccionario;
        }
        
        private Diccionario ListaDiccionarioModificado()
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

        private Diccionario ListaEliminarUnaEtiquetaDiccionario()
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

        #endregion

        private Diccionario NuevoDiccionario()
        {

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), "ambiente");

            return diccionario;

        }


        //private Diccionario DiccionarioModificado()
        //{

        //    Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), "pruebaaa");

        //    return diccionario;

        //}


        #region ArrangeYAct

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

        #region Mantenimiento

        #region PruebasCrearDiccionario
        /// <summary>
        /// 
        /// </summary>
        //[Test]
        //public void PruebaCrearUnDiccionario()
        //{
        //    //Arrange

        //    const string ambiente = "ambiente";


        //    AplicacionServicio serviciosApi = new AplicacionServicio(diccionarioRepositorio);

        //    var unDiccionarioRespuesta = serviciosApi.CrearUnDiccionario(CrearUnDiccionarioPeticion.CrearNuevaInstancia(ambiente));

        //    unDiccionarioRespuesta.DiccionarioNuevo.ShouldNotBeNull();
        //    unDiccionarioRespuesta.DiccionarioNuevo.Ambiente.ShouldBeSameAs("ambiente");
        //}

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
