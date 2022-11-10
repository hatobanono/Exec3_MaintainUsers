using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	public class SqlDbHelper
	{
		private string connString;
		public SqlDbHelper(string keyOfConnString) {
			connString = System.Configuration.ConfigurationManager.ConnectionStrings[keyOfConnString].ConnectionString;
		}

		public void ExecuteNonQuery(string sql, SqlParameter[] parameters)
		{
			using(var conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open();

				cmd.Parameters.AddRange(parameters);
				cmd.ExecuteNonQuery();
			}
			
		}
		public DataTable Select(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connString))
			{
				var cmd = new SqlCommand(sql, conn);
				if (parameters != null)
				{
					cmd.Parameters.AddRange(parameters);
				}
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);

				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet, "Users");

				return dataSet.Tables["Users"];
			}
		}
	}
}
