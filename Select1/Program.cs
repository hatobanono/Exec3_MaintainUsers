using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "SELECT Id, Name, Account, Password, DateOfBirth, Height FROM Users WHERE Id > @Id ORDER BY Id DESC";
			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddInt("Id", 0)
					.Build();
				DataTable users = dbHelper.Select(sql, parameters);

				foreach(DataRow row in users.Rows)
				{
					int id = row.Field<int>("id");
					string name = row.Field<string>("Name");
					string account = row.Field<string>("Account");
					string password = row.Field<string>("Password");
					DateTime date = row.Field<DateTime>("DateOfBirth");
					int height = row.Field<int>("Height");

					Console.WriteLine($"Id = {id}, Name = {name}, Account = {account}, Password = {password}, DateOfBirth = {date}, Height = {height}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"錯誤 原因為{ex.Message}");
			}
		}
	}
}
