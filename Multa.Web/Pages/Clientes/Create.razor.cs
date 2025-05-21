using Microsoft.AspNetCore.Components;
using MudBlazor;
using Multa.Core.Handlers;
using Multa.Core.Models;
using Multa.Core.Requests.Cliente;
using Multa.Core.Responses;

namespace Multa.Web.Pages.Clientes
{
    public partial class CreateClientePage : ComponentBase
    {
        #region Propriedades

        public bool IsBusy { get; set; } = false;
        public CreateClienteRequest InputModel { get; set; } = new();

        #endregion

        #region Serviços

        [Inject]
        public IClienteHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Métodos

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                //var result = await Handler.CreateAsync(InputModel);

                var result = new Response<Cliente>();

                if (result.IsSuccess)
                {
                    //Snackbar.Add(result.Message, Severity.Success);
                    Snackbar.Add($"O cliente {InputModel.Nome} cadastrado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo(NavigationManager.BaseUri + "clientes");
                }
                else
                {
                    Snackbar.Add(result.Message, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Erro ao salvar cliente: {ex.Message}", Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }

}
