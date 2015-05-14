using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Babel.Interfaz.WebApi.Modelos
{
	[XmlRoot ("etiquetas")]
	public class Etiquetas
	{
        [XmlElement ("etiqueta")]
        public List<Babel.Interfaz.WebApi.Modelos.Etiqueta> ListaEtiquetas { get; set; }

        public Etiquetas()
        {
            this.ListaEtiquetas = new List<Babel.Interfaz.WebApi.Modelos.Etiqueta>();
        }

        public Etiquetas(Babel.Interfaz.WebApi.Modelos.Etiqueta etiqueta)
        {
            this.ListaEtiquetas = new List<Babel.Interfaz.WebApi.Modelos.Etiqueta>();
            this.ListaEtiquetas.Add(etiqueta);
		}
	}
}

