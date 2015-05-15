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

            const string idDiccionario = "7a83a1a0-415f-40bd-bd37-82e7f71efdab";

            var diccionarioDom = repositorio.ObtenerUnDiccionario(new Guid(idDiccionario));


            diccionarioDom.ShouldBeType<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>();

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
        public void ProbarCrearUnDiccionarioExistente()
        {

            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();

            
            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom.Textos = new List<Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion>();

            EtqDom.Textos.Add(traduccionDom2);


            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test2");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom2.Textos = new List<Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion>();

            EtqDom2.Textos.Add(traduccionDom22);


            DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid());

            DiccionarioDominio.Etiquetas = new List<Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta>();

            DiccionarioDominio.Etiquetas.Add(EtqDom);
            DiccionarioDominio.Etiquetas.Add(EtqDom2);

            repositorio.SalvarUnDiccionario(DiccionarioDominio).ShouldBeType <List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>>();
        
        
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

            EtqDom.Textos = new List<Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion>();

            EtqDom.Textos.Add(traduccionDom2);


            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test2");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom2.Textos = new List<Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion>();

            EtqDom2.Textos.Add(traduccionDom22);


            DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid());

            DiccionarioDominio.Etiquetas = new List<Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta>();

            DiccionarioDominio.Etiquetas.Add(EtqDom);
            DiccionarioDominio.Etiquetas.Add(EtqDom2);


            DiccionarioDominio2 = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid());

            DiccionarioDominio2.Etiquetas = new List<Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta>();


            DiccionarioDominio2.Etiquetas.Add(EtqDom);
            DiccionarioDominio2.Etiquetas.Add(EtqDom2);

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

