namespace ConsoleApp33.Builder
{
    public class ResultBuilder : IResultBuilder
    {
        public string Sql { get; private set; }
        public object Parameter { get; private set; }

        public ResultBuilder(string sql, object parameter)
        {
            Sql = sql;
            Parameter = parameter;
        }
    }
}
