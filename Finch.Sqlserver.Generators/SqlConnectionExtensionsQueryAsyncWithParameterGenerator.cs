using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Finch.Sqlserver.Generators;

public static class SqlConnectionExtensionsQueryAsyncWithParameterGenerator
{
    public static void GenerateQueryAsyncWithParameter(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classDeclarations)
    {
        foreach (var classDeclarationSyntax in classDeclarations)
        {
            var semanticModel = compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(classDeclarationSyntax) is not INamedTypeSymbol classSymbol)
                continue;

            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();
            var code = CreateQueryMethod(namespaceName);
            context.AddSource("SqlConnectionExtensions.QueryAsyncWithParameter.g.cs", SourceText.From(code, Encoding.UTF8));
            break;
        }
    }

    private static string CreateQueryMethod(string namespaceName)
    {
        var code =
            $$"""
              // <auto-generated/>

              using System.Collections.Generic;
              using System.Threading;
              using Microsoft.Data.SqlClient;

              namespace {{namespaceName}};

              public static partial class SqlConnectionExtensions
              {
                  public static async Task<List<T>> QueryAsync<T>(
                      this SqlConnection connection,
                      string sql,
                      CancellationToken cancellationToken,
                      params SqlParameter[] parameters)
                      where T : new()
                  {
                      await connection.OpenAsync(cancellationToken);
              
                      var items = new List<T>();
                      await using var command = new SqlCommand(sql, connection);
                      command.Parameters.AddRange(parameters);
                      await using var reader = await command.ExecuteReaderAsync(cancellationToken);
                      while (await reader.ReadAsync(cancellationToken))
                      {
                          T item = new T();
              
                          GenericMapper.Map(item, reader);
                          items.Add(item);
                      }
                      
                      return items;
                  }
              }
              """;
        return code;
    }
}