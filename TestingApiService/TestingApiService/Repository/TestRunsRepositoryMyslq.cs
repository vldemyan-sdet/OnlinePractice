using MySql.Data.MySqlClient;
using Npgsql;
using TestingApiService.Models;
using TestingApiService.Settings;

namespace TestingApiService.Repository
{
    public class TestRunsRepositoryMyslq
    {
        public void LogTestExecutionTime(TestRunModel testRunModel)
        {
            using (var conn = new MySqlConnection(ApiSettings.MysqlConnectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection to PostgreSQL database successful!");

                    using (var cmd = new MySqlCommand(
                        @"CREATE TABLE IF NOT EXISTS testruns(
                            test_name varchar(200) NOT NULL,
                            start_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            end_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            test_result varchar(30)
                        );", conn))
                    {
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"CREATE TABLE testruns result, rows affected: {result}");
                    }

                    using (var cmd = new MySqlCommand(@"INSERT INTO testruns(test_name, start_time, end_time, test_result)	VALUES (@test_name, @start_time, @end_time, @test_result);", conn))
                    {
                        cmd.Parameters.AddWithValue("@test_name", testRunModel.TestName);
                        cmd.Parameters.AddWithValue("@start_time", testRunModel.StartTime);
                        cmd.Parameters.AddWithValue("@end_time", testRunModel.EndTime);
                        cmd.Parameters.AddWithValue("@test_result", testRunModel.Result);
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"INSERT INTO testruns, rows affected: {result}");
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
