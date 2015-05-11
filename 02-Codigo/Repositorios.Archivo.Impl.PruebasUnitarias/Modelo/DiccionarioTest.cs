using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo;
using Should;
using System;
using System.Xml;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorios.Archivo.Impl.PruebasUnitarias.Modelo
{
    [TestFixture]
    public class DiccionarioTest
    {

        public Diccionarios diccionarios { get; set; }

        public Diccionario diccionario { get; set; }

        public Etiquetas etiquetas { get; set; }

        public Etiqueta etiqueta { get; set; }



        public Traducciones traducciones { get; set; }

        //private string directory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + @"\Xml.xml";
        private string directory = "DatosPrueba\\diccionario_ok.xml";


        public DiccionarioTest()
        {

            /*var traduccion1 = new Traduccion ("es-VE", "aceptar", "aceptar");
            var traduccion2 = new Traduccion ("es", "aceptar", "aceptar");
            traducciones = new Traducciones ();
            traducciones.traducciones.Add (traduccion1);
            traducciones.traducciones.Add (traduccion2);
            etiqueta = new Etiqueta ();
            etiqueta.nombre = "app.common.aceptar";
            etiqueta.descripcion = "seh";
            etiqueta.traducciones = traducciones;
            etiqueta.nombreEtiqueta = etiqueta.nombre;
            etiquetas = new Etiquetas (etiqueta);
            diccionario = new Diccionario ("dev", etiquetas);

            this.diccionarios = new Diccionarios (diccionario);
            */


        }


        [Test]
        public void ProbarCreacionArchivoXMLEnDiscoConEstructuraEsperada()
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
                    serializer.Serialize(writer, this.diccionarios);
                }
                //Assert
                Assert.IsTrue(File.Exists(directory));
            }

        }

        [Test]
        public void ProbarDeserealizarDiccionariosDesdeArchivoXMLEnDisco()
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

