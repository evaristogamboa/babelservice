using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class ConsultarUnDiccionarioarioRespuesta
	{
		public Diccionario Diccionario { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarUnDiccionarioarioRespuesta(string ambiente)
		{
			Relaciones = new Dictionary<string, Guid> { { "diccionario", Guid.Empty } };
            Diccionario = Diccionario.CrearNuevoDiccionario(ambiente);
			Respuesta = new ModeloRespuesta();
		}

        public static ConsultarUnDiccionarioarioRespuesta CrearNuevaInstancia(string ambiente)
		{
            return new ConsultarUnDiccionarioarioRespuesta(ambiente);
		}

		#endregion
	}
}