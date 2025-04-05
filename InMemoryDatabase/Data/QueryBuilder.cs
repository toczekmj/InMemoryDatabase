using InMemoryDatabase.Internal_Interfaces;
using InMemoryDatabase.Public_Interfaces;

namespace InMemoryDatabase.Data;

public class QueryBuilder : IQueryBuilder
{
    private readonly string[]? _columns;
    private readonly ITableInternal? _table;
    private bool _descending;
    private string? _groupBy;
    private int? _limit;
    private string? _orderBy;
    private Func<dynamic, bool>? _wherePredicate;

    public QueryBuilder(ITable? table, string[] columns)
    {
        _table = table as ITableInternal;
        _columns = columns;
    }

    public IQueryBuilder Where(Func<dynamic, bool> predicate)
    {
        _wherePredicate = predicate;
        return this;
    }

    public IQueryBuilder OrderBy(string column, bool descending = false)
    {
        _orderBy = column;
        _descending = descending;
        return this;
    }

    public IQueryBuilder GroupBy(string column)
    {
        _groupBy = column;
        return this;
    }

    public IQueryBuilder Limit(int count)
    {
        _limit = count;
        return this;
    }

    public int? Count()
    {
        return Execute()?.Count;
    }

    public double? Sum(string column)
    {
        return CalculateDouble(column, rows => rows.Sum());
    }

    public double? Avg(string column)
    {
        return CalculateDouble(column, rows => rows.Average());
    }

    public object? Min(string column)
    {
        return CalculateObject(column, rows => rows.Min());
    }

    public object? Max(string column)
    {
        return CalculateObject(column, rows => rows.Max());
    }

    public List<dynamic>? Execute()
    {
        return _table?.ExecuteQuery(_wherePredicate, _columns, _orderBy, _groupBy, _descending, _limit);
    }

    #region private methods

    private double? CalculateDouble(string column, Func<IEnumerable<double>, double> aggregation)
    {
        IEnumerable<double>? rows = Execute()?.Select(row =>
        {
            if (row is not Dictionary<string, object> rowDict)
                throw new ArgumentException(
                    $"Row is not a {typeof(Dictionary<string, object>)} please check your database configuration.");
            return Convert.ToDouble(rowDict[column]);
        });

        return rows is null ? null : aggregation(rows);
    }

    private object? CalculateObject(string column, Func<IEnumerable<dynamic>, object?> aggregation)
    {
        IEnumerable<dynamic>? rows = Execute()?.Select(row =>
        {
            if (row is not Dictionary<string, object> rowDict)
                throw new ArgumentException(
                    $"Row is not a {typeof(Dictionary<string, object>)} please check your database configuration.");
            return rowDict[column];
        });

        return rows is null ? null : aggregation(rows);
    }

    #endregion
}