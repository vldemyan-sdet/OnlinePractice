using Evershop.Tests.API.Settings;
using Npgsql;

namespace Evershop.Tests.API.Utilities
{
    internal class DbUtil
    {
        public void Connect()
        {
            string connString = "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=postgres";

            // Create a connection
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    // Open the connection
                    conn.Open();
                    Console.WriteLine("Connection to PostgreSQL database successful!");

                    // Example query execution (optional)
                    using (var cmd = new NpgsqlCommand("SELECT version()", conn))
                    {
                        string version = cmd.ExecuteScalar()?.ToString();
                        Console.WriteLine($"PostgreSQL version: {version}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void DeleteProduct(string uuid)
        {

            //string connString = "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=postgres";

            // Create a connection
            using (var conn = new NpgsqlConnection(ApiSettings.PostreeSqlConnectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();
                    Console.WriteLine("Connection to PostgreSQL database successful!");

                    // Example query execution (optional)
                    using (var cmd = new NpgsqlCommand(@"DELETE FROM product WHERE uuid = @uuid", conn))
                    {
                        cmd.Parameters.AddWithValue("@uuid", Guid.Parse(uuid));
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"PostgreSQL: {result}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        public void LogTestExecutionTime(string testName, DateTime startTime, DateTime stopTime)
        {

            // Create a connection
            using (var conn = new NpgsqlConnection(ApiSettings.PostreeSqlConnectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();
                    Console.WriteLine("Connection to PostgreSQL database successful!");

                    // Example query execution (optional)
                    using (var cmd = new NpgsqlCommand(@"INSERT INTO public.testruns(test_name, start_time, stop_time)	VALUES (@test_name, @start_time, @stop_time);", conn))
                    {
                        cmd.Parameters.AddWithValue("@test_name", testName);
                        cmd.Parameters.AddWithValue("@start_time", startTime);
                        cmd.Parameters.AddWithValue("@stop_time", stopTime);
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"PostgreSQL: {result}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
