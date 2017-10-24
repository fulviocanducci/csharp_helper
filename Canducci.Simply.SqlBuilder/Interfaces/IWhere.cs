using System.Data.Common;
namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IWhere: IWhereDelete, IWhereBuilder
    {                
        IWhere SetValue<T>(string field, T value)
            where T : DbParameter;
    }
}
