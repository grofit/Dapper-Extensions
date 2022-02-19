﻿using DapperExtensions.Sql;
using NUnit.Framework;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DapperExtensions.Test.IntegrationTests.Async.Oracle
{
    [NonParallelizable]
    public class OracleBaseAsyncFixture : DatabaseAsyncTestsFixture
    {
        [ExcludeFromCodeCoverage]
        private OracleConnection SetupDatabase()
        {
            var connection = new OracleConnection(GetConnectionString("OracleDBA"));

            ExecuteScripts(connection, true, "Setup");

            connection.Close();

            return new OracleConnection(GetConnectionString("Oracle"));
        }

        [SetUp]
        public virtual void Setup()
        {
            ConnectionString = GetConnectionString("Oracle");
            var connection = new OracleConnection(ConnectionString);

            try
            {
                CommonSetup(connection, new OracleDialect());
            }
            catch (OracleException oex)
            {
                if (oex.Number == 01017)
                {
                    connection = SetupDatabase();
                    CommonSetup(connection, new OracleDialect());
                }
                else
                    throw;
            }

            ExecuteScripts(connection, true, CreateTableScripts);
        }
    }
}