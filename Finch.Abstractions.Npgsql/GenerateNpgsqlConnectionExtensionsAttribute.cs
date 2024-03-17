using System;

namespace Finch.Abstractions.Npgsql;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateNpgsqlConnectionExtensionsAttribute : Attribute;