using Microsoft.AspNetCore.Components;
using MudBlazor;
using Multa.Core.Handlers;
using Multa.Core.Models;

namespace Multa.Web.Pages.Clientes
{
    public partial class ListClientesPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public List<Cliente> Clientes { get; set; } = [];
        public Cliente? ClienteSelected = null;
        public string SearchTerm { get; set; } = string.Empty;
        [CascadingParameter]
        public MudTheme Theme { get; set; } = new MudTheme();

        #endregion

        #region Services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public IClienteHandler Handler { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                //var request = new GetAllCategoriesRequest();
                //var result = await Handler.GetAllAsync(request);

                //var result = await Handler.GetAllAsync();
                //if (result.IsSuccess)
                //    Clientes = result.Data ?? [];

                var result = new List<Cliente>()
                {
                    new()
                    {
                        Nome = "Leonardo",
                        Telefone = "45 999880989"
                    },
                    new()
                    {
                        Nome = "Henrique",
                        Telefone = "44 999880101"
                    }
                };
                Clientes = result;
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

        #region Methods

        public async void OnDeleteButtonClickedAsync(long id, string nome)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir o cliente {nome} será excluída. Esta é uma ação irreversível! Deseja continuar?",
                yesText: "EXCLUIR",
                cancelText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, nome);

            StateHasChanged();
        }

        public async Task OnDeleteAsync(long id, string title)
        {
            try
            {
                //var request = new DeleteCategoryRequest { Id = id };
                //await Handler.DeleteAsync(request);
                //Categories.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Categoria {title} excluída", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public async Task OnEditing(long id)
        {
            NavigationManager.NavigateTo($"/clientes/editar/{id}");
        }

        public void OnRowClick(DataGridRowClickEventArgs<Cliente> args)
        {
            if (ClienteSelected != args.Item)
                ClienteSelected = args.Item;
            else
                ClienteSelected = null;
        }

        public string AlterColorSelect(Cliente cliente, int rowIndex)
        {
            return cliente == ClienteSelected
                ? $"background-color: #6A66A3; "
                : "";
        }

        public Func<Cliente, bool> Filter => category =>
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
                return true;

            if (category.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (category.Nome.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (category.Telefone is not null &&
                category.Telefone.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        #endregion
    }
}
