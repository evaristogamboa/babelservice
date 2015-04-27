using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Negocio.Entidades;
using Negocio.Repositorios;

namespace AccesoDatos
{
	public class EtiquetaesRepositorioSql : IDiccionarioRepositorio
	{
		private Conexion basedatos;
		private DataTable dtEtiquetaes;
		private Hashtable parametros;
		private Etiqueta Etiqueta;
		private List<Etiqueta> listaEtiquetaes;

		private EtiquetaesRepositorioSql(Conexion basedatos, DataTable dtEtiquetaes, Hashtable parametros, Etiqueta Etiqueta, List<Etiqueta> listaEtiquetaes)
		{
			this.basedatos = basedatos;
			this.dtEtiquetaes = dtEtiquetaes;
			this.parametros = parametros;
			this.Etiqueta = Etiqueta;
			this.listaEtiquetaes = listaEtiquetaes;
		}

		public static EtiquetaesRepositorioSql CrearNuevoRepositorioEtiquetaeSql(Conexion basedatos, DataTable dtEtiquetaes, Hashtable parametros, Etiqueta Etiqueta, List<Etiqueta> listaEtiquetaes)
		{
			return new EtiquetaesRepositorioSql(basedatos, dtEtiquetaes, parametros, Etiqueta, listaEtiquetaes);
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


