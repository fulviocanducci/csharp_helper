using Canducci.Simply.SqlBuilder.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Canducci.Simply.SqlBuilder
{
    public static class Extensions
    {

        #region Alias_Insert<T>
        public static int InsertToInt(this IDbConnection connection, IResultBuilder result)
        {
            return Insert<int>(connection, result);
        }
        public static long InsertToLong(this IDbConnection connection, IResultBuilder result)
        {
            return Insert<long>(connection, result);
        }
        #endregion

        public static T Insert<T>(this IDbConnection connection, IResultBuilder result)
            where T: struct
        {
            T o;
            connection.On();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;                
                command.Parameters.AddRange(result.Parameter);
                o = (T)command.ExecuteScalar();
                command.Parameters.Clear();
            }
            connection.Off();
            return o;
        }

        public static bool Insert(this IDbConnection connection, IResultBuilder result)            
        {
            bool status = false;
            connection.On();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;                
                command.Parameters.AddRange(result.Parameter);
                status = (command.ExecuteNonQuery() > 0);
                command.Parameters.Clear();
            }
            connection.Off();
            return status;
        }

        public static bool Update(this IDbConnection connection, IResultBuilder result)        
        {
            int o = 0;
            connection.On();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;                
                command.Parameters.AddRange(result.Parameter);
                o = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            connection.Off();
            return (o > 0);
        }

        #region Internal_Methods
        internal static void AddRange(this IDataParameterCollection parameterCollection, DbParameter[] parameters)
        {            
            foreach (DbParameter parameter in parameters)
                parameterCollection.Add(parameter);            
        }

        internal static void On(this IDbConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        internal static void Off(this IDbConnection connection)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        #endregion region

        public static ArrayList Query(this IDbConnection connection, IResultBuilder result)
        {
            connection.On();
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
                command.Parameters.Clear();
            }
            connection.Off();
            return items;
        }

        public static IList<T> Query<T>(this IDbConnection connection, IResultBuilder result) where T: class, new()
        {            
            IList<T> list = new List<T>();
            T model = null;
            connection.On();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = result.Sql;                
                command.Parameters.AddRange(result.Parameter);
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model = Activator.CreateInstance<T>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            PropertyInfo property = model
                                .GetType()
                                .GetProperties()
                                .Where(x => x.Name == reader.GetName(i))
                                .FirstOrDefault();
                            if (property == null)
                            {
                                throw new Exception("Class different of result");
                            }
                            if (!reader.IsDBNull(i))
                            {
                                property?.SetValue(model, reader.GetValue(i));
                            }                            
                        }
                        list.Add(model);
                    }
                    command.Parameters.Clear();                    
                }
            }
            connection.Off();
            return list;
        }
    }
}
