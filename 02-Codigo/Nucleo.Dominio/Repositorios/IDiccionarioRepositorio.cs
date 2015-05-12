using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Comunes;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;

namespace Babel.Nucleo.Dominio.Repositorios
{
	public interface IDiccionarioRepositorio
	{
		#region Consultas

		List<Diccionario> ObtenerDiccionarios ();

		#endregion

		#region Salvar

		IEnumerable<Diccionario> SalvarDiccionarios (IEnumerable<Diccionario> diccionarioLista);

		#endregion






	}
}
