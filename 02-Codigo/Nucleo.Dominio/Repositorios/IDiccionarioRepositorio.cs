using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Comunes;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Dominio.Repositorios
{
	public interface IDiccionarioRepositorio : IRepositorio<Diccionario>
	{
		List<Diccionario> ObtenerDiccionarios ();

		Diccionario ObtenerUnDiccionario (Guid diccionarioId);
	}
}
