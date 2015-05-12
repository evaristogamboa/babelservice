using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Babel.Repositorio.Xml.Impl.Modelo;
using Babel.Nucleo.Dominio.Entidades;
using Babel.Repositorio.Xml.Impl.Implementacion;
using Should;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Babel.Repositorio.Xml.Impl.PruebasUnitarias.Modelo
{
	[TestFixture]
	public class DiccionarioRepositorioTest
	{


		public DiccionarioRepositorioTest ()
		{


		}



		[Test]
		public void ProbarObtenerDiccionariosDelRepositorio ()
		{		
			//Arrange
			DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl ();
			var diccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> ();
			//Act

			diccionarios = (List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>)repositorio.ObtenerDiccionarios ();

			//Assert
			diccionarios.ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>> ();

		}
	}
}

