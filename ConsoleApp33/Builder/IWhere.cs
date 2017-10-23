using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp33.Builder
{
    public interface IWhere
    {
        IResultBuilder Builder();
        IWhere Where<T>(string field, T value);
        IWhere SetValue<T>(string field, T value);
    }
}
