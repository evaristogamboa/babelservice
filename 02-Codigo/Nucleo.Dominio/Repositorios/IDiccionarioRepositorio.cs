using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Nucleo.Dominio.Repositorios
{
	public interface IDiccionarioRepositorio
	{
		#region Consultas

		List<Diccionario> ObtenerDiccionarios ();

        Diccionario ObtenerUnDiccionario(Guid idDiccionario);

		#endregion

		#region Salvar

        List<Diccionario> SalvarUnDiccionario(Diccionario diccionario);

		IEnumerable<Diccionario> SalvarDiccionarios (IEnumerable<Diccionario> diccionarioLista);

		#endregion






	}
}
