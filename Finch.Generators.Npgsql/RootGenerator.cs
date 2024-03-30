using System.Collections.Immutable;
using Finch.Generators.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Finch.Generators.Npgsql;

[Generator]
public class RootGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var info = new DatabaseSpecificInfo()
        {
            readerType = "global::Npgsql.NpgsqlDataReader",
            commandType = "global::Npgsql.NpgsqlCommand",
            connectionType = "global::Npgsql.NpgsqlConnection",
            parameterType = "global::Npgsql.NpgsqlParameter",
            prefix = "Npgsql"
        };

        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(
                (s, _) => s is ClassDeclarationSyntax or RecordDeclarationSyntax,
                (ctx, _) => ClassDeclarationForSourceGenService.Get(
                    ctx,
                    "Finch.Abstractions.Npgsql.GenerateNpgsqlConnectionExtensionsAttribute"))
            .Where(t => t.reportAttributeFound)
            .Select((t, _) => t.Item1);

        context.RegisterSourceOutput(context.CompilationProvider.Combine(provider.Collect()),
            (ctx, t) => GenerateCode(ctx, t.Left, t.Right, info));
    }

    private static void GenerateCode(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<TypeDeclarationSyntax> classOrRecordDeclarations,
        DatabaseSpecificInfo info)
    {
        ConnectionExtensionsGenerator.GenerateQuery(context, compilation, classOrRecordDeclarations, info);
        ConnectionExtensionsQueryAsyncGenerator.GenerateQueryAsync(context, compilation, classOrRecordDeclarations,
            info);

        ConnectionExtensionsQueryAsyncWithParameterGenerator.GenerateQueryAsyncWithParameter(
            context,
            compilation,
            classOrRecordDeclarations,
            info);

        GenericMapperGenerator.Generate(context, compilation, classOrRecordDeclarations, info);
        TypedMapperGenerator.Generate(context, compilation, classOrRecordDeclarations, info);
    }
}