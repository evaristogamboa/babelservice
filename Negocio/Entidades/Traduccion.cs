﻿using System;
using System.Linq;
using Negocio.Interfaces;

namespace Negocio.Entidades
{
	public class Traduccion : ITraduccion, IEquatable<Traduccion>
	{
		private Guid id;
		private string idiomaISO;
		private string etiquetaNombre;
		private string etiquetaValor;
		private string etiquetaDescripcion;

		private Traduccion(string idiomaISO, string etiquetaNombre, string etiquetaValor, string etiquetaDescripcion)
		{
			this.id = new Guid();
			this.idiomaISO = idiomaISO;
			this.etiquetaNombre = etiquetaNombre;
			this.etiquetaValor = etiquetaValor;
			this.etiquetaDescripcion = etiquetaDescripcion;
		}

		public static Traduccion CrearNuevaTraduccion(string idiomaISO, string etiquetaNombre, string etiquetaValor, string etiquetaDescripcion)
		{
			return new Traduccion(idiomaISO, etiquetaNombre, etiquetaValor, etiquetaDescripcion);
		}

		public string ObtenerIdiomaIso()
		{
			return this.idiomaISO;
		}

		public string ObtenerNombreDeEtiqueta()
		{
			return this.etiquetaNombre;
		}

		public string ObtenerValorDeEtiqueta()
		{
			return this.etiquetaValor;
		}

		public string ObtenerDescripcionDeEtiqueta()
		{
			return this.etiquetaDescripcion;
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

		public bool Equals(Traduccion other)
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
			Traduccion temp = obj as Traduccion;
			if (temp == null)
				return false;
			return this.Equals(temp);
		}

	}
}