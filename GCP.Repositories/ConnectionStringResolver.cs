using GCP.Common.Helpers;

namespace GCP.DAL
{
    public class ConnectionStringResolver : IConnectionStringResolver
    {
        public string Resolve => OptionsHelper.GenerateConnectionString();
    }
}
