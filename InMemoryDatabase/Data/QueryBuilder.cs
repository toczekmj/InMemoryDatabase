using InMemoryDatabase.Public_Interfaces;

namespace InMemoryDatabase.Data;

public class QueryBuilder : IQueryBuilder
{
    public IQueryBuilder Where(Func<dynamic, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryBuilder OrderBy(string column, bool descending = false)
    {
        throw new NotImplementedException();
    }

    public IQueryBuilder GroupBy(string column)
    {
        throw new NotImplementedException();
    }

    public IQueryBuilder Limit(int count)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        throw new NotImplementedException();
    }

    public double Sum(string column)
    {
        throw new NotImplementedException();
    }

    public double Avg(string column)
    {
        throw new NotImplementedException();
    }

    public object? Min(string column)
    {
        throw new NotImplementedException();
    }

    public object? Max(string column)
    {
        throw new NotImplementedException();
    }

    public List<dynamic> Execute()
    {
        throw new NotImplementedException();
    }
}