
using Negocio.Comunes;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades.Diccionario;

namespace Nubise.Hc.Utils.I18n.Babel.Dominio.Repositorios
{
	public interface IDiccionarioRepositorio : IRepositorio<Etiqueta>
	{
		List<Diccionario> ObtenerDiccionarios ();

		Diccionario ObtenerUnDiccionario ();
	}
}
