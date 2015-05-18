using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Should;
using Babel.Nucleo.Aplicacion.Servicios;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicación.PruebasUnitarias
{
	[TestFixture]
	public class AplicacionServicioPruebas
	{
        private const string ambienteTestPrueba = "Prueba";

		[SetUp]
		public void Inicializar()
		{
			List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();
            Diccionario diccionario = Diccionario.CrearNuevoDiccionario(ambienteTestPrueba);
			Etiqueta etiqueta1 = Etiqueta.CrearNuevaEtiqueta("app.common.aceptar");
			Etiqueta etiqueta2 = Etiqueta.CrearNuevaEtiqueta("app.common.cancelar");
			Cultura cultura = Cultura.CrearNuevaCultura("es-VE");
			Traduccion traduccion = Traduccion.CrearNuevaTraduccion(cultura, "");

			traduccion.Texto = "";
			traduccion.ToolTip = "";


			
			//etiqueta1.Id = new Guid("8a87f8a7-3df9-4d90-9478-350b964fc888");
			etiqueta1.IdiomaPorDefecto = "es-VE";
			etiqueta1.Nombre = "";
			etiqueta1.AgregarTraduccion(traduccion);

			etiqueta1.Activo = true;


			listaDeEtiquetas.Add(etiqueta1);
			listaDeEtiquetas.Add(etiqueta2);

			diccionario.Ambiente = "desarrollo";
			diccionario.AgregarEtiquetas(listaDeEtiquetas);

		}

		[Test]
		public void PruebaDeConsultarEtiquetasDeDiccionarioPorIdioma()
		{
			ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion = ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion.CrearNuevaInstancia();

			peticion.DiccionarioId = new Guid("");
			peticion.Idioma = "es-VE";


			ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta respuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			//respuesta.ListaDeEtiquetas =
			//respuesta.Relaciones =
			//respuesta.Respuesta =

			AplicacionServicio serviciosApi = new AplicacionServicio();


			respuesta = serviciosApi.ConsultarEtiquetasDeDiccionarioPorIdioma(peticion);

			//Assert
			respuesta.ShouldNotBeNull();
		}
	}
}
