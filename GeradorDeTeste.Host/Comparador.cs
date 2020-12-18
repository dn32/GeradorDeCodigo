using System;
using GeradorDeTeste.Host;

public class Comparador
{
    public static string[] ObterImplementacoes()
    {
        return new[] { "Categoria", "Cliente", "Marca" };
    }

    public static object Criar(string nomeDaClasse) => nomeDaClasse switch
    {
		"Categoria" => new Categoria(),
		"Cliente" => new Cliente(),
		"Marca" => new Marca(),
        _ => throw new ArgumentException($"Tipo {nomeDaClasse} não encontrado")
    };

    public static string[] Propriedades(string nomeDaClasse) => nomeDaClasse switch
    {
		"Categoria" => new[] { "Codigo", "ObterComparador" },
		"Cliente" => new[] { "CodigoDoCliente", "ObterComparador" },
		"Marca" => new[] { "Codigo", "Ativo", "Categoria", "ObterComparador" },
        _ => throw new ArgumentException($"Tipo {nomeDaClasse} não encontrado")
    };
}