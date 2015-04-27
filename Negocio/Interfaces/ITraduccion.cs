﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
	public interface ITraduccion
	{
		string ObtenerIdiomaIso();
		string ObtenerNombreDeEtiqueta();
		string ObtenerValorDeEtiqueta();
		string ObtenerDescripcionDeEtiqueta();
	}
}
