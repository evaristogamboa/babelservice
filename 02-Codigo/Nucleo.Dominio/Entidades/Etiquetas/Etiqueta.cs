using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Babel.Nucleo.Dominio.Comunes;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Dominio.Entidades.Etiquetas
{
    public class Etiqueta : Entity<Etiqueta>
    {
        private readonly List<Traduccion> listaTextos = new List<Traduccion>();

        public bool Activo { get; set; }


        public string IdiomaPorDefecto { get; set; }


        public string Descripcion { get; set; }

        [Required]
        public string Nombre { get; set; }


        public IReadOnlyList<Traduccion> Textos
        {
            get
            {
                return new ReadOnlyCollection<Traduccion>(this.listaTextos);
            }
        }

        private Etiqueta(string nombre)
        {
            this.Nombre = nombre;
        }

        private Etiqueta(Guid id)
            : base(id)
        {
        }

        public static Etiqueta CrearNuevaEtiqueta(Guid id)
        {
            return new Etiqueta(id);
        }

        public static Etiqueta CrearNuevaEtiqueta(string nombre)
        {
            var entidad = new Etiqueta(nombre);

            Validator.ValidateObject(entidad, new ValidationContext(entidad), true);

            return entidad;
        }

        public Etiqueta AgregarTraduccion(Traduccion traduccion)
        {
            Validator.ValidateObject(traduccion, new ValidationContext(traduccion), true);

            if (this.listaTextos.Exists(item => item.Cultura.CodigoIso == traduccion.Cultura.CodigoIso))
            {
                throw new ArgumentException("Ya existe una traducción con código Iso " + traduccion.Cultura.CodigoIso);
            }

            this.listaTextos.Add(traduccion);

            return this;
        }

        public Etiqueta AgregarTraducciones(List<Traduccion> traducciones)
        {
            if (traducciones == null)
            {
                throw new ArgumentNullException();
            }

            foreach (Traduccion item in traducciones)
            {
                this.AgregarTraduccion(item);
            }

            return this;
        }

        public Etiqueta EliminarTraduccion(Traduccion traduccion)
        {
            this.listaTextos.Remove(traduccion);

            return this;
        }

        public Etiqueta ModificarTraduccion(Traduccion traduccion)
        {
            if (this.listaTextos.Exists(item => item.Cultura.CodigoIso == traduccion.Cultura.CodigoIso))
            {
                this.listaTextos[this.listaTextos.FindIndex(item => item.Cultura.CodigoIso == traduccion.Cultura.CodigoIso)] = traduccion;
            }
            else
            {
                this.AgregarTraduccion(traduccion);
            }

            return this;
        }
    }
}