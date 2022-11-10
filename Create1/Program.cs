using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Create1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"INSERT INTO Users(Name, Account, Password, DateOfBirth, Height)
						   VALUES(@Name, @Account, @Password, @DateOfBirth, @Height)";

			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddNVarchar("Name", 50, "alpha")
					.AddNVarchar("Account", 50, "alpha")
					.AddNVarchar("Password", 50, "a001")
					.AddDateTime("DateOfBirth", new DateTime(2000, 1, 1))
					.AddInt("Height", 162)
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);

				Console.WriteLine("紀錄已新增");
			}
			catch(Exception ex)
			{
				Console.WriteLine($"錯誤 原因為{ex.Message}");
			}
		}
	}
}
