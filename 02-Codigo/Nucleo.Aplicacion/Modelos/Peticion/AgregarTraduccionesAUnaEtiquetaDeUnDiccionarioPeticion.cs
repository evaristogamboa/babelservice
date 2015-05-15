using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Aplicacion.Modelos.Peticion
{
	public class AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion
	{
		[Required]
		public List<Traduccion> ListaDeTraducciones { get; set; }

		[Required]
		public Guid EtiquetaId { get; set; }

		[Required]
		public Guid DiccionarioId { get; set; }

		#region constructores

		private AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion()
		{
			ListaDeTraducciones = new List<Traduccion>();
			EtiquetaId = Guid.Empty;
			DiccionarioId = Guid.Empty;
		}

		public static AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion();
		}

		#endregion
	}
}