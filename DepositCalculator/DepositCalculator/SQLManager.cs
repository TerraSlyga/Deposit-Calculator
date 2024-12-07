﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositCalculator
{
	internal class SQLManager
	{
		NpgsqlConnection connection;

		public SQLManager()
		{
			var connectionString = "Server=localhost;User Id=postgres;Password=friger0999;Database=DepositCalculator;";
			connection = new NpgsqlConnection(connectionString);
			connection.Open();
		}

		public InterestRates ReadInterestRates()
		{
			var sql = "SELECT * FROM depositinterestrates";
			var cmd = new NpgsqlCommand(sql, connection);
			var reader = cmd.ExecuteReader();
			InterestRates interestRates = new();
			while (reader.Read())
			{
				interestRates.AddInterestRates(reader.GetString(0), reader.GetInt32(1), reader.GetDouble(2));
			}
			return interestRates;
		}

		public void CloseConnection()
		{
			connection.Close();
		}
	}
}
