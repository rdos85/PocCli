using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using poccli.Options;
using System.Reflection;

var parsedValue = Parser.Default.ParseArguments<OpcaoA, OpcaoB>(args);

parsedValue.WithParsed(async options => await ExecutarAsync(options))
           .WithNotParsed(errors => Console.WriteLine(string.Join(", ", errors.Select(e => e.Tag))));

// Sem o MediatR, a implementação seria algo assim.
//parsedValue.WithParsed<OpcaoA>(opcaoA => Executar(opcaoA))
//           .WithParsed<OpcaoB>(opcaoB => Executar(opcaoB))
//           .WithNotParsed(errors => Console.WriteLine(string.Join(", ", errors.Select(e => e.Tag))));


// Solicita ao MediatR que enderece o processamento da option. 
async Task ExecutarAsync(object option)
{
    var services = new ServiceCollection();

    ConfigureServices(services);

    var serviceProvider = services.BuildServiceProvider();
    
    await ExecuteOption(option, serviceProvider);
}

void ConfigureServices(IServiceCollection services)
{
    // Configura serviços da aplicação.

    services.AddMediatR(Assembly.GetExecutingAssembly());
}

static async Task ExecuteOption(object options, ServiceProvider serviceProvider)
{
    var mediator = serviceProvider.GetService<IMediator>();

    if (mediator == null)
        throw new Exception("MediatR não foi configurado corretamente.");

    await mediator.Send(options);
}