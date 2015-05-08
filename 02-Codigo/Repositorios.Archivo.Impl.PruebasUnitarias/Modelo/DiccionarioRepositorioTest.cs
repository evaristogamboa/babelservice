using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades;
using Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Implementacion;
using Should;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorios.Archivo.Impl.PruebasUnitarias.Modelo
{
	[TestFixture]
	public class DiccionarioRepositorioTest
	{


		public DiccionarioRepositorioTest ()
		{
		

		}

		[Test]
		public void ProbarObtenerUnDiccionarioDelRepositorio ()
		{		
			//Arrange
			DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl ();
			var diccionario = Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario.CrearNuevoDiccionario ();
			Guid id = new Guid ("ecf7b09c-2ccc-4205-8cb1-2dc935a20595");
			//Act
			diccionario = repositorio.ObtenerUnDiccionario (id);

			//Assert
			diccionario.ShouldBeType<Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> ();


		}

		[Test]
		public void ProbarObtenerDiccionariosDelRepositorio ()
		{		
			//Arrange
			DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl ();
			var diccionarios = new List<Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> ();
			//Act

			diccionarios = repositorio.ObtenerDiccionarios ();

			//Assert
			diccionarios.ShouldBeType<List<Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>> ();

		}
	}
}

