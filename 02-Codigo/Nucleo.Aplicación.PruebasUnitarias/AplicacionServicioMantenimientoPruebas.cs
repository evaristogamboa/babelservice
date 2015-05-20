using System;
using System.Collections.Generic;
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
        private const string ambienteTestPruebaModificar = "calidad";
		private Diccionario diccionarioPrueba;
        private Diccionario nuevodiccionario;
        private Diccionario modificarDiccionario;
		private string nombreIdioma = "en-US";
		private List<Diccionario> listaDeDiccionarios = new List<Diccionario>();

		public AplicacionServicioMantenimientoPruebas()
        { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			diccionarioRepositorio = repositorioMock;
            diccionarioRepositorioModificado = repositorioMock;
			diccionarioPrueba = InicializarDiccionario();
		    nuevodiccionario = NuevoDiccionario();
		    modificarDiccionario = DiccionarioModificado();

			listaDeDiccionarios.Add(diccionarioPrueba);

			diccionarioRepositorio.ObtenerUnDiccionario(diccionarioPrueba.Id).Returns(diccionarioPrueba);
			diccionarioRepositorio.ObtenerDiccionarios().Returns(listaDeDiccionarios);

            // Eliminar y Guardar (Modifica)
		    diccionarioRepositorio.SalvarUnDiccionario(diccionarioPrueba).Returns(nuevodiccionario);

		    diccionarioRepositorioModificado.SalvarUnDiccionario(diccionarioPrueba).Returns(modificarDiccionario);



        }

        #region InicializadorDatos

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

        private Diccionario InicializarDiccionarioEliminar()
        {
            
            List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

            List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa811YCM"), ambienteTestPrueba);

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

        private Diccionario InicializarDiccionarioModificarAmbiente()
        {
            // Primer diccionario
            List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

            List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), ambienteTestPruebaModificar);

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



        private Diccionario InicializarDiccionarioCrear()
        {
            List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

            List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();
            List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(
                new Guid("cd6205a8-d8dd-4c9c-84c1-63f381585c6e"), ambienteTestPrueba);

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

        private Diccionario NuevoDiccionario()
        {

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), "ambiente");

            return diccionario;

        }


        private Diccionario DiccionarioModificado()
        {

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), "ambiente");

            return diccionario;

        }

        #endregion

        #region ArrangeYAct

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ModificarUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeModificarAmbienteDiccionario()
        {
            //Arrange
            var peticion = ModificarUnDiccionarioPeticion.CrearNuevaInstancia(string.Empty);
            peticion.Diccionario = null;
            peticion.Diccionario = diccionarioPrueba;
            ModificarUnDiccionarioRespuesta respuesta = ModificarUnDiccionarioRespuesta.CrearNuevaInstancia();

            //Act
            AplicacionServicio servicio = new AplicacionServicio(diccionarioRepositorio);
            respuesta = servicio.ModificarUnDiccionario(peticion);
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private EliminarUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeEliminarUnDiccionario()
        {
            //Arrange
            EliminarUnDiccionarioPeticion peticion = EliminarUnDiccionarioPeticion.CrearNuevaInstancia();
            peticion.DiccionarioId = diccionarioPrueba.Id;
            EliminarUnDiccionarioRespuesta respuesta = EliminarUnDiccionarioRespuesta.CrearNuevaInstancia();

            //Act
            AplicacionServicio serviciosApi = new AplicacionServicio(diccionarioRepositorio);
            respuesta = serviciosApi.EliminarUnDiccionario(peticion);
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ModificarEtiquetasAUnDiccionarioRespuesta ArrangeYActDeTodasLasPruebasDeModificarEtiquetasAUnDiccionario()
        {
            //Arrange
            var peticion = ModificarEtiquetasAUnDiccionarioPeticion.CrearNuevaInstancia();
            var diccionario = InicializarDiccionario();

            peticion.DiccionarioId = diccionario.Id;
            peticion.ListaDeEtiquetas = new List<Etiqueta>();
            peticion.ListaDeEtiquetas.AddRange(diccionario.Etiquetas);

            peticion.ListaDeEtiquetas[0].Nombre = "App.YCM.New_0";
            peticion.ListaDeEtiquetas[1].Nombre = "App.YCM.New_1";
            
            var respuesta = ModificarEtiquetasAUnDiccionarioRespuesta.CrearNuevaInstancia();

            //Act
            AplicacionServicio servicio = new AplicacionServicio(diccionarioRepositorio);
            respuesta = servicio.ModificarEtiquetasAUnDiccionario(peticion);
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

        #region PruebaModificarAmbienteDiccionario

        /// <summary>
        /// Valida que la respuesta que retorna sea de tipo ModificarUnDiccionarioRespuesta
        /// </summary>
        [Test]
        public void PruebaModificarAmbienteDiccionarioRetornaElTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeModificarAmbienteDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(ModificarUnDiccionarioRespuesta));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarAmbienteDiccionarioNoRetornaNulo()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeModificarAmbienteDiccionario();
            
            //Assert
            respuesta.ShouldNotBeNull();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarAmbienteDiccionarioRetornaRelacionesNoVacia()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeModificarAmbienteDiccionario();

            //Assert
            respuesta.Relaciones.Count.ShouldNotEqual(0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarAmbienteDiccionarioRetornaRespuestaNula()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeModificarAmbienteDiccionario();

            //Assert
            respuesta.Respuesta.ShouldBeNull();
        }

        #endregion

        #region PruebasEliminarDiccionario

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaEliminarDiccionarioNoEsNull()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeEliminarUnDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaEliminarDiccionarioRetornaTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeEliminarUnDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(EliminarUnDiccionarioRespuesta));
        }

        #endregion

        #region Pruebas ModificarEtiquetasAUnDiccionario

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarEtiquetasAUnDiccionarioRetornaTipoRespuestaAdecuado()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeModificarEtiquetasAUnDiccionario();

            //Assert
            respuesta.ShouldBeType(typeof(ModificarEtiquetasAUnDiccionarioRespuesta));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaModificarEtiquetasAUnDiccionarioNoRetornaNulo()
        {
            var respuesta = ArrangeYActDeTodasLasPruebasDeModificarEtiquetasAUnDiccionario();

            //Assert
            respuesta.ShouldNotBeNull();
        }

        #endregion
        
       #endregion



    }
}
