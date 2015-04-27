using System;
using NUnit.Framework;
using Negocio.Entidades;
using Should;
using Negocio.Interfaces;

namespace NegocioTest
{
	[TestFixture]
    public class TraduccionTest
    {
		private ITraduccion etiqueta;
		public TraduccionTest()
		{
			this.etiqueta = Traduccion.CrearNuevaTraduccion("en", "test de mi aplicación", "test", "Es Gay");
		}
		[Test]
		public void ProbarCreacionDeNuevaEtiqueta()
		{ 
			//Arrange
			Traduccion prueba = Traduccion.CrearNuevaTraduccion("en", "test de mi aplicación", "test", "Es Gay");
			//Act
			//Assert
			prueba.ShouldBeType(typeof(Traduccion));		
		}

		[Test]
		public void ProbarRetornoDescripcionEtiqueta()
		{
			//Arrange
			//Act
			string pruebaDescripcionDeEtiqueta = this.etiqueta.ObtenerDescripcionDeEtiqueta();
			//Assert
			pruebaDescripcionDeEtiqueta.ShouldEqual("Es Gay");
			
		}

		[Test]
		public void ProbarRetornoNombreEtiqueta()
		{
			//Arrange
			//Act
			string pruebaNombreDeEtiqueta = this.etiqueta.ObtenerNombreDeEtiqueta();
			//Assert
			pruebaNombreDeEtiqueta.ShouldEqual("test de mi aplicación");
			
		}

		[Test]
		public void ProbarRetornoIdomaISO()
		{
			//Arrange			
			//Act
			string pruebaIdiomaISO = this.etiqueta.ObtenerIdiomaIso();
			//Assert
			pruebaIdiomaISO.ShouldEqual("en");			
		}

		[Test]
		public void PruebaRetornoValorEtiqueta()
		{
			//Arrange			
			//Act
			string pruebaValorEtiqueta = this.etiqueta.ObtenerValorDeEtiqueta();
			//Assert
			pruebaValorEtiqueta.ShouldEqual("test");			
		}

		[Test]
		public void PruebaEqualsEsFalsoCuandoNoEsLaMismaTraduccion()
		{
			//Arrange	
			Traduccion prueba = Traduccion.CrearNuevaTraduccion("es", "test de mi aplicación", "test", "Es Gay");
			//Act

			Boolean resultado = this.etiqueta.Equals(prueba);

			//Assert
			resultado.ShouldBeFalse();
			
		}

		[Test]
		public void PruebaEqualsEsVerdaderoCuandoEsUnaTraduccionConLosMismosValores()
		{
			//Arrange	
			Traduccion prueba = Traduccion.CrearNuevaTraduccion("en", "test de mi aplicación", "test", "Es Gay");
			//Act			
			Boolean resultado=this.etiqueta.Equals(prueba);
			//Assert
			resultado.ShouldBeTrue();
			
		}

		[Test]
		public void PruebaEqualsVerdaderoCuandoEsElMismoObjetoDeTraduccion()
		{
			//Arrange				
			//Act
			Boolean resultado = this.etiqueta.Equals(this.etiqueta);
			//Assert
			resultado.ShouldBeTrue();
			
		}

		[Test]
		public void PruebaEqualsFalsoCuandoElObjetoEsNulo()
		{
			//Arrange				
			//Act
			Boolean resultado = this.etiqueta.Equals(null);
			//Assert
			resultado.ShouldBeFalse();
		}

		[Test]
		public void PruebaHashCodeEsEntero()
		{
			//Arrange
			Traduccion prueba = Traduccion.CrearNuevaTraduccion(null, null, null, null);
	     	//Act
			int resultado =prueba.GetHashCode();
			//Assert
			resultado.ShouldBeType(typeof(int));
			
		}
    }
}
