using System;
using Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Comunes;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Etiquetas
{
	public class Etiqueta : Entity<Etiqueta>
	{
		public Traducciones traducciones{ get; private set; }

		public string nombre { get; private set; }

		public Traducciones descripcion { get; private set; }

		private Etiqueta (string nombre)
		{
			this.id = Guid.NewGuid ();
			this.nombre = nombre;
			this.descripcion = Traducciones.CrearNuevaTraduccion ();
			this.traducciones = Traducciones.CrearNuevaTraduccion ();
			this.fechaCreacion = DateTime.UtcNow;
			this.fechaModificacion = DateTime.UtcNow;
		}

		public static Etiqueta CrearNuevaEtiqueta (string nombre)
		{
			return new Etiqueta (nombre);
		}

		public Etiqueta RetornarEtiqueta ()
		{
			return this;
		}

		//		public Traduccion RetornarTraduccionDeEtiqueta (Cultura cultura)
		//		{
		//			return traducciones.;
		//		}
	}
}