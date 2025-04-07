using Microsoft.AspNetCore.Components;
using MudBlazor;
using Multa.Core.Handlers;
using Multa.Core.Models;
using Multa.Core.Responses;

namespace Multa.Web.Pages.Multas;

public partial class ListMultasPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Core.Models.Multa> Multas { get; set; } = [];
    public Core.Models.Multa? MultaSelected = null;
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
    public IMultaHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            //var result = await Handler.GetAllAsync();

            #region Codigo teste fake dados

            List<Core.Models.Multa> multasFake = new()
            {
                new()
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
                    Cliente = new Cliente
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
                },
                new()
                {
                    Id = 2,
                    AutoInfracao = "B654321",
                    PlacaVeiculo = "XYZ9F87",
                    Renavam = "98765432100",
                    CodigoInfracao = "74560",
                    DescricaoInfracao = "Ultrapassagem em local proibido",
                    ValorMulta = 880.41m,
                    DataInfracao = DateTime.Now.AddDays(-20),
                    LocalInfracao = "Rod. dos Imigrantes, km 45",
                    OrgaoAutuador = "PRF",
                    PontosNaCNH = 7,
                    Cliente = new Cliente
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
                },
                new()
                {
                    Id = 3,
                    AutoInfracao = "C112233",
                    PlacaVeiculo = "MNO3T56",
                    Renavam = "65432198700",
                    CodigoInfracao = "51710",
                    DescricaoInfracao = "Estacionamento em local proibido",
                    ValorMulta = 195.23m,
                    DataInfracao = DateTime.Now.AddDays(-5),
                    LocalInfracao = "Rua das Flores, 200 - Jardim",
                    OrgaoAutuador = "CET-SP",
                    PontosNaCNH = 3,
                    Cliente = new Cliente
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
                },
                new()
                {
                    Id = 4,
                    AutoInfracao = "D445566",
                    PlacaVeiculo = "DEF2K89",
                    Renavam = "10293847566",
                    CodigoInfracao = "73780",
                    DescricaoInfracao = "Excesso de velocidade - até 20%",
                    ValorMulta = 130.16m,
                    DataInfracao = DateTime.Now.AddDays(-15),
                    LocalInfracao = "Av. João XXIII, 580",
                    OrgaoAutuador = "SMT-BH",
                    PontosNaCNH = 4,
                    Cliente = new Cliente
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
                },
                new()
                {
                    Id = 5,
                    AutoInfracao = "E778899",
                    PlacaVeiculo = "GHI5Y67",
                    Renavam = "56781234987",
                    CodigoInfracao = "74530",
                    DescricaoInfracao = "Conduzir veículo sem CNH",
                    ValorMulta = 880.41m,
                    DataInfracao = DateTime.Now.AddDays(-30),
                    LocalInfracao = "Rua Principal, 321 - Centro",
                    OrgaoAutuador = "DETRAN-PR",
                    PontosNaCNH = 0,
                    Cliente = new Cliente
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
                },
                new()
                {
                    Id = 6,
                    AutoInfracao = "F998877",
                    PlacaVeiculo = "JKL7P65",
                    Renavam = "22334455667",
                    CodigoInfracao = "60402",
                    DescricaoInfracao = "Não uso do cinto de segurança",
                    ValorMulta = 195.23m,
                    DataInfracao = DateTime.Now.AddDays(-7),
                    LocalInfracao = "Av. Independência, 99",
                    OrgaoAutuador = "CET-RJ",
                    PontosNaCNH = 5,
                    Cliente = new Cliente
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
                },
                new()
                {
                    Id = 7,
                    AutoInfracao = "G334455",
                    PlacaVeiculo = "RST4Z21",
                    Renavam = "44556677889",
                    CodigoInfracao = "50500",
                    DescricaoInfracao = "Veículo com farol apagado à noite",
                    ValorMulta = 130.16m,
                    DataInfracao = DateTime.Now.AddDays(-3),
                    LocalInfracao = "Av. das Nações, 1100",
                    OrgaoAutuador = "DETRAN-MG",
                    PontosNaCNH = 4,
                    Cliente = new Cliente
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
                },
                new()
                {
                    Id = 8,
                    AutoInfracao = "H556677",
                    PlacaVeiculo = "UVW6A98",
                    Renavam = "99887766554",
                    CodigoInfracao = "60203",
                    DescricaoInfracao = "Dirigir utilizando celular",
                    ValorMulta = 293.47m,
                    DataInfracao = DateTime.Now.AddDays(-12),
                    LocalInfracao = "Rua Tiradentes, 60",
                    OrgaoAutuador = "SMTT",
                    PontosNaCNH = 7,
                    Cliente = new Cliente
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

                },
                new()
                {
                    Id = 9,
                    AutoInfracao = "I889900",
                    PlacaVeiculo = "XYZ1L34",
                    Renavam = "12312312399",
                    CodigoInfracao = "74780",
                    DescricaoInfracao = "Avanço de faixa de pedestres",
                    ValorMulta = 195.23m,
                    DataInfracao = DateTime.Now.AddDays(-18),
                    LocalInfracao = "Av. Paulista, 1500",
                    OrgaoAutuador = "CET-SP",
                    PontosNaCNH = 4,
                    Cliente = new Cliente
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

                },
                new()
                {
                    Id = 10,
                    AutoInfracao = "J001122",
                    PlacaVeiculo = "AAA2B22",
                    Renavam = "11223344556",
                    CodigoInfracao = "51830",
                    DescricaoInfracao = "Não respeitar parada obrigatória",
                    ValorMulta = 293.47m,
                    DataInfracao = DateTime.Now.AddDays(-25),
                    LocalInfracao = "Rua São João, 808",
                    OrgaoAutuador = "DETRAN-RS",
                    PontosNaCNH = 7,
                    Cliente = new Cliente
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

                }
            };

            var result = new Response<List<Core.Models.Multa>>(multasFake);
            #endregion

            if (result.IsSuccess && result.Data is not null)
                Multas = result.Data;
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

    public async Task OnDeleteButtonClickedAsync(long id, string autoInfracao)
    {
        var result = await DialogService.ShowMessageBox(
            "ATENÇÃO",
            $"Deseja realmente excluir a multa {autoInfracao}? Esta ação não poderá ser desfeita!",
            yesText: "EXCLUIR",
            cancelText: "Cancelar");

        if (result is true)
            await OnDeleteAsync(id);
    }

    public async Task OnDeleteAsync(long id)
    {
        try
        {
            //await Handler.DeleteAsync(id);
            //Multas.RemoveAll(x => x.Id == id);

            Snackbar.Add($"Multa excluída com sucesso", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    public async Task OnEditing(long id)
    {
        NavigationManager.NavigateTo($"multas/editar/{id}");
    }

    public async Task ButtonCreateClick()
    {
        NavigationManager.NavigateTo($"multas/adicionar");
    }

    public void OnRowClick(DataGridRowClickEventArgs<Core.Models.Multa> args)
    {
        if (MultaSelected != args.Item)
            MultaSelected = args.Item;
        else
            MultaSelected = null;
    }

    public string AlterColorSelect(Core.Models.Multa multa, int rowIndex)
    {
        return multa == MultaSelected
            ? $"background-color: var(--mud-palette-primary); "
            : "";
    }

    public Func<Core.Models.Multa, bool> Filter => multa =>
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return true;

        return multa.AutoInfracao.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
            || multa.PlacaVeiculo.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
            || multa.CodigoInfracao.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
            || multa.DescricaoInfracao.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
            || multa.Renavam.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
            || multa.Cliente.Nome.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
            || multa.CodigoInfracao.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase);
    };

    #endregion
}
