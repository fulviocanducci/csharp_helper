using Canducci.Simply.SqlBuilder.Interfaces;

namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders
    {
        public IWhereDelete Delete(string table, string schema = "")
        {
            if (string.IsNullOrWhiteSpace(schema))
                StrQuery.Append($"DELETE FROM {table}");
            else
                StrQuery.Append($"DELETE FROM {schema}.{table}");
            return this;
        }
    }
}
