using System;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Comunes;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Etiquetas;
using System.Collections.ObjectModel;

namespace Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Diccionario
{
    public class Diccionario : Entity<Diccionario>
    {
        # region campos

        private readonly IDictionary<string, Etiqueta> etiquetas = new Dictionary<string, Etiqueta>();

        #endregion
        
        #region propiedades

        public IReadOnlyCollection<Etiqueta> Etiquetas
        {
            get { return new List<Etiqueta>(this.etiquetas.Values).AsReadOnly(); }
        }

        #endregion

        #region constructores

        private Diccionario()
        {
        }

        private Diccionario(Guid id)
            : base(id)
        {
        }

        public static Diccionario CrearNuevoDiccionario()
        {
            return new Diccionario();
        }

        public static Diccionario CrearNuevoDiccionario(Guid id)
        {
            return new Diccionario(id);
        }

        #endregion

        #region agregar

        public Diccionario AgregarEtiqueta(Etiqueta etiqueta)
        {
            if (etiqueta == null)
            {
                throw new ArgumentNullException();
            }

            this.etiquetas.Add(etiqueta.Nombre, etiqueta);

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
            this.etiquetas.Clear();
        }

        public Diccionario EliminarEtiqueta(Etiqueta etiqueta)
        {
            if (etiqueta == null)
            {
                throw new ArgumentNullException();
            }

            this.etiquetas.Remove(etiqueta.Nombre);

            return this;
        }

        #endregion

    }
}
