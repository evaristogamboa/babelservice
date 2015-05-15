using Babel.Nucleo.Dominio.Comunes;
using System.ComponentModel.DataAnnotations;

namespace Babel.Nucleo.Dominio.Entidades.Etiquetas
{
	public class Cultura : ValueObject<Cultura>
	{
		[Required]
		[RegularExpression (@"^[a-z]{2}(-[A-Z]{2}){0,1}$", ErrorMessage="El c�digo ISO no es v�lido")]
		public string CodigoIso { get; private set; }

		private Cultura (string cultura)
		{
			this.CodigoIso = cultura;
		}

		public static Cultura CrearNuevaCultura (string codigo)
		{
			var valor = new Cultura (codigo);

			Validator.ValidateObject (valor, new ValidationContext (valor), true);

			return valor;
		}

	}
}