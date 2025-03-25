using InMemoryDatabase.Public_Interfaces;

namespace InMemoryDatabase.Internal_Interfaces;

public interface IDatabaseInternal : IDatabase
{
    internal ITableInternal GetTable(string tableName);
}