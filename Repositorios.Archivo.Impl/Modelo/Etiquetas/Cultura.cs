

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Etiquetas
{
	public class Cultura
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