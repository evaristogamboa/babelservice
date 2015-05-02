using Nubise.Hc.Utils.I18n.Babel.Dominio.Comunes;

namespace Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades.Etiquetas
{
	public class Valor : ValueObject<Valor>
	{
		public string valor{ get; private set; }

		private Valor (string valor)
		{
			this.valor = valor;
		}

		public static Valor CrearNuevoValorDeTraduccion (string valor)
		{
			return new Valor (valor);
		}
	}


}