﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Babel.Repositorio.Xml.Impl.Modelo
{
	[XmlRoot ("etiquetas")]
	public class Etiquetas
	{
		[XmlElement ("etiqueta")]
		public List<Etiqueta> ListaEtiquetas { get; set; }

		public Etiquetas ()
		{
			this.ListaEtiquetas = new List<Etiqueta> ();
		}

		public Etiquetas (Etiqueta etiqueta)
		{
			this.ListaEtiquetas = new List<Etiqueta> ();
			this.ListaEtiquetas.Add (etiqueta);
		}
	}
}

