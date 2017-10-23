namespace ConsoleApp33.Builder
{
    public interface IResultBuilder
    {
        string Sql { get; }
        object Parameter { get; }
    }
}
