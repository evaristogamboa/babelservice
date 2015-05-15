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

namespace Babel.Nucleo.Aplicación.PruebasUnitarias
{
	[TestFixture]
	public class AplicacionServicioPruebas
	{

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
