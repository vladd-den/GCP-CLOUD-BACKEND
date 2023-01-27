using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCP.Common.UIModels.ResponseModels
{
    public class TokenResult
    {
        public TokenResponseModel TokenModel { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public bool Success => string.IsNullOrEmpty(Error);
    }
}
