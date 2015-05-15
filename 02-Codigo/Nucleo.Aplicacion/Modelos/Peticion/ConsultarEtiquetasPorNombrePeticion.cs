using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	/// <summary>
	/// Se consulta el nombre de la etiqueta enviado en todos los diccionarios
	/// </summary>
	public class ConsultarEtiquetasPorNombrePeticion
	{
		[Required]
		public string Nombre { get; set; }

		#region Constructores

		private ConsultarEtiquetasPorNombrePeticion()
		{
			Nombre = string.Empty;
		}

		public static ConsultarEtiquetasPorNombrePeticion CrearNuevaInstancia()
		{
			return new ConsultarEtiquetasPorNombrePeticion();
		}

		#endregion
	}
}