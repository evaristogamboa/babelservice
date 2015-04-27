using System;
using System.Linq;
using NUnit.Framework;
using Should;
using Negocio.Entidades;
using System.Collections.Generic;

namespace NegocioTest
{
	[TestFixture]
	public class DiccionarioTest
	{
		private Diccionario diccionario;
		private List<Etiqueta> listaEtiquetas;
		private Etiqueta etiqueta1;
		private Etiqueta etiqueta2;
	
		public DiccionarioTest()
		{

			this.listaEtiquetas = new List<Etiqueta>();
			this.etiqueta1 = Etiqueta.CrearNuevaEtiqueta("en", "1 test de mi aplicación", "1 test", "1 El tooltip de la Etiqueta");
			this.etiqueta2 = Etiqueta.CrearNuevaEtiqueta("es", "2 test de mi aplicación", "2 test", "2 El tooltip de la Etiqueta");
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
			prueba.ObtenerListaDeEtiquetaes().ShouldBeType(typeof(List<Etiqueta>));
			prueba.ObtenerListaDeEtiquetaes().Count().ShouldBeGreaterThan(0);
			prueba.ObtenerListaDeEtiquetaes().ShouldContain(etiqueta1);
		}

		[Test]
		public void PruebaModificarEtiquetasAlDiccionario()
		{
			//Arrange
			Diccionario prueba = Diccionario.CrearNuevoDiccionarioVacio();
			//Act
			prueba.AgregarVariasEtiquetasAlDiccionario(this.listaEtiquetas);
			//Assert
			prueba.ObtenerListaDeEtiquetaes().ShouldBeType(typeof(List<Etiqueta>));
			prueba.ObtenerListaDeEtiquetaes().Count().ShouldBeGreaterThan(0);
			prueba.ObtenerListaDeEtiquetaes().ShouldContain(etiqueta1);
		}
	}
}
