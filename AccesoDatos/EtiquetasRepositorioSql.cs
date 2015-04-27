using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Negocio.Entidades;
using Negocio.Repositorios;

namespace AccesoDatos
{
	public class EtiquetasRepositorioSql : IDiccionarioRepositorio
	{
		private Conexion basedatos;
		private DataTable dtEtiquetaes;
		private Hashtable parametros;
		private Etiqueta Etiqueta;
		private List<Etiqueta> listaEtiquetaes;

		private EtiquetasRepositorioSql(Conexion basedatos, DataTable dtEtiquetaes, Hashtable parametros, Etiqueta Etiqueta, List<Etiqueta> listaEtiquetaes)
		{
			this.basedatos = basedatos;
			this.dtEtiquetaes = dtEtiquetaes;
			this.parametros = parametros;
			this.Etiqueta = Etiqueta;
			this.listaEtiquetaes = listaEtiquetaes;
		}

		public List<T> ObtenerTodosLosElementos<T>()
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public T ObtenerUnElemento<T>()
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public bool EliminarUnElemento(Guid id)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public T ModificarUnElemento<T>(T elementoAModificar)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public T CrearUnElemento<T>(T elementoACrear)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public static EtiquetasRepositorioSql CrearNuevoRepositorioEtiquetaeSql(Conexion basedatos, DataTable dtEtiquetaes, Hashtable parametros, Etiqueta Etiqueta, List<Etiqueta> listaEtiquetaes)
		{
			return new EtiquetasRepositorioSql(basedatos, dtEtiquetaes, parametros, Etiqueta, listaEtiquetaes);
		}

		public List<Etiqueta> GetAll()
		{
			this.dtEtiquetaes = this.basedatos.ExecuteSelect(ref this.parametros);
			if (dtEtiquetaes.Rows.Count > 0)
			{
				for (int i = 0; i <= dtEtiquetaes.Rows.Count - 1; i++)
				{
					Etiqueta datosEtiqueta = Etiqueta.CrearNuevaEtiqueta(this.dtEtiquetaes.Rows[i].ItemArray[0].ToString(),
						this.dtEtiquetaes.Rows[i].ItemArray[1].ToString(),
						this.dtEtiquetaes.Rows[i].ItemArray[2].ToString(),
						 this.dtEtiquetaes.Rows[i].ItemArray[3].ToString()
						);

					listaEtiquetaes.Add(datosEtiqueta);
				}
			}
			return listaEtiquetaes;
		}
	}
}


