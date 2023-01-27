namespace GCP.Common.Helpers
{
    public static class OptionsHelper
    {
        public static string GenerateConnectionString()
        {
            string host = EnvironmentManager.DBHost;
            string port = EnvironmentManager.DBPort;
            string user = EnvironmentManager.DBUser;
            string password = EnvironmentManager.DBPassword;
            string database = EnvironmentManager.DBName;

            string result =
                $"Host={host};port={port};User ID={user};Password={password};Database={database};";

            return result;
        }
    }
}
