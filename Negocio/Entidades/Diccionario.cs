using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Entidades
{
	public class Diccionario
	{
		private Guid Id;
		private List<Etiqueta> Etiquetaes;

		private Diccionario()
		{
			this.Id = new Guid();
			this.Etiquetaes = null;
		}
		
		public static Diccionario CrearNuevoDiccionarioVacio()
		{
			return new Diccionario();
		}

		public Diccionario RetornarDiccionario()
		{
			return this;
		}
		
		public Diccionario AgregarUnaEtiquetaAlDiccionario(List<Etiqueta> Etiqueta)
		{

			return ModificarEtiquetasDelDiccionario(Etiqueta);

		}

		public Diccionario AgregarVariasEtiquetasAlDiccionario(List<Etiqueta> Etiquetaes)
		{
			return ModificarEtiquetasDelDiccionario(Etiquetaes);
		}

		public Diccionario ModificarEtiquetasDelDiccionario(List<Etiqueta> Etiquetaes)
		{
			this.Etiquetaes = Etiquetaes;
			return this;
		}

		public Diccionario EliminarTodoElDiccionario()
		{
			this.Etiquetaes = new List<Etiqueta>();
			return this;
		}


		public Guid ObtenerIdDiccionario()
		{
			return this.Id;
		}

		public List<Etiqueta> ObtenerListaDeEtiquetaes() {
			return this.Etiquetaes;
		}

	}
}
