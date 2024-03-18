## Finch - Database Connection Mapping Extension Generator

### Goals

1. Generate concise extension methods for simplifying database queries and mappings.
2. Provide support for MSSQL and other Postgres databases.
3. Ensure Ahead-of-Time (AOT) compatibility.

### Non-Goals

1. Do not prioritize compatibility with other libraries (such as [Dapper](https://github.com/DapperLib/Dapper)).
2. Performance benchmarks are not a priority.
3. Avoid focusing on Object Relational Model (ORM) functionality.
4. Support frameworks older then dotnet 8.

### TO DO
1. Support records
2. Pack nuget package (packages?)
3. Fix namespace generation somehow
4. Support all primitive types