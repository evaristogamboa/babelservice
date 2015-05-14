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


        [Test]
		public void DiccionarioRepositorioTestSalvar ()
		{

            var file = @"diccionario_ok.xml";

            var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + file;




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

