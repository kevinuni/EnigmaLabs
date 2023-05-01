namespace Enigma.Domain.Base;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BsonCollectionAttribute : Attribute
{
    public string TableName { get; }
    public string Schema { get; set; }

    public BsonCollectionAttribute(string tableName, string schema)
    {
        TableName = tableName;
        Schema = schema;
    }
}