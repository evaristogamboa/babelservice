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
	public class DiccionarioRepositorioXmlImpl : IDiccionarioRepositorio{



        #region "Atributos Privados"
            private string directory = string.Empty;
        #endregion        

        #region "Constructor"


        ///  Método: DiccionarioRepositorioXmlImpl
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 22/05/2015
        ///  Descripción: Constructor de la clase DiccionarioRepositorioXmlImpl.        
        /// </summary>
        /// <param name="directory">Parametro de tipo string que contiene la ruta del archivo XML</param>       
       public DiccionarioRepositorioXmlImpl(string directory)
	   {
			    AutoMapperConfig.SetAutoMapperConfiguration ();
                this.directory = directory;
	   }

        #endregion

        #region "IDiccionarioRepositorio implementation"      



        /// <summary>	
        ///  Método: ObtenerDiccionarios
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 20/05/2015
        ///  Descripción: Método que busca todos los diccionarios contenido en el xml repositario.        
        /// </summary>
        /// <returns>Lista de tipo EntidadDom.Diccionario.Diccionario</returns>
        public List<EntidadDom.Diccionario.Diccionario> ObtenerDiccionarios ()
		{

            EntidadRepo.Diccionarios DiccionariosRepositorio = null;

			List<EntidadDom.Diccionario.Diccionario> diccionarios = new List<EntidadDom.Diccionario.Diccionario> ();

            DiccionariosRepositorio = XmlDeSerializador();

			foreach (EntidadRepo.Diccionario item in DiccionariosRepositorio.ListaDiccionarios) {
				diccionarios.Add (MapearRepositorioConDiccionario (item));
			}


			return diccionarios;
		}


        /// <summary>	
        ///  Método: MapearRepositorioConDiccionario
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 14/05/2015
        ///  Descripción: Método que mapea dinámicamente objetos repositorios a objetos dominio.        
        /// </summary>
        /// <param name="diccionarioRepo">Diccionario de tipo repositorio</param>
        /// <returns>Un diccionario de tipo objetos de dominio</returns>
		private EntidadDom.Diccionario.Diccionario MapearRepositorioConDiccionario (EntidadRepo.Diccionario diccionarioRepo)
		{
            
            EntidadDom.Diccionario.Diccionario DiccionarioDominio = null;

			DiccionarioDominio = EntidadDom.Diccionario.Diccionario.CrearNuevoDiccionario (diccionarioRepo.Id, diccionarioRepo.Ambiente);
			
            
			for (int i = 00; i < diccionarioRepo.Etiquetas.ListaEtiquetas.Count (); i++) {
			
				DiccionarioDominio.AgregarEtiqueta (Mapper.Map<EntidadDom.Etiquetas.Etiqueta> (diccionarioRepo.Etiquetas.ListaEtiquetas [i]));
				
                for (int x = 0; x < diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.Traducciones1.Count (); x++) {

					var cultura = EntidadDom.Etiquetas.Cultura.CrearNuevaCultura (diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.Traducciones1 [x].Cultura);
					var traduccion = Mapper.Map<EntidadDom.Etiquetas.Traduccion> (diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.Traducciones1 [x]);
					traduccion.Cultura = cultura;
					DiccionarioDominio.Etiquetas [i].AgregarTraduccion(traduccion);
				}
			}

		
			return DiccionarioDominio;
		}

        /// <summary>	
        ///  Método: MapearDiccionarioConRepositorio
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 15/05/2015
        ///  Descripción: Método que mapea dinámicamente objetos dominio a objetos repositorio.        
        /// </summary>
        /// <param name="diccionarioDom">Dicionario de tipo dominio</param>
        /// <returns>Diccionario mapeado de tipo repositorio</returns>
        private EntidadRepo.Diccionario MapearDiccionarioConRepositorio(Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario diccionarioDom)
        {
            var dicctionarioRepo = new EntidadRepo.Diccionario() { Id = diccionarioDom.Id, Ambiente = diccionarioDom.Ambiente };

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

        /// <summary>	
        ///  Método: SalvarDiccionarios
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 12/05/2015
        ///  Descripción: Método que guarda los diccionarios en el xml repositario.
        /// </summary>        
        /// <param name="diccionarioLista">Lista de Diccionarios de tipo Dominio.Entidades.Diccionario.Diccionario</param>
        /// <returns>Lista de Diccionarios de tipo EntidadDom.Diccionario.Diccionario</returns>
        public IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> SalvarDiccionarios(IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> diccionarioLista)
		{

            var dirRepositario = new EntidadRepo.Diccionarios();

            dirRepositario.ListaDiccionarios = new List<EntidadRepo.Diccionario>();
            
            var diccionarioDom = new List<EntidadDom.Diccionario.Diccionario>();


            if (diccionarioLista.Count() == 0) {

                throw new ArgumentNullException();
            }                    
            

            foreach (EntidadDom.Diccionario.Diccionario diccionario in diccionarioLista)
            {
                dirRepositario.ListaDiccionarios.Add(MapearDiccionarioConRepositorio(diccionario));            
            }

            XmlSerializador(dirRepositario);

            var dirRepositarioDom = XmlDeSerializador();

            foreach (EntidadRepo.Diccionario diccionario in dirRepositarioDom.ListaDiccionarios)
            {

                diccionarioDom.Add(MapearRepositorioConDiccionario(diccionario));
            }

            return diccionarioDom;

		}


        /// <summary>	
        ///  Método: ObtenerUnDiccionario
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 14/05/2015
        ///  Descripción: Método que busca los diccionarios en el xml repositario.
        /// </summary>    
        /// <param name="idDiccionario">Recibe el id del diccionario a buscar de tipo Guid</param>
        /// <returns>Un diccionario de tipo EntidadDom.Diccionario.Diccionario</returns>
        public Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario ObtenerUnDiccionario(Guid idDiccionario)
        {
                        
            EntidadDom.Diccionario.Diccionario diccionarioDom = null;

            EntidadRepo.Diccionarios diccionarioRep = XmlDeSerializador();


            foreach (var diccionario in diccionarioRep.ListaDiccionarios)
            {

                if (diccionario.Id == new Guid(idDiccionario.ToString()))
                {

                    diccionarioDom = MapearRepositorioConDiccionario(diccionario);

                }

            }

            return diccionarioDom;

        }

        /// <summary>	
        ///  Método: EliminarUnDiccionario
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 18/05/2015
        ///  Descripción: Método que elimina un diccionario en el xml repositario.
        /// </summary>    
        /// <param name="idDiccionario">Id del diccionario a buscar de tipo Guid</param>
        /// <returns>Lista de diccionarios de tipo EntidadDom.Diccionario.Diccionario</returns>
        public List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> EliminarUnDiccionario(Guid idDiccionario)
        {

            List<EntidadDom.Diccionario.Diccionario> diccionarioDom = null;

            EntidadRepo.Diccionarios diccionarioRep = XmlDeSerializador();

            var dicSearch = diccionarioRep.ListaDiccionarios.Find(e => e.Id == new Guid(idDiccionario.ToString()));

            if (dicSearch != null) {

                diccionarioRep.ListaDiccionarios.Remove(dicSearch);
            
            }else{

                throw new NullReferenceException();
            
            }

            XmlSerializador(diccionarioRep);

            var dirRepositarioDom = XmlDeSerializador();

            foreach (EntidadRepo.Diccionario diccionario in dirRepositarioDom.ListaDiccionarios)
            {

                diccionarioDom.Add(MapearRepositorioConDiccionario(diccionario));
            }
                      

            return diccionarioDom;

        }
        
        /// <summary>	
        ///  Método: EliminarDiccionarios
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 18/05/2015
        ///  Descripción: Método que busca los diccionarios en el xml repositario para ser eliminados.
        /// </summary> 
        /// <param name="idDiccionarioList">Lista de id's de diccionarios a buscar de tipo Guid's</param>
        /// <returns>Lista de diccionarios de tipo Dominio.Entidades.Diccionario.Diccionario</returns>
        public List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> EliminarDiccionarios(List<Guid> idDiccionarioList)
        {

            
            List<EntidadDom.Diccionario.Diccionario> diccionarioDom = null;

            EntidadRepo.Diccionarios diccionarioRep = XmlDeSerializador();

            foreach (var idDiccionario in idDiccionarioList) {

                var dicSearch = diccionarioRep.ListaDiccionarios.Find(e => e.Id == new Guid(idDiccionario.ToString()));

                if (dicSearch != null)
                {

                    diccionarioRep.ListaDiccionarios.Remove(dicSearch);

                }
                else
                {

                    throw new NullReferenceException(dicSearch.Id.ToString());

                }            
            
            }

            XmlSerializador(diccionarioRep);

            var dirRepositarioDom = XmlDeSerializador();

            foreach (EntidadRepo.Diccionario diccionario in dirRepositarioDom.ListaDiccionarios)
            {

                diccionarioDom.Add(MapearRepositorioConDiccionario(diccionario));
            }


            return diccionarioDom;

        }

        /// <summary>	
        ///  Método: SalvarUnDiccionario
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 21/05/2015
        ///  Descripción: Método que salva un diccionario en el xml repositario.
        /// </summary>   
        /// <param name="diccionario">Diccionario de tipo EntidadDom.Diccionario.Diccionario</param>
        /// <returns>Diccionario de tipo EntidadDom.Diccionario.Diccionario</returns>
        public EntidadDom.Diccionario.Diccionario SalvarUnDiccionario(EntidadDom.Diccionario.Diccionario diccionario)
        {
            
            var exist = false;
            
            EntidadDom.Diccionario.Diccionario dicDom = null;
            
            EntidadRepo.Diccionarios diccionarioRep = XmlDeSerializador();

            if (diccionario == null) { 
            
                throw new Exception();
            
            }

            var test = diccionarioRep.ListaDiccionarios.Find(e => e.Ambiente == diccionario.Ambiente);

            if (diccionarioRep.ListaDiccionarios.Find(e => e.Ambiente == diccionario.Ambiente) != null) {

                throw new Exception();
            
            }

           
                foreach (EntidadRepo.Diccionario direp in diccionarioRep.ListaDiccionarios)
                {

                    if (direp.Id == diccionario.Id)
                    {
                        
                        var dirRepoReplace = MapearDiccionarioConRepositorio(diccionario);

                        direp.Etiquetas.ListaEtiquetas.Clear();

                        foreach (var etiquetas in dirRepoReplace.Etiquetas.ListaEtiquetas)
                        {

                            direp.Etiquetas.ListaEtiquetas.Add(etiquetas);

                        }

                        exist = true;

                    }                    
                
                }


                if (exist == false) {

                    diccionarioRep.ListaDiccionarios.Add(MapearDiccionarioConRepositorio(diccionario));                         
                
                }


                XmlSerializador(diccionarioRep);

                EntidadRepo.Diccionarios diccionarioRepDom = XmlDeSerializador();

                foreach (EntidadRepo.Diccionario dirRep in diccionarioRepDom.ListaDiccionarios)
                {


                    if (dirRep.Id == diccionario.Id)                 
                    
                    {
                        dicDom =  MapearRepositorioConDiccionario(dirRep);
                        break;

                    }                  
               
                }                

            

            return dicDom;
            
        }

        #endregion

        #region "Metodos de lectura - escritura"       


        /// <summary>
        ///  Método: XmlSerializador
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 21/05/2015
        ///  Descripción: Método que escribe los diccionarios según el directorio que se le envie.
        /// </summary>
        /// <param name="diccionarios">Lista de diccionario tipo repositorio</param>
        /// <param name="Directory">Ruta del directorio del archivo especificado</param>
        private void XmlSerializador(EntidadRepo.Diccionarios diccionarios)
        {

            try
            {
                File.Delete(directory);

                var serializer = new XmlSerializer(typeof(Diccionarios));

                using (TextWriter writer = new StreamWriter(directory))
                {
                    serializer.Serialize(writer, diccionarios);
                }
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        
        }


        /// <summary>
        ///  Método: XmlSerializador
        ///  Desarrollador: Johans Cuéllar
        ///  Creado: 21/05/2015
        ///  Descripción: Método que busca los diccionarios según el directorio que se le envie.
        /// </summary>        
        /// <param name="Directory">Ruta del directorio del archivo especificado</param>
        private EntidadRepo.Diccionarios XmlDeSerializador()
       {

            if (File.Exists(directory))
                {

                    var deserializer = new XmlSerializer(typeof(EntidadRepo.Diccionarios));

                    StreamReader reader = new StreamReader(directory);
                    object obj = deserializer.Deserialize(reader);
                    reader.Close();

                    EntidadRepo.Diccionarios diccionarioRep = (EntidadRepo.Diccionarios)obj;

                    return diccionarioRep;

                }
                else
                {

                    throw new Exception();

                }


        }

        #endregion

    }
 
     

    
}

