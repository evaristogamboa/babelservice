using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
		private const string ambienteTestPrueba = "desarrollo";
		private Diccionario diccionarioPrueba;
        private Diccionario nuevodiccionario;
		private string nombreIdioma = "en-US";
		private List<Diccionario> listaDeDiccionarios = new List<Diccionario>();

		public AplicacionServicioMantenimientoPruebas()
        { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			diccionarioRepositorio = repositorioMock;
			diccionarioPrueba = InicializarDiccionario();
		    nuevodiccionario = NuevoDiccionario();

			listaDeDiccionarios.Add(diccionarioPrueba);

			diccionarioRepositorio.ObtenerUnDiccionario(diccionarioPrueba.Id).Returns(diccionarioPrueba);
			diccionarioRepositorio.ObtenerDiccionarios().Returns(listaDeDiccionarios);

		    diccionarioRepositorio.SalvarUnDiccionario(diccionarioPrueba).Returns(nuevodiccionario);

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

        private Diccionario InicializarDiccionarioModificar()
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

        private Diccionario InicializarDiccionarioCrear()
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

        private Diccionario NuevoDiccionario()
        {

            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), "ambiente");

            return diccionario;

        }

        #endregion



        #region Mantenimiento

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaCrearUnDiccionario()
        {
            //Arrange

            const string ambiente = "ambiente";


            AplicacionServicio serviciosApi = new AplicacionServicio(diccionarioRepositorio);

            var unDiccionarioRespuesta = serviciosApi.CrearUnDiccionario(CrearUnDiccionarioPeticion.CrearNuevaInstancia(ambiente));

            unDiccionarioRespuesta.DiccionarioNuevo.ShouldNotBeNull();
            unDiccionarioRespuesta.DiccionarioNuevo.Ambiente.ShouldBeSameAs("ambiente");
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public  void PruebaModificarAmbienteDiccionario()
        {
            //Arrange
            var peticion = ModificarUnDiccionarioPeticion.CrearNuevaInstancia(string.Empty);

            peticion.Diccionario = null;

            peticion.Diccionario = diccionarioPrueba;
            

            //ModificarUnDiccionarioRespuesta respuesta = ModificarUnDiccionarioRespuesta.CrearNuevaInstancia();

            //Act
            AplicacionServicio servicio = new AplicacionServicio(diccionarioRepositorio);
            var test = servicio.ModificarUnDiccionario(peticion);
            //respuesta = servicio.ModificarUnDiccionario(peticion.DiccionarioId).ShouldBeType(ModificarUnDiccionarioRespuesta.CrearNuevaInstancia());

        }

        #endregion



    }
}
