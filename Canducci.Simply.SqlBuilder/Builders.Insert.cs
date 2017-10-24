using Canducci.Simply.SqlBuilder.Interfaces;
using System;
using System.Data.Common;
namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders : IInsert, IColumns, IValues, IBuilder, IIdentity
    {
        public IValues Columns(params string[] values)
        {
            StrQuery.AppendFormat("([{0}]) ", String.Join("],[", values));
            return this;
        }

        public IIdentity Values(params DbParameter[] values)
        {
            Parameters.AddRange(values);
            StrQuery.Append("VALUES(");
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) StrQuery.AppendFormat(",");
                StrQuery.Append(values[i].ParameterName);                
            }
            StrQuery.Append(");");
            return this; 
        }

        public IResultBuilder Builder()
        {            
            return new ResultBuilder(StrQuery.ToString(), Parameters.ToArray());
        }

        public IBuilder Identity()
        {
            StrQuery.Append("SELECT CAST(SCOPE_IDENTITY() AS int);");
            return this;
        }

        public IColumns Insert(string table, string schema = "")
        {
            if (string.IsNullOrWhiteSpace(schema))
                StrQuery.Append($"INSERT INTO {table}");
            else
                StrQuery.Append($"INSERT INTO {schema}.{table}");
            return this;
        }
    }
}
