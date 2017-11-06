using System;

namespace ConsoleApp33
{
    public class Owe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public bool Active { get; set; }
    }

    public class Credit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }        
    }
}
