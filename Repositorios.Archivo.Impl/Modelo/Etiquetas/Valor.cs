
namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Etiquetas
{
	public class Valor
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