using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SqlExtensions.Create("nono", "nono123", "uouo321", new DateTime(2000, 1, 1), 160);
			SqlExtensions.Update(4, "tsugu", "tsugu00", "9876", new DateTime(2010, 1, 1), 150);
			SqlExtensions.Delete(0);
			SqlExtensions.Select(0);
		}
	}
	public static class SqlExtensions
	{
		public static void Select(this int idk)
		{
			string sql = "SELECT Id, Name, Account, Password, DateOfBirth, Height FROM Users WHERE Id > @Id ORDER BY Id DESC";
			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddInt("Id", idk)
					.Build();
				DataTable users = dbHelper.Select(sql, parameters);

				foreach (DataRow row in users.Rows)
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
		public static void Create(this string name, string account, string password, DateTime dateOfBirth, int height)
		{
			string sql = @"INSERT INTO Users(Name, Account, Password, DateOfBirth, Height)
						   VALUES(@Name, @Account, @Password, @DateOfBirth, @Height)";

			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddNVarchar("Name", 50, name)
					.AddNVarchar("Account", 50, account)
					.AddNVarchar("Password", 50, password)
					.AddDateTime("DateOfBirth", dateOfBirth)
					.AddInt("Height", height)
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);

				Console.WriteLine("紀錄已新增");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"錯誤 原因為{ex.Message}");
			}
		}
		public static void Update(this int id, string name, string account, string password, DateTime dateOfBirth, int height)
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
					.AddNVarchar("Name", 50, name)
					.AddNVarchar("Account", 50, account)
					.AddNVarchar("Password", 50, password)
					.AddDateTime("DateOfBirth", dateOfBirth)
					.AddInt("Height", height)
					.AddInt("Id", id)
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);

				Console.WriteLine("紀錄已更新");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"錯誤 原因為{ex.Message}");
			}
		}
		public static void Delete(this int id)
		{
			string sql = "DELETE FROM Users WHERE Id = @Id";


			var dbHelper = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder()
					.AddInt("Id", id)
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
