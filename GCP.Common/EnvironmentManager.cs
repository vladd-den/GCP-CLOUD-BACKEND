using GCP.Common.Constants;

namespace GCP.Common
{
    public static class EnvironmentManager
    {
        static EnvironmentManager()
        {
            DBHost = Environment.GetEnvironmentVariable(OptionsKey.DBHost);
            DBPort = Environment.GetEnvironmentVariable(OptionsKey.DBPort);
            DBUser = Environment.GetEnvironmentVariable(OptionsKey.DBUser);
            DBPassword = Environment.GetEnvironmentVariable(OptionsKey.DBPassword);
            DBName = Environment.GetEnvironmentVariable(OptionsKey.DBDatabase);
        }

        public static string DBHost { get; }
        public static string DBPort { get; }
        public static string DBUser { get; }
        public static string DBPassword { get; }
        public static string DBName { get; }
    }
}
