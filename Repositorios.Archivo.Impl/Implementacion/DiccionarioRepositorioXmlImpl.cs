﻿using System;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Repositorios;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario;
using EntidadDom = Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades;
using EntidadRepo = Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo;
using System.Xml.Serialization;
using System.IO;
using AutoMapper;
using System.Xml;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Etiquetas;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Comunes;



namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Implementacion
{
	public class DiccionarioRepositorioXmlImpl : IDiccionarioRepositorio
	{

		private EntidadDom.Diccionario.Diccionario diccionarioDominio { get; set; }

		private EntidadRepo.Diccionarios diccionariosRepositorio { get; set; }

		public string directory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + @"\Xml.xml";



		public DiccionarioRepositorioXmlImpl ()
		{

		}

		#region IDiccionarioRepositorio implementation

		public List<Diccionario> ObtenerDiccionarios ()
		{
			List<Diccionario> diccionarios = new List<Diccionario> ();
			var deserializer = new XmlSerializer (typeof(EntidadRepo.Diccionarios));	

			StreamReader reader = new StreamReader (directory);
			object obj = deserializer.Deserialize (reader);
			reader.Close ();

			diccionariosRepositorio = (EntidadRepo.Diccionarios)obj;

			foreach (EntidadRepo.Diccionario item in diccionariosRepositorio.diccionarios) {
				diccionarios.Add (MapearRepositorioConDiccionario (item));
			}


			return diccionarios;
		}

		public Diccionario ObtenerUnDiccionario (Guid diccionarioId)
		{

			var deserializer = new XmlSerializer (typeof(EntidadRepo.Diccionarios));	

			StreamReader reader = new StreamReader (directory);
			object obj = deserializer.Deserialize (reader);
			reader.Close ();

			diccionariosRepositorio = (EntidadRepo.Diccionarios)obj;

			var diccionarioRepo = diccionariosRepositorio.diccionarios.Find (d => d.id == diccionarioId);


			return MapearRepositorioConDiccionario (diccionarioRepo);

		}

		private EntidadDom.Diccionario.Diccionario MapearRepositorioConDiccionario (EntidadRepo.Diccionario diccionarioRepo)
		{
			diccionarioDominio = Diccionario.CrearInstaciaDiccionarioPorId (diccionarioRepo.id);

			foreach (EntidadRepo.Etiqueta item in diccionarioRepo.etiquetas.etiquetas) {
				var etiquetaDominio = EntidadDom.Etiquetas.Etiqueta.CrearNuevaEtiqueta (item.nombreEtiqueta);
				etiquetaDominio.activo = item.activo;
				etiquetaDominio.descripcion = item.descripcion;
				etiquetaDominio.idiomaPorDefecto = item.idiomaPorDefecto;
				etiquetaDominio.nombre = item.nombre;
				etiquetaDominio.traducciones = MapearRepositorioConTraducciones (item.traducciones);

				diccionarioDominio.AgregarUnaEtiquetaAlDiccionario (etiquetaDominio);
			}
				
			diccionarioDominio.ambiente = diccionarioRepo.ambiente;

			return diccionarioDominio;
		}

	
		private EntidadDom.Etiquetas.Traducciones MapearRepositorioConTraducciones (EntidadRepo.Traducciones traduccionesRepo)
		{
			EntidadDom.Etiquetas.Traducciones traduccionesDom = EntidadDom.Etiquetas.Traducciones.CrearNuevaTraduccion ();
			EntidadDom.Etiquetas.Cultura cultura;
			EntidadDom.Etiquetas.Traduccion traduccion;
			EntidadDom.Etiquetas.Valor valor;

			foreach (EntidadRepo.Traduccion item in traduccionesRepo.traducciones) {
				cultura = EntidadDom.Etiquetas.Cultura.CrearNuevoValorDeCultura (item.cultura);
				valor = EntidadDom.Etiquetas.Valor.CrearNuevoValorDeTraduccion (item.value);
				traduccion = EntidadDom.Etiquetas.Traduccion.CrearNuevaTraduccion (cultura, valor);
				traduccionesDom.AgregarTraduccion (traduccion);
			}

			return traduccionesDom;
		}

		#endregion

		#region IRepositorio implementation

		public List<Diccionario> ObtenerTodosLosElementos ()
		{
			throw new NotImplementedException ();
		}

		public Diccionario ObtenerUnElemento ()
		{
			throw new NotImplementedException ();
		}

		public bool EliminarUnElemento (Guid id)
		{
			throw new NotImplementedException ();
		}

		public Diccionario ModificarUnElemento (Diccionario elementoAModificar)
		{
			throw new NotImplementedException ();
		}

		public Diccionario CrearUnElemento (Diccionario elementoACrear)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

