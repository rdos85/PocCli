using CommandLine;
using CommandLine.Text;
using MediatR;
using System.Text;

namespace poccli.Options
{
    [Verb("acao-b", HelpText = "Executa a ação B.")]
    public class OpcaoB : IRequest
    {
        [Option('p', "parametro-qualquer", Required = true, HelpText = "Um parâmetro qualquer.")]
        public string ParametroQualquer { get; set; }

        [Option('t', "tipo", Required = true, HelpText = "Tipo de alguma coisa.")]
        public Tipos Tipo { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                var examples = new List<Example>();

                var tipos = Enum.GetValues<Tipos>();

                foreach (Tipos tipo in tipos)
                    examples.Add(new Example($"Para ação B com {tipo}", new OpcaoB { ParametroQualquer = "um texto qualquer", Tipo = tipo }));

                return examples;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"-p = {ParametroQualquer}");
            stringBuilder.AppendLine($"-t = {Tipo}");

            return stringBuilder.ToString();
        }
    }

    [Flags]
    public enum Tipos
    {
        None,
        ValueA,
        ValueB,
        ValueC,
        ValueD
    }
}
