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
                        },
                        new Cliente
                        {
                            Id = 3,
                            Nome = "Carlos Pereira",
                            CPF = "34567890123",
                            CNH = "76543210988",
                            DataNascimento = new DateTime(1982, 3, 25),
                            Endereco = "Rua XV de Novembro, 789 - Maringá/PR",
                            Telefone = "(44) 97777-7890",
                            Email = "carlos.pereira@email.com"
                        },
                        new Cliente
                        {
                            Id = 4,
                            Nome = "Ana Souza",
                            CPF = "45678901234",
                            CNH = "65432109877",
                            DataNascimento = new DateTime(1995, 9, 30),
                            Endereco = "Rua dos Pioneiros, 101 - Cascavel/PR",
                            Telefone = "(45) 96666-1122",
                            Email = "ana.souza@email.com"
                        },
                        new Cliente
                        {
                            Id = 5,
                            Nome = "Felipe Andrade",
                            CPF = "56789012345",
                            CNH = "54321098766",
                            DataNascimento = new DateTime(1988, 1, 5),
                            Endereco = "Av. das Araucárias, 202 - Ponta Grossa/PR",
                            Telefone = "(42) 95555-3344",
                            Email = "felipe.andrade@email.com"
                        },
                        new Cliente
                        {
                            Id = 6,
                            Nome = "Juliana Lima",
                            CPF = "67890123456",
                            CNH = "43210987655",
                            DataNascimento = new DateTime(1993, 11, 20),
                            Endereco = "Rua Pedro Álvares Cabral, 321 - Guarapuava/PR",
                            Telefone = "(46) 94444-5566",
                            Email = "juliana.lima@email.com"
                        },
                        new Cliente
                        {
                            Id = 7,
                            Nome = "Ricardo Fernandes",
                            CPF = "78901234567",
                            CNH = "32109876544",
                            DataNascimento = new DateTime(1979, 12, 15),
                            Endereco = "Rua Dom Pedro II, 654 - Foz do Iguaçu/PR",
                            Telefone = "(45) 93333-7788",
                            Email = "ricardo.fernandes@email.com"
                        },
                        new Cliente
                        {
                            Id = 8,
                            Nome = "Patrícia Gomes",
                            CPF = "89012345678",
                            CNH = "21098765433",
                            DataNascimento = new DateTime(2000, 2, 28),
                            Endereco = "Av. das Indústrias, 987 - São José dos Pinhais/PR",
                            Telefone = "(41) 92222-8899",
                            Email = "patricia.gomes@email.com"
                        },
                        new Cliente
                        {
                            Id = 9,
                            Nome = "Bruno Costa",
                            CPF = "90123456789",
                            CNH = "10987654322",
                            DataNascimento = new DateTime(1986, 6, 10),
                            Endereco = "Rua do Comércio, 432 - Araucária/PR",
                            Telefone = "(41) 91111-9900",
                            Email = "bruno.costa@email.com"
                        },
                        new Cliente
                        {
                            Id = 10,
                            Nome = "Larissa Ribeiro",
                            CPF = "01234567890",
                            CNH = "99887766550",
                            DataNascimento = new DateTime(1999, 10, 18),
                            Endereco = "Rua Independência, 210 - Colombo/PR",
                            Telefone = "(41) 98888-7777",
                            Email = "larissa.ribeiro@email.com"
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

        public async Task OnDeleteAsync(long id, string nome)
        {
            try
            {
                //var request = new DeleteCategoryRequest { Id = id };
                //await Handler.DeleteAsync(request);
                //Categories.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Cliente {nome} excluído", Severity.Info);
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
                ? $"background-color: var(--mud-palette-primary); "
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
