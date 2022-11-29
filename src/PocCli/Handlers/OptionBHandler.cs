using MediatR;
using poccli.Options;

namespace poccli.Handlers
{
    public class OptionBHandler : IRequestHandler<OpcaoB>
    {
        public Task<Unit> Handle(OpcaoB request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Executando acao-b...");
            Console.WriteLine(request);

            return Task.FromResult(Unit.Value);
        }
    }
}
