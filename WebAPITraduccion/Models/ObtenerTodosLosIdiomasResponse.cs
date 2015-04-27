using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPITraduccion.Models
{
	public class ObtenerTodosLosIdiomasResponse
	{

		public List<Traduccion> traducciones { get; set; }
		public ObtenerTodosLosIdiomasResponse(List<Traduccion> traducciones){
		this.traducciones= traducciones;
		}
		public List<Traduccion> AgregarTraduccion(Traduccion traduccion) {
			this.traducciones.Add(traduccion);
			return this.traducciones;
		}

		public List<Traduccion> DevolverTraducciones() {
			return this.traducciones;
		}
	}
}