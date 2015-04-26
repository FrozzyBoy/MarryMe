namespace MarryMe.Model.Factory
{
	#region Using

	using System;
	using System.Configuration;
	using System.Data;
	using System.Data.Common;

	#endregion

	public class DBFactory
	{
		public const string StatisticOutData = "statistic";
		private const string DefaultConnectionStringName = "DefaultConnection";

		#region Singleton factory

		private static object _lockFactory = new object();
		private static DbProviderFactory _connectionFactory = null;
		private static DbProviderFactory ConnectionFactory
		{
			get
			{
				if (_connectionFactory == null)
				{
					lock (_lockFactory)
					{
						if (_connectionFactory == null)
						{
							ConnectionStringSettings connectionString = GetConnectionString(DefaultConnectionStringName);

							if (connectionString != null)
							{
								_connectionFactory = DbProviderFactories.GetFactory(connectionString.ProviderName);
							}

						}
					}
				}
				return _connectionFactory;
			}
		}

		#endregion

		public static void AddParameter(DbCommand cmd, string paramName, object value)
		{
			var dbParam = cmd.CreateParameter();
			dbParam.Value = value;
			dbParam.ParameterName = paramName;
			cmd.Parameters.Add(dbParam);
		}

		public static DbConnection GetConnection()
		{
			DbConnection connection = null;
			if (ConnectionFactory != null)
			{
				connection = ConnectionFactory.CreateConnection();
			}
			return connection;
		}

		private static ConnectionStringSettings GetConnectionString(string connectionName)
		{
			ConnectionStringSettings connectionString = null;

			ConnectionStringSettingsCollection settings =
		ConfigurationManager.ConnectionStrings;

			foreach (ConnectionStringSettings cs in settings)
			{
				if (cs.Name == connectionName)
				{
					connectionString = cs;
					break;
				}
			}

			return connectionString;
		}
	}
}
