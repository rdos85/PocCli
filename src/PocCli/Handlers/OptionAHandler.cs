using MediatR;
using poccli.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poccli.Handlers
{
    public class OptionAHandler : IRequestHandler<OpcaoA>
    {
        public Task<Unit> Handle(OpcaoA request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Executando acao-a...");
            Console.WriteLine(request);

            return Task.FromResult(Unit.Value);
        }
    }
}
