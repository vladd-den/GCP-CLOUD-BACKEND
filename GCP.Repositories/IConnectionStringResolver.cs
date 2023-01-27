namespace GCP.DAL
{
    public interface IConnectionStringResolver
    {
        string Resolve { get; }
    }
}
