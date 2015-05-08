using System;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Comunes;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Etiquetas
{
	public class Etiqueta : Entity<Etiqueta>
	{
		private readonly IDictionary<string, Traduccion> textos = new Dictionary<string, Traduccion> ();
		//private readonly IDictionary<string, Traduccion> descripciones = new Dictionary<string, Traduccion>();

		[Required]
		public bool Activo { get; set; }

		[Required]
		public string IdiomaPorDefecto { get; set; }

		[Required]
		public string Descripcion { get; set; }

		[Required]
		public string Nombre { get; set; }

		public IReadOnlyCollection<Traduccion> Textos {
			get { return new List<Traduccion> (this.textos.Values).AsReadOnly (); }
		}



		private Etiqueta (string nombre)
		{
			this.Nombre = nombre;
		}

		public static Etiqueta CrearNuevaEtiqueta (string nombre)
		{
			var entidad = new Etiqueta (nombre);

			Validator.ValidateObject (entidad, new ValidationContext (entidad), true);

			return entidad;
		}

		public Etiqueta AgregarTraduccion (Traduccion traduccion)
		{
			Validator.ValidateObject (traduccion, new ValidationContext (traduccion), true);

			this.textos.Add (traduccion.Cultura.CodigoISO, traduccion);

			return this;
		}

		public Etiqueta EliminarTraduccion (Cultura cultura)
		{
			this.textos.Remove (cultura.CodigoISO);

			return this;
		}

		public Etiqueta EliminarTraduccion (Traduccion traduccion)
		{
			this.textos.Remove (traduccion.Cultura.CodigoISO);

			return this;
		}

		public Etiqueta ModificarTraduccion (Traduccion traduccion)
		{
			if (this.textos.ContainsKey (traduccion.Cultura.CodigoISO) == true) {
				this.textos [traduccion.Cultura.CodigoISO] = traduccion;
			} else {
				this.AgregarTraduccion (traduccion);
			}

			return this;
		}
	}
}