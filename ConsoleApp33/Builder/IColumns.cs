using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp33.Builder
{
    public interface IColumns
    {
        IValues Columns(params string[] values); 
    }
}
