using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Babel.Repositorio.Xml.Impl.Modelo;
using Should;
using System;
using System.Collections.Generic;
using EntidadRepo = Babel.Repositorio.Xml.Impl.Modelo;
using EntidadDom = Babel.Nucleo.Dominio.Entidades;
using AutoMapper;

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

        private EntidadDom.Diccionario.Diccionario DiccionarioDominio2 { get; set; }

        private readonly Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura cultura;
        private readonly string texto;

        private Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta Etiq { get; set; }

        
        


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
        
        // Johans
        public void CrearUnDiccionario() 
        {

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test");
                                               
            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept","accept");
                        
            EtqDom.Textos = new List<EntidadDom.Etiquetas.Traduccion>();
            
            EtqDom.Textos.Add(traduccionDom2);


            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test2");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom2.Textos = new List<EntidadDom.Etiquetas.Traduccion>();

            EtqDom2.Textos.Add(traduccionDom22);


            DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid());

            DiccionarioDominio.Etiquetas = new List<EntidadDom.Etiquetas.Etiqueta>();

            DiccionarioDominio.Etiquetas.Add(EtqDom);
            DiccionarioDominio.Etiquetas.Add(EtqDom2);

            // Metodo Mapeo

                        
            DiccionariosRepositorio = new EntidadRepo.Diccionarios();
                        
            DiccionariosRepositorio.ListaDiccionarios = new List<EntidadRepo.Diccionario>();

                          
            var dicctionarioRepo = new EntidadRepo.Diccionario();
            
            dicctionarioRepo.Etiquetas = new EntidadRepo.Etiquetas();

            foreach (var etiqueta in DiccionarioDominio.Etiquetas)
            {


                var EtiquetaMapper = new EntidadRepo.Etiqueta() {
                
                    Activo = etiqueta.Activo,
                    Descripcion = etiqueta.Descripcion,
                    Id = etiqueta.Id,
                    IdiomaPorDefecto = etiqueta.IdiomaPorDefecto,
                    Nombre = etiqueta.Nombre,
                    NombreEtiqueta = etiqueta.Nombre,
                    Traducciones = new EntidadRepo.Traducciones()
                
                };


                foreach (var texto in etiqueta.Textos)
                {

                    var TextoMapper = new EntidadRepo.Traduccion()
                    {
                        Cultura = texto.Cultura.CodigoIso.ToString(),
                        Tooltip = texto.ToolTip,
                        Value = texto.Texto
                    };

                    EtiquetaMapper.Traducciones.Traducciones1.Add(TextoMapper);
                }

                                

                dicctionarioRepo.Etiquetas.ListaEtiquetas.Add(EtiquetaMapper);

            }

            DiccionariosRepositorio.ListaDiccionarios.Add(dicctionarioRepo);

            if (File.Exists(directory))
            {
                File.Delete(directory);
            }

            var serializer = new XmlSerializer(typeof(Diccionarios));


            using (TextWriter writer = new StreamWriter(directory))
            {
                serializer.Serialize(writer, DiccionariosRepositorio);
            }


            //var deserializer = new XmlSerializer(typeof(Diccionarios));

            //StreamReader reader = new StreamReader(directory);
            //object obj = deserializer.Deserialize(reader);
            //reader.Close();

            //DiccionariosRepositorio = (EntidadRepo.Diccionarios)obj;

            //foreach (EntidadRepo.Diccionario item in DiccionariosRepositorio.ListaDiccionarios)
            //{
            //    diccionarios.Add(MapearRepositorioConDiccionario(item));
            //}
        
        }


        [Test]

        // Johans
        public void CrearDiccionarios()
        {

            var listaDiccionarios = new List<EntidadDom.Diccionario.Diccionario>();

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom.Textos = new List<EntidadDom.Etiquetas.Traduccion>();

            EtqDom.Textos.Add(traduccionDom2);


            Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta EtqDom2 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta.CrearNuevaEtiqueta("app.test2");

            Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion traduccionDom22 = Babel.Nucleo.Dominio.Entidades.Etiquetas.Traduccion.CrearNuevaTraduccion(Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura.CrearNuevaCultura("en-US"), "accept", "accept");

            EtqDom2.Textos = new List<EntidadDom.Etiquetas.Traduccion>();

            EtqDom2.Textos.Add(traduccionDom22);


            DiccionarioDominio = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid());

            DiccionarioDominio.Etiquetas = new List<EntidadDom.Etiquetas.Etiqueta>();

            DiccionarioDominio2 = Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario(Guid.NewGuid());

            DiccionarioDominio2.Etiquetas = new List<EntidadDom.Etiquetas.Etiqueta>();



            DiccionarioDominio.Etiquetas.Add(EtqDom);
            DiccionarioDominio.Etiquetas.Add(EtqDom2);

            DiccionarioDominio2.Etiquetas.Add(EtqDom);
            DiccionarioDominio2.Etiquetas.Add(EtqDom2);


            listaDiccionarios.Add(DiccionarioDominio);

            listaDiccionarios.Add(DiccionarioDominio2);

            // Metodo Mapeo


            DiccionariosRepositorio = new EntidadRepo.Diccionarios();

            DiccionariosRepositorio.ListaDiccionarios = new List<EntidadRepo.Diccionario>();
           

            foreach (var diccioario in listaDiccionarios) {

                var dicctionarioRepo = new EntidadRepo.Diccionario();
                
                dicctionarioRepo.Etiquetas = new EntidadRepo.Etiquetas();


                foreach (var etiqueta in diccioario.Etiquetas)
                {


                    var EtiquetaMapper = new EntidadRepo.Etiqueta()
                    {

                        Activo = etiqueta.Activo,
                        Descripcion = etiqueta.Descripcion,
                        Id = etiqueta.Id,
                        IdiomaPorDefecto = etiqueta.IdiomaPorDefecto,
                        Nombre = etiqueta.Nombre,
                        NombreEtiqueta = etiqueta.Nombre,
                        Traducciones = new EntidadRepo.Traducciones()

                    };


                    foreach (var texto in etiqueta.Textos)
                    {

                        var TextoMapper = new EntidadRepo.Traduccion()
                        {
                            Cultura = texto.Cultura.CodigoIso.ToString(),
                            Tooltip = texto.ToolTip,
                            Value = texto.Texto
                        };

                        EtiquetaMapper.Traducciones.Traducciones1.Add(TextoMapper);
                    }



                    dicctionarioRepo.Etiquetas.ListaEtiquetas.Add(EtiquetaMapper);

                }

                DiccionariosRepositorio.ListaDiccionarios.Add(dicctionarioRepo);
            }

            

            if (File.Exists(directory))
            {
                File.Delete(directory);
            }

            var serializer = new XmlSerializer(typeof(Diccionarios));


            using (TextWriter writer = new StreamWriter(directory))
            {
                serializer.Serialize(writer, DiccionariosRepositorio);
            }

                        

        }       


    }
}

