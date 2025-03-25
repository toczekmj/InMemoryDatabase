using System.Data;
using System.Dynamic;
using InMemoryDatabase.Internal_Interfaces;
using InMemoryDatabase.Public_Interfaces;

namespace InMemoryDatabase.Data;

public class Table : ITableInternal
{
    private Dictionary<string, Type>? _schema;
    private List<ExpandoObject>? _rows;
    public string? Name { get; set; }

    public Dictionary<string, Type>? Schema
    {
        get => _schema ??= new Dictionary<string, Type>();
        set
        {
            if (_schema is null && value is not null)
            {
                _schema = new Dictionary<string, Type>(value);
            }
            else if (_schema is not null && value is not null)
            {
                _schema.Clear();
                _schema = new Dictionary<string, Type>(value);
            }
            else
            {
                throw new NoNullAllowedException("Schema cannot be null");
            }
        }
    }

    public List<ExpandoObject> Rows
    {
        get => _rows ??= [];
        set
        {
            if(_rows is null)
            {
                _rows = [..value];
            }
            else if (_rows is not null)
            {
                _rows.Clear();
                _rows = [..value];
            }
            else
            {
                throw new NoNullAllowedException("Rows cannot be null");
            }
        }
    }
    
    public void SetupField<T>(string fieldName) => SetupField(fieldName, typeof(T));

    public void SetupField(string fieldName, Type fieldType)
    {
        if (Schema is null)
        {
            throw new NoNullAllowedException("Schema cannot be null");
        }
        Schema[fieldName] = fieldType;
    }

    public void Insert(Action<dynamic> configure)
    {
        dynamic row = new ExpandoObject();
        IDictionary<string, object> rowDict = (IDictionary<string, object>)row;
        
        configure(rowDict);

        if(Schema is null)
        {
            throw new NoNullAllowedException("Schema is null. Please configure table before inserting data.");
        }
        
        foreach (KeyValuePair<string, Type> field in Schema)
        {
            var isValue = rowDict.TryGetValue(field.Key, out object? expandoValue);
            if (!isValue)
            {
                throw new ArgumentException($"Missing field '{field.Key}' in row");
            }

            var expectedValue = Schema.TryGetValue(field.Key, out Type? expectedType);
            if(!expectedValue)
            {
                throw new ArgumentException($"Field '{field.Key}' is not defined in schema");
            }
            
            if(expandoValue is not null && expandoValue.GetType() != expectedType)
            {
                throw new ArgumentException($"Field '{field.Key}' expected type '{expectedType}' but got '{expandoValue.GetType()}'");
            }
        }
        
        Rows.Add(row);
    }
    
    public void Insert(List<Action<dynamic>> configureList)
    {
        configureList.ForEach(entity => Insert(entity));
    }

    public IQueryBuilder Select(params string[] columns)
    {
        throw new NotImplementedException();
    }

    public List<dynamic>? ExecuteQuery(Func<dynamic, bool>? predicate, string[]? columns, string? orderBy = null, string? groupBy = null,
        bool descending = false, int? limit = null)
    {
        throw new NotImplementedException();
    }
}