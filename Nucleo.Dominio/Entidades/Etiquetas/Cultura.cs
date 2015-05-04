using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Comunes;

namespace Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Etiquetas
{
	public class Cultura : ValueObject<Cultura>
	{
		public string cultura{ get; private set; }

		private Cultura (string cultura)
		{
			this.cultura = cultura;
		}

		public static Cultura CrearNuevoValorDeCultura (string cultura)
		{
			return new Cultura (cultura);
		}

	}
}