using Canducci.Simply.SqlBuilder.Interfaces;
using System.Data;
using System.Data.Common;

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
                command.Parameters.AddRange(result.Parameter);
                o = (T)command.ExecuteScalar();
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return o;
        }

        public static bool Update(this IDbConnection connection, IResultBuilder result)        
        {
            int o = 0;
            if (connection.State == ConnectionState.Closed) connection.Open();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;
                command.Parameters.AddRange(result.Parameter);
                o = command.ExecuteNonQuery();
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return (o > 0);
        }

        public static void AddRange(this IDataParameterCollection parameterCollection, DbParameter[] parameters)
        {
            foreach (DbParameter parameter in parameters)
                parameterCollection.Add(parameter);            
        }
    }
}
