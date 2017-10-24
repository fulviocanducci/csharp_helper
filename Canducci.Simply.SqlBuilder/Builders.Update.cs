using Canducci.Simply.SqlBuilder.Interfaces;
using System.Data.Common;
namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders: ISetValue, IWhere, IUpdate
    {
        public ISetValue SetValue<T>(string field, T value)
            where T : DbParameter
        {
            if (!StrQuery.ToString().Contains("SET"))
                StrQuery.AppendFormat(" SET ");
            else
                StrQuery.AppendFormat(", ");
            StrQuery.AppendFormat("[{0}]={1}", field, value.ParameterName);
            Parameters.Add(value);
            return this;
        }

        public ISetValue Update(string table, string schema = "")
        {
            if (string.IsNullOrWhiteSpace(schema))
                StrQuery.Append($"UPDATE {table}");
            else
                StrQuery.Append($"UPDATE INTO {schema}.{table}");
            return this;
        }

        public IWhere Where<T>(string field, T value)
            where T : DbParameter
        {
            if (!StrQuery.ToString().Contains("WHERE"))
                StrQuery.AppendFormat(" WHERE ");
            else
                StrQuery.AppendFormat(" AND ");
            StrQuery.AppendFormat("[{0}]={1}", field, value.ParameterName);
            Parameters.Add(value);
            return this;
        }

        IWhere ISetValue.SetValue<T>(string field, T value)
        {
            return (IWhere)SetValue(field, value);
        }

        IWhere IWhere.SetValue<T>(string field, T value)
        {
            return (IWhere)SetValue(field, value);
        }
    }
}
