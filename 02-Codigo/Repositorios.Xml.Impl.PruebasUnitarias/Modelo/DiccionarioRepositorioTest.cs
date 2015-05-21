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
        private const string ambienteTestSoloAmbiente = "SoloAmbiente";

        private Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario DiccionarioDominio { get; set; }


        private Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario DiccionarioDominio2 { get; set; }
    

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

            const string idDiccionario = "25829869-2551-4b60-9dd7-2aaafccf8bfa";

            var diccionarioDom = repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));


            diccionarioDom.ShouldBeType<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

        }

         [Test]

        // Johans
        public void ProbarObtenerUnDiccionarioArchivoNoExiste()
        {

            // Para que ejecute la excepción modificar el ID del diccionario por uno que no exista (Verificar Diccionario)

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            const string idDiccionario = "25829869-2551-4b60-9dd7-2aaafccf8bfa";

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

             // Para que ejecute la excepción modificar el ID del diccionario por uno que no exista (Verificar Diccionario)

             DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

             const string idDiccionario = "25829869-2551-4b60-9dd7-2aaafccf8bfa";

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

             try
             {
                 // Se coloca este valor Convert.ToString(DateTime.Now.Ticks) para que cree diccionarios dinamico con un numero X basado en milisegundos

                 DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();


                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo1_" + Convert.ToString(DateTime.Now.Ticks));

                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                 EtqDom.AgregarTraduccion(traduccionDom2);


                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.testNuevo2_" + Convert.ToString(DateTime.Now.Ticks));

                 Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

                 EtqDom2.AgregarTraduccion(traduccionDom22);


                 DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid(), ambienteTestPrueba);


                 DiccionarioDominio.AgregarEtiqueta(EtqDom);
                 DiccionarioDominio.AgregarEtiqueta(EtqDom2);

                 repositorio.SalvarUnDiccionario(DiccionarioDominio).ShouldEqual(DiccionarioDominio);

             }
             catch (Exception ex) { 
             
             
             }

         }

        [Test]
        public void ProbarCrearUnDiccionarioNuevoConAmbienteExistente()
        {


            try
            {
                // Se coloca este valor Convert.ToString(DateTime.Now.Ticks) para que cree diccionarios dinamico con un numero X basado en milisegundos

                DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

                DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid(), ambienteTestSoloAmbiente);

                repositorio.SalvarUnDiccionario(DiccionarioDominio);

            }
            catch (Exception ex) {

                ex.ShouldBeType<Exception>();
            
            }

        }


        [Test]
        public void ProbarModificarUnDiccionarioExistente()
        {

            // Se coloca este valor Convert.ToString(DateTime.Now.Ticks) para que cree diccionarios dinamico con un numero X basado en milisegundos

            try
            {

                DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();


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

                repositorio.SalvarUnDiccionario(DiccionarioDominio);

            }
            catch (Exception ex) {

                ex.ShouldBeType<Exception>();
            
            }
        
        }

        [Test]

        // Johans
        public void ProbarCrearUnDiccionarioNoExistente()
        {

            try
            {

                DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

                repositorio.SalvarUnDiccionario(DiccionarioDominio);

            }
            catch (Exception ex) {

                ex.ShouldBeType<Exception>();
            
            }


        }

        [Test]

        // Johans
        public void ProbarCrearDiccionariosExistentes()
        {

            try
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
            catch (Exception ex) {

                ex.ShouldBeType<SystemException>();            
            
            }

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


        [Test]
        public void EliminarUnDiccionarioExistente() 
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

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
        public void EliminarListaDiccionarioExistente()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            var listaDiccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

            var listaguid = new List<Guid>() {             
                new Guid("ed14ab25-0178-43a4-ab77-d7c342bd8780"),
                new Guid("4dc68f37-b2d9-4274-852b-03938512864e")            
            };
            
           
            try
            {

                repositorio.EliminarDiccionarios(listaguid);

            }
            catch (Exception ex)
            {

                ex.ShouldBeType<System.NullReferenceException>();
            }



        }




	}
}

