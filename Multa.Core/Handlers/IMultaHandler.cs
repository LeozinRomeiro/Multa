using Multa.Core.Models;
using Multa.Core.Requests.Multa;
using Multa.Core.Responses;

namespace Multa.Core.Handlers
{
    public interface IMultaHandler
    {
        Task<Response<Core.Models.Multa?>> CreateAsync(CreateMultaRequest request);
        Task<Response<Core.Models.Multa?>> UpdateAsync(UpdateMultaRequest request);
        //Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
        //Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<PagedResponse<List<Core.Models.Multa>>> GetAllAsync();
    }
}
