using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;

namespace Nubise.Hc.Utils.I18n.Babel.Dominio.Servicios
{
	public class ServicioDeCulturasIso
	{
		public IEnumerable culturasEspecificas { get; private set; }

		public IEnumerable culturasNeutrales { get; private set; }

		private ServicioDeCulturasIso ()
		{
			this.culturasEspecificas = CultureInfo.GetCultures (CultureTypes.SpecificCultures);
			this.culturasNeutrales = CultureInfo.GetCultures (CultureTypes.NeutralCultures);
		}

		public static ServicioDeCulturasIso CrearObjetoDeCulturasIso ()
		{
			return new ServicioDeCulturasIso ();
		}

	
	}

}