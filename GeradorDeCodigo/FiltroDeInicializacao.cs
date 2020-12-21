using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace GeradorDeTeste
{
    internal sealed class FiltroDeInicializacao : ISyntaxReceiver
    {
        public List<TypeDeclarationSyntax> Candidates { get; } = new List<TypeDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax)
            {
                this.Candidates.Add(typeDeclarationSyntax);

                // Caso eu queira filtrar por attributes é o código abaixo
                //foreach (var attributeList in typeDeclarationSyntax.AttributeLists)
                //{
                //    foreach (var attribute in attributeList.Attributes)
                //    {
                //        if (attribute.Name.ToString() == "IComparador" ||
                //            attribute.Name.ToString() == "IComparadorAttribute")
                //        {
                //            this.Candidates.Add(typeDeclarationSyntax);
                //        }
                //    }
                //}
            }
        }
    }
}

