namespace InMemoryDatabase.Public_Interfaces;

public interface ITable
{
    void SetupField<T>(string fieldName);
    void SetupField(string fieldName, Type fieldType);
    void Insert(Action<dynamic> configure);
    public IQueryBuilder Select(params string[] columns);
}