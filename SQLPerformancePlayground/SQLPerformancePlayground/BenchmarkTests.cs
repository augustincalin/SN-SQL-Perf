using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace SQLPerformancePlayground
{
    public class BenchmarkTests
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=PERFDB;Integrated Security=False;User ID=sa;Password=safz_edekk1;Enlist=True;Pooling=True;Connect Timeout=60;";
        private readonly string insertCommand = @"
                    INSERT INTO [dbo].[TableOne]
                        ([column_1]
                        , [column_2])
                    VALUES
                        ('value_col_1'
                        ,'value_col_2')";

        [Benchmark]
        public async Task ExecuteScalarAsyncTest()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(insertCommand, connection))
                {
                    await command.ExecuteScalarAsync();
                }
            }
        }

        [Benchmark]
        public async Task ExecuteNonQueryAsyncTest()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(insertCommand, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
