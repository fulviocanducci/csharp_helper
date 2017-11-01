using Canducci.Simply.SqlBuilder;
using Canducci.Simply.SqlBuilder.Interfaces;
using Dapper;
//using Flepper.QueryBuilder.DapperExtensions;
using System;
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


            IResultBuilder resultInsert = Builders.InsertFrom(layout, "Owe")
                .Columns("Created", "Name", "Active")
                .Values(Created, Name, Active)
                .Identity()
                .Builder();

            var r = dbConnection.InsertToInt(resultInsert);
            
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


            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("Name", "ccc NULL", DbType.String, ParameterDirection.Input);
            parameter.Add("Created", null, DbType.Date, ParameterDirection.Input);            
            parameter.Add("Active", true, DbType.Boolean, ParameterDirection.Input);

            var ra = dbConnection.Execute("INSERT INTO Owe(Name, Created, Active) VALUES(@Name, @Created, @Active)", parameter);


            var result = Builders.SelectFrom(layout, "Owe")
                
                //.Where("Id", Id)//
                .Builder();

            var dados = dbConnection.Query(result);


            Console.ReadKey();
        }
    }
}
