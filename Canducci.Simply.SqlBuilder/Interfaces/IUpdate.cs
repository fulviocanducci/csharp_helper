namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IUpdate
    {
        ISetValue Update(string table, string schema = "");
    }
}
