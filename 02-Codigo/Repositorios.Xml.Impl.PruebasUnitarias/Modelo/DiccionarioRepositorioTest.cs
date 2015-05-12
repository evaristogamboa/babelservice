using Babel.Repositorio.Xml.Impl.Implementacion;
using NUnit.Framework;
using Should;
using System;
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
            DiccionarioRepositorioXmlImpl repositorio = new DiccionarioRepositorioXmlImpl();
			var diccionarios = new List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario> ();
			//Act

			diccionarios = repositorio.ObtenerDiccionarios ();

			//Assert
			diccionarios.ShouldBeType<List<Babel.Nucleo.Dominio.Entidades.Diccionario.Diccionario>> ();

		}
	}
}

