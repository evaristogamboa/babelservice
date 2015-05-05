using NUnit.Framework;
using System.IO;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorios.Archivo.Impl.PruebasUnitarias.Modelo
{
	[TestFixture]
	public class DiccionarioTest
	{
		[Test]
		public void ProbarCreacionDiccionarioXML ()
		{
			var serializer = new XmlSerializer (typeof(Diccionario)); 
			using (TextWriter writer = new StreamWriter (@"C:\Xml.xml")) {
				serializer.Serialize (writer, details); 
			} 
		}
	}
}

