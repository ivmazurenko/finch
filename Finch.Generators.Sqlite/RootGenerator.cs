using System.Collections.Immutable;
using Finch.Generators.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Finch.Generators.Sqlite;

[Generator]
public class RootGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var info = new DatabaseSpecificInfo()
        {
            readerType = "global::System.Data.Common.DbDataReader",
            commandType = "global::System.Data.SQLite.SQLiteCommand",
            connectionType = "global::System.Data.SQLite.SQLiteConnection",
            parameterType = "global::System.Data.SQLite.SQLiteParameter",
            prefix = "Sqlite",
        };

        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(
                (s, _) => s is ClassDeclarationSyntax,
                (ctx, _) => ClassDeclarationForSourceGenService.Get(
                    ctx,
                    "Finch.Abstractions.Sqlite.GenerateSqliteConnectionExtensionsAttribute"))
            .Where(t => t.reportAttributeFound)
            .Select((t, _) => t.Item1);

        context.RegisterSourceOutput(context.CompilationProvider.Combine(provider.Collect()),
            (ctx, t) => GenerateCode(ctx, t.Left, t.Right, info));
    }

    private static void GenerateCode(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classDeclarations,
        DatabaseSpecificInfo info)
    {
        ConnectionExtensionsGenerator.GenerateQuery(context, compilation, classDeclarations, info);
        ConnectionExtensionsQueryAsyncGenerator.GenerateQueryAsync(context, compilation, classDeclarations, info);

        ConnectionExtensionsQueryAsyncWithParameterGenerator.GenerateQueryAsyncWithParameter(
            context,
            compilation,
            classDeclarations,
            info);

        ReaderGenericGenerator.Generate(context, compilation, classDeclarations, info);
        ReaderGenerator.Generate(context, compilation, classDeclarations, info);
    }
}