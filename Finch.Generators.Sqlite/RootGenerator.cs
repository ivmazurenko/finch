using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Finch.Generators.Sqlite;

[Generator]
public class RootGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(
                (s, _) => s is ClassDeclarationSyntax,
                (ctx, _) => GetClassDeclarationForSourceGen(ctx))
            .Where(t => t.reportAttributeFound)
            .Select((t, _) => t.Item1);

        context.RegisterSourceOutput(context.CompilationProvider.Combine(provider.Collect()),
            (ctx, t) => GenerateCode(ctx, t.Left, t.Right));
    }

    private static (ClassDeclarationSyntax, bool reportAttributeFound) GetClassDeclarationForSourceGen(
        GeneratorSyntaxContext context)
    {
        var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

        foreach (var attributeListSyntax in classDeclarationSyntax.AttributeLists)
        foreach (var attributeSyntax in attributeListSyntax.Attributes)
        {
            if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                continue;

            var attributeName = attributeSymbol.ContainingType.ToDisplayString();

            if (attributeName == "Finch.Abstractions.Sqlite.GenerateSqliteConnectionExtensionsAttribute")
                return (classDeclarationSyntax, true);
        }

        return (classDeclarationSyntax, false);
    }

    private static void GenerateCode(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classDeclarations)
    {
        const string readerType = "global::System.Data.Common.DbDataReader";
        const string commandType = "global::System.Data.SQLite.SQLiteCommand";
        const string connectionType = "global::System.Data.SQLite.SQLiteConnection";
        const string parameterType = "global::System.Data.SQLite.SQLiteParameter";
        const string prefix = "Sqlite";

        ConnectionExtensionsGenerator.GenerateQuery(
            context,
            compilation,
            classDeclarations,
            commandType,
            connectionType,
            prefix);

        ConnectionExtensionsQueryAsyncGenerator.GenerateQueryAsync(
            context,
            compilation,
            classDeclarations,
            commandType,
            connectionType,
            prefix);

        ConnectionExtensionsQueryAsyncWithParameterGenerator.GenerateQueryAsyncWithParameter(
            context,
            compilation,
            classDeclarations,
            commandType,
            connectionType,
            parameterType,
            prefix);

        ReaderGenericGenerator.Generate(context, compilation, classDeclarations, readerType, prefix);
        ReaderGenerator.Generate(context, compilation, classDeclarations, readerType, prefix);
    }
}