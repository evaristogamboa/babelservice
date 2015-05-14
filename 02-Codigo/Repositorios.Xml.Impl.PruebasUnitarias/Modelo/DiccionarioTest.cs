using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Babel.Repositorio.Xml.Impl.Modelo;
using Should;
using System;
using System.Collections.Generic;
using EntidadRepo = Babel.Repositorio.Xml.Impl.Modelo;
using EntidadDom = Babel.Nucleo.Dominio.Entidades;


namespace Babel.Repositorio.Xml.Impl.PruebasUnitarias.Modelo
{
    [TestFixture]
    public class DiccionarioTest
    {

        public Diccionarios Diccionarios { get; set; }

        public Diccionario DiccionarioEs { get; set; }


        public Diccionario DiccionarioEn { get; set; }

        public Etiquetas Etiquetas { get; set; }

        public Etiqueta Etiqueta { get; set; }

        public EntidadDom.Etiquetas.Etiqueta EtiquetaDom { get; set; }

        public EntidadDom.Etiquetas.Traduccion TraduccionDom { get; set; }


        private EntidadRepo.Diccionarios DiccionariosRepositorio { get; set; }


        private EntidadDom.Diccionario.Diccionario DiccionarioDominio { get; set; }

        


        public Traducciones Traducciones { get; set; }

        //private string Directory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + @"\Xml.xml";
        private readonly string directory = "C:\\HC3\\02-Codigo\\Repositorios.Xml.Impl.PruebasUnitarias\\DatosPrueba\\diccionario_ok.xml";

        

        //public DiccionarioTest()
        //{

        //    var traduccion1 = new Traduccion ("es-VE", "aceptar2", "aceptar2");
        //    var traduccion2 = new Traduccion ("es", "aceptar2", "aceptar2");
        //    var Traducciones1 = new Traducciones ();
        //    Traducciones1.Traducciones1.Add (traduccion1);
        //    Traducciones1.Traducciones1.Add (traduccion2);
        //    Etiqueta = new Etiqueta ();
        //    Etiqueta.Nombre = "app.common.aceptar2";
        //    Etiqueta.Descripcion = "johans";
        //    Etiqueta.Traducciones = Traducciones1;
        //    Etiqueta.NombreEtiqueta = Etiqueta.Nombre;
        //    Etiquetas = new Etiquetas (Etiqueta);
        //    Diccionario = new Diccionario("dev");
        //    Diccionario.Etiquetas = Etiquetas;

        //    this.Diccionarios = new Diccionarios(Diccionario);
            


        //}


        [Test]
        public void ProbarCreacionArchivoXmlEnDiscoConEstructuraEsperada()
        {
            //Arrange
            if (File.Exists(directory))
            {
            
                File.Delete(directory);
            
            }

                var traduccion1 = new Traduccion("es-VE", "aceptar3", "aceptar2");
                var traduccion2 = new Traduccion ("es", "aceptar3", "aceptar2");
                var Traducciones1 = new Traducciones ();
                Traducciones1.Traducciones1.Add(traduccion1);
                Traducciones1.Traducciones1.Add(traduccion2);
                Etiqueta = new Etiqueta();
                Etiqueta.Nombre = "app.common.aceptar3";
                Etiqueta.Descripcion = "johans";
                Etiqueta.Traducciones = Traducciones1;
                Etiqueta.NombreEtiqueta = Etiqueta.Nombre;
                Etiquetas = new Etiquetas(Etiqueta);
                DiccionarioEs = new Diccionario("dev");
                DiccionarioEs.Etiquetas = Etiquetas;
                this.Diccionarios = new Diccionarios(DiccionarioEs);
                

                             
                var serializer = new XmlSerializer(typeof(Diccionarios));
                //Act
                using (TextWriter writer = new StreamWriter(directory))
                {
                    serializer.Serialize(writer, this.Diccionarios);
                }
                //Assert
                Assert.IsTrue(File.Exists(directory));
            

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

        [Test]

        public void CrearXml() 
        {

         
            //if (File.Exists(directory))
            //{

            //    File.Delete(directory);

            //}

            // Repositorio

            var Traducciones = new Traducciones();
            Traducciones.Traducciones1.Add(new Traduccion("es-VE", "aceptar", "aceptar"));
            Traducciones.Traducciones1.Add(new Traduccion("es", "aceptar", "aceptar"));
            Traducciones.Traducciones1.Add(new Traduccion("en-EU", "accept", "aceptar"));
            Traducciones.Traducciones1.Add(new Traduccion("en", "accept", "accept"));
            Etiqueta = new Etiqueta();
            Etiqueta.Nombre = "app.common.aceptar";
            Etiqueta.Descripcion = "Etiqueta aceptar";
            Etiqueta.Traducciones = Traducciones;
            Etiqueta.NombreEtiqueta = Etiqueta.Nombre;
            Etiquetas = new Etiquetas(Etiqueta);
            DiccionarioEs = new Diccionario("dev");
            DiccionarioEs.Etiquetas = Etiquetas;
            this.Diccionarios = new Diccionarios(DiccionarioEs);

            // Dominio        
    

        

            
            var serializer = new XmlSerializer(typeof(Diccionarios));
            //Act
            using (TextWriter writer = new StreamWriter(directory))
            {
                serializer.Serialize(writer, this.Diccionarios);
            }
            //Assert

            var deserializer = new XmlSerializer(typeof(EntidadRepo.Diccionarios));

            StreamReader reader = new StreamReader(directory);
            object obj = deserializer.Deserialize(reader);
            reader.Close();

            DiccionariosRepositorio = (EntidadRepo.Diccionarios)obj;


            Assert.IsTrue(File.Exists(directory));
        
        }


        


    }
}

