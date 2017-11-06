namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface ISelect: IBuilder, IWhereType<ISelect>
    {
        ISelect From(string table);
        ISelect Columns(params string[] values);
        ISelect Columns(string value);        
    }
}
