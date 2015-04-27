using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace AccesoDatos
{
    public class Conexion
    {

		private SqlConnection cnn;
		private SqlCommand cmd;
		private SqlDataAdapter adapter;
		private DataTable dataObject;
		private SqlParameterFactory sqlparameterFactory;

		public Conexion(SqlConnection cnn, SqlCommand cmd, SqlDataAdapter adapter, DataTable dataObject,SqlParameterFactory sqlparameterFactory)
		{
			this.cnn = cnn;
			this.cmd = cmd;
			this.adapter = adapter;
			this.dataObject = dataObject;
			this.sqlparameterFactory = sqlparameterFactory;
		}

		public DataTable ExecuteSelect(ref Hashtable parameters)
		{

			try
			{
				this.cmd.CommandType = CommandType.StoredProcedure;
				this.cmd.CommandTimeout = 0;


				if ((parameters != null))
				{
					IDictionaryEnumerator item = parameters.GetEnumerator();
					object valor = null;

					while (item.MoveNext())
					{
						valor = item.Value;
						if (object.ReferenceEquals(valor, System.DBNull.Value) | valor == null)
						{
							valor = System.DBNull.Value;
						}

						cmd.Parameters.Add(this.sqlparameterFactory.GetNewSqlParameter(Convert.ToString(item.Key), (object)valor));
					}
				}

				this.adapter.Fill(this.dataObject);

				return this.dataObject;

			}
			catch (Exception ex)
			{
				if (this.cnn.State == ConnectionState.Open)
				{
					this.cnn.Close();
				}
				throw ex;
				// sube el error a la capa de DAL
			}

		}
		
    }
}
