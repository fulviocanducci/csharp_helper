using System.Data.Common;
namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IWhere
    {
        IResultBuilder Builder();
        IWhere Where<T>(string field, T value)
            where T : DbParameter;
        IWhere SetValue<T>(string field, T value)
            where T : DbParameter;
    }
}
