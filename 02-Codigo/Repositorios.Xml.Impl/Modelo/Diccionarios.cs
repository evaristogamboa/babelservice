﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace Babel.Repositorio.Xml.Impl.Modelo
{
	[XmlRoot ("diccionarios")]
	public class Diccionarios
	{
		#region propiedades

		[XmlElement ("diccionario")]
		public List<Diccionario> diccionarios{ get; set; }

		#endregion

		#region constructores

		public Diccionarios ()
		{
			this.diccionarios = new List<Diccionario> ();
		}

		public Diccionarios (Diccionario diccionario)
		{
			this.diccionarios = new List<Diccionario> ();
			this.diccionarios.Add (diccionario);
		}



		#endregion


	}
}