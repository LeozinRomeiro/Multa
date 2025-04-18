using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Multa.Web.Components
{
    public partial class Form<TModel>
    {

        [Parameter]
        public TModel Model { get; set; }

        [Parameter]
        public EventCallback OnValidSubmit { get; set; }

        [Parameter]
        public bool IsBusy { get; set; }

        [Parameter]
        public string TextoBotaoSalvar { get; set; } = "Salvar";

        [Parameter]
        public string TextoBotaoVoltar { get; set; } = "Voltar";

        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;

        [Inject]
        public IJSRuntime JS { get; set; } = null!;


        public async Task Voltar()
        {
            await JS.InvokeVoidAsync("voltarPagina");
        }
    }
}
