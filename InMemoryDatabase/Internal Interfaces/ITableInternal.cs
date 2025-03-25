using System.Dynamic;
using InMemoryDatabase.Public_Interfaces;

namespace InMemoryDatabase.Internal_Interfaces;

internal interface ITableInternal : ITable
{
    internal Dictionary<string, Type>? Schema { get; }
    internal List<ExpandoObject>? Rows { get; }
    public string? Name { get; }
    internal List<dynamic>? ExecuteQuery(Func<dynamic, bool>? predicate, string[]? columns, string? orderBy = null,
        string? groupBy = null, bool descending = false, int? limit = null);
}