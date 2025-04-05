using Microsoft.AspNetCore.Components;
using MudBlazor;
using Multa.Core.Handlers;
using Multa.Core.Models;
using Multa.Core.Requests.Cliente;
using Multa.Core.Responses;

namespace Multa.Web.Pages.Clientes;

public partial class EditClientePage : ComponentBase
{
    #region Propriedades

    public bool IsBusy { get; set; } = false;
    public UpdateClienteRequest InputModel { get; set; } = new();

    #endregion

    #region Parâmetros

    [Parameter]
    public string Id { get; set; } = string.Empty;

    #endregion

    #region Serviços

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public IClienteHandler Handler { get; set; } = null!;

    #endregion

    #region Métodos do Ciclo de Vida

    protected override async Task OnInitializedAsync()
    {
        if (!long.TryParse(Id, out var clienteId))
        {
            Snackbar.Add("Parâmetro inválido", Severity.Error);
            return;
        }

        IsBusy = true;

        try
        {
            //var request = new GetClienteByIdRequest { Id = clienteId };
            //var response = await Handler.GetByIdAsync(request);

            Cliente clienteFake = new Cliente
            {
                Id = 4,
                Nome = "Ana Souza",
                CPF = "45678901234",
                CNH = "65432109877",
                DataNascimento = new DateTime(1995, 9, 30),
                Endereco = "Rua dos Pioneiros, 101 - Cascavel/PR",
                Telefone = "(45) 96666-1122",
                Email = "ana.souza@email.com"
            };

            var response = new Response<Cliente>(clienteFake); 

            if (response is { IsSuccess: true, Data: not null })
            {
                var cliente = response.Data;

                InputModel = new UpdateClienteRequest
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    CPF = cliente.CPF,
                    CNH = cliente.CNH,
                    DataNascimento = cliente.DataNascimento,
                    Endereco = cliente.Endereco,
                    Telefone = cliente.Telefone,
                    Email = cliente.Email
                };
            }
            else
            {
                Snackbar.Add(response?.Message ?? "Erro ao buscar cliente", Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    #region Métodos

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            //var result = await Handler.UpdateAsync(InputModel);
            var result = new Response<Cliente>();
            if (result.IsSuccess)
            {
                Snackbar.Add("Cliente atualizado com sucesso", Severity.Success);
                NavigationManager.NavigateTo("/clientes");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao atualizar cliente: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}
