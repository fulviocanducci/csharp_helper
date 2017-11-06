using System.Data;
using System.Data.Common;

namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IWhereType<Q>
    {
        Q Where<T>(string column, T parameter) where T : DbParameter;
        Q Where<T>(string column, string compare, T parameter) where T : DbParameter;
        Q Where<ParameterType, T>(string column, string compare, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct;
        Q Where<ParameterType, T>(string column, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct;

        Q OrWhere<T>(string column, T parameter) where T : DbParameter;
        Q OrWhere<T>(string column, string compare, T parameter) where T : DbParameter;
        Q OrWhere<ParameterType, T>(string column, string compare, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
           where ParameterType : DbParameter
           where T : struct;
        Q OrWhere<ParameterType, T>(string column, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct;
    }
}
