using System.Data.Common;
namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IValues
    {
        IIdentity Values(params DbParameter[] values);        
    }

}
