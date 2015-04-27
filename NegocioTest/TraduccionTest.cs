using System;
using NUnit.Framework;
using Negocio.Entidades;
using Should;

namespace NegocioTest
{
	[TestFixture]
    public class EtiquetaTest
    {
		private Etiqueta etiqueta;
		public EtiquetaTest()
		{
			this.etiqueta = Etiqueta.CrearNuevaEtiqueta("en", "test de mi aplicación", "test", "Es Gay");
		}
		[Test]
		public void ProbarCreacionDeNuevaEtiqueta()
		{ 
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta("en", "test de mi aplicación", "test", "Es Gay");
			//Act
			//Assert
			prueba.ShouldBeType(typeof(Etiqueta));		
		}

	

		[Test]
		public void PruebaEqualsEsFalsoCuandoNoEsLaMismaEtiqueta()
		{
			//Arrange	
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta("es", "test de mi aplicación", "test", "Es Gay");
			//Act

			Boolean resultado = this.etiqueta.Equals(prueba);

			//Assert
			resultado.ShouldBeFalse();
			
		}

		[Test]
		public void PruebaEqualsEsVerdaderoCuandoEsUnaEtiquetaConLosMismosValores()
		{
			//Arrange	
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta("en", "test de mi aplicación", "test", "Es Gay");
			//Act			
			Boolean resultado=this.etiqueta.Equals(prueba);
			//Assert
			resultado.ShouldBeTrue();
			
		}

		[Test]
		public void PruebaEqualsVerdaderoCuandoEsElMismoObjetoDeEtiqueta()
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
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta(null, null, null, null);
	     	//Act
			int resultado =prueba.GetHashCode();
			//Assert
			resultado.ShouldBeType(typeof(int));
			
		}
    }
}
