using System;
using GeradorDeTeste.Host;

public class Comparador
{
    public static string[] ObterImplementacoes()
    {
        return new[] { "Categoria", "Cliente", "Produto", "Marca" };
    }

    public static object Criar(string nomeDaClasse) => nomeDaClasse switch
    {
		"Categoria" => new Categoria(),
		"Cliente" => new Cliente(),
		"Produto" => new Produto(),
		"Marca" => new Marca(),
        _ => throw new ArgumentException($"Tipo {nomeDaClasse} não encontrado")
    };

    public static string[] Propriedades(string nomeDaClasse) => nomeDaClasse switch
    {
		"Categoria" => new[] { "Codigo" },
		"Cliente" => new[] { "CodigoDoCliente" },
		"Produto" => new[] { "CodigoDoProduto", "NomeDoProduto", "Marca", "Categoria" },
		"Marca" => new[] { "Codigo", "Ativo", "Categoria" },
        _ => throw new ArgumentException($"Tipo {nomeDaClasse} não encontrado")
    };
}