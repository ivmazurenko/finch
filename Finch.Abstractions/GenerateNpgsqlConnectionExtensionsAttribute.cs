using System;

namespace Finch.Abstractions;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateNpgsqlConnectionExtensionsAttribute : Attribute;