using CommandLine;
using CommandLine.Text;
using MediatR;
using System.Text;

namespace poccli.Options
{
    [Verb("acao-a", HelpText = "Executa a ação A.")]
    public class OpcaoA : IRequest
    {
        [Option('t', "texto-qualquer", Required = true, HelpText = "Esse é um texto qualquer.")]
        public string? TextoQualquer { get; set; }

        [Option('l', "lista", Required = true, HelpText = "Lista de strings", Min = 1, Max = 3)]
        public IEnumerable<string>? Lista { get; set; }

        [Option('a', "ativo", HelpText = "Um boleano qualquer.")]
        public bool Ativo { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
            => new List<Example>
            {
            new Example("Com o bool false", new OpcaoA{ TextoQualquer = "um texto qualquer", Lista = new[]{ "item 1", "item 2", "item 3" }, Ativo = false }),
            new Example("Com o bool true", new OpcaoA{ TextoQualquer = "um texto qualquer", Lista = new[]{ "item 1", "item 2", "item 3" }, Ativo = true }),
            };

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"-a = {Ativo}");
            stringBuilder.AppendLine($"-t = {TextoQualquer}");
            foreach (var item in Lista)
                stringBuilder.AppendLine($"-l = {item}");

            return stringBuilder.ToString();
        }
    }
}
