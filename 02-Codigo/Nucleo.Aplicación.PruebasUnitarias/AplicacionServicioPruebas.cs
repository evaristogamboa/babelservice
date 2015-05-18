﻿using System;
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
		private Diccionario diccionarioPrueba;
		private Diccionario diccionarioRespuesta;
		private string nombreIdioma = "en-US";

		public AplicacionServicioPruebas() { 
			var repositorioMock=Substitute.For<IDiccionarioRepositorio>();		
			this.diccionarioRepositorio = repositorioMock;
			this.diccionarioPrueba = InicializarDiccionario();
			this.diccionarioRepositorio.ObtenerUnDiccionario(diccionarioPrueba.Id).Returns(diccionarioPrueba);
			this.diccionarioRespuesta = DiccionarioRespuestaPorIdiomaEsVe();
		}
	

		private Diccionario InicializarDiccionario()
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

			return diccionario;

		}

		private Diccionario DiccionarioRespuestaPorIdiomaEsVe()
		{
			List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();


			List<Traduccion> listaDeTraduccionesAceptar = new List<Traduccion>();
			List<Traduccion> listaDeTraduccionesCancelar = new List<Traduccion>();

			Diccionario diccionario = Diccionario.CrearNuevoDiccionario(new Guid("a1fa3369-bc3f-4ebc-9cac-5677cbaa8114"), ambienteTestPrueba);

			Etiqueta etiquetaAceptar = Etiqueta.CrearNuevaEtiqueta(new Guid("8a87f8a7-3df9-4d90-9478-350b964fc888"));
			Etiqueta etiquetaCancelar = Etiqueta.CrearNuevaEtiqueta(new Guid("9a39ad6d-62c8-42bf-a8f7-66417b2b08d0"));

			Cultura culturaEsVe = Cultura.CrearNuevaCultura("es-VE");

			Traduccion traduccionAceptarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "aceptar");

			listaDeTraduccionesAceptar.Add(traduccionAceptarEsVe);

			etiquetaAceptar.IdiomaPorDefecto = "es-VE";
			etiquetaAceptar.Nombre = "app.common.aceptar";
			etiquetaAceptar.Textos = listaDeTraduccionesAceptar;
			etiquetaAceptar.Activo = true;

			Traduccion traduccionCancelarEsVe = Traduccion.CrearNuevaTraduccion(culturaEsVe, "cancelar");

			listaDeTraduccionesCancelar.Add(traduccionCancelarEsVe);

			etiquetaCancelar.IdiomaPorDefecto = "es-VE";
			etiquetaCancelar.Nombre = "app.common.cancelar";
			etiquetaCancelar.Textos = listaDeTraduccionesCancelar;
			etiquetaCancelar.Activo = true;


			listaDeEtiquetas.Add(etiquetaAceptar);
			listaDeEtiquetas.Add(etiquetaCancelar);

			diccionario.Ambiente = "desarrollo";
			diccionario.AgregarEtiquetas(listaDeEtiquetas);

			return diccionario;

		}

		#region ConsultarEtiquetasDeDiccionarioPorIdioma

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaNoEsNull()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;

			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

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

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

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

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

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

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

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

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();
			
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

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

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

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.Respuesta.ShouldBeNull();
		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdiomaRetornaLasEtiquetasEnElIdiomaSolicitado()
		{
			//Arrange
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = diccionarioPrueba.Id;
			peticion.Idioma = nombreIdioma;


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//Act
			AplicacionServicio serviciosApi = new AplicacionServicio(this.diccionarioRepositorio);


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			Boolean traduccionDiferenteDelIdioma = false;

			foreach (Etiqueta item in respuesta.ListaDeEtiquetas)
			{
				foreach (Traduccion tra in item.Textos)
				{
					if (tra.Cultura.CodigoIso != "es-VE")
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

        #region Mantenimiento

        [Test]
	    public void PruebaCrearUnDiccionario()
	    {
	        //Arrange
            CrearUnDiccionarioPeticion peticion = CrearUnDiccionarioPeticion.CrearNuevaInstancia("ambiente");
            peticion.DiccionarioNuevo = Diccionario.CrearNuevoDiccionario("ambiente");

            // Validacion de que haya un solo diccionario con el mismo nombre
            
            CrearUnDiccionarioPeticion peticion2 = CrearUnDiccionarioPeticion.CrearNuevaInstancia("ambiente");
            peticion2.DiccionarioNuevo = Diccionario.CrearNuevoDiccionario("ambiente");
            
            if (peticion.DiccionarioNuevo.Ambiente == peticion2.DiccionarioNuevo.Ambiente)
            {
                throw new Exception();
            }

            CrearUnDiccionarioRespuesta respuesta = CrearUnDiccionarioRespuesta.CrearNuevaInstancia("ambiente");
            //Act

            AplicacionServicio serviciosApi = new AplicacionServicio(diccionarioRepositorio);

            respuesta = serviciosApi.CrearUnDiccionario(peticion);

            //Assert

            respuesta.ShouldBeType(typeof(Diccionario));
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



            //diccionario.Id.ShouldEqual(peticion.DiccionarioId);

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
