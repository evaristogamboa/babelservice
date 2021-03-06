﻿using Babel.Repositorio.Xml.Impl.Implementacion;
using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;

namespace Babel.Repositorio.Xml.Impl.PruebasUnitarias.Modelo
{
	[TestFixture]
	public class DiccionarioRepositorioTest
	{

        private const string ambienteTestPrueba = "Prueba";
        private const string ambienteTestDesarrollo = "Desarrollo";
        private const string ambienteTestSoloAmbiente = "SoloAmbiente";
        private string Directory = Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\DatosPrueba\\") + "diccionario_ok.xml";

        private Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario DiccionarioDominio { get; set; }


        private Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario DiccionarioDominio2 { get; set; }
    

		[Test]
        public void ProbarObtenerDiccionariosDelRepositorioEnElXMLRepositorioRetornaListaDeDiccionarios()
		{		
			//Arrange
            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
			var diccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> ();
			//Act
			diccionarios = repositorio.ObtenerDiccionarios ();
			//Assert
			diccionarios.ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>> ();
		}



        [Test]       
        public void ProbarObtenerUnDiccionarioExisteEnElXMLRepositorioRetornaNullReferenceException() 
        {
            try {
            //Arrange
            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
            const string idDiccionario = "25829869-2551-4b60-9dd7-2aaafccf8bfa";
            //Act
            repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));
            }
            catch (Exception ex) {            
                    ex.ShouldBeType<NullReferenceException>();            
            }
        }

         [Test]
        public void ProbarObtenerUnDiccionarioArchivoNoExisteEnElXMLRepositorioRetornaArgumentNullException()
        {
            // Para que ejecute la excepción modificar el ID del diccionario por uno que no exista (Verificar Diccionario)
            //Arrange
            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
            const string idDiccionario = "25829869-2551-4b60-9dd7-2aaafccf8bfa";
            try {
            //Act
            repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));        
            }catch (Exception ex) {
                ex.ShouldBeType<System.ArgumentNullException>();            
            }

        }
        

         [Test]
         public void ProbarObtenerUnDiccionarioArchivoVacioEnElXMLRepositorioRetornaInvalidOperationException()
         {
             // Para que ejecute la excepción modificar el ID del diccionario por uno que no exista (Verificar Diccionario)
             //Arrange
             DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
             const string idDiccionario = "25829869-2551-4b60-9dd7-2aaafccf8bfa";
             try
             {
             //Act
             repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));
             }catch (Exception ex)
             {
                 ex.ShouldBeType <System.InvalidOperationException>();
             }

         }



        [Test]
         public void ProbarObtenerUnDiccionarioNoExisteEnElXMLRepositorioRetornaNulo()
        {
            //Arrange
            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
            const string idDiccionario = "7a83a1a0-415f-40bd-bd37-66e7f71efdab";
            //Act
            repositorio.ObtenerUnDiccionario(new Guid(idDiccionario)).ShouldBeNull();           
            
        }

         [Test]
        public void ProbarObtenerUnDiccionarioGuidInvalidoEnElXMLRepositorioRetornaFormatException()
        {
            //Arrange
            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
            const string idDiccionario = "918646121";
            try
            {
            //Act
            repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));
            }
            catch (Exception ex) {
            //Assert
            ex.ShouldBeType<System.FormatException>();
            }
        }


        [Test]
         public void ProbarCrearUnDiccionarioNuevoEnElXMLRepositorioRetornaDiccionarioCreadoRetornaDiccionarioCreado()
         {

             try
             {
                 // Se coloca este valor Convert.ToString(DateTime.Now.Ticks) para que cree diccionarios dinamico con un numero X basado en milisegundos

                 //Arrange
                 DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);

                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo1_" + Convert.ToString(DateTime.Now.Ticks));

                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                 EtqDom.AgregarTraduccion(traduccionDom2);

                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo2_" + Convert.ToString(DateTime.Now.Ticks));

                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                 EtqDom2.AgregarTraduccion(traduccionDom22);

                 DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid(), ambienteTestPrueba);

                 DiccionarioDominio.AgregarEtiqueta(EtqDom);
                 DiccionarioDominio.AgregarEtiqueta(EtqDom2);

                 //Act
                 repositorio.SalvarUnDiccionario(DiccionarioDominio).ShouldEqual(DiccionarioDominio);

             }
             catch (Exception ex) {
                 //Assert
                 ex.ShouldBeType<Exception>();
             
             }

         }

        [Test]
        public void ProbarCrearUnDiccionarioNuevoConAmbienteExistenteEnElXMLRepositorioRetornaDiccionarioCreado()
        {


            try
            {                
                //Arrange
                DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
                DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid(), ambienteTestSoloAmbiente);
                //Act
                repositorio.SalvarUnDiccionario(DiccionarioDominio);

            }
            catch (Exception ex) {
                //Assert
                ex.ShouldBeType<Exception>();
            
            }

        }


        [Test]
        public void ProbarModificarUnDiccionarioExistenteEnElXMLRepositorioRetornaDiccionarioModificado()
        {

            // Se coloca este valor Convert.ToString(DateTime.Now.Ticks) para que cree diccionarios dinamico con un numero X basado en milisegundos

            try
            {

                //Arrange

                DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo1_" + Convert.ToString(DateTime.Now.Ticks));

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                EtqDom.AgregarTraduccion(traduccionDom2);
                
                Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo2_" + Convert.ToString(DateTime.Now.Ticks));

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                EtqDom2.AgregarTraduccion(traduccionDom22);

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom3 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo3_" + Convert.ToString(DateTime.Now.Ticks));

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom23 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                EtqDom3.AgregarTraduccion(traduccionDom23);

                DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.Parse("25829869-2551-4b60-9dd7-2aaafccf8bfa"), ambienteTestPrueba);
                
                DiccionarioDominio.AgregarEtiqueta(EtqDom);
                DiccionarioDominio.AgregarEtiqueta(EtqDom2);
                DiccionarioDominio.AgregarEtiqueta(EtqDom3);

                //Act
                repositorio.SalvarUnDiccionario(DiccionarioDominio);

            }
            catch (Exception ex) {
                //Assert
                ex.ShouldBeType<Exception>();
            
            }
        
        }

        [Test]

        // Johans
        public void ProbarCrearUnDiccionarioNoExistenteEnElXMLRepositorioRetornaException()
        {
            try
            {
                //Arrange
                DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);
                //Act
                repositorio.SalvarUnDiccionario(DiccionarioDominio);

            }
            catch (Exception ex) {
                //Assert
                ex.ShouldBeType<Exception>();            
            }


        }

        [Test]

        // Johans
        public void ProbarCrearListadeDiccionariosExistentesEnElXMLRepositorioRetornaListaDiccionarios()
        {

            try
            {

                DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);

                var listaDiccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();


                Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test");

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                EtqDom.AgregarTraduccion(traduccionDom2);

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test2");

                Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                EtqDom2.AgregarTraduccion(traduccionDom22);


                DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid(), ambienteTestPrueba);

                DiccionarioDominio.AgregarEtiqueta(EtqDom);
                DiccionarioDominio.AgregarEtiqueta(EtqDom2);


                DiccionarioDominio2 = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid(), ambienteTestDesarrollo);

                DiccionarioDominio2.AgregarEtiqueta(EtqDom);
                DiccionarioDominio2.AgregarEtiqueta(EtqDom2);

                listaDiccionarios.Add(DiccionarioDominio);
                listaDiccionarios.Add(DiccionarioDominio2);


                repositorio.SalvarDiccionarios(listaDiccionarios).ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>>();
            }
            catch (Exception ex) {

                ex.ShouldBeType<SystemException>();            
            
            }

        }

        [Test]

        // Johans
        public void ProbarCrearListadeDiccionariosNoExistentesEnElXMLRepositorio()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);

            var listaDiccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

            try
            {

                repositorio.SalvarDiccionarios(listaDiccionarios).ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>>();

            }
            catch (Exception ex) {

                ex.ShouldBeType<System.ArgumentNullException>();
            }          


        }


        [Test]
        public void EliminarUnDiccionarioExistenteEnElXMLRepositorio() 
        {

            // Se tiene que buscar un ID en el Xml del repositorio.

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);

            var listaDiccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

            try
            {

                repositorio.EliminarUnDiccionario(new Guid("25829869-2551-4b60-9dd7-2aaafccf8bfa")); ;

            }
            catch (Exception ex)
            {

                ex.ShouldBeType<System.NullReferenceException>();
            }     
            
        
        
        }
        
        [Test]
        public void EliminarUnDiccionarioNoExistenteEnElXMLRepositorio()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);

            var listaDiccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

            try
            {

                repositorio.EliminarUnDiccionario(new Guid("835944df-3bc0-46b3-8508-cb1aed001bc4"));

            }
            catch (Exception ex)
            {

                ex.ShouldBeType<System.NullReferenceException>();
            }



        }



        [Test]
        public void EliminarListadeDiccionariosExistentesEnElXMLRepositorio()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl(Directory);

            var listaDiccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

            var listaguid = new List<Guid>() {            
                new Guid("ed14ab25-0178-43a4-ab77-d7c342bd8780"),
                new Guid("4dc68f37-b2d9-4274-852b-03938512864e")            
            };
            
           
            try
            {

                repositorio.EliminarDiccionarios(listaguid).ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>>();

            }
            catch (Exception ex)
            {

                ex.ShouldBeType<System.NullReferenceException>();
            }



        }




	}
}

