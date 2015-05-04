using System;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Comunes;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Repositorios
{
	public interface IDiccionarioRepositorio : IRepositorio<Diccionario>
	{
		List<Diccionario> ObtenerDiccionarios ();

		Diccionario ObtenerUnDiccionario (Guid diccionarioId);
	}
}
