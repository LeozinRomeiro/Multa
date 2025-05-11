using Multa.Core.Requests.Account;
using Multa.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multa.Core.Handlers
{
    public interface IAccountHandler
    {
        Task<Response<string>> LoginAsync(LoginRequest request);
        //Task<Response<string>> RegisterAsync(RegisterRequest request);
        Task LogoutAsync();
    }
}
