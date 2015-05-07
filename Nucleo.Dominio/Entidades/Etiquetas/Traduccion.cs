using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Comunes;

namespace Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Etiquetas
{
    public class Traduccion : ValueObject<Traduccion>
    {
        [Required]
        public Cultura Cultura { get; private set; }

        [Required]
        public string Texto { get; private set; }

        private Traduccion(Cultura cultura, string texto)
        {
            this.Cultura = cultura;
            this.Texto = texto;
        }

        public static Traduccion CrearNuevaTraduccion(Cultura cultura, string texto)
        {
            var instancia = new Traduccion(cultura, texto);

            Validator.ValidateObject(instancia, new ValidationContext(instancia), true);

            return instancia;
        }
    }
}