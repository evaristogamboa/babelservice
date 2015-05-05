using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorios.Archivo.Impl.PruebasUnitarias.Modelo
{
	[TestFixture]
	public class DiccionarioTest
	{
		[Test]
		public void ProbarCreacionDiccionarioXML ()
		{
			//Arrange
			var diccionario = new Diccionario ("dev");
			var diccionarios = new Diccionarios (diccionario);
			//Act
			Serialize (diccionarios);
			//Assert
		}

		private void Serialize (Diccionarios diccionario)
		{
			var serializer = new XmlSerializer (typeof(Diccionarios));
			using (TextWriter writer = new StreamWriter (@"C:\Users\gcarrillo\Documents\Xml.xml")) {
				serializer.Serialize (writer, diccionario);
			} 
		}
	}
}

