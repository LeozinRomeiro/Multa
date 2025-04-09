using Microsoft.AspNetCore.Components;
using MudBlazor;
using Multa.Core.Handlers;
using Multa.Core.Models;
using Multa.Core.Requests.Multa;

namespace Multa.Web.Pages.Multas;

public partial class CreateMultaPage : ComponentBase
{
    public bool IsBusy { get; set; } = false;
    public CreateMultaRequest InputModel { get; set; } = new();
    public List<Cliente> Clientes { get; set; }

    #region Serviços

    [Inject] public IMultaHandler MultaHandler { get; set; } = null!;
    [Inject] public IClienteHandler ClienteHandler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Override

    protected override async Task OnInitializedAsync()
    {

        IsBusy = true;

        try
        {
            //var result = await ClienteHandler.GetAllAsync();

            var result = new List<Cliente>()
                {
                    new Cliente
                        {
                            Id = 1,
                            Nome = "João da Silva",
                            CPF = "12345678901",
                            CNH = "98765432100",
                            DataNascimento = new DateTime(1985, 5, 12),
                            Endereco = "Rua das Laranjeiras, 123 - Curitiba/PR",
                            Telefone = "(41) 99999-1234",
                            Email = "joao.silva@email.com"
                        },
                    new Cliente
                    {
                        Id = 2,
                        Nome = "Maria Oliveira",
                        CPF = "23456789012",
                        CNH = "87654321099",
                        DataNascimento = new DateTime(1990, 7, 8),
                        Endereco = "Av. Brasil, 456 - Londrina/PR",
                        Telefone = "(43) 98888-4567",
                        Email = "maria.oliveira@email.com"
                    }
            };

            //if (result.IsSuccess)
            //{
                //Clientes = result.Data ?? [];
                Clientes = result ?? [];
                InputModel.ClienteId = Clientes.FirstOrDefault()?.Id ?? 0;
            //}
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            //var result = await MultaHandler.CreateAsync(InputModel);

            //if (result.IsSuccess)
            //{
                Snackbar.Add("Multa cadastrada com sucesso", Severity.Success);
                NavigationManager.NavigateTo("/multas");
            //}
            //else
            //{
            //    Snackbar.Add(result.Message, Severity.Error);
            //}
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao salvar multa: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
