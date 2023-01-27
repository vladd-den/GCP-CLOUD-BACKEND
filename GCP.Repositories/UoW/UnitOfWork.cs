using GCP.DAL.Interfaces;
using GCP.DAL.Realizations;
using Npgsql;
using System.Data;

namespace GCP.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private NpgsqlTransaction _transaction;
        private IUserRepository _userRepository;

        public UnitOfWork(
            IConnectionStringResolver connectionStringResolver
        )
        {
            NpgsqlConnection connection = new(connectionStringResolver.Resolve);
            connection.Open();
            _transaction = connection.BeginTransaction();
        }

        public Task CommitAsync()
        {
            return _transaction.CommitAsync();
        }

        public void Dispose()
        {
            if (_transaction is null) return;

            if (_transaction.Connection is not null
                && _transaction.Connection.State != ConnectionState.Closed) _transaction.Connection.Close();

            _transaction.Dispose();
            _transaction = null;
        }


        public IUserRepository UserRepository
            => _userRepository ??= new UserRepository(_transaction);
    }
}
