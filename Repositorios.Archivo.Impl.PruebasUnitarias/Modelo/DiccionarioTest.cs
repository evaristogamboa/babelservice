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
			var traduccion1 = new Traduccion ("es-VE", "aceptar", "aceptar");
			var traduccion2 = new Traduccion ("es", "aceptar", "aceptar");
			var traducciones = new Traducciones ();
			traducciones.traducciones.Add (traduccion1);
			traducciones.traducciones.Add (traduccion2);
			var etiqueta = new Etiqueta ();
			etiqueta.nombre = "app.common.aceptar";
			etiqueta.descripcion = "seh";
			etiqueta.traducciones = traducciones;
			var etiquetas = new Etiquetas (etiqueta);
			var diccionario = new Diccionario ("dev", etiquetas);
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

