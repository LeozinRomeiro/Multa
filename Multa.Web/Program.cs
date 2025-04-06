using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Multa.Core.Handlers;
using Multa.Web;
using Multa.Web.Handlers;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(Configuration.HttpClientName, opt => { opt.BaseAddress = new Uri(Configuration.BackendUrl); })
    //.AddHttpMessageHandler<CookieHandler>()
    ;

builder.Services.AddTransient<IClienteHandler, ClienteHandler>();
builder.Services.AddTransient<IMultaHandler, MultaHandler>();

builder.Services.AddLocalization();
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

await builder.Build().RunAsync();
