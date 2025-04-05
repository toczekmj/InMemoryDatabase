namespace InMemoryDatabase.Public_Interfaces;

public interface IQueryBuilder
{
    IQueryBuilder Where(Func<dynamic, bool> predicate);
    IQueryBuilder OrderBy(string column, bool descending = false);
    IQueryBuilder GroupBy(string column);
    IQueryBuilder Limit(int count);
    int? Count();
    double? Sum(string column);
    double? Avg(string column);
    object? Min(string column);
    object? Max(string column);

    List<dynamic>? Execute();
    // TODO: Add Join method
    // TODO: Add Update method
}