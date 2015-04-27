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
	public class TraduccionesRepositorioSql : IDiccionarioRepositorio
	{
		private Conexion basedatos;
		private DataTable dtTraducciones;
		private Hashtable parametros;
		private Traduccion traduccion;
		private List<Traduccion> listaTraducciones;

		private TraduccionesRepositorioSql(Conexion basedatos, DataTable dtTraducciones, Hashtable parametros, Traduccion traduccion, List<Traduccion> listaTraducciones)
		{
			this.basedatos = basedatos;
			this.dtTraducciones = dtTraducciones;
			this.parametros = parametros;
			this.traduccion = traduccion;
			this.listaTraducciones = listaTraducciones;
		}

		public static TraduccionesRepositorioSql CrearNuevoRepositorioTraduccioneSql(Conexion basedatos, DataTable dtTraducciones, Hashtable parametros, Traduccion traduccion, List<Traduccion> listaTraducciones)
		{
			return new TraduccionesRepositorioSql(basedatos, dtTraducciones, parametros, traduccion, listaTraducciones);
		}

		public List<Traduccion> GetAll()
		{
			this.dtTraducciones = this.basedatos.ExecuteSelect(ref this.parametros);
			if (dtTraducciones.Rows.Count > 0)
			{
				for (int i = 0; i <= dtTraducciones.Rows.Count - 1; i++)
				{
					Traduccion datosTraduccion = Traduccion.CrearNuevaTraduccion(this.dtTraducciones.Rows[i].ItemArray[0].ToString(),
						this.dtTraducciones.Rows[i].ItemArray[1].ToString(),
						this.dtTraducciones.Rows[i].ItemArray[2].ToString(),
						 this.dtTraducciones.Rows[i].ItemArray[3].ToString()
						);

					listaTraducciones.Add(datosTraduccion);
				}
			}
			return listaTraducciones;
		}
	}
}


