using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp33.Builder
{
    public partial class Builders : ISetValue, IWhere, IUpdate
    {
        private StringBuilder StrQuery { get; set; } = new StringBuilder();
        private IDictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();          

        public static IColumns InsertFrom(string table)
        {
            return (new Builders().Insert(table));
        }

        public static ISetValue UpdateFrom(string table)
        {
            return (new Builders().Update(table));
        }

        public ISetValue SetValue<T>(string field, T value)
        {
            string p = $"@p{Parameters.Count}";
            Parameters.Add(p, value);
            if (!StrQuery.ToString().Contains("SET"))
                StrQuery.AppendFormat(" SET ");
            else
                StrQuery.AppendFormat(", ");
            StrQuery.AppendFormat("[{0}]={1}", field, p);
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
        {
            string p = $"@p{Parameters.Count}";
            Parameters.Add(p, value);
            if (!StrQuery.ToString().Contains("WHERE"))
                StrQuery.AppendFormat(" WHERE ");
            else
                StrQuery.AppendFormat(" AND ");
            StrQuery.AppendFormat("[{0}]={1}", field, p);
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
