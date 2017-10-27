using Canducci.Simply.SqlBuilder.Interfaces;

namespace Canducci.Simply.SqlBuilder
{
    public class LayoutSqlServer : ILayout
    {
        public string Close()
        {
            return "]";
        }

        public string Open()
        {
            return "[";
        }

        public string Param<T>(T value)
        {
            return $"{Open()}{value}{Close()}";
        }
    }
}
