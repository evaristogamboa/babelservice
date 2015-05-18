using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Comunes;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Dominio.Entidades.Etiquetas
{
	public class Etiqueta : Entity<Etiqueta>
	{


		public bool Activo { get; set; }


		public string IdiomaPorDefecto { get; set; }


		public string Descripcion { get; set; }

		[Required]
		public string Nombre { get; set; }


		public List<Traduccion> Textos { get; set; }


		private Etiqueta (string nombre)
		{
            this.Nombre = nombre;
            Textos = new List<Traduccion>();
         
		}

		private Etiqueta (Guid id)
			: base (id)
		{
            Textos = new List<Traduccion>();
		}
		public static Etiqueta CrearNuevaEtiqueta(Guid id)
		{
			return new Etiqueta(id);
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

            if (this.Textos.Exists(item => item.Cultura.CodigoIso == traduccion.Cultura.CodigoIso))
            {
                throw new ArgumentException("Ya existe una traducción con código Iso " + traduccion.Cultura.CodigoIso);
            }

			this.Textos.Add ( traduccion);

			return this;
		}


		public Etiqueta EliminarTraduccion (Traduccion traduccion)
		{
			this.Textos.Remove (traduccion);

			return this;
		}

        public Etiqueta ModificarTraduccion(Traduccion traduccion)
        {
            if(this.Textos.Exists(item=> item.Cultura.CodigoIso == traduccion.Cultura.CodigoIso))
            {
                this.Textos[this.Textos.FindIndex(item => item.Cultura.CodigoIso == traduccion.Cultura.CodigoIso)] = traduccion;
            }
            else
            {
                this.AgregarTraduccion(traduccion);
            }

            return this;
        }
	}
}