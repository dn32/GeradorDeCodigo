using System.Collections.Generic;

namespace GeradorDeTeste
{
    public partial class Generator
    {
        private string Template(List<string> namespaces, List<Classe> classes)
        {
            return @$"
using System;
{Join("\n", namespaces, (x => $"using {x};"))}

public class Comparador
{{
    public static string[] ObterImplementacoes()
    {{
        return new[] {{ {Join(", ", classes, (x => $"\"{x.Nome}\""))} }};
    }}

    public static object Criar(string nomeDaClasse) => nomeDaClasse switch
    {{
{Join(",\n", classes, (x => $"\t\t\"{x.Nome}\" => new {x.Nome}()"))},
        _ => throw new ArgumentException($""Tipo {{nomeDaClasse}} não encontrado"")
    }};

    public static string[] Propriedades(string nomeDaClasse) => nomeDaClasse switch
    {{
{Join(",\n", classes, (x => $"\t\t\"{x.Nome}\" => new[] {{ {PropriedadesString(x)} }}"))},
        _ => throw new ArgumentException($""Tipo {{nomeDaClasse}} não encontrado"")
    }};
}}";
        }

    }
}
