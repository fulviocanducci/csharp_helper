using System;

namespace ConsoleApp33.Builder
{
    public partial class Builders : IInsert, IColumns, IValues, IBuilder, IIdentity
    {
        public IValues Columns(params string[] values)
        {
            StrQuery.AppendFormat("([{0}]) ", String.Join("],[", values));
            return this;
        }

        public IIdentity Values(params object[] values)
        {
            StrQuery.Append("VALUES(");
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) StrQuery.AppendFormat(",");
                StrQuery.Append($"@p{i}");
                Parameters.Add($"@p{i}", values[i]);
            }
            StrQuery.Append(");");
            return this;
        }

        public IResultBuilder Builder()
        {
            var dynamicParameter = CreateParameters.Instance.TypeWithValues(Parameters);
            return new ResultBuilder(StrQuery.ToString(), dynamicParameter);
        }

        public IBuilder Identity()
        {
            StrQuery.Append("SELECT SCOPE_IDENTITY();");
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
