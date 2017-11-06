using Canducci.Simply.SqlBuilder;
using Canducci.Simply.SqlBuilder.Interfaces;
//using Dapper;
//using Flepper.QueryBuilder.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = FlepperQueryBuilder
            //    .Insert()
            //    .Into("Table1")                
            //    .Columns("Column1")
            //    .Values("Value1")
            //    .WithScopeIdentity()
            //    .BuildWithParameters(); 




            IDbConnection dbConnection = new SqlConnection("Server=.\\SqlExpress;Database=QueryBuilderDatabase;User Id=sa;Password=senha;MultipleActiveResultSets=true;");
            ILayout layout = new LayoutSqlServer();

            #region Layout
            SqlParameter Created = new SqlParameter("@Created", SqlDbType.DateTime)
            {
                IsNullable = true,
                SourceColumnNullMapping = true, 
                Value = DateTime.Now.Date.AddDays(-1) // DBNull.Value
            };

            SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50)
            {
                Value = "Maria Aparecida Dias Cintra"
            };

            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int)
            {
                Value = 2
            };

            SqlParameter Active = new SqlParameter("@Active", SqlDbType.Bit)
            {
                Value = true
            };
            #endregion


            IResultBuilder resultSelect0 = Builders
                .SelectFrom(layout, "Owe")
                .Where<SqlParameter, int>("Id", "=", 2)
                .Builder();

            IResultBuilder resultSelect1 = Builders
                .SelectFrom(layout, "Credit")
                .Where<SqlParameter, int>("Id", "=", 1)                
                .Builder();

            var a1 = dbConnection.Query<Owe>(resultSelect0);
            var a2 = dbConnection.Query<Credit>(resultSelect1);


            var aaa = 100;
            //var r = dbConnection.InsertToInt(resultInsert);

            //IResultBuilder resultUpdate = Builders.UpdateFrom(layout, "Owe")                
            //    .SetValue("Created", Created)
            //    .Where("Id", Id)
            //    .Builder();

            ////var id = dbConnection.Update(resultUpdate);

            //var resultDelete = Builders.DeleteFrom(layout, "Owe")
            //    .Where("Id", Id)
            //    .Builder();

            //var a = dbConnection.Update(resultDelete);

            //Console.WriteLine(a);

            //dbConnection.Execute(resultUpdate);


            //DynamicParameters parameter = new DynamicParameters();
            //parameter.Add("Name", "ccc NULL", DbType.String, ParameterDirection.Input);
            //parameter.Add("Created", null, DbType.Date, ParameterDirection.Input);            
            //parameter.Add("Active", true, DbType.Boolean, ParameterDirection.Input);

            //var ra = dbConnection.Execute("INSERT INTO Owe(Name, Created, Active) VALUES(@Name, @Created, @Active)", parameter);


            IResultBuilder result = Builders
                .SelectFrom(layout, "Owe")
                
                .Builder();

            IList<Owe> listOwe = dbConnection.Query<Owe>(result);


            var dados = dbConnection.Query(result);


            Console.ReadKey();
        }
    }
}
