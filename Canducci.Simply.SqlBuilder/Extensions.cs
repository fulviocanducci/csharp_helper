using Canducci.Simply.SqlBuilder.Interfaces;
using System.Data;

namespace Canducci.Simply.SqlBuilder
{
    public static class Extensions
    {
        public static T Insert<T>(this IDbConnection connection, IResultBuilder result)
            where T: struct
        {
            T o;
            if (connection.State == ConnectionState.Closed) connection.Open();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;
                foreach (var parameter in result.Parameter)
                    command.Parameters.Add(parameter);
                o = (T)command.ExecuteScalar();
            }
            connection.Close();
            return o;
        }

        public static bool Update(this IDbConnection connection, IResultBuilder result)        
        {
            int q = 0;
            if (connection.State == ConnectionState.Closed) connection.Open();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;
                foreach (var parameter in result.Parameter)
                    command.Parameters.Add(parameter);
                q = command.ExecuteNonQuery();
            }
            connection.Close();
            return q > 0;
        }
    }
}
