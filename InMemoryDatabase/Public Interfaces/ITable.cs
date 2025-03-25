namespace InMemoryDatabase.Public_Interfaces;

public interface ITable
{
    void SetupField<T>(string fieldName);
    void SetupField(string fieldName, Type fieldType);
    void Insert(Action<dynamic> configure);
    void Insert(Action<List<dynamic>> configureList);
    public IQueryBuilder Select(params string[] columns);
}