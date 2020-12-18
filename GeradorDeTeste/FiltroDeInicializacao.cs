using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GeradorDeTeste
{
    internal sealed class FiltroDeInicializacao : ISyntaxReceiver
    {
        public List<TypeDeclarationSyntax> Candidates { get; } = new List<TypeDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax)
            {
                foreach (var attributeList in typeDeclarationSyntax.AttributeLists)
                {
                    foreach (var attribute in attributeList.Attributes)
                    {
                        if (attribute.Name.ToString() == "IComparador" ||
                            attribute.Name.ToString() == "IComparadorAttribute")
                        {
                            this.Candidates.Add(typeDeclarationSyntax);
                        }
                    }
                }
            }
        }
    }
}

