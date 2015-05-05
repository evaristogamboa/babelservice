using System;
using System.Linq;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo.Etiquetas
{
	public class Traduccion
	{
		public Cultura cultura { get; private set; }

		public Valor valor { get; private set; }

		private  Traduccion (Cultura cultura, Valor valor)
		{
			this.cultura = cultura;
			this.valor = valor;
		}

		public static Traduccion CrearNuevaTraduccion (Cultura cultura, Valor valor)
		{
			return new Traduccion (cultura, valor);
		}
	}
}