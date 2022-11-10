using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "DELETE FROM Users WHERE Id = @Id";


			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddInt("Id", 2)
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);

				Console.WriteLine("紀錄已刪除");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"錯誤 原因為{ex.Message}");
			}
		}
	}
}
