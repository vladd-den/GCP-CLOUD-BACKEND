using GCP.DAL.Interfaces;

namespace GCP.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        Task CommitAsync();
    }
}
