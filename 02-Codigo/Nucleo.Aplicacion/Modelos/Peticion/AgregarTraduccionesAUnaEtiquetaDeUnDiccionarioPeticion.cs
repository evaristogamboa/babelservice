using System;
using System.Collections.Generic;
using System.Linq;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using System.ComponentModel.DataAnnotations;

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
		
		}

		public static AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion CrearNuevaInstancia()
		{
			return new AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion();
		}

		#endregion
	}
}