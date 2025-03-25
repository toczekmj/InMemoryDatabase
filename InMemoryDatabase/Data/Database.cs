using System.Text.Json;
using InMemoryDatabase.Converters;
using InMemoryDatabase.Internal_Interfaces;
using InMemoryDatabase.Public_Interfaces;

namespace InMemoryDatabase.Data;

public sealed class Database : IDatabaseInternal
{
    private readonly Dictionary<string, ITableInternal> _tables = new();
    private readonly IDynamicJsonSerializer _serializer = new DynamicJsonSerializer();

    public bool TryCreateTable(string tableName, Action<ITable> tableSetup, out ITable? result)
    {
        result = null;
        Table table = new()
        {
            Name = tableName
        };

        tableSetup(table);

        if (!_tables.TryAdd(tableName, table))
        {
            return false;
        }

        result = table;
        return true;
    }

    public bool CreateTable(string tableName, Action<ITable> tableSetup)
    {
        Table table = new()
        {
            Name = tableName
        };

        tableSetup(table);

        return _tables.TryAdd(tableName, table);
    }

    public void Insert(string tableName, Action<dynamic> configure)
    {
        bool tableExists = _tables.TryGetValue(tableName, out ITableInternal? table);

        if (!tableExists)
        {
            throw new ArgumentNullException($"Table {tableName} does not exists. Please use CreateTable method first.");
        }

        table!.Insert(configure);
    }

    public void Insert(string tableName, List<Action<dynamic>> configureMultiple)
    {
        bool tableExists = _tables.TryGetValue(tableName, out ITableInternal? table);

        if (!tableExists)
        {
            throw new ArgumentNullException($"Table {tableName} does not exists. Please use CreateTable method first.");
        }

        table!.Insert(configureMultiple);
    }

    public IQueryBuilder Select(string tableName, params string[] columns)
    {
        bool tableExists = _tables.TryGetValue(tableName, out ITableInternal? table);

        if (!tableExists)
        {
            throw new ArgumentNullException($"Table {tableName} does not exists. Please use CreateTable method first.");
        }

        return table!.Select(columns);
    }

    ITableInternal IDatabaseInternal.GetTable(string tableName)
    {
        bool tableExists = _tables.TryGetValue(tableName, out ITableInternal? table);

        if (!tableExists)
        {
            throw new ArgumentNullException($"Table {tableName} does not exists. Please use CreateTable method first.");
        }

        return table!;
    }

    public void SaveData()
    {
        const string path = "database.json";
        
        
        
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new DynamicJsonConverter() }
        };
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter sw = new(fs))
            {
            }
        }
    }

    public void LoadData()
    {
    }


    // public void Dispose()
    // {
    //     Type type = GetType();
    //     EventInfo[] events = type.GetEvents();
    //
    //     foreach (EventInfo eventInfo in events)
    //     {
    //         FieldInfo? field = type.GetField(eventInfo.Name, BindingFlags.Instance | BindingFlags.NonPublic);
    //         MulticastDelegate? eventDelegate = (MulticastDelegate?)field?.GetValue(this);
    //         if (eventDelegate != null)
    //         {
    //             foreach (Delegate handler in eventDelegate.GetInvocationList())
    //             {
    //                 eventInfo.RemoveEventHandler(this, handler);
    //             }
    //         }
    //     }
    // }
}