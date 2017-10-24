using Canducci.Simply.SqlBuilder.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Canducci.Simply.SqlBuilder
{
    public partial class Builders
    {
        private StringBuilder StrQuery { get; set; } = new StringBuilder();
        private List<DbParameter> Parameters { get; set; } = new List<DbParameter>();         

        public static IColumns InsertFrom(string table)
        {
            return (new Builders().Insert(table));
        }

        public static ISetValue UpdateFrom(string table)
        {
            return (new Builders().Update(table));
        }

        public static IWhereDelete DeleteFrom(string table)
        {
            return (new Builders().Delete(table));
        }

    }
}
