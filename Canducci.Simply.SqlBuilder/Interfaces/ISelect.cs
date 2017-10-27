namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface ISelect: IBuilder
    {
        ISelect From(string table);
        ISelect Columns(params string[] values);
        ISelect Columns(string value);
    }
}
