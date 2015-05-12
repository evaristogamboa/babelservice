using System;
using Babel.Nucleo.Dominio;
using Babel.Nucleo.Dominio.Repositorios;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using EntidadDom = Babel.Nucleo.Dominio.Entidades;
using EntidadRepo = Babel.Repositorio.Xml.Impl.Modelo;
using System.Xml.Serialization;
using System.IO;
using AutoMapper;
using System.Xml;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using Babel.Nucleo.Dominio.Comunes;
using Babel.Repositorio.Xml.Impl.Modelo;
using System.Linq;



namespace Babel.Repositorio.Xml.Impl.Implementacion
{
	public class DiccionarioRepositorioXmlImpl : IDiccionarioRepositorio
	{

		private EntidadDom.Diccionario.Diccionario diccionarioDominio { get; set; }

		private EntidadRepo.Diccionarios diccionariosRepositorio { get; set; }

		public string directory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + @"\Xml.xml";



		public DiccionarioRepositorioXmlImpl ()
		{
			AutoMapperConfig.SetAutoMapperConfiguration ();
		}

		#region IDiccionarioRepositorio implementation

		public List<EntidadDom.Diccionario.Diccionario> ObtenerDiccionarios ()
		{
			List<EntidadDom.Diccionario.Diccionario> diccionarios = new List<EntidadDom.Diccionario.Diccionario> ();
			var deserializer = new XmlSerializer (typeof(EntidadRepo.Diccionarios));	

			StreamReader reader = new StreamReader (directory);
			object obj = deserializer.Deserialize (reader);
			reader.Close ();

			diccionariosRepositorio = (EntidadRepo.Diccionarios)obj;

			foreach (EntidadRepo.Diccionario item in diccionariosRepositorio.ListaDiccionarios) {
				diccionarios.Add (MapearRepositorioConDiccionario (item));
			}


			return diccionarios;
		}



		private EntidadDom.Diccionario.Diccionario MapearRepositorioConDiccionario (EntidadRepo.Diccionario diccionarioRepo)
		{
			diccionarioDominio = EntidadDom.Diccionario.Diccionario.CrearNuevoDiccionario (diccionarioRepo.Id);
			diccionarioDominio.Etiquetas = new List<EntidadDom.Etiquetas.Etiqueta> ();



			for (int i = 00; i < diccionarioRepo.Etiquetas.ListaEtiquetas.Count (); i++) {
			
				diccionarioDominio.Etiquetas.Add (Mapper.Map<EntidadDom.Etiquetas.Etiqueta> (diccionarioRepo.Etiquetas.ListaEtiquetas [i]));
				for (int x = 0; x < diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.traducciones.Count (); x++) {

					var cultura = EntidadDom.Etiquetas.Cultura.CrearNuevaCultura (diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.traducciones [x].Cultura);
					var traduccion = Mapper.Map<EntidadDom.Etiquetas.Traduccion> (diccionarioRepo.Etiquetas.ListaEtiquetas [i].Traducciones.traducciones [x]);
					traduccion.Cultura = cultura;
					diccionarioDominio.Etiquetas [i].Textos = new List<EntidadDom.Etiquetas.Traduccion> ();
					diccionarioDominio.Etiquetas [i].Textos.Add (traduccion);
				}
			}

		
			return diccionarioDominio;
		}



		public IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> SalvarDiccionarios (IEnumerable<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> diccionarioLista)
		{
			throw new NotImplementedException ();
		}

		#endregion



	
	}
}

