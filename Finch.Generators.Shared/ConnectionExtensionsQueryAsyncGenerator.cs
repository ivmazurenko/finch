using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Finch.Generators.Sqlite;

public static class ConnectionExtensionsQueryAsyncGenerator
{
    public static void GenerateQueryAsync(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classDeclarations,
        string commandType,
        string connectionType,
        string prefix)
    {
        foreach (var classDeclarationSyntax in classDeclarations)
        {
            var semanticModel = compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(classDeclarationSyntax) is not INamedTypeSymbol classSymbol)
                continue;

            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();
            var code =
                $$"""
                  // <auto-generated/>

                  namespace {{namespaceName}};

                  public static partial class {{prefix}}ConnectionExtensions
                  {
                      public static async global::System.Threading.Tasks.Task<global::System.Collections.Generic.List<T>> QueryAsync<T>(
                          this {{connectionType}} connection,
                          string sql,
                          CancellationToken cancellationToken = default)
                          where T : new()
                      {
                          await connection.OpenAsync(cancellationToken);
                  
                          var items = new global::System.Collections.Generic.List<T>();
                          await using var command = new {{commandType}}(sql, connection);
                          await using var reader = await command.ExecuteReaderAsync(cancellationToken);
                          while (await reader.ReadAsync(cancellationToken))
                          {
                              T item = new T();
                  
                              {{prefix}}GenericMapper.Map(item, reader);
                              items.Add(item);
                          }
                          
                          return items;
                      }
                  }
                  """;
            context.AddSource($"{prefix}ConnectionExtensions.QueryAsync.g.cs", SourceText.From(code, Encoding.UTF8));
            break;
        }
    }
}