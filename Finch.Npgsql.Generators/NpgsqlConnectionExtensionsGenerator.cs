using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Finch.Npgsql.Generators;

public static class NpgsqlConnectionExtensionsGenerator
{
    public static void Generate(SourceProductionContext context, Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classDeclarations)
    {
        foreach (var classDeclarationSyntax in classDeclarations)
        {
            var semanticModel = compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(classDeclarationSyntax) is not INamedTypeSymbol classSymbol)
                continue;

            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();
            var code = CreateQueryMethod(namespaceName);
            context.AddSource("Query.g.cs", SourceText.From(code, Encoding.UTF8));
            break;
        }
    }

    private static string CreateQueryMethod(string namespaceName)
    {
        var code =
            $$"""
              // <auto-generated/>

              using System.Collections.Generic;
              using Npgsql;

              namespace {{namespaceName}};

              public static class NpgsqlConnectionExtensions
              {
                  public static List<T> Query<T>(this NpgsqlConnection connection, string sql)
                      where T : new()
                  {
                      connection.Open();
              
                      var items = new List<T>();
                      string sqlQuery = sql;
                      using NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
                      using NpgsqlDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                      {
                          T item = new T();
              
                          ReaderGeneric.Read(item, reader);
                          items.Add(item);
                      }
                      
                      return items;
                  }
              }
              """;
        return code;
    }
}