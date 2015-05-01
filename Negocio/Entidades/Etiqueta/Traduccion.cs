using System;
using System.Linq;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades;
using System.Security.Cryptography;

namespace Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades
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