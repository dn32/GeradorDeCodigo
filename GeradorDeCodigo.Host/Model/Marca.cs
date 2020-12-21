using CheeseConsole;
using GeradorDeCodigo.Host.Model.Categorias;

namespace GeradorDeCodigo.Host.Model.Marcas
{
    public class Marca : IComparador
    {
        public int Codigo { get; set; }
        public bool Ativo { get; set; }
        public Categoria Categoria { get; set; }
        public int ObterComparador() => 3;
    }
}