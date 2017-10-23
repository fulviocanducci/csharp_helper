using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp33.Builder
{
    public interface IUpdate
    {
        ISetValue Update(string table, string schema = "");
    }
}
