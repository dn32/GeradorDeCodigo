using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeradorDeTeste
{
    public partial class Generator
    {
        private void SalvarEmArquivo(string codigo)
        {
            var path = @"C:\Users\dn\source\repos\GeradorDeTeste\GeradorDeTeste.Host\Comparador.cs";
            if (File.Exists(path)) File.Delete(path);
            var arquivo = File.CreateText(path);
            arquivo.Write(codigo);
            arquivo.Close();
        }

        private string Join<T>(string separados, IEnumerable<T> colecao, Func<T, string> func) =>
            string.Join(separados, colecao.Select(func));

        private string PropriedadesString(Classe classe) => string.Join(", ", classe.Propriedade.Select(p => $"\"{p.Nome}\"").ToArray());
    }
}
