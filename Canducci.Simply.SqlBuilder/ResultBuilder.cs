using Canducci.Simply.SqlBuilder.Interfaces;
using System.Data.Common;
namespace Canducci.Simply.SqlBuilder
{
    public class ResultBuilder : IResultBuilder
    {
        public string Sql { get; private set; }
        public DbParameter[] Parameter { get; private set; }

        public ResultBuilder(string sql, DbParameter[] parameter)
        {
            Sql = sql;
            Parameter = parameter;
        }
    }
}
