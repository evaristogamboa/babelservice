using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades.Etiquetas;
using Should;

namespace Nubise.Hc.Utils.I18n.Babel.DominioTests.Entidades
{
	[TestFixture]
	public class EtiquetaTest
	{
		private Etiqueta etiqueta;
		private Cultura cultura;
		private Valor valor;

		public EtiquetaTest ()
		{
			this.etiqueta = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			this.cultura = Cultura.CrearNuevoValorDeCultura ("en-US");
			this.valor = Valor.CrearNuevoValorDeTraduccion ("accept");
		}

		#region creacion

		[Category ("Long")]
		[Test]
		public void PruebaCreacionDeNuevaEtiqueta ()
		{ 
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("en");
			//Act
			//Assert
			prueba.ShouldBeType (typeof(Etiqueta));		
		}

		#endregion

		#region igualdad

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

		#endregion

		#region hashcode

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

		#endregion

		#region agregar traducciones

		[Test]
		public void PruebaAgregarTraduccionExitenteAEtiquetaConTraducciones ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			Traduccion traduccion = Traduccion.CrearNuevaTraduccion (this.cultura, this.valor);
			Traduccion traduccion2 = Traduccion.CrearNuevaTraduccion (this.cultura, this.valor);
			//Act
			prueba.traducciones.AgregarTraduccion (traduccion);
			//Assert
			Assert.Throws<ArgumentException> (delegate {
				prueba.traducciones.AgregarTraduccion (traduccion2);
			});
		}

		[Test]
		public void PruebaAgregarTraduccionAEtiquetaSinTraducciones ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			//Act
			Traduccion traduccion = Traduccion.CrearNuevaTraduccion (this.cultura, this.valor);
			prueba.traducciones.AgregarTraduccion (traduccion);
			//Assert
			prueba.ShouldBeType<Etiqueta> ();
			prueba.traducciones.dict.Count.ShouldEqual (1);
			prueba.traducciones.dict.ShouldContain (new KeyValuePair<Cultura, Valor> (this.cultura, this.valor));

		}

		[Test]
		public void PruebaAgregarTraduccionAEtiquetaConTraducciones ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			Traduccion traduccion = Traduccion.CrearNuevaTraduccion (this.cultura, this.valor);
			prueba.traducciones.AgregarTraduccion (traduccion);
			//Act
			Traduccion traprueba = Traduccion.CrearNuevaTraduccion (Cultura.CrearNuevoValorDeCultura ("en"), this.valor);
			prueba.traducciones.AgregarTraduccion (traprueba);
			//Assert
			prueba.ShouldBeType<Etiqueta> ();
			prueba.traducciones.dict.Count.ShouldEqual (2);
			prueba.traducciones.dict.ShouldContain (new KeyValuePair<Cultura, Valor> (this.cultura, this.valor));
			prueba.traducciones.dict.ShouldContain (new KeyValuePair<Cultura, Valor> (Cultura.CrearNuevoValorDeCultura ("en"), this.valor));

		}



		#endregion

		#region eliminar traducciones

		[Test]
		public void PruebaEliminarTraduccionAEtiquetaSinTraducciones ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			//Act
			prueba.traducciones.EliminarTraduccion (this.cultura);
			//Assert
			prueba.traducciones.dict.Count.ShouldEqual (0);
		}

		[Test]
		public void PruebaEliminarTraduccionExistenteAEtiquetaConTraducciones ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			prueba.traducciones.AgregarTraduccion (Traduccion.CrearNuevaTraduccion (this.cultura, this.valor));
			//Act
			prueba.traducciones.EliminarTraduccion (this.cultura);
			//Assert
			prueba.traducciones.dict.Count.ShouldEqual (0);
		}

		[Test]
		public void PruebaEliminarTraduccionNoExistenteAEtiquetaConTraducciones ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			prueba.traducciones.AgregarTraduccion (Traduccion.CrearNuevaTraduccion (this.cultura, this.valor));
			//Act
			prueba.traducciones.EliminarTraduccion (Cultura.CrearNuevoValorDeCultura ("es"));
			//Assert
			prueba.traducciones.dict.Count.ShouldEqual (1);
		}

		#endregion

		#region modificar traducciones

		[Test]
		public void PruebaModificarTraduccionAEtiquetaSinTraduccionesAgregaNuevaTraduccion ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			Traduccion traduccion = Traduccion.CrearNuevaTraduccion (Cultura.CrearNuevoValorDeCultura ("es"), Valor.CrearNuevoValorDeTraduccion ("aceptar"));
			//Act
			prueba.traducciones.ModificarTraduccion (traduccion);
			//Assert
			prueba.traducciones.dict.Count.ShouldEqual (1);
			prueba.traducciones.dict.ContainsKey (Cultura.CrearNuevoValorDeCultura ("es")).ShouldEqual (true);
		}

		[Test]
		public void PruebaModificarTraduccionExistenteAEtiquetaConTraduccionesCambiaValorDeLaTraduccion ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta ("app.common.aceptar");
			prueba.traducciones.AgregarTraduccion (Traduccion.CrearNuevaTraduccion (Cultura.CrearNuevoValorDeCultura ("jp"), Valor.CrearNuevoValorDeTraduccion ("oajsdojand")));
			Traduccion traduccion = Traduccion.CrearNuevaTraduccion (Cultura.CrearNuevoValorDeCultura ("jp"), Valor.CrearNuevoValorDeTraduccion ("fdfdaddsa"));
			//Act
			prueba.traducciones.ModificarTraduccion (traduccion);
			//Assert
			prueba.traducciones.dict.Count.ShouldEqual (1);
			prueba.traducciones.dict.ContainsKey (Cultura.CrearNuevoValorDeCultura ("jp")).ShouldEqual (true);
			prueba.traducciones.dict [Cultura.CrearNuevoValorDeCultura ("jp")].ShouldEqual (Valor.CrearNuevoValorDeTraduccion ("fdfdaddsa"));
		}

		#endregion
	}
}
