using Multa.Core.Models;
using Multa.Core.Handlers;
using Multa.Core.Responses;
using System.Net.Http.Json;
using Multa.Core.Requests.Cliente;

namespace Multa.Web.Handlers
{
    public class ClienteHandler(IHttpClientFactory httpClientFactory) : IClienteHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

        public async Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/clientes", request);
            return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
                    ?? new Response<Cliente?>(null, 400, "Falha ao criar a categoria");
        }

        public Task<PagedResponse<List<Cliente>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
                    ?? new Response<Cliente?>(null, 400, "Falha ao atualizar a categoria");
        }

        //public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        //{
        //    var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
        //    return await result.Content.ReadFromJsonAsync<Response<Category?>>()
        //            ?? new Response<Category?>(null, 400, "Falha ao excluir a categoria");
        //}

        //public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        //    => await _client.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
        //        ?? new Response<Category?>(null, 400, "Não foi possível obter a categoria");

        //public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
        //    => await _client.GetFromJsonAsync<PagedResponse<List<Category>>>("v1/categories")
        //        ?? new PagedResponse<List<Category>>(null, 400, "Não foi possível obter as categorias");
    }
}
