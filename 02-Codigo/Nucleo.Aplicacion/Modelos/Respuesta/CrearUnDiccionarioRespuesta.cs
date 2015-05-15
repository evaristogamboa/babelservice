﻿using System;
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

		private CrearUnDiccionarioRespuesta()
		{
			Relaciones = new Dictionary<string, Guid> { { "diccionario", Guid.Empty } };
			DiccionarioNuevo = Diccionario.CrearNuevoDiccionario();
			Respuesta = new ModeloRespuesta();
		}

		public static CrearUnDiccionarioRespuesta CrearNuevaInstancia()
		{
			return new CrearUnDiccionarioRespuesta();
		}

		#endregion
	}
}