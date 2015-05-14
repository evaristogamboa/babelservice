using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Babel.Interfaz.WebApi.Modelos
{
	[XmlRoot ("traducciones")]
	public class Traducciones
	{
        [XmlElement ("traduccion")]
        public List<Babel.Interfaz.WebApi.Modelos.Traduccion> Traducciones1 { get; set; }

        public Traducciones()
        {
            this.Traducciones1 = new List<Babel.Interfaz.WebApi.Modelos.Traduccion>();
        }

        public Traducciones(Babel.Interfaz.WebApi.Modelos.Traduccion traduccion)
        {
            this.Traducciones1 = new List<Babel.Interfaz.WebApi.Modelos.Traduccion>();
            this.Traducciones1.Add(traduccion);
		}
	}
}

