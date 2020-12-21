using CheeseConsole;

namespace GeradorDeTeste.Host
{
    public class Cliente : IComparador
    {
        public int CodigoDoCliente { get; set; }
        public int ObterComparador() => 2;
    }

    public class Categoria : IComparador
    {
        public int Codigo { get; set; }
        public int ObterComparador() => 4;
    }

    public class Marca : IComparador
    {
        public int Codigo { get; set; }
        public bool Ativo { get; set; }
        public Categoria Categoria { get; set; }
        public int ObterComparador() => 3;
    }

    public class Produto : IComparador
    {
        public int CodigoDoProduto { get; set; }
        public string NomeDoProduto { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }

        public int ObterComparador() => 1;
    }
}
