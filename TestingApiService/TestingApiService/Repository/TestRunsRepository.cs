using Npgsql;
using TestingApiService.Models;
using TestingApiService.Settings;

namespace TestingApiService.Repository
{
    public class TestRunsRepository
    {
        public void DeleteProduct(string uuid)
        {
            using (var conn = new NpgsqlConnection(ApiSettings.PostreeSqlConnectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection to PostgreSQL database successful!");

                    using (var cmd = new NpgsqlCommand(@"DELETE FROM product WHERE uuid = @uuid", conn))
                    {
                        cmd.Parameters.AddWithValue("@uuid", Guid.Parse(uuid));
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"DELETE FROM product result, rows affected: {result}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DeleteProduct Error: {ex.Message}");
                }
            }
        }


        public void LogTestExecutionTime(TestRunModel testRunModel)
        {
            using (var conn = new NpgsqlConnection(ApiSettings.PostreeSqlConnectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection to PostgreSQL database successful!");

                    using (var cmd = new NpgsqlCommand(
                        @"CREATE TABLE IF NOT EXISTS public.testruns(
                            test_name varchar(200) NOT NULL,
                            start_time timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
                            end_time timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
                            test_result varchar(30)
                        );", conn))
                    {
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"CREATE TABLE public.testruns result, rows affected: {result}");
                    }

                    using (var cmd = new NpgsqlCommand(@"INSERT INTO public.testruns(test_name, start_time, end_time, test_result)	VALUES (@test_name, @start_time, @end_time, @test_result);", conn))
                    {
                        cmd.Parameters.AddWithValue("@test_name", testRunModel.TestName);
                        cmd.Parameters.AddWithValue("@start_time", testRunModel.StartTime);
                        cmd.Parameters.AddWithValue("@end_time", testRunModel.EndTime);
                        cmd.Parameters.AddWithValue("@test_result", testRunModel.Result);
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"INSERT INTO public.testruns, rows affected: {result}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"LogTestExecutionTime Error: {ex.Message}");
                }
            }
        }
    }
}
