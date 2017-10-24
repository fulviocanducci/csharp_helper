namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IInsert
    {        
        IColumns Insert(string table, string schema = "");        
    }
}
