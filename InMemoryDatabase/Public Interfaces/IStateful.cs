namespace InMemoryDatabase.Public_Interfaces;

public interface IStateful
{
    void SaveData();
    void LoadData();
}