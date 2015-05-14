using System;
using System.Linq;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	/// <summary>
	/// Se consulta el nombre de la etiqueta enviado en todos los diccionarios
	/// </summary>
	public class ConsultarEtiquetasPorNombrePeticion
	{
		public string Nombre { get; set; }

		#region Constructores

		private ConsultarEtiquetasPorNombrePeticion()
		{ 
		
		}

		public static ConsultarEtiquetasPorNombrePeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasPorNombrePeticion();
		}

		#endregion
	}
}