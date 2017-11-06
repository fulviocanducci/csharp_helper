using System.Data.Common;
using Canducci.Simply.SqlBuilder.Interfaces;
using System;
using System.Data;

namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders : ISelect
    {
        public ISelect Columns(string value)
        {
            string[] c = value.Split(',');
            return ((ISelect)this).Columns(c);
        }

        public ISelect From(string table)
        {
            StrQuery.AppendFormat($"SELECT * FROM {Layout.Param(table)}");
            return this;
        }

        #region OrWhere

        public ISelect OrWhere<T>(string column, T parameter) where T : DbParameter
        {
            return OrWhere(column, "=", parameter);
        }

        public ISelect OrWhere<T>(string column, string compare, T parameter) where T : DbParameter
        {
            if (StrQuery.ToString().Contains("WHERE") == false)
                StrQuery.AppendFormat(" WHERE ");
            else
                StrQuery.AppendFormat(" OR ");
            StrQuery.AppendFormat($"{Layout.Param(column)} {compare} {parameter.ParameterName}");
            Parameters.Add(parameter);
            return this;
        }

        public ISelect OrWhere<ParameterType, T>(string column, string compare, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct
        {
            ParameterType parameter = Activator.CreateInstance<ParameterType>();
            parameter.ParameterName = parameterName ?? $"@{column}";
            parameter.Value = value;
            parameter.SourceColumn = column;
            parameter.SourceColumnNullMapping = nullMapping;
            parameter.Direction = parameterDirection;
            if (dbType != null) parameter.DbType = dbType.Value;
            if (size != null) parameter.Size = size.Value;
            return OrWhere(column, compare, parameter);
        }

        public ISelect OrWhere<ParameterType, T>(string column, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct
        {
            return OrWhere<ParameterType, T>(column, "=", value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        #endregion

        #region Where

        public ISelect Where<T>(string column, string compare, T parameter) where T : DbParameter
        {
            if (StrQuery.ToString().Contains("WHERE") == false)
                StrQuery.AppendFormat(" WHERE ");
            else
                StrQuery.AppendFormat(" AND ");
            StrQuery.AppendFormat($"{Layout.Param(column)} {compare} {parameter.ParameterName}");
            Parameters.Add(parameter);
            return this;
        }

        public ISelect Where<ParameterType,T>(string column, string compare, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null) 
            where ParameterType: DbParameter
            where T: struct
        {
            ParameterType parameter = Activator.CreateInstance<ParameterType>();
            parameter.ParameterName = parameterName ?? $"@{column}";
            parameter.Value = value;
            parameter.SourceColumn = column;
            parameter.SourceColumnNullMapping = nullMapping;
            parameter.Direction = parameterDirection;
            if (dbType != null) parameter.DbType = dbType.Value;            
            if (size != null) parameter.Size = size.Value;
            return Where(column, compare, parameter);
        }

        public ISelect Where<ParameterType, T>(string column, T value, string parameterName = null, DbType? dbType = null, bool nullMapping = false, ParameterDirection parameterDirection = ParameterDirection.Input, int? size = null)
            where ParameterType : DbParameter
            where T : struct
        {
            return Where<ParameterType, T>(column, "=", value, parameterName, dbType, nullMapping, parameterDirection, size);
        }

        ISelect IWhereType<ISelect>.Where<T>(string column, T parameter)
        {
            return Where(column, "=", parameter);
        }

        #endregion

        ISelect ISelect.Columns(params string[] values)
        {
            var index = StrQuery.ToString().IndexOf("*");
            if (index >= 0)
            {
                string columns = Layout.Open() +
                    string.Join($"{Layout.Close()},{Layout.Open()}", values) +
                    Layout.Close();
                StrQuery = StrQuery.Replace("*", columns);
            }
            return this;
        }
       
    }
}
