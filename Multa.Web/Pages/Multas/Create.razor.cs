using Microsoft.AspNetCore.Components;
using MudBlazor;
using Multa.Core.Handlers;
using Multa.Core.Requests.Multa;

namespace Multa.Web.Pages.Multas;

public partial class CreateMultaPage : ComponentBase
{
    public bool IsBusy { get; set; } = false;
    public CreateMultaRequest InputModel { get; set; } = new();

    [Inject] public IMultaHandler Handler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add("Multa cadastrada com sucesso", Severity.Success);
                NavigationManager.NavigateTo("/multas");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
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
