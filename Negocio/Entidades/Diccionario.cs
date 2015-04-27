using System;
using System.Collections.Generic;
using System.Linq;
using Negocio.Interfaces;

namespace Negocio.Entidades
{
	public class Diccionario
	{
		private Guid Id;
		private List<ITraduccion> Traducciones;

		private Diccionario()
		{
			this.Id = new Guid();
			this.Traducciones = null;
		}
		
		public static Diccionario CrearNuevoDiccionarioVacio()
		{
			return new Diccionario();
		}

		public Diccionario RetornarDiccionario()
		{
			return this;
		}
		
		public Diccionario AgregarUnaEtiquetaAlDiccionario(List<ITraduccion> traduccion)
		{

			return ModificarEtiquetasDelDiccionario(traduccion);

		}

		public Diccionario AgregarVariasEtiquetasAlDiccionario(List<ITraduccion> traducciones)
		{
			return ModificarEtiquetasDelDiccionario(traducciones);
		}

		public Diccionario ModificarEtiquetasDelDiccionario(List<ITraduccion> traducciones)
		{
			this.Traducciones = traducciones;
			return this;
		}

		public Diccionario EliminarTodoElDiccionario()
		{
			this.Traducciones = new List<ITraduccion>();
			return this;
		}


		public Guid ObtenerIdDiccionario()
		{
			return this.Id;
		}

		public List<ITraduccion> ObtenerListaDeTraducciones() {
			return this.Traducciones;
		}

	}
}
