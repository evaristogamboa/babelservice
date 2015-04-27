using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPEtiqueta.Models
{
	public class ObtenerTodosLosIdiomasResponse
	{

		public List<Etiqueta> Etiquetaes { get; set; }
		public ObtenerTodosLosIdiomasResponse(List<Etiqueta> Etiquetaes){
		this.Etiquetaes= Etiquetaes;
		}
		public List<Etiqueta> AgregarEtiqueta(Etiqueta Etiqueta) {
			this.Etiquetaes.Add(Etiqueta);
			return this.Etiquetaes;
		}

		public List<Etiqueta> DevolverEtiquetaes() {
			return this.Etiquetaes;
		}
	}
}