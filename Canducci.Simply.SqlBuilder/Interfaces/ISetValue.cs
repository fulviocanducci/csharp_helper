using System.Data.Common;
namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface ISetValue
    {
        IWhere SetValue<T>(string field, T value)
            where T : DbParameter;
    }
}
