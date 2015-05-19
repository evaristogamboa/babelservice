using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Aplicacion.Modelos.Respuesta
{
	public class CrearUnDiccionarioRespuesta
	{
		public Diccionario DiccionarioNuevo { get; set; }

		public Dictionary<string, Guid> Relaciones { get; set; }

		public ModeloRespuesta Respuesta { get; set; }

		#region constructores

        private CrearUnDiccionarioRespuesta(string ambiente)
		{
            DiccionarioNuevo = Diccionario.CrearNuevoDiccionario(ambiente);
            Relaciones = new Dictionary<string, Guid> { { "diccionario", DiccionarioNuevo.Id } };

			Respuesta = new ModeloRespuesta();
		}

        public static CrearUnDiccionarioRespuesta CrearNuevaInstancia(string ambiente)
		{
            return new CrearUnDiccionarioRespuesta(ambiente);
		}

		#endregion
	}
}