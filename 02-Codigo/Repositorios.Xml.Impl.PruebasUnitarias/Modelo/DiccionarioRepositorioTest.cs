using Babel.Repositorio.Xml.Impl.Implementacion;
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

        private Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario DiccionarioDominio { get; set; }


        private Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario DiccionarioDominio2 { get; set; }
                
        [Test]
		public void DiccionarioRepositorioTestSalvar ()
		{

            var file = @"diccionario_ok.xml";

            var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + file;




		}





		[Test]
		public void ProbarObtenerDiccionariosDelRepositorio ()
		{		
			//Arrange
            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();
			var diccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> ();
			//Act

			diccionarios = repositorio.ObtenerDiccionarios ();

			//Assert
			diccionarios.ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>> ();

		}



        [Test]

        // Johans
        public void ProbarObtenerUnDiccionarioExiste() 
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            const string idDiccionario = "0175a469-a3fa-46d8-a30c-59197800447a";

            var diccionarioDom = repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));


            diccionarioDom.ShouldBeType<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

        }

         [Test]

        // Johans
        public void ProbarObtenerUnDiccionarioArchivoNoExiste()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            const string idDiccionario = "7a83a1a0-415f-40bd-bd37-82e7f71efdab";

            try {

                var diccionarioDom = repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));

                diccionarioDom.ShouldBeType<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();            
            
            
            }
            
            
            catch (Exception ex) {

                ex.ShouldBeType<System.ArgumentNullException>();              
            
            }

        }



         [Test]

         // Johans
         public void ProbarObtenerUnDiccionarioArchivoVacio()
         {

             DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

             const string idDiccionario = "7a83a1a0-415f-40bd-bd37-82e7f71efdab";

             try
             {

                 var diccionarioDom = repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));

                 diccionarioDom.ShouldBeType<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();


             }


             catch (Exception ex)
             {

                 ex.ShouldBeType <System.InvalidOperationException>();

             }

         }



        [Test]
        public void ProbarObtenerUnDiccionarioNoExiste()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            const string idDiccionario = "7a83a1a0-415f-40bd-bd37-66e7f71efdab";

            var diccionarioDom = repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));


            diccionarioDom.ShouldBeNull();

        }

         [Test]
        public void ProbarObtenerUnDiccionarioGuidInvalido()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            const string idDiccionario = "918646121";

            try
            {

                var diccionarioDom = repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));

            }
            catch (Exception ex) {

                ex.ShouldBeType<System.FormatException>();
            }
            

        }


        [Test]
        //Johans
            
         public void ProbarCrearUnDiccionarioNuevo()
         {

             DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();


             Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo2");

             Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

             EtqDom.AgregarTraduccion(traduccionDom2);


             Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo2");

             Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

             EtqDom2.AgregarTraduccion(traduccionDom22);


             DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid(), ambienteTestPrueba);

             

             DiccionarioDominio.AgregarEtiqueta(EtqDom);
             DiccionarioDominio.AgregarEtiqueta(EtqDom2);

             repositorio.SalvarUnDiccionario(DiccionarioDominio).ShouldEqual(DiccionarioDominio);



         }


        [Test]
        public void ProbarModificarUnDiccionarioExistente()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            
            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testReplaceEvaristo2");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom.AgregarTraduccion(traduccionDom2);


            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testReplaceEvaristo2");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom2.AgregarTraduccion(traduccionDom22);



            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom3 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testReplaceEvaristo3New");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom23 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom3.AgregarTraduccion(traduccionDom23);


            DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.Parse("17b1685e-47f4-4696-941a-fac497052f0d"),ambienteTestPrueba);

          

            DiccionarioDominio.AgregarEtiqueta(EtqDom);
            DiccionarioDominio.AgregarEtiqueta(EtqDom2);
            DiccionarioDominio.AgregarEtiqueta(EtqDom3);

            repositorio.SalvarUnDiccionario(DiccionarioDominio).ShouldEqual(DiccionarioDominio);
        

        
        }

        [Test]

        // Johans
        public void ProbarCrearUnDiccionarioNoExistente()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();      

            try
            {
                
                repositorio.SalvarUnDiccionario(DiccionarioDominio).ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>>();

            }
            catch (Exception ex) {

                ex.ShouldBeType<System.NullReferenceException>();            
            
            }


        }

        [Test]

        // Johans
        public void ProbarCrearDiccionariosExistentes()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

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

        [Test]

        // Johans
        public void ProbarCrearDiccionariosNoExistentes()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            var listaDiccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

            try
            {

                repositorio.SalvarDiccionarios(listaDiccionarios).ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>>();

            }
            catch (Exception ex) {

                ex.ShouldBeType<System.ArgumentNullException>();
            }          


        }


	}
}

