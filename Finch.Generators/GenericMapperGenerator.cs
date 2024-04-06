using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Finch.Generators;

public static class GenericMapperGenerator
{
    public static void Generate(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<TypeDeclarationSyntax> classDeclarations,
        DatabaseSpecificInfo info)
    {
        var items = new List<string>();

        string allNamespace = null;

        foreach (var classDeclarationSyntax in classDeclarations)
        {
            var semanticModel = compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);

            if (semanticModel.GetDeclaredSymbol(classDeclarationSyntax) is not INamedTypeSymbol classSymbol)
                continue;

            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();
            allNamespace = namespaceName; // rework

            var className = classDeclarationSyntax.Identifier.Text;

            items.Add(
                $$"""
                          if(typeof(T) == typeof({{namespaceName}}.{{className}}))
                          {
                              {{info.prefix}}PropertyMapper.Map(item as {{namespaceName}}.{{className}}, reader);
                              return;
                          }
                  """);
        }

        var code =
            $$"""
              // <auto-generated/>

              using System;
              using System.Collections.Generic;

              namespace {{allNamespace}};

              internal class {{info.prefix}}GenericMapper
              {
                  public static void Map<T>(T item, {{info.readerType}} reader)
                  {
              {{string.Join("\n", items)}}
                  }
              }

              """;

        context.AddSource($"{info.prefix}GenericMapper.g.cs", SourceText.From(code, Encoding.UTF8));
    }
}