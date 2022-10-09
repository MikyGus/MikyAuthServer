using Dapper;
using System.Data;

namespace MikyAuth.Library.PersistentStorage;
public class MySqlGuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override Guid Parse(object value)
    {
        string? v = value.ToString();
        if (v is null)
        {
            throw new ArgumentException($"Invalid Guid provided. [{v}]");
        }
        Guid guid = new(v);
        return guid;
    }

    public override void SetValue(IDbDataParameter parameter, Guid guid)
    {
        parameter.Value = guid.ToString();
    }
}
