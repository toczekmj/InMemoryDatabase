namespace InMemoryDatabase.Converters;

internal class DynamicJsonSerializer : IDynamicJsonSerializer 
{
    public void Serialize(dynamic obj)
    {
        throw new NotImplementedException();
    }

    public void Deserialize(string json)
    {
        throw new NotImplementedException();
    }
}

internal interface IDynamicJsonSerializer
{
    void Serialize(dynamic obj);
    void Deserialize(string json);
}