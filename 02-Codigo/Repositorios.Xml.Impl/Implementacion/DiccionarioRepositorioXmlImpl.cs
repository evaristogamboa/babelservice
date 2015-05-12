using System;
using Babel.Nucleo.Dominio.Repositorios;
using System.Collections.Generic;
using EntidadDom = Babel.Nucleo.Dominio.Entidades;
using EntidadRepo = Babel.Repositorio.Xml.Impl.Modelo;
using System.Xml.Serialization;
using System.IO;
using AutoMapper;
using System.Linq;



namespace Babel.Repositorio.Xml.Impl.Implementacion
{
	public class DiccionarioRepositorioXmlImpl : IDiccionarioRepositorio
	{

		private EntidadDom.Diccionario.Diccionario DiccionarioDominio { get; set; }

		private EntidadRepo.Diccionarios DiccionariosRepositorio { get; set; }

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



		public IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> SalvarDiccionarios (IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> diccionarioLista)
		{
			throw new NotImplementedException ();
		}

		#endregion



	
	}
}

