using System;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Comunes;
using Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Etiquetas;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Diccionario
{
	public class Diccionario : Entity<Diccionario>
	{
		#region propiedades

		public Dictionary<string,Etiqueta> etiquetas{ get; private set; }

		#endregion

		#region constructores

		private Diccionario ()
		{
			this.id = Guid.NewGuid ();
			this.fechaCreacion = DateTime.UtcNow;
			this.fechaModificacion = DateTime.UtcNow;
			this.etiquetas = new Dictionary<string,Etiqueta> ();

		}

		#endregion

		#region métodos

		public static Diccionario CrearNuevoDiccionarioVacio ()
		{
			return new Diccionario ();
		}

		public Diccionario RetornarDiccionario ()
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region agregar

		public Diccionario AgregarUnaEtiquetaAlDiccionario (Etiqueta etiqueta)
		{
			this.etiquetas.Add (etiqueta.nombre, etiqueta);

			return this;
		}

		#endregion

		public Diccionario ModificarEtiquetasDelDiccionario (List<Etiqueta> etiquetas)
		{
			throw new NotImplementedException ();
		}

		#region eliminar

		public void EliminarTodoElDiccionario ()
		{
			this.etiquetas.Clear ();
		}


		public Diccionario EliminarEtiqueta (Etiqueta etiqueta)
		{
			this.etiquetas.Remove (etiqueta.nombre);
			return this;
		}

		#endregion

	}
}
