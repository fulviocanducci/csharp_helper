﻿using System.Data.Common;
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

        public ISelect Where<T>(string column, string compare, T parameter) where T : DbParameter
        {
            if (StrQuery.ToString().Contains("WHERE") == false)
                StrQuery.AppendFormat(" WHERE ");
            StrQuery.AppendFormat($"{Layout.Param(column)} {compare} {parameter.ParameterName}");
            Parameters.Add(parameter);
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

        ISelect ISelect.Where<T>(string column, T parameter)
        {
            return Where(column, "=", parameter);
        }
    }
}
