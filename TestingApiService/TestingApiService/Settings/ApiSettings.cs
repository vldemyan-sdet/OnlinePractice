namespace TestingApiService.Settings
{
    public static class ApiSettings
    {
        public static string BaseUrl { get; set; }
        public static int ClientTimeoutSeconds { get; set; }
        public static int MaxRetryAttempts { get; set; }
        public static int PauseBetweenFailures { get; set; }
        public static bool EnableBDDLogging { get; set; }
        public static bool EnableToastMessages { get; set; }
        public static string PostreeSqlConnectionString { get; set; }
    }
}
