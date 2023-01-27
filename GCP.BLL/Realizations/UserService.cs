using GCP.BLL.Interfaces;
using GCP.Common.Constants;
using GCP.Common.DALModels;
using GCP.Common.Helpers;
using GCP.Common.UIModels.RequestModels;
using GCP.Common.UIModels.ResponseModels;
using GCP.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCP.BLL.Realizations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateAsync(SignUpRequestModel request)
        {
            Guid passwordSalt = Guid.NewGuid();

            string passwordHash = HashPasswordHelper.CalculatePasswordHash(request.Password, passwordSalt);
            
            Guid id = await _unitOfWork.UserRepository.CreateAsync(request, passwordSalt, passwordHash);
            
            if (id == Guid.Empty) return Guid.Empty; 
            
            await _unitOfWork.CommitAsync();

            return id;
        }

        public async Task<TokenResult> LoginAsync(LoginRequestModel request)
        {
            UserEntity user = await GetUserByLoginAndPasswordAsync(request.Email, request.Password);

            if (user == null) return TokenResultHelper.InvalidEmailOrPassword;

            return GetTokenAsync(user);
        }

        private TokenResult GetTokenAsync(
            UserEntity accountEntity
        )
        {
            if (accountEntity == null) return TokenResultHelper.ExpiredAccessToken;

            Guid refreshToken = Guid.NewGuid();
            DateTime currentTime = DateTime.UtcNow;

            TokenResult tokenResult = TokenResultHelper.InternalGenerateToken(
                accountEntity.Id,
                refreshToken,
                currentTime.AddDays(AuthOptions.SESSION_LIFE_TIME_DAYS),
                accountEntity.Email,
                null);

            return tokenResult;
        }

        private async Task<UserEntity> GetUserByLoginAndPasswordAsync(string email, string password)
        {
            UserEntity user = await _unitOfWork.UserRepository.GetByEmailAsync(email.ToLowerInvariant());

            if (user == null) return null;

            string passwordHash = HashPasswordHelper.CalculatePasswordHash(password, user.PasswordSalt);

            return string.Equals(passwordHash, user.PasswordHash, StringComparison.Ordinal) ? user : null;
        }
    }
}
