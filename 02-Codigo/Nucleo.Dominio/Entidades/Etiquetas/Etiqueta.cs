using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Comunes;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Dominio.Entidades.Etiquetas
{
	public class Etiqueta : Entity<Etiqueta>
	{

		[Required]
		public bool Activo { get; set; }

		[Required]
		public string IdiomaPorDefecto { get; set; }

		[Required]
		public string Descripcion { get; set; }

		[Required]
		public string Nombre { get; set; }


		public List<Traduccion> Textos { get; set; }


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

			this.Textos.Add (traduccion.Cultura.CodigoIso, traduccion);

			return this;
		}

		public Etiqueta EliminarTraduccion (Cultura cultura)
		{
			this.Textos.Remove (cultura.CodigoIso);

			return this;
		}

		public Etiqueta EliminarTraduccion (Traduccion traduccion)
		{
			this.Textos.Remove (traduccion.Cultura.CodigoIso);

			return this;
		}

        //public Etiqueta ModificarTraduccion (Traduccion traduccion)
        //{
        //    if (this.Textos. (traduccion.Cultura.CodigoIso) == true) {
        //        this.Textos [traduccion.Cultura.CodigoIso] = traduccion;
        //    } else {
        //        this.AgregarTraduccion (traduccion);
        //    }

        //    return this;
        //}
	}
}