using System;
using System.Linq;

namespace Negocio.Entidades
{
	public class Etiqueta : IEquatable<Etiqueta>
	{
		private Guid id;
		private string idiomaISO;
		private string etiquetaNombre;
		private string etiquetaValor;
		private string etiquetaDescripcion;

		private Etiqueta(string idiomaISO, string etiquetaNombre, string etiquetaValor, string etiquetaDescripcion)
		{
			this.id = new Guid();
			this.idiomaISO = idiomaISO;
			this.etiquetaNombre = etiquetaNombre;
			this.etiquetaValor = etiquetaValor;
			this.etiquetaDescripcion = etiquetaDescripcion;
		}

		public static Etiqueta CrearNuevaEtiqueta(string idiomaISO, string etiquetaNombre, string etiquetaValor, string etiquetaDescripcion)
		{
			return new Etiqueta(idiomaISO, etiquetaNombre, etiquetaValor, etiquetaDescripcion);
		}

		public Etiqueta RetornarEtiqueta() {
			return this;
		}
		
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 17;
				result = result * 23 + ((idiomaISO != null) ? this.idiomaISO.GetHashCode() : 0);
				result = result * 23 + ((etiquetaNombre != null) ? this.etiquetaNombre.GetHashCode() : 0);
				result = result * 23 + ((etiquetaValor != null) ? this.etiquetaValor.GetHashCode() : 0);
				result = result * 23 + ((etiquetaDescripcion != null) ? this.etiquetaDescripcion.GetHashCode() : 0);
				return result;
			}
		}

		public bool Equals(Etiqueta other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return Equals(this.idiomaISO, other.idiomaISO) &&
				   Equals(this.etiquetaNombre, other.etiquetaNombre) &&
				   Equals(this.etiquetaValor, other.etiquetaValor) &&
				   Equals(this.etiquetaDescripcion, other.etiquetaDescripcion);
		}

		public override bool Equals(object obj)
		{
			Etiqueta temp = obj as Etiqueta;
			if (temp == null)
				return false;
			return this.Equals(temp);
		}

	}
}