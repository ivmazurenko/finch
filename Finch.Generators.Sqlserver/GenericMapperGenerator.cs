using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Finch.Generators.Sqlserver;

public static class ReaderGenericGenerator
{
    public static void Generate(SourceProductionContext context, Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classDeclarations)
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

            items.Add($$"""
                                if(typeof(T) == typeof({{namespaceName}}.{{className}}))
                                {
                                    TypedMapper.Map(item as {{namespaceName}}.{{className}}, reader);
                                    return;
                                }
                        """);
        }

        var code =
            $$"""
              // <auto-generated/>

              using System;
              using System.Collections.Generic;
              using Microsoft.Data.SqlClient;

              namespace {{allNamespace}};

              internal class GenericMapper
              {
                  public static void Map<T>(T item, SqlDataReader reader)
                  {
              {{string.Join("\n", items)}}
                  }
              }

              """;

        context.AddSource("GenericMapper.g.cs", SourceText.From(code, Encoding.UTF8));
    }
}