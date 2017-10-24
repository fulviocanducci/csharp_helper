using System.Data.Common;
namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IWhereDelete: IWhereBuilder
    {
        IWhereDelete Where<T>(string field, T value)
            where T : DbParameter;
    }
}
