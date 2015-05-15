using System;
using Babel.Nucleo.Dominio.Repositorios;
using System.Collections.Generic;
using EntidadDom = Babel.Nucleo.Dominio.Entidades;
using EntidadRepo = Babel.Repositorio.Xml.Impl.Modelo;
using System.Xml.Serialization;
using System.IO;
using AutoMapper;
using System.Linq;
using Babel.Repositorio.Xml.Impl.Modelo;



namespace Babel.Repositorio.Xml.Impl.Implementacion
{
	public class DiccionarioRepositorioXmlImpl : IDiccionarioRepositorio
	{

        public Diccionarios Diccionarios { get; set; }

		private EntidadDom.Diccionario.Diccionario DiccionarioDominio { get; set; }

		private EntidadRepo.Diccionarios DiccionariosRepositorio { get; set; }

        private EntidadRepo.Diccionario DiccionarioRepositorio { get; set; }

		public string Directory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + @"\Xml.xml";



        public DiccionarioRepositorioXmlImpl()
		{
			AutoMapperConfig.SetAutoMapperConfiguration ();
		}

		#region IDiccionarioRepositorio implementation

		public List<EntidadDom.Diccionario.Diccionario> ObtenerDiccionarios ()
		{
			List<EntidadDom.Diccionario.Diccionario> diccionarios = new List<EntidadDom.Diccionario.Diccionario> ();
			var deserializer = new XmlSerializer (typeof(EntidadRepo.Diccionarios));	

			StreamReader reader = new StreamReader (Directory);
			object obj = deserializer.Deserialize (reader);
			reader.Close ();

			DiccionariosRepositorio = (EntidadRepo.Diccionarios)obj;

			foreach (EntidadRepo.Diccionario item in DiccionariosRepositorio.ListaDiccionarios) {
				diccionarios.Add (MapearRepositorioConDiccionario (item));
			}


			return diccionarios;
		}



		private EntidadDom.Diccionario.Diccionario MapearRepositorioConDiccionario (EntidadRepo.Diccionario diccionarioRepo)
		{
                       

			DiccionarioDominio = EntidadDom.Diccionario.Diccionario.CrearNuevoDiccionario (diccionarioRepo.Id);
			DiccionarioDominio.Etiquetas = new List<EntidadDom.Etiquetas.Etiqueta> ();

            
			for (int i = 00; i < diccionarioRepo.Etiquetas.ListaEtiquetas.Count (); i++) {
			
				DiccionarioDominio.Etiquetas.Add (Mapper.Map<EntidadDom.Etiquetas.Etiqueta> (diccionarioRepo.Etiquetas.ListaEtiquetas [i]));
				
                for (int x = 0; x < diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.Traducciones1.Count (); x++) {

					var cultura = EntidadDom.Etiquetas.Cultura.CrearNuevaCultura (diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.Traducciones1 [x].Cultura);
					var traduccion = Mapper.Map<EntidadDom.Etiquetas.Traduccion> (diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.Traducciones1 [x]);
					traduccion.Cultura = cultura;
					DiccionarioDominio.Etiquetas [i].Textos = new List<EntidadDom.Etiquetas.Traduccion> ();
					DiccionarioDominio.Etiquetas [i].Textos.Add (traduccion);
				}
			}

		
			return DiccionarioDominio;
		}


        private EntidadRepo.Diccionario MapearDiccionarioConRepositorio(Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario diccionarioDom)
        {

            var dirRepositorio = new EntidadRepo.Diccionarios();

            DiccionariosRepositorio.ListaDiccionarios = new List<EntidadRepo.Diccionario>();            

            var dicctionarioRepo = new EntidadRepo.Diccionario();

            dicctionarioRepo.Etiquetas = new EntidadRepo.Etiquetas();

            foreach (var etiqueta in diccionarioDom.Etiquetas)
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
            

            return dicctionarioRepo;
        }



        public IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> SalvarDiccionarios(IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> diccionarioLista)
		{
            
            DiccionariosRepositorio.ListaDiccionarios = new List<EntidadRepo.Diccionario>();
            
            var diccionarioDom = new List<EntidadDom.Diccionario.Diccionario>();


            if (diccionarioLista.Count() == 0) {

                return diccionarioDom;
            }

         
            if (File.Exists(Directory))
            {
                File.Delete(Directory);
            }                      
            

            foreach (EntidadDom.Diccionario.Diccionario diccionario in diccionarioLista)
            {

                DiccionariosRepositorio.ListaDiccionarios.Add(MapearDiccionarioConRepositorio(diccionario));            
            }
            
            var serializer = new XmlSerializer(typeof(Diccionarios));
            
           
            using (TextWriter writer = new StreamWriter(Directory))
            {
                serializer.Serialize(writer, DiccionariosRepositorio);
            }                       
                        
            var deserializer = new XmlSerializer(typeof(EntidadRepo.Diccionarios));	

            StreamReader reader = new StreamReader(Directory);
            object obj = deserializer.Deserialize(reader);
            reader.Close();

            DiccionariosRepositorio = (EntidadRepo.Diccionarios)obj;

            foreach (EntidadRepo.Diccionario diccionario in DiccionariosRepositorio.ListaDiccionarios) {

                diccionarioDom.Add(MapearRepositorioConDiccionario(diccionario));
            }

            return diccionarioDom;

		}

        public Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario ObtenerUnDiccionario(Guid idDiccionario)
        {

            EntidadDom.Diccionario.Diccionario diccionarioDom = null;

            var deserializer = new XmlSerializer(typeof(EntidadRepo.Diccionarios));

            StreamReader reader = new StreamReader(Directory);
            object obj = deserializer.Deserialize(reader);
            reader.Close();

            EntidadRepo.Diccionarios diccionarioRep = (EntidadRepo.Diccionarios)obj;


            foreach (var diccionario in diccionarioRep.ListaDiccionarios)
            {

                if (diccionario.Id == new Guid(idDiccionario.ToString()))
                {

                    diccionarioDom = MapearRepositorioConDiccionario(diccionario);

                }

            }

            return diccionarioDom;

        }
          
        

        public EntidadDom.Diccionario.Diccionario SalvarUnDiccionario(EntidadDom.Diccionario.Diccionario diccionario)
        {

            if (File.Exists(Directory))
            {
                var deserializer = new XmlSerializer(typeof(EntidadRepo.Diccionarios));

                StreamReader reader = new StreamReader(Directory);
                object obj = deserializer.Deserialize(reader);
                reader.Close();

                EntidadRepo.Diccionarios diccionarioRep = (EntidadRepo.Diccionarios)obj;                

                diccionarioRep.ListaDiccionarios.Add(MapearDiccionarioConRepositorio(diccionario));

                var serializer = new XmlSerializer(typeof(Diccionarios));

                using (TextWriter writer = new StreamWriter(Directory))
                {
                    serializer.Serialize(writer, diccionarioRep);
                }



                var deserializerDom = new XmlSerializer(typeof(EntidadRepo.Diccionarios));

                StreamReader readerDom = new StreamReader(Directory);
                object objDom = deserializer.Deserialize(readerDom);
                reader.Close();


                EntidadRepo.Diccionario diccionarioRepDom = (EntidadRepo.Diccionario)obj;

                return MapearRepositorioConDiccionario(diccionarioRepDom);

            }
            else
            {

                throw new Exception();

            }
            
            
        }
    }

       


		#endregion

        



       

       
    
}

