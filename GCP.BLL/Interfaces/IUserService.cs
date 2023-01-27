using GCP.Common.UIModels.RequestModels;
using GCP.Common.UIModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCP.BLL.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateAsync(SignUpRequestModel request);
        Task<TokenResult> LoginAsync(LoginRequestModel request);
    }
}
