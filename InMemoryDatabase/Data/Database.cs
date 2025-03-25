using InMemoryDatabase.Internal_Interfaces;
using InMemoryDatabase.Public_Interfaces;

namespace InMemoryDatabase.Data;

public class Database : IDatabaseInternal
{
    public void SaveData()
    {
        throw new NotImplementedException();
    }

    public void LoadData()
    {
        throw new NotImplementedException();
    }

    public void CreateTable(string tableName, Action<ITable> tableSetup)
    {
        throw new NotImplementedException();
    }

    public void Insert(string tableName, Action<dynamic> configure)
    {
        throw new NotImplementedException();
    }

    public IQueryBuilder Select(string tableName, params string[] columns)
    {
        throw new NotImplementedException();
    }

    ITableInternal IDatabaseInternal.GetTable(string tableName)
    {
        throw new NotImplementedException();
    }
}