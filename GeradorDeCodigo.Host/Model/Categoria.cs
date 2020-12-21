using CheeseConsole;

namespace GeradorDeCodigo.Host.Model.Categorias
{
    public class Categoria : IComparador
    {
        public int Codigo { get; set; }
        public int ObterComparador() => 4;
    }
}
