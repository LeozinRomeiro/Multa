using Multa.Core.Handlers;
using Multa.Core.Models;
using Multa.Core.Requests.Multa;
using Multa.Core.Responses;

namespace Multa.Web.Handlers
{
    public class MultaHandler : IMultaHandler
    {
        public Task<Response<Core.Models.Multa?>> CreateAsync(CreateMultaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Core.Models.Multa>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Core.Models.Multa?>> UpdateAsync(UpdateMultaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
