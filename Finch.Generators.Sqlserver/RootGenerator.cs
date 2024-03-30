using System.Collections.Immutable;
using Finch.Generators.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Finch.Generators.Sqlserver;

[Generator]
public class RootGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var info = new DatabaseSpecificInfo
        {
            readerType = "global::Microsoft.Data.SqlClient.SqlDataReader",
            commandType = "global::Microsoft.Data.SqlClient.SqlCommand",
            connectionType = "global::Microsoft.Data.SqlClient.SqlConnection",
            parameterType = "global::Microsoft.Data.SqlClient.SqlParameter",
            prefix = "Sqlserver"
        };

        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(
                (s, _) => s is TypeDeclarationSyntax or RecordDeclarationSyntax,
                (ctx, _) => ClassDeclarationForSourceGenService.Get(
                    ctx,
                    "Finch.Abstractions.Sqlserver.GenerateSqlserverConnectionExtensionsAttribute"))
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