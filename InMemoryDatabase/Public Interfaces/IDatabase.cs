namespace InMemoryDatabase.Public_Interfaces;

public interface IDatabase
{
    bool TryCreateTable(string tableName, Action<ITable> tableSetup, out ITable? result);
    bool CreateTable(string tableName, Action<ITable> tableSetup);
    void Insert(string tableName, Action<dynamic> configure);
    public void Insert(string tableName, List<Action<dynamic>> configureMultiple);
    IQueryBuilder Select(string tableName, params string[] columns);
}