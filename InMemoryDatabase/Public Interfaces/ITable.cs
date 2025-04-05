namespace InMemoryDatabase.Public_Interfaces;

public interface ITable
{
    void SetupField<T>(string fieldName);
    void SetupField(string fieldName, Type fieldType);

    // TODO: should user has an access to particular table IO operations? 
    void Insert(Action<dynamic> configure);
    void Insert(List<Action<dynamic>> configureList);
    public IQueryBuilder Select(params string[] columns);
}