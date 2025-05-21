using Microsoft.AspNetCore.Components;
using MudBlazor;
using Multa.Core.Handlers;
using Multa.Core.Models;
using Multa.Core.Requests.Multa;
using Multa.Core.Responses;

namespace Multa.Web.Pages.Multas;

public partial class EditMultaPage : ComponentBase
{
    public bool IsBusy { get; set; } = false;
    public UpdateMultaRequest InputModel { get; set; } = new();

    [Parameter] public string Id { get; set; } = string.Empty;

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public IMultaHandler Handler { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        if (!long.TryParse(Id, out var multaId))
        {
            Snackbar.Add("Parâmetro inválido", Severity.Error);
            return;
        }

        IsBusy = true;

        try
        {
            //var request = new GetMultaByIdRequest { Id = multaId };
            //var response = await Handler.GetByIdAsync(request);

            Core.Models.Multa clienteFake = new()
            {
                Id = 1,
                AutoInfracao = "A123456",
                PlacaVeiculo = "ABC1D23",
                Renavam = "12345678901",
                CodigoInfracao = "60123",
                DescricaoInfracao = "Avanço de sinal vermelho",
                ValorMulta = 293.47m,
                DataInfracao = DateTime.Now.AddDays(-10),
                LocalInfracao = "Av. Brasil, 1000 - Centro",
                OrgaoAutuador = "DETRAN-SP",
                PontosNaCNH = 7,
                ClienteId = 101
            };

            var response = new Response<Core.Models.Multa>(clienteFake);

            if (response is { IsSuccess: true, Data: not null })
            {
                var multa = response.Data;

                InputModel = new UpdateMultaRequest
                {
                    Id = multa.Id,
                    AutoInfracao = multa.AutoInfracao,
                    PlacaVeiculo = multa.PlacaVeiculo,
                    Renavam = multa.Renavam,
                    CodigoInfracao = multa.CodigoInfracao,
                    DescricaoInfracao = multa.DescricaoInfracao,
                    ValorMulta = multa.ValorMulta,
                    DataInfracao = multa.DataInfracao,
                    LocalInfracao = multa.LocalInfracao,
                    OrgaoAutuador = multa.OrgaoAutuador,
                    PontosNaCNH = multa.PontosNaCNH,
                    ClienteId = multa.ClienteId
                };
            }
            else
            {
                Snackbar.Add(response?.Message ?? "Erro ao buscar multa", Severity.Error);
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

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            //var result = await Handler.UpdateAsync(InputModel);

            var result = new Response<Core.Models.Multa>();

            if (result.IsSuccess)
            {
                Snackbar.Add("Multa atualizada com sucesso", Severity.Success);
                NavigationManager.NavigateTo(NavigationManager.BaseUri + "multas");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao atualizar multa: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
