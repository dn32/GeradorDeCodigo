using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace GeradorDeTeste
{
    [Generator]
    public partial class Generator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) =>
            context.RegisterForSyntaxNotifications(() => new FiltroDeInicializacao());

        public void Execute(GeneratorExecutionContext context)
        {
            //if (!Debugger.IsAttached) Debugger.Launch();

            if (context.SyntaxReceiver is FiltroDeInicializacao receiver)
            {
                var namespaces = new List<string>();
                var classes = new List<Classe>();

                foreach (var candidateTypeNode in receiver.Candidates)
                {
                    var model = context.Compilation.GetSemanticModel(candidateTypeNode.SyntaxTree);
                    var candidateTypeSymbol = model.GetDeclaredSymbol(candidateTypeNode) as ITypeSymbol;

                    //Passa somente quem implementa a interface IComparador
                    if (!candidateTypeSymbol.AllInterfaces.Any(x => x.Name == "IComparador")) continue;

                    namespaces.Add(candidateTypeSymbol.ContainingNamespace.ToDisplayString());

                    var propriedades = ObterPropriedades(candidateTypeSymbol);

                    var classe = new Classe
                    {
                        Nome = candidateTypeNode.Identifier.Text,
                        Propriedade = propriedades.Select(x => new Propriedade { Nome = x.Name }).ToList()
                    };

                    classes.Add(classe);
                }

                classes = classes.OrderByDescending(x => x.Nome.Length).ToList();
                namespaces = namespaces.GroupBy(x => x).Select(x => x.First()).OrderBy(x => x).ToList();
                
                var codigo = Template(namespaces, classes).Trim();
                SalvarEmArquivo(codigo);

                //context.AddSource("Factory.cs", SourceText.From(source, Encoding.UTF8));
            }
        }
    }
}