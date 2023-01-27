using GCP.Common.DALModels;
using GCP.Common.UIModels.RequestModels;

namespace GCP.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> CreateAsync(SignUpRequestModel request, Guid passwordSalt, string passwordHash);
        Task<UserEntity> GetByEmailAsync(string email);
    }
}
