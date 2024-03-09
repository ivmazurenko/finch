using System;

namespace Finch.Npgsql.Abstractions;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateNpgsqlConnectionExtensionsAttribute : Attribute;