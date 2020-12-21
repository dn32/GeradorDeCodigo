using CheeseConsole;
using GeradorDeCodigo.Host.Model.Categorias;
using GeradorDeCodigo.Host.Model.Marcas;

namespace GeradorDeCodigo.Host.Model.Produtos
{
    public class Produto : IComparador
    {
        public int CodigoDoProduto { get; set; }
        public string NomeDoProduto { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public int ObterComparador() => 1;
    }
}