
using Negocio.Comunes;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades.Diccionario;
using System;

namespace Nubise.Hc.Utils.I18n.Babel.Dominio.Repositorios
{
	public interface IDiccionarioRepositorio : IRepositorio<Diccionario>
	{
		List<Diccionario> ObtenerDiccionarios ();

		Diccionario ObtenerUnDiccionario (Guid diccionarioId);
	}
}
