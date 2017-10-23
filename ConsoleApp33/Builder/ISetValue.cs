namespace ConsoleApp33.Builder
{
    public interface ISetValue
    {
        IWhere SetValue<T>(string field, T value);        
    }
}
