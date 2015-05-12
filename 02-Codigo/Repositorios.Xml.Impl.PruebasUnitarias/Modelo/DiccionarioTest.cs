using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Babel.Repositorio.Xml.Impl.Modelo;
using Should;
using System;

namespace Babel.Repositorio.Xml.Impl.PruebasUnitarias.Modelo
{
    [TestFixture]
    public class DiccionarioTest
    {

        public Diccionarios Diccionarios { get; set; }

        public Diccionario Diccionario { get; set; }

        public Etiquetas Etiquetas { get; set; }

        public Etiqueta Etiqueta { get; set; }



        public Traducciones Traducciones { get; set; }

        //private string Directory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + @"\Xml.xml";
        private readonly string directory = "DatosPrueba\\diccionario_ok.xml";

        public DiccionarioTest()
        {

            /*var traduccion1 = new Traduccion ("es-VE", "aceptar", "aceptar");
            var traduccion2 = new Traduccion ("es", "aceptar", "aceptar");
            Traducciones1 = new Traducciones ();
            Traducciones1.Traducciones1.Add (traduccion1);
            Traducciones1.Traducciones1.Add (traduccion2);
            Etiqueta = new Etiqueta ();
            Etiqueta.nombre = "app.common.aceptar";
            Etiqueta.descripcion = "seh";
            Etiqueta.Traducciones1 = Traducciones1;
            Etiqueta.nombreEtiqueta = Etiqueta.nombre;
            Etiquetas = new Etiquetas (Etiqueta);
            Diccionario = new Diccionario ("dev", Etiquetas);

            this.Diccionarios = new Diccionarios (Diccionario);
            */


        }


        [Test]
        public void ProbarCreacionArchivoXmlEnDiscoConEstructuraEsperada()
        {
            //Arrange
            if (File.Exists(directory))
            {
                // intentar borrar el archivo existente, si no se puede, se omite la prueba

                Assert.Ignore("Ya existe un archivo con el mismo nombre.  Se omite la prueba.");
            }
            else
            {
                var serializer = new XmlSerializer(typeof(Diccionarios));
                //Act
                using (TextWriter writer = new StreamWriter(directory))
                {
                    serializer.Serialize(writer, this.Diccionarios);
                }
                //Assert
                Assert.IsTrue(File.Exists(directory));
            }

        }

        [Test]
        public void ProbarDeserealizarDiccionariosDesdeArchivoXmlEnDisco()
        {
            //Arrange
            var deserializer = new XmlSerializer(typeof(Diccionarios));
            //Act


            StreamReader reader = new StreamReader(directory);
            object obj = deserializer.Deserialize(reader);
            reader.Close();
            Diccionarios diccionarios = (Diccionarios)obj;

            //Assert
            diccionarios.ShouldBeType<Diccionarios>();
        }
    }
}

