using System.Data;
using System.Data.Common;

namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface ISelect: IBuilder
    {
        ISelect From(string table);
        ISelect Columns(params string[] values);
        ISelect Columns(string value);
        ISelect Where<T>(string column, T parameter)  where T : DbParameter;
        ISelect Where<T>(string column, string compare, T parameter) where T : DbParameter;
        ISelect Where<ParameterType, T>(string column, string compare, T value, string parameterName = null, DbType? dbType = null, bool NullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct;
    }
}
