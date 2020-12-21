using CheeseConsole;

namespace GeradorDeCodigo.Host.Model.Clientes
{
    public class Cliente : IComparador
    {
        public int CodigoDoCliente { get; set; }
        public int ObterComparador() => 2;
    }
}