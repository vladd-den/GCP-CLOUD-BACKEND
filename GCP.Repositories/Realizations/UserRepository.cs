using Dapper;
using GCP.Common.DALModels;
using GCP.Common.UIModels.RequestModels;
using GCP.DAL.Interfaces;
using GCP.DAL.Queries;
using System.Data;

namespace GCP.DAL.Realizations
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public UserRepository(
            IDbTransaction transaction
        )
        {
            _transaction = transaction;
            _connection = _transaction.Connection;
        }


        public async Task<Guid> CreateAsync(SignUpRequestModel request, Guid passwordSalt, string passwordHash)
        {
            var parameters = new
            {
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                passwordSalt,
                passwordHash
            };

            Guid id = await _connection.QueryFirstAsync<Guid>(UserQueries.INSERT, parameters);

            return id;
        }

        public async Task<UserEntity> GetByEmailAsync(string email)
        {
            var parameters = new
            {
                email
            };

            return await _connection.QueryFirstOrDefaultAsync<UserEntity>(UserQueries.GET_BY_EMAIL, parameters);
        }
    }
}
