using System;
using System.Collections.Generic;
using Babel.Nucleo.Dominio.Comunes;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using System.Collections.ObjectModel;

namespace Babel.Nucleo.Dominio.Entidades.Diccionario
{
    public class Diccionario : Entity<Diccionario>
    {
        # region campos

        private readonly List<Etiqueta> etiquetaLista = new List<Etiqueta>();

        #endregion

        #region propiedades

        public IReadOnlyList<Etiqueta> Etiquetas
        {
            get
            {
                return new ReadOnlyCollection<Etiqueta>(etiquetaLista);
            }
        }

        public string Ambiente { get; set; }


        #endregion

        #region constructores

        private Diccionario(string ambiente)
        {
            this.Ambiente = ambiente;
        }

        private Diccionario(Guid id, string ambiente)
            : base(id)
        {
            this.Ambiente = ambiente;
        }

        public static Diccionario CrearNuevoDiccionario(string ambiente)
        {
            return new Diccionario(ambiente);
        }

        public static Diccionario CrearNuevoDiccionario(Guid id, string ambiente)
        {
            return new Diccionario(id, ambiente);
        }

        #endregion

        #region agregar

        public Diccionario AgregarEtiqueta(Etiqueta etiqueta)
        {
            if (etiqueta == null)
            {
                throw new ArgumentNullException();
            }

            if (etiquetaLista.Exists(item => item.Nombre == etiqueta.Nombre))
            {
                throw new ArgumentException("Ya existe una etiqueta con Nombre " + etiqueta.Nombre);
            }

            this.etiquetaLista.Add(etiqueta);

            return this;
        }

        public Diccionario AgregarEtiquetas(List<Etiqueta> etiquetas)
        {
            if (etiquetas == null)
            {
                throw new ArgumentNullException();
            }

            foreach (Etiqueta item in etiquetas)
            {
                this.AgregarEtiqueta(item);
            }

            return this;
        }


        #endregion

        #region editar

        public Diccionario ModificarEtiquetas(List<Etiqueta> etiquetas)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region eliminar

        public void EliminarTodoElDiccionario()
        {
            this.etiquetaLista.Clear();
        }

        public Diccionario EliminarEtiqueta(Etiqueta etiqueta)
        {
            if (etiqueta == null)
            {
                throw new ArgumentNullException();
            }

            this.etiquetaLista.Remove(etiqueta);

            return this;
        }

        #endregion

    }
}
