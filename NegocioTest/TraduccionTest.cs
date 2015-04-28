using System;
using NUnit.Framework;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades;
using Should;

namespace Nubise.Hc.Utils.I18n.Babel.DominioTest
{
	[TestFixture]
	public class EtiquetaTest
	{
		private Etiqueta etiqueta;

		public EtiquetaTest ()
		{
			this.etiqueta = Etiqueta.CrearNuevaEtiqueta ("en");
		}

		[Test]
		public void ProbarCreacionDeNuevaEtiqueta ()
		{ 
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("en");
			//Act
			//Assert
			prueba.ShouldBeType (typeof(Etiqueta));		
		}

	

		[Test]
		public void PruebaEqualsEsFalsoCuandoNoEsLaMismaEtiqueta ()
		{
			//Arrange	
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("es");
			//Act

			Boolean resultado = this.etiqueta.Equals (prueba);

			//Assert
			resultado.ShouldBeFalse ();
			
		}

		[Test]
		public void PruebaEqualsEsFalsoCuandoEsUnaEtiquetaConLosMismosValores ()
		{
			//Arrange	
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("en");
			//Act			
			Boolean resultado = this.etiqueta.Equals (prueba);
			//Assert
			resultado.ShouldBeFalse ();
			
		}

		[Test]
		public void PruebaEqualsVerdaderoCuandoEsElMismoObjetoDeEtiqueta ()
		{
			//Arrange				
			//Act
			Boolean resultado = this.etiqueta.Equals (this.etiqueta);
			//Assert
			resultado.ShouldBeTrue ();
			
		}

		[Test]
		public void PruebaEqualsFalsoCuandoElObjetoEsNulo ()
		{
			//Arrange				
			//Act
			Boolean resultado = this.etiqueta.Equals (null);
			//Assert
			resultado.ShouldBeFalse ();
		}

		[Test]
		public void PruebaHashCodeEsEntero ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta (null);
			//Act
			int resultado = prueba.GetHashCode ();
			//Assert
			resultado.ShouldBeType (typeof(int));
			
		}
	}
}
