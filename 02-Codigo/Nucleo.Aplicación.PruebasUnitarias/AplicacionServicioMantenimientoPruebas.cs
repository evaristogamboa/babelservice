using System;
using System.Collections.Generic;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using Babel.Nucleo.Dominio.Repositorios;
using NSubstitute;
using NUnit.Framework;
using Should;

namespace Babel.Nucleo.Aplicación.PruebasUnitarias
{
    public class AplicacionServicioMantenimientoPruebas
    {
        private IDiccionarioRepositorio diccionarioRepositorio;
		private const string ambienteTestPrueba = "desarrollo";
		private Diccionario diccionarioPrueba;
		private string nombreIdioma = "en-US";
		private List<Diccionario> listaDeDiccionarios = new List<Diccionario>();

		AplicacionServicioMantenimientoPruebas() { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			diccionarioRepositorio = repositorioMock;
			diccionarioPrueba = InicializarDiccionario();

			listaDeDiccionarios.Add(diccionarioPrueba);

			diccionarioRepositorio.ObtenerUnDiccionario(diccionarioPrueba.Id).Returns(diccionarioPrueba);
			diccionarioRepositorio.ObtenerDiccionarios().Returns(listaDeDiccionarios);
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

        #region Mantenimiento

        [Test]
        public void PruebaCrearUnDiccionario()
        {
            //Arrange

            var unDiccionarioRespuesta = ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(String.Empty);

            var diccionario = Diccionario.CrearNuevoDiccionario("ambiente");





            //try
            //{
            //    diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

            //    unDiccionarioRespuesta.Diccionario = diccionario;
            //    unDiccionarioRespuesta.Relaciones["diccionario"] = diccionario.Id;
            //    unDiccionarioRespuesta.Respuesta = null;
            //}
            //catch (Exception ex)
            //{
            //    //etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;
            //}



            //Assert

            //respuesta.ShouldBeType(typeof(Diccionario));
        }

        [Test]
        public void PruebaConsultarDiccionarioPorGuid()
        {
            //Arrange
            ConsultarUnDiccionarioPeticion peticion = ConsultarUnDiccionarioPeticion.CrearNuevaInstancia();
            peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");

            //ConsultarDiccionariosRespuesta respuesta = ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

            var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);





            var dirRquest = ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(diccionario.Ambiente);


            if (dirRquest != null)
            {


            }

            throw new Exception();



            diccionario.Id.ShouldEqual(peticion.DiccionarioId);

        }


        //public void PruebaModificarAmbienteDiccionario()
        //{
        //    //Arrange
        //    ConsultarUnDiccionarioPeticion peticion = ConsultarUnDiccionarioPeticion.CrearNuevaInstancia();
        //    peticion.DiccionarioId = new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114");

        //    ConsultarDiccionariosRespuesta respuesta = ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

        //    //ACt
        //    AplicacionServicio servicio = new AplicacionServicio(diccionarioRepositorio);
        //    //respuesta = servicio.ConsultarDiccionarios()

        //}

        #endregion

    }
}
