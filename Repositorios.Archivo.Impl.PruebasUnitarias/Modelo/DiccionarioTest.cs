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
			var prueba = new Diccionarios ();
			//Act
			Serialize (prueba);
			//Assert
		}

		private void Serialize (Diccionarios diccionario)
		{
			XmlSerializer serializer = new XmlSerializer (typeof(Diccionarios));
			using (TextWriter writer = new StreamWriter (@"C:\Users\egamboa\Documents\Xml.xml")) {
				serializer.Serialize (writer, diccionario);
			} 
		}
	}
}

