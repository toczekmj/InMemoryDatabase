namespace InMemoryDatabase.Public_Interfaces;

public interface IDatabase
{
    void SaveData();
    void LoadData();
    void CreateTable(string tableName, Action<ITable> tableSetup);
    void Insert(string tableName, Action<dynamic> configure);
    IQueryBuilder Select(string tableName, params string[] columns);
}