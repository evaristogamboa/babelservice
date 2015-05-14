using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

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
