using System;
using System.Linq;
using NUnit.Framework;
using Should;
using Negocio.Interfaces;
using Negocio.Entidades;
using System.Collections.Generic;

namespace NegocioTest
{
	[TestFixture]
	public class DiccionarioTest
	{
		private Diccionario diccionario;
		private List<ITraduccion> listaEtiquetas;
		private ITraduccion etiqueta1;
		private ITraduccion etiqueta2;
	
		public DiccionarioTest()
		{

			this.listaEtiquetas = new List<ITraduccion>();
			this.etiqueta1 = Traduccion.CrearNuevaTraduccion("en", "1 test de mi aplicación", "1 test", "1 El tooltip de la traduccion");
			this.etiqueta2 = Traduccion.CrearNuevaTraduccion("es", "2 test de mi aplicación", "2 test", "2 El tooltip de la traduccion");
			this.listaEtiquetas.Add(this.etiqueta1);
			this.listaEtiquetas.Add(this.etiqueta2);
			this.diccionario = Diccionario.CrearNuevoDiccionarioVacio();
			
		}


		[Test]
		public void PruebaCrearDiciconarioNuevo()
		{
			//Arrange
			Diccionario prueba = Diccionario.CrearNuevoDiccionarioVacio();
			//Act
			//Assert
			prueba.ShouldBeType(typeof(Diccionario));
		
		}

		[Test]
		public void PruebaObtenerGuidDiccionario()
		{
			//Arrange
			//Act
			//Assert
			this.diccionario.ObtenerIdDiccionario().ShouldBeType(typeof(Guid));

		}
		[Test]
		public void PruebaAgregarEtiquetasAlDiccionario(){
			//Arrange
			Diccionario prueba=Diccionario.CrearNuevoDiccionarioVacio();
			//Act
			prueba.AgregarVariasEtiquetasAlDiccionario(this.listaEtiquetas);
			//Assert
			prueba.ObtenerListaDeTraducciones().ShouldBeType(typeof(List<ITraduccion>));
			prueba.ObtenerListaDeTraducciones().Count().ShouldBeGreaterThan(0);
			prueba.ObtenerListaDeTraducciones().ShouldContain(etiqueta1);
		}

		[Test]
		public void PruebaModificarEtiquetasAlDiccionario()
		{
			//Arrange
			Diccionario prueba = Diccionario.CrearNuevoDiccionarioVacio();
			//Act
			prueba.AgregarVariasEtiquetasAlDiccionario(this.listaEtiquetas);
			//Assert
			prueba.ObtenerListaDeTraducciones().ShouldBeType(typeof(List<ITraduccion>));
			prueba.ObtenerListaDeTraducciones().Count().ShouldBeGreaterThan(0);
			prueba.ObtenerListaDeTraducciones().ShouldContain(etiqueta1);
		}
	}
}
