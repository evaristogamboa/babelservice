using System;
using System.Linq;
using NUnit.Framework;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades.Diccionario;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades.Etiquetas;
using Should;
using System.Collections.Generic;

namespace Nubise.Hc.Utils.I18n.Babel.DominioPruebasUnitarias.Entidades
{
	[TestFixture]
	public class DiccionarioTest
	{
		private Diccionario diccionarioPrueba;
		private Dictionary<string,Etiqueta> listaEtiquetas;
		private Etiqueta etiqueta1;
		private Etiqueta etiqueta2;

		public DiccionarioTest ()
		{

			this.listaEtiquetas = new Dictionary<string,Etiqueta> ();
			this.etiqueta1 = Etiqueta.CrearNuevaEtiqueta ("1 test de mi aplicación");
			this.etiqueta2 = Etiqueta.CrearNuevaEtiqueta ("2 test de mi aplicación");
			this.listaEtiquetas.Add (this.etiqueta1.nombre, this.etiqueta1);
			this.listaEtiquetas.Add (this.etiqueta2.nombre, this.etiqueta2);

		}

		[SetUp]
		public void SetUp ()
		{
			this.diccionarioPrueba = Diccionario.CrearNuevoDiccionarioVacio ();
		}

		#region creacion

		[Test]
		public void PruebaCrearDiciconarioNuevo ()
		{
			//Arrange
			//Act
			//Assert
			this.diccionarioPrueba.ShouldBeType (typeof(Diccionario));
		
		}

		[Test]
		public void PruebaObtenerGuidDiccionario ()
		{
			//Arrange

			//Act
			//Assert
			this.diccionarioPrueba.id.ShouldBeType (typeof(Guid));

		}

		#endregion

		#region agregar etiquetas

		[Test]
		public void PruebaAgregarUnaEtiquetaNoExistenteAlDiccionarioVacio ()
		{
			//Arrange

			//Act
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (this.etiqueta1);
			//Assert
			this.diccionarioPrueba.etiquetas.ShouldBeType (typeof(Dictionary<string,Etiqueta>));
			this.diccionarioPrueba.etiquetas.Count ().ShouldBeGreaterThan (0);
			this.diccionarioPrueba.etiquetas.ShouldContain (new KeyValuePair<string, Etiqueta> (etiqueta1.nombre, etiqueta1));
		}

		[Test]
		public void PruebaAgregarUnaEtiquetaNoExistenteAlDiccionarioConValores ()
		{
			//Arrange

			//Act
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (this.etiqueta1);
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (this.etiqueta2);
			//Assert
			this.diccionarioPrueba.etiquetas.ShouldBeType (typeof(Dictionary<string,Etiqueta>));
			this.diccionarioPrueba.etiquetas.Count ().ShouldBeGreaterThan (0);
			this.diccionarioPrueba.etiquetas.ShouldContain (new KeyValuePair<string, Etiqueta> (etiqueta1.nombre, etiqueta1));
			this.diccionarioPrueba.etiquetas.ShouldContain (new KeyValuePair<string, Etiqueta> (etiqueta2.nombre, etiqueta2));

		}

		[Test]
		public void PruebaAgregarUnaEtiquetaExistenteAlDiccionarioConValores ()
		{
			//Arrange

			//Act
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (this.etiqueta1);

			//Assert
			Assert.Throws<ArgumentException> (delegate {
				this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (this.etiqueta1);
			});

		}

		[Test]
		public void PruebaAgregarUnaEtiquetaNullAlDiccionarioVacio ()
		{
			//Arrange
			//Act
			//Assert
			Assert.Throws<NullReferenceException> (delegate {
				this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (null);
			});

		}

		[Test]
		public void PruebaAgregarUnaEtiquetaNullAlDiccionarioConValores ()
		{
			//Arrange

			//Act
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (etiqueta1);

			//Assert
			Assert.Throws<NullReferenceException> (delegate {
				this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (null);
			});

		}

		[Test]
		public void PruebaAgregarUnaEtiquetaConKeyNullAlDiccionarioVacio ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta (null);		
			//Act
			//Assert
			Assert.Throws<ArgumentNullException> (delegate {
				this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (prueba);
			});

		}

		[Test]
		public void PruebaAgregarUnaEtiquetaConKeyNullAlDiccionarioConValores ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta (null);	
			//Act
			//Assert
			Assert.Throws<ArgumentNullException> (delegate {
				this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (prueba);
			});
		}

		#endregion



		#region eliminar etiquetas

		[Test]
		public void PruebaEliminarDiccionarioCompleto ()
		{
			//Arrange

			//Act
			this.diccionarioPrueba.EliminarTodoElDiccionario ();
			//Assert
			this.diccionarioPrueba.etiquetas.Count ().ShouldEqual (0);
		}

		[Test]
		public void PruebaEliminarUnaEtiquetaExistenteAlDiccionarioConValores ()
		{
			//Arrange
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (this.etiqueta1);
			//Act
			this.diccionarioPrueba.EliminarEtiqueta (this.etiqueta1);
			//Assert
			this.diccionarioPrueba.etiquetas.ShouldNotContain (new KeyValuePair<string, Etiqueta> (this.etiqueta1.nombre, this.etiqueta1));
		}

		[Test]
		public void PruebaEliminarUnaEtiquetaNoExistenteAlDiccionarioConValores ()
		{
			//Arrange
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (this.etiqueta2);
			//Act		
			this.diccionarioPrueba.EliminarEtiqueta (this.etiqueta1);
			//Assert
			this.diccionarioPrueba.etiquetas.Count ().ShouldEqual (1);
		}


		[Test]
		public void PruebaEliminarUnaEtiquetaConKeyNullAlDiccionarioConValores ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta (null);	
			//Act
			//Assert
			Assert.Throws<ArgumentNullException> (delegate {
				this.diccionarioPrueba.EliminarEtiqueta (prueba);
			});
		}

		[Test]
		public void PruebaEliminarUnaEtiquetaNullAlDiccionarioConValores ()
		{
			//Arrange

			//Act
			this.diccionarioPrueba.AgregarUnaEtiquetaAlDiccionario (etiqueta1);

			//Assert
			Assert.Throws<NullReferenceException> (delegate {
				this.diccionarioPrueba.EliminarEtiqueta (null);
			});

		}

		[Test]
		public void PruebaEliminarUnaEtiquetaAlDiccionarioVacio ()
		{
			//Arrange
			Diccionario prueba = Diccionario.CrearNuevoDiccionarioVacio ();
			//Act
			prueba.EliminarEtiqueta (this.etiqueta1);
			//Assert
			prueba.etiquetas.Count ().ShouldEqual (0);
		}




		[Test]
		public void PruebaEliminarUnaEtiquetaConKeyNullAlDiccionarioVacio ()
		{
			//Arrange
			Etiqueta prueba = Etiqueta.CrearNuevaEtiqueta (null);
			Diccionario dicprueba = Diccionario.CrearNuevoDiccionarioVacio ();
			//Act
			//Assert
			Assert.Throws<ArgumentNullException> (delegate {
				dicprueba.EliminarEtiqueta (prueba);
			});
		}

		[Test]
		public void PruebaEliminarUnaEtiquetaNullAlDiccionarioVacio ()
		{
			//Arrange

			//Act
			Diccionario prueba = Diccionario.CrearNuevoDiccionarioVacio ();
			//Assert
			Assert.Throws<NullReferenceException> (delegate {
				prueba.EliminarEtiqueta (null);
			});

		}

		#endregion

		#region Igualdad

		[Test]
		public void PruebaIgualdadDeDiccionariosTrueCuandoEsElMismoDiccionario ()
		{
			//Arrange
			//Act
			//Assert
			this.diccionarioPrueba.Equals (this.diccionarioPrueba).ShouldBeTrue ();
		}

		[Test]
		public void PruebaIgualdadDeDiccionariosFalseCuandoSonDiccionariosDistintos ()
		{
			//Arrange
			Diccionario prueba = Diccionario.CrearNuevoDiccionarioVacio ();
			//Act
			//Assert
			this.diccionarioPrueba.Equals (prueba).ShouldBeFalse ();
		}

		[Test]
		public void PruebaIgualdadDeDiccionariosFalseCuandoComparoConNull ()
		{
			//Arrange
			Diccionario prueba = null;
			//Act
			//Assert
			this.diccionarioPrueba.Equals (prueba).ShouldBeFalse ();
		}

		#endregion
	}

}
