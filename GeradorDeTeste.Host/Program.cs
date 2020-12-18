using System;
using System.Linq;
using System.Collections.Generic;

namespace CheeseConsole
{
    class Program
    {

        public static List<string> ObterImplementacoesPorReflexao()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                 .Where(x => !x.IsDynamic)
                 .OrderBy(x => x.FullName)
                 .SelectMany(x => x.ExportedTypes)
                 .Where(x => typeof(IComparador).IsAssignableFrom(x) && !x.IsInterface)
                 .Select(x => x.Name)
                 .ToList();
        }

        static void Main(string[] _)
        {
            var implementacoesReflexao = ObterImplementacoesPorReflexao();

            var implementacoes = Comparador.ObterImplementacoes();
            foreach (var implementacao in implementacoes)
            {
                var elemento = Comparador.Criar(implementacao) as IComparador;
                var propriedades = Comparador.Propriedades(implementacao);
                var comparador = elemento.ObterComparador();

            }


            Console.ReadLine();
        }
    }
}
