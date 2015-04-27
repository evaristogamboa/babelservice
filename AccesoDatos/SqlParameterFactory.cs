using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
	public class SqlParameterFactory
	{
		public SqlParameter GetNewSqlParameter(String key,object value) { 
			return new SqlParameter(key,value);
		}
	}
}
