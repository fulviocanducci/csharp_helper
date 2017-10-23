using ConsoleApp33.Builder;
using Dapper;
using Flepper.QueryBuilder;
using Flepper.QueryBuilder.DapperExtensions;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = FlepperQueryBuilder
                .Insert()
                .Into("Table1")                
                .Columns("Column1")
                .Values("Value1")
                .WithScopeIdentity()
                .BuildWithParameters(); 




            IDbConnection dbConnection = new SqlConnection("Server=.\\SqlExpress;Database=QueryBuilderDatabase;User Id=sa;Password=senha;MultipleActiveResultSets=true;");

            //dbConnection.Execute("",)

            //var id = dbConnection.Insert()
            //    .Into("credit")
            //    .Columns("description")
            //    .Values(Guid.NewGuid().ToString())
            //    .WithScopeIdentity()
            //    .QueryFirst<int>();
            //Console.WriteLine();
            //Console.WriteLine(id);
            //Console.WriteLine();
            ////builder = builder.Into("Test");
            ////builder = builder.Columns("Col1", "Col2");
            ////var r = builder.Values("1", 2).BuildWithParameters();



            //IResultBuilder rs = Builders
            //    .Insert("Owe")                
            //    .Columns("Name", "Created", "Active")
            //    .Values(Guid.NewGuid().ToString(), DateTime.Now.Date.AddDays(-1), true)
            //    .Identity()
            //    .Builder();


            ////var result0 = dbConnection.Execute(rs.Sql, rs.Parameter);
            //var result1 = dbConnection.ExecuteScalar<int>(rs.Sql, rs.Parameter);
            DateTime? dt = null;
            //IResultBuilder rs = Builders.InsertFrom("Owe")
            //    .Columns("Name", "Created", "Active")
            //    .Values("Nome 1", null, false)
            //    .Identity()
            //    .Builder();

            IResultBuilder rs = Builders
                .UpdateFrom("Owe")
                .SetValue("Active", true)
                .SetValue("Name", "Fúlvio Cezar")
                .SetValue("Created", default(DateTime?))
                .Where("Id", 1)
                .Builder();

            var res = dbConnection.Execute(rs.Sql, rs.Parameter);
            //var res0 = dbConnection.Execute("INSERT INTO Owe([Name],[Created],[Active]) VALUES(@p0,@p1,@p2);SELECT SCOPE_IDENTITY();", new
            //{
            //    p0 = "1",
            //    p1 = default(DateTime?),
            //    p2 = true
            //});
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
