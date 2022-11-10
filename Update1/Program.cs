using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"UPDATE Users 
						   SET    Name = @Name, 
							      Account = @Account, 
							      Password = @Password, 
							      DateOfBirth = @DateOfBirth,
							      Height = @Height
						   WHERE  Id = @Id";
											

			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddNVarchar("Name", 50, "Beta")
					.AddNVarchar("Account", 50, "Beta")
					.AddNVarchar("Password", 50, "b002")
					.AddDateTime("DateOfBirth", new DateTime(2001, 1, 1))
					.AddInt("Height", 158)
					.AddInt("Id", 1)
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);

				Console.WriteLine("紀錄已更新");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"錯誤 原因為{ex.Message}");
			}
		}
	}
}
