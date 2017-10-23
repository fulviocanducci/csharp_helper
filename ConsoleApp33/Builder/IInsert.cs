using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp33.Builder
{
    public interface IInsert
    {        
        IColumns Insert(string table, string schema = "");        
    }
}
