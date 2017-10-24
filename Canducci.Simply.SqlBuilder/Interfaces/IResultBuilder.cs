using System.Data.Common;
namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IResultBuilder
    {
        string Sql { get; }
        DbParameter[] Parameter { get; }
    }
}
