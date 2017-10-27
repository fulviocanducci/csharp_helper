using Canducci.Simply.SqlBuilder.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;

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

        public static ArrayList Query(this IDbConnection connection, IResultBuilder result)
        {            
            if (connection.State == ConnectionState.Closed) connection.Open();
            ArrayList items = new ArrayList();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;
                command.Parameters.AddRange(result.Parameter);
                using (IDataReader reader = command.ExecuteReader())
                {                    
                    while (reader.Read())
                    {                
                        object[] param = new object[reader.FieldCount];
                        reader.GetValues(param);
                        items.Add(param);                        
                    }
                }
            }
            if (connection.State == ConnectionState.Open) connection.Close();            
            return items;
        }
    }
}
