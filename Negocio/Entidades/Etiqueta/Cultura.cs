using System;
using System.Linq;
using System.Collections.Generic;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Servicios;
using Nubise.Hc.Utils.I18n.Babel.Dominio.Comunes;

namespace Nubise.Hc.Utils.I18n.Babel.Dominio.Entidades
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