using Canducci.Simply.SqlBuilder.Interfaces;

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
