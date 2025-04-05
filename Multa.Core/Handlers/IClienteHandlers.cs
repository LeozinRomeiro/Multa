using Multa.Core.Models;
using Multa.Core.Requests.Cliente;
using Multa.Core.Responses;

namespace Multa.Core.Handlers
{
    public interface IClienteHandler
    {
        Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request);
        Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request);
        //Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
        //Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<PagedResponse<List<Cliente>>> GetAllAsync();
    }
}
