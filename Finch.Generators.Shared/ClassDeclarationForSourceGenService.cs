using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Finch.Generators.Shared;

public static class ClassDeclarationForSourceGenService
{
    public static (ClassDeclarationSyntax, bool reportAttributeFound) Get(
        GeneratorSyntaxContext context, string targetAttributeName)
    {
        var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

        foreach (var attributeListSyntax in classDeclarationSyntax.AttributeLists)
        foreach (var attributeSyntax in attributeListSyntax.Attributes)
        {
            if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                continue;

            var attributeName = attributeSymbol.ContainingType.ToDisplayString();

            if (attributeName == targetAttributeName)
                return (classDeclarationSyntax, true);
        }

        return (classDeclarationSyntax, false);
    }
}