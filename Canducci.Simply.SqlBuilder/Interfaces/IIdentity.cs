namespace Canducci.Simply.SqlBuilder.Interfaces
{
    public interface IIdentity
    {
        IBuilder Identity(IdentityResult result = IdentityResult.Integer);
        IResultBuilder Builder();
    }
}
